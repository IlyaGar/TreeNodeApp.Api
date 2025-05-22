namespace TreeNodeApp.Provider.Service.Interface.UserJournals.Models.InComing
{
    public class JournalExceptionInContract
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Path { get; set; }
        public string Body { get; set; }
        public string RequestId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
