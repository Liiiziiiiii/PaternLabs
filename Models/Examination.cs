using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class Examination
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
