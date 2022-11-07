using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _8_database.Models
{
    public class CollegeModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = "";
        [Required]
        [Display(Name = "Phone Number")]
        public string Number { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
    }
}
