
namespace TreeNodeApp.Provider.Service.Interface.UserTreeNodes.Interfaces
{
    public interface IUserTreeNodeService
    {
        Task CreateTreeNodeAsync(string treeName, long parentNodeId, string nodeName);
        Task DeleteTreeNodeAsync(string treeName, long nodeId);
        Task RenameTreeNodeAsync(string treeName, long nodeId, string newNodeName);
    }
}
