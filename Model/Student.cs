using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem_VishalMundhra_API.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        public ICollection<StudentClass> Classes { get; set; }
    }
}
