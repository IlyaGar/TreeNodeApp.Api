using Microsoft.AspNetCore.Mvc;

namespace TreeNodeApp.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UserPartnerController : ControllerBase
    {
        [HttpPost("api.user.partner.rememberMe")]
        public async Task<IActionResult> RememberMe(/*[FromBody] UserJournalFilter filter*/)
        {
            //var result = await _userJournalService.GetRangeAsync(null);

            return Ok(1);
        }
    }
}
