using WebFEB.Models;

namespace WebFEB.Storage
{
    public class MonitorStorage
    {
        public static List<ChangeDTO> Changes { get; set; } = new List<ChangeDTO>();
    }
}
