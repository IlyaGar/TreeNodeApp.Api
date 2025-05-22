using Microsoft.EntityFrameworkCore;
using TreeNodeApp.DataAccess.Repository.Interface.Context;
using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Interfaces;
using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Models;

namespace TreeNodeApp.DataAccess.Repository.UserTrees
{
    public class UserTreeRepository : IUserTreeRepository
    {
        private readonly TreeNodeDbContext _context;

        public UserTreeRepository(TreeNodeDbContext context)
        {
            _context = context;
        }

        public async Task<TreeNode?> GetTreeAsync(string treeName)
        {
            return await _context.TreeModels.FirstOrDefaultAsync(x => x.Name.Equals(treeName));
        }

        public async Task<TreeNode?> GetTreeAsync(long parentNodeId)
        {
            return await _context.TreeModels.FirstOrDefaultAsync(x => x.Id.Equals(parentNodeId));
        }

        public async Task CreateTreeNodeAsync(TreeNode treeNode)
        {
            _context.TreeModels.Add(treeNode);
            await _context.SaveChangesAsync();
        }

        public async Task<TreeNode> CreateTreeAsync(TreeNode treeNode)
        {
            _context.TreeModels.Add(treeNode);
            await _context.SaveChangesAsync();

            return treeNode;
        }

        public async Task UpdateTreeNodeAsync(TreeNode treeById)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTreeNodeAsync(TreeNode treeNode)
        {
            _context.Remove(treeNode);
            await _context.SaveChangesAsync();
        }
    }
}
