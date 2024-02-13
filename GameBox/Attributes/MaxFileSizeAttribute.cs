
// Make server side validation for file size << 1 MB

using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Drawing;

namespace GameBox.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute( int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var fileSize = value as IFormFile;

            if (fileSize is not null)
            {
                if (fileSize.Length > _maxFileSize)
                {
                    return new ValidationResult($"This Image Size is more than {fileSize.Length/1000000} MB, and the Max Size is {_maxFileSize/ 1000000} MB!\n");
                    
                }
            } 
            
            return ValidationResult.Success;
        }
    }
}
