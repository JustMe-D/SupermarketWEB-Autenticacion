using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class Customer
    { 
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string document_number { get; set; }
        [Required]
        [StringLength(20)]
        public string first_name { get; set; }
        [Required]
        [StringLength(20)]
        public string last_name { get; set; } 
        
        [StringLength(80)]
        public string? address { get; set; }
        public DateTime? birthday { get; set; }
        
        [StringLength(20)]
        public string? phone_number { get; set; }
        [StringLength(100)]
        public string? email { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
