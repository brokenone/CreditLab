using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(string subjectId, int validHours = 24);
    }
}
