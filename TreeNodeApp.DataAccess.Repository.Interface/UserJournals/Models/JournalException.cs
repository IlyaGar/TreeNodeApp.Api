namespace TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Models
{
    public class JournalException
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Path { get; set; }
        public string RequestId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
