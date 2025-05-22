using TreeNodeApp.DataAccess.Repository.Interface.Common.Models;
using TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Interfaces;
using TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Models;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Interfaces;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Models.InComing;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Models.OutGoing;

namespace TreeNodeApp.Provider.Service.UserJournals
{
    public class UserJournalService : IUserJournalService
    {
        private readonly IUserJournalRepository _userJournalRepository;

        public UserJournalService(IUserJournalRepository userJournalRepository)
        {
            _userJournalRepository = userJournalRepository;
        }

        public async Task<UserJournalOutContract> GetRangeAsync(int skip, int take, UserJournalFilter journalFilter)
        {
            var filterModel = ConvertToFilterModel(skip, take, journalFilter);
            var journals = await _userJournalRepository.GetRangeAsync(filterModel);

            return new UserJournalOutContract()
            {
                Count = journals.Item1,
                Skip = skip,
                Items = journals.Item2.Select(ConvertToJournalExceptionOutContract)
            };
        }

        public async Task<JournalExceptionSingleOutContract> GetSingleAsync(int id)
        {
            return ConvertToJournalExceptionSimgleOutContract(await _userJournalRepository.GetSingleAsync(id));
        }


        public async Task CreateJournalExceptionAsync(JournalExceptionInContract exception)
        {
            await _userJournalRepository.CreateExceptionAsync(ConvertToJournalException(exception));
        }

        private static FilterModel ConvertToFilterModel(int skip, int take, UserJournalFilter journalFilter)
        {
            return new FilterModel()
            {
                Skip = skip,
                Take = take,
                From = journalFilter != null ? journalFilter.From : null,
                To = journalFilter != null ? journalFilter.To : null,
                Search = journalFilter != null ? journalFilter.Search : null,
            };
        }

        private static JournalExceptionOutContract ConvertToJournalExceptionOutContract(JournalException source)
        {
            return new JournalExceptionOutContract()
            {
                Id = source.Id,
                EventId = source.EventId,
                CreatedAt = source.CreatedAt,
            };
        }

        private static JournalExceptionSingleOutContract ConvertToJournalExceptionSimgleOutContract(JournalException source)
        {
            return new JournalExceptionSingleOutContract()
            {
                Id = source.Id,
                EventId = source.EventId,
                CreatedAt = source.CreatedAt,
                Text = "Request ID " + source.EventId + " " + source.Path + " " + source.Message + " " + source.StackTrace,
            };
        }

        private static JournalException ConvertToJournalException(JournalExceptionInContract source)
        {
            return new JournalException()
            {
                EventId = source.EventId,
                CreatedAt = source.CreatedAt,
                Message = source.Message,
                StackTrace = source.StackTrace,
                Path = source.Path,
                RequestId = source.RequestId,
            };
        }
    }
}
