using System.ComponentModel.DataAnnotations;

namespace CSVApplication.Entities
{
    public class CSVBodyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FileAsBase64 { get; set; }
        [Required]
        public string Delimiter { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}