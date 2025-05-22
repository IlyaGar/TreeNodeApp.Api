namespace TreeNodeApp.Provider.Service.Interface.UserJournals.Models.OutGoing
{
    public class UserJournalOutContract
    {
        public int Skip { get; set; }
        public int Count { get; set; }
        public IEnumerable<JournalExceptionOutContract> Items { get; set; }
    }
}
