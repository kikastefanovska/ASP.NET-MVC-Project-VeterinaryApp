using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinaryApp.Models
{
    public class Pet
    {
 
        public int PetId { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Range(0, 50, ErrorMessage = "Age must be between 0 and 50")]
        public int Age { get; set; }

        public int OwnerId { get; set; }
        
        public  Owner Owner { get; set; }

        public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
        [NotMapped]
       public List<int> VaccineIds { get; set; }
    }
}
