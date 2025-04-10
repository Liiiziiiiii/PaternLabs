using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class HealthySystem
    {
        [Key]
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}
