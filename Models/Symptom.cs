using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class Symptom
    {
        [Key]
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }


        public string Name { get; set; }

    }
}
