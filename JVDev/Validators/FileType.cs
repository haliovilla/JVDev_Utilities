using JVDev.Defaults;
using JVDev.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JVDev.Validators
{
    public class FileType : ValidationAttribute
    {
        private readonly string[] validFileTypes;

        public FileType(string[] validFileTypes)
        {
            this.validFileTypes = validFileTypes;
        }

        public FileType(GroupFileType groupFileType)
        {
            if (groupFileType == GroupFileType.Image)
                validFileTypes = FileExtensions.Image;

            if (groupFileType == GroupFileType.Document)
                validFileTypes = FileExtensions.Document;

            if (groupFileType == GroupFileType.Video)
                validFileTypes = FileExtensions.Video;

            if (groupFileType == GroupFileType.Audio)
                validFileTypes = FileExtensions.Audio;

            if (groupFileType == GroupFileType.Executable)
                validFileTypes = FileExtensions.Executable;

            if (groupFileType == GroupFileType.Compressed)
                validFileTypes = FileExtensions.Compressed;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return ValidationResult.Success;

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
                return ValidationResult.Success;

            if (!validFileTypes.Contains(formFile.ContentType))
                return new ValidationResult($"Invalid file type. Valid file types are: {string.Join(", ", validFileTypes)}");

            return ValidationResult.Success;
        }
    }
}
