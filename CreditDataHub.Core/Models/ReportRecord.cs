using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Models
{
    public class ReportRecord
    {
        public string ReportId { get; set; } = string.Empty;
        public string SubjectId { get; set; } = string.Empty;
        public DateTime GeneratedAt { get; set; }
        public bool IsPerson { get; set; }
    }
}
