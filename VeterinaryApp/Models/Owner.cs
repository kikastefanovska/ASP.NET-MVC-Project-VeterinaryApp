using System.ComponentModel.DataAnnotations;

namespace VeterinaryApp.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 30 characters")]
        public  string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 40 characters")]
        public  string Surname { get; set; }
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }
        public string FullName
        {
            get { return $"{Name} {Surname}"; }
        }

        public  List<Pet> Pets { get; set; }
    }
}
