namespace TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Models
{
    public class TreeNode
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public virtual Int64? TreeNodeId { get; set; }
        public virtual ICollection<TreeNode> Children { get; set; } = new List<TreeNode>();
    }
}
