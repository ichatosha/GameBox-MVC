namespace GameBox.Models
{
    public class Category : BaseProp
    {
         public ICollection<Game>games { get; set; }= new List<Game>();
    }
}
