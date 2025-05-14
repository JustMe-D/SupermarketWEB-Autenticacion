using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class PayMode
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Observation { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }

    }
}
