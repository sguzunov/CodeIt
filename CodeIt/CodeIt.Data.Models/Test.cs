using System.ComponentModel.DataAnnotations;

namespace CodeIt.Data.Models
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public string Output { get; set; }
    }
}
