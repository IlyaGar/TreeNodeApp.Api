namespace TreeNodeApp.DataAccess.Repository.Interface.Common.Models
{
    public class FilterModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? Search { get; set; }
    }
}
