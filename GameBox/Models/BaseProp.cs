

namespace GameBox.Models
{
    public class BaseProp
    {

        public int Id { get; set; }


        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;


    }
}
