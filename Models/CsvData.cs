using System.ComponentModel.DataAnnotations;

namespace PaternLab.Models
{
    public class CsvData
    {
        [Key]
        public int Id { get; set; }
        [MinLength(1000)]
        public string Data { get; set; }
    }
}
