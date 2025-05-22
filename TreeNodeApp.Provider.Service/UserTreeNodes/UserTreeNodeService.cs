using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Interfaces;
using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Models;
using TreeNodeApp.Provider.Service.Interface.Exceptions;
using TreeNodeApp.Provider.Service.Interface.UserTreeNodes.Interfaces;

namespace TreeNodeApp.Provider.Service.UserTreeNodes
{
    public class UserTreeNodeService : IUserTreeNodeService
    {
        private readonly IUserTreeRepository _userTreeRepository;

        public UserTreeNodeService(IUserTreeRepository userTreeRepository)
        {
            _userTreeRepository = userTreeRepository;
        }

        public async Task CreateTreeNodeAsync(string treeName, long parentNodeId, string nodeName)
        {
            var tree = await GetValidTreeNode(treeName, parentNodeId);

            if (tree.Children.Any(child => child.Name.Equals(nodeName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new SecureException("Duplicate name");
            }

            var treeNode = new TreeNode
            {
                Name = nodeName,
                TreeNodeId = parentNodeId,
            };

            await _userTreeRepository.CreateTreeNodeAsync(treeNode);
        }

        public async Task DeleteTreeNodeAsync(string treeName, long nodeId)
        {
            var tree = await GetValidTreeNode(treeName, nodeId);
            if (tree.Children.Any())
            {
                throw new SecureException("You have to delete all children nodes first");
            }
            await _userTreeRepository.DeleteTreeNodeAsync(tree);
        }

        public async Task RenameTreeNodeAsync(string treeName, long nodeId, string newNodeName)
        {
            var tree = await GetValidTreeNode(treeName, nodeId);

            tree.Name = newNodeName;
            await _userTreeRepository.UpdateTreeNodeAsync(tree);
        }

        private async Task<TreeNode> GetValidTreeNode(string treeName, long nodeId)
        {
            var treeById = await _userTreeRepository.GetTreeAsync(nodeId);
            if (treeById == null)
            {
                throw new SecureException($"Node with ID = {nodeId} was not found");
            }

            var treeByName = await _userTreeRepository.GetTreeAsync(treeName);
            if (treeById != treeByName)
            {
                throw new SecureException("Requested node was found, but it doesn't belong your tree");
            }

            return treeById;
        }
    }
}
