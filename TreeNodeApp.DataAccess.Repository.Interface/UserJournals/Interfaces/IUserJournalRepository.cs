using TreeNodeApp.DataAccess.Repository.Interface.Common.Models;
using TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Models;

namespace TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Interfaces
{
    public interface IUserJournalRepository
    {
        Task<(int, IEnumerable<JournalException>)> GetRangeAsync(FilterModel filterModel);
        Task<JournalException> GetSingleAsync(int id);
        Task CreateExceptionAsync(JournalException exception);
    }
}
