using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Interfaces;
using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Models;
using TreeNodeApp.Provider.Service.Interface.UserTrees.Interfaces;
using TreeNodeApp.Provider.Service.Interface.UserTrees.Models.OutContracts;

namespace TreeNodeApp.Provider.Service.UserTrees
{
    public class UserTreeService : IUserTreeService
    {
        private readonly IUserTreeRepository _userTreeRepository;

        public UserTreeService(IUserTreeRepository userTreeRepository)
        {
            _userTreeRepository = userTreeRepository;
        }

        public async Task<TreeModelOutContract> GetTreeAsync(string treeName)
        {
            var tree = await _userTreeRepository.GetTreeAsync(treeName);
            if (tree == null)
            {
                var createdTree = await _userTreeRepository.CreateTreeAsync(CreateTreeNodeModel(treeName));
                return ConvertToTreeModelOutContract(createdTree);
            }

            return ConvertToTreeModelOutContract(tree);
        }

        private static TreeModelOutContract ConvertToTreeModelOutContract(TreeNode tree)
        {
            return new TreeModelOutContract()
            {
                Id = tree.Id,
                Name = tree.Name,
                Children = tree.Children.Select(child => ConvertToTreeModelOutContract(child)).ToList(),
            };
        }

        private static TreeNode CreateTreeNodeModel(string treeName)
        {
            return new TreeNode
            {
                Name = treeName,
            };
        }
    }
}
