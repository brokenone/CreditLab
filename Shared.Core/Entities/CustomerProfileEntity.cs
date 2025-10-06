using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Entities
{
    public class CustomerProfileEntity
    {
        [Key]
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string SSN { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(20)")]
        public string FullName { get; set; } = string.Empty;

        public decimal Income { get; set; }
        public decimal Debt { get; set; }
        public int CreditHistoryYears { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(1000)")]
        public string PaymentHistoryJson { get; set; } = string.Empty;
    }
}
