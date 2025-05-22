using Microsoft.AspNetCore.Mvc;
using TreeNodeApp.Provider.Service.Interface.UserTrees.Interfaces;

namespace TreeNodeApp.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UserTreeController : ControllerBase
    {
        private readonly IUserTreeService _userTreeService;

        public UserTreeController(IUserTreeService userTreeService)
        {
            _userTreeService = userTreeService;
        }

        [HttpPost("api.user.tree.get")]
        public async Task<IActionResult> Get(string treeName)
        {
            var result = await _userTreeService.GetTreeAsync(treeName);

            return Ok(result);
        }
    }
}
