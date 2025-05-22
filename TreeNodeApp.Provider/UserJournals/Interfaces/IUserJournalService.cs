using TreeNodeApp.Provider.Service.Interface.UserJournals.Models.InComing;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Models.OutGoing;

namespace TreeNodeApp.Provider.Service.Interface.UserJournals.Interfaces
{
    public interface IUserJournalService
    {
        Task<UserJournalOutContract> GetRangeAsync(int skip, int take, UserJournalFilter journalFilter);
        Task<JournalExceptionSingleOutContract> GetSingleAsync(int id);
        Task CreateJournalExceptionAsync(JournalExceptionInContract exception);
    }
}
