using System;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Payment
    {
        public long Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [CreditCard]
        public string? Card { get; set; }

        [Required]
        [StringLength(3)]
        public string? CVC { get; set; }

        [Required]
        public DateTime Expiry { get; set; }
    }
}