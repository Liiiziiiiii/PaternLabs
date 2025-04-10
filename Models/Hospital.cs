using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Doctor> doctors { get; set; }

    }
}
