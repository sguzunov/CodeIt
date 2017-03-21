using System;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.Data.Models
{
    public abstract class FileInfo
    {
        public Guid Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string FileSystemPath { get; set; }
    }
}
