namespace TreeNodeApp.Provider.Service.Interface.Common.Models
{
    public class RequestFilterContract
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? Search { get; set; }
    }
}
