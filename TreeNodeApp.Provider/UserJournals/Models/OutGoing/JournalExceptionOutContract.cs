using System.Text.Json.Serialization;
using TreeNodeApp.Provider.Service.Interface.Common.Helpers;

namespace TreeNodeApp.Provider.Service.Interface.UserJournals.Models.OutGoing
{
    public class JournalExceptionOutContract
    {
        public Int64 Id { get; set; }
        [JsonConverter(typeof(LongToStringConverter))]
        public Int64 EventId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}