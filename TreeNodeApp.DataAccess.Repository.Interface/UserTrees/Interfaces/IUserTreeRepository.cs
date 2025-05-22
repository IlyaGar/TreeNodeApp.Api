using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Models;

namespace TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Interfaces
{
    public interface IUserTreeRepository
    {
        Task<TreeNode?> GetTreeAsync(string treeName);
        Task<TreeNode?> GetTreeAsync(long parentNodeId);
        Task CreateTreeNodeAsync(TreeNode treeNode);
        Task<TreeNode> CreateTreeAsync(TreeNode treeNode);
        Task UpdateTreeNodeAsync(TreeNode treeById);
        Task DeleteTreeNodeAsync(TreeNode treeById);
    }
}
