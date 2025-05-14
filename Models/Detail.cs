using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class Detail
    {
        public int Id { get; set; }

        [Required]
        public int invoiceId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal price { get; set; }

        [ForeignKey("invoiceId")]
        public Invoice? Invoice { get; set; }

        [ForeignKey("productId")]
        public Product? Product { get; set; }
    }
}
