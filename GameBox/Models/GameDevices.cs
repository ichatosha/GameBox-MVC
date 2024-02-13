using System.ComponentModel.DataAnnotations.Schema;

namespace GameBox.Models
{
    public class GameDevices
    {
        public int GameId { get; set; }
        public Game Game { get; set; } = default!;

        // FK to Devices table
        [ForeignKey("devices")]
        public int DeviceId { get; set; }
        // navigation property
        public Devices devices { get; set; } = default!;
    }
}
