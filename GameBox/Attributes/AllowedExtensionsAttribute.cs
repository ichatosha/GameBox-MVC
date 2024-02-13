
// make server side validation for >> image (extensions) allowed : .jpg , .jpeg , .png

namespace GameBox.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string _allowedExtensions;

        public AllowedExtensionsAttribute( string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extensions = Path.GetExtension(file.FileName);

                // ignore if extension are capital 
                var isAllowed = _allowedExtensions.Split(",").Contains(extensions,StringComparer.OrdinalIgnoreCase);

                if (!isAllowed) 
                {
                    return new ValidationResult($"Only {_allowedExtensions} are allowed!");
                }
                else
                {
                    return ValidationResult.Success;
                }
                
            }
            return ValidationResult.Success;

        }
    }
}
