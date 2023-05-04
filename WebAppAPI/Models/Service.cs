using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAPI.Models
{
    [Table("RentalServices")]
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public int Price { get; set; }
        [Column("Service")]
        [MaxLength(100)]
        public string Description { get; set; }
        public bool IsAvalible { get; set; }
    }
}
