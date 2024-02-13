namespace GameBox.Models
{
    public class Devices : BaseProp
    {

        [MaxLength(250)]
        public string Icon { get; set; } = string.Empty;
    }
}
