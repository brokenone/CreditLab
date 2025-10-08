using CreditDataHub.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Services.Utils
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(string subjectId, int validHours = 24)
        {
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return token;
        }
    }
}
