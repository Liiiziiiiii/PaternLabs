using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public int Experience { get; set; }
        public string FieldActivity { get; set; }
    }
}
