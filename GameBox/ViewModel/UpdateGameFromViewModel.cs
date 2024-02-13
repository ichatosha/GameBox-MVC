namespace GameBox.ViewModel
{
    public class UpdateGameFromViewModel : CommonPropViewModel
    {

        public int Id { get; set; }

        // cover
        public string? CurrentCover { get; set; }

        // allowed Extensions 
        // limit size 1 mb
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
