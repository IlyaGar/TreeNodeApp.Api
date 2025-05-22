using Microsoft.EntityFrameworkCore;
using TreeNodeApp.DataAccess.Repository.Interface.Common.Models;
using TreeNodeApp.DataAccess.Repository.Interface.Context;
using TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Interfaces;
using TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Models;

namespace TreeNodeApp.DataAccess.Repository.UserJournals
{
    public class UserJournalRepository : IUserJournalRepository
    {
        private readonly TreeNodeDbContext _context;

        public UserJournalRepository(TreeNodeDbContext context)
        {
            _context = context;
        }

        public async Task CreateExceptionAsync(JournalException exception)
        {
            _context.JournalExceptions.Add(exception);
            await _context.SaveChangesAsync();
        }

        public async Task<(int, IEnumerable<JournalException>)> GetRangeAsync(FilterModel filterModel)
        {
            var query = _context.JournalExceptions.AsQueryable();

            if (filterModel.From.HasValue)
                query = query.Where(j => j.CreatedAt >= filterModel.From.Value);

            if (filterModel.To.HasValue)
                query = query.Where(j => j.CreatedAt <= filterModel.To.Value);

            if (!string.IsNullOrEmpty(filterModel.Search))
            {
                query = query.Where(j => j.Message.Contains(filterModel.Search) ||
                                         j.StackTrace.Contains(filterModel.Search) ||
                                         j.Path.Contains(filterModel.Search) ||
                                         j.RequestId.Contains(filterModel.Search));
            }
            query = query.OrderByDescending(j => j.CreatedAt);

            int totalCount = await query.CountAsync();

            var items = await query.Skip(filterModel.Skip).Take(filterModel.Take).ToListAsync();

            return (totalCount, items);
        }

        public async Task<JournalException> GetSingleAsync(int id)
        {
            return await _context.JournalExceptions.SingleAsync(x => x.Id == id);
        }
    }
}
