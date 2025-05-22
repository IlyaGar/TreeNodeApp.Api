using System.Text;
using TreeNodeApp.Provider.Service.Interface.Exceptions;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Interfaces;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Models.InComing;

namespace TreeNodeApp.Api.ExceptionHandling
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public ExceptionHandlingMiddleware(
            RequestDelegate next, 
            ILogger<ExceptionHandlingMiddleware> logger,
            IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SecureException ex)
            {
                var exception = await CreateJournalExceptionInContract(ex, context);
                using (var scope = _scopeFactory.CreateScope())
                {
                    var userJournalService = scope.ServiceProvider.GetRequiredService<IUserJournalService>();
                    await userJournalService.CreateJournalExceptionAsync(exception);
                }
                var errorResponse = new
                {
                    type = "Secure",
                    id = exception.EventId.ToString(),
                    data = new
                    {
                        message = ex.Message
                    }
                };

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (Exception ex)
            {
                var exception = await CreateJournalExceptionInContract(ex, context);
                using (var scope = _scopeFactory.CreateScope())
                {
                    var userJournalService = scope.ServiceProvider.GetRequiredService<IUserJournalService>();
                    await userJournalService.CreateJournalExceptionAsync(exception);
                }
                var errorResponse = new
                {
                    type = "Error",
                    id = exception.EventId.ToString(),
                    data = new
                    {
                        message = $"Internal server error ID = {exception.EventId} of event"
                    }
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }

        private async Task<JournalExceptionInContract> CreateJournalExceptionInContract(Exception ex, HttpContext context)
        {
            var request = context.Request;
            var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(requestBody));
            context.Request.Body.Position = 0;
            return new JournalExceptionInContract
            {
                EventId = DateTime.UtcNow.Ticks,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Path = request.Path + "/" + request.QueryString,
                Body = requestBody,
                RequestId = context.TraceIdentifier,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
