using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem_VishalMundhra_API.Model
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public ICollection<StudentClass> Students { get; set; }
    }
}
