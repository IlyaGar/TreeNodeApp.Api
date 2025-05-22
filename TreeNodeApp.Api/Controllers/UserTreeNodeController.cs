using Microsoft.AspNetCore.Mvc;
using TreeNodeApp.Provider.Service.Interface.UserTreeNodes.Interfaces;

namespace TreeNodeApp.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UserTreeNodeController : ControllerBase
    {
        private readonly IUserTreeNodeService _userTreeNodeService;

        public UserTreeNodeController(IUserTreeNodeService userTreeNodeService)
        {
            _userTreeNodeService = userTreeNodeService;
        }

        [HttpPost("api.user.tree.node.create")]
        public async Task<IActionResult> Create(string treeName, Int64 parentNodeId, string nodeName)
        {
            await _userTreeNodeService.CreateTreeNodeAsync(treeName, parentNodeId, nodeName);

            return Ok();
        }

        [HttpPost("api.user.tree.node.delete")]
        public async Task<IActionResult> Delete(string treeName, Int64 nodeId)
        {
            await _userTreeNodeService.DeleteTreeNodeAsync(treeName, nodeId);

            return Ok();
        }

        [HttpPost("api.user.tree.node.rename")]
        public async Task<IActionResult> Rename(string treeName, Int64 nodeId, string newNodeName)
        {
            await _userTreeNodeService.RenameTreeNodeAsync(treeName, nodeId, newNodeName);

            return Ok();
        }
    }
}
