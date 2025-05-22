using Microsoft.AspNetCore.Mvc;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Interfaces;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Models.InComing;

namespace TreeNodeApp.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UserJournalController : ControllerBase
    {
        private readonly IUserJournalService _userJournalService;
        public UserJournalController(IUserJournalService userJournalService)
        {
            _userJournalService = userJournalService;
        }

        /// <summary>
        /// Gget Range
        /// </summary>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="take">The number of records to take.</param>
        /// <param name="filter">Filter data for the query.</param>
        [HttpPost("api.user.journal.getRange")]
        public async Task<IActionResult> GgetRange([FromQuery] int skip, [FromQuery] int take, [FromBody] UserJournalFilter filter)
        {
            var result = await _userJournalService.GetRangeAsync(skip, take, filter);

            return Ok(result);
        }

        /// <summary>
        /// Gget Single
        /// </summary>
        /// <param name="id">Record id.</param>
        [HttpPost("api.user.journal.getSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await _userJournalService.GetSingleAsync(id);

            return Ok(result);
        }
    }
}
