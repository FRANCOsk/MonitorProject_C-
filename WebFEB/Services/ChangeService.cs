using WebFEB.Enums;
using WebFEB.Models;
using WebFEB.Storage;

namespace WebFEB.Services;

public class ChangeService : IChangeService
{
    private readonly ILogger<ChangeService> _logger;

    public ChangeService(ILogger<ChangeService> logger)
    {
        _logger = logger;
    }

    public Task TrackChange(ChangeDTO action)
    {
        action.Id = MonitorStorage.Changes.Count + 1;
        action.Timestamp = DateTime.UtcNow;
        MonitorStorage.Changes.Add(action);

        string logMessage =
            "Change tracked: {ChangeType} by {Email} at {Timestamp}. Message: {Message}";

        switch (action.ChangeType)
        {
            case ChangeTypes.Warning:
                _logger.LogWarning(
                    logMessage,
                    action.ChangeType,
                    action.Email,
                    action.Timestamp,
                    action.Message);
                break;

            case ChangeTypes.Error:
                _logger.LogError(
                    logMessage,
                    action.ChangeType,
                    action.Email,
                    action.Timestamp,
                    action.Message);
                break;

            default:
                _logger.LogInformation(
                    logMessage,
                    action.ChangeType,
                    action.Email,
                    action.Timestamp,
                    action.Message);
                break;
        }

        return Task.CompletedTask;
    }

    public Task<List<ChangeDTO>> GetAllChangesAsync()
    {
        return Task.FromResult(MonitorStorage.Changes.ToList());
    }

    public Task<ChangeDTO?> GetChangeByIdAsync(int id)
    {
        return Task.FromResult(MonitorStorage.Changes.SingleOrDefault(change => change.Id == id));
    }
}
