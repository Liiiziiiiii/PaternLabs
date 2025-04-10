using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class PatientExamination
    {
        [Key]
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? ExaminationId { get; set; }
        public Examination? Examination { get; set; }
        [DataType(DataType.Date)]
        public DateTime PassedDate { get; set; }
        public bool Passed { get; set; }
        public string Result { get; set; }


    }
}
