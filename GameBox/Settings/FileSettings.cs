

namespace GameBox.Settings
{
    public static class FileSettings
    {
        public const string ImagePath = "/assets/images/games";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxSizeForImageInMB = 1;
        public const int MaxSizeInBytes = MaxSizeForImageInMB * 1024 * 1024;
    }
}
