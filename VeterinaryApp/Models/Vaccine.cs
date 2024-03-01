using System.ComponentModel.DataAnnotations;

namespace VeterinaryApp.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 30 characters")]
        public required string Name { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
