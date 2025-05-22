
using TreeNodeApp.Provider.Service.Interface.UserTrees.Models.OutContracts;

namespace TreeNodeApp.Provider.Service.Interface.UserTrees.Interfaces
{
    public interface IUserTreeService
    {
        Task<TreeModelOutContract> GetTreeAsync(string treeName);
    }
}
