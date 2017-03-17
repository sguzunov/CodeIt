using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class Test : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public string ExpectedOutput { get; set; }
    }
}
