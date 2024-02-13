namespace GameBox.Models
{
    public class Game : BaseProp
    {

        public string Description { get; set; } = string.Empty;

        public string Cover { get; set; } = string.Empty;

        // FK
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        // Relation one to many
        public ICollection<GameDevices> Devices { get; set;} = new List<GameDevices>();
    }
}
