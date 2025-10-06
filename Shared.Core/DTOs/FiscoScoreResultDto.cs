using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.DTOs
{
    public class FiscoScoreResultDto
    {
        public int Score { get; set; }
        public string RiskLevel {  get; set; } = string.Empty;
        public List<string> Factors { get; set; } = new();
    }
}
