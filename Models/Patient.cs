using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public List<Symptom> symptoms { get; set; }
    }
}
