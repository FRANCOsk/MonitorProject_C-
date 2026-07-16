using WebFEB.Enums;

namespace WebFEB.Models;

public class ChangeDTO
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public ChangeTypes ChangeType { get; set; }

    public DateTime Timestamp { get; set; }

    public string Message { get; set; } = string.Empty;
}
