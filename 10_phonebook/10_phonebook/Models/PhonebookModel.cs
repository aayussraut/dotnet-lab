using System.ComponentModel.DataAnnotations;

namespace _10_phonebook.Models
{
    public class PhonebookModel
    {
        public int Id{ get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name ="Full Name")]
        public string Name { get; set; } = "";
        [Required]
        [Display(Name = "Phone Number")]
        public string Number { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
    }
}
