using System.Diagnostics;
using WebFEB.Enums;
using WebFEB.Models;
using WebFEB.Storage;

namespace WebFEB.Services
{
    public class ChangeService: IChangeService
    {
        private EventLog _eventLog;

        public ChangeService()
        {
            _eventLog = new EventLog("WebFEB");
        }

        public async Task TrackChange(ChangeDTO action)
        {

            action.Id = MonitorStorage.Changes.Count + 1;
            action.Timestamp = DateTime.Now;
            MonitorStorage.Changes.Add(action);
            EventLogEntryType eventLogType = EventLogEntryType.Information;
            switch(action.ChangeType)
            {
                case ChangeTypes.Warning:
                    eventLogType = EventLogEntryType.Warning;
                    break;
                case ChangeTypes.Error:
                    eventLogType = EventLogEntryType.Error;
                    break;
                default:
                    eventLogType = EventLogEntryType.Information;
                    break;
            }
            _eventLog.WriteEntry($"Change tracked: {action.ChangeType} by {action.Email} at {action.Timestamp}. Message: {action.Message}", eventLogType);
        }

        public async Task<List<ChangeDTO>> GetAllChangesAsync()
        {
            return MonitorStorage.Changes;
        }

        public Task<ChangeDTO> GetChangeByIdAsync(int id)
        {
            return Task.FromResult(MonitorStorage.Changes.SingleOrDefault(x => x.Id == id));
        }
    }
}