
namespace GameBox.ViewModel
{
    public class CreateGameFormViewModel : CommonPropViewModel
    {

        // allowed Extensions 
        // limit size 1 mb
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
        
    }
}
