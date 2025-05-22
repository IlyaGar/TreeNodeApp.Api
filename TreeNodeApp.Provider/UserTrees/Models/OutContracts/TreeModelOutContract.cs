namespace TreeNodeApp.Provider.Service.Interface.UserTrees.Models.OutContracts
{
    public class TreeModelOutContract
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TreeModelOutContract> Children { get; set; } = new List<TreeModelOutContract>();
    }
}
