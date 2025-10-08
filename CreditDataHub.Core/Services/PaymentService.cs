using CreditDataHub.Core.Interfaces;
using CreditDataHub.Shared.Enums;
using CreditDataHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Services
{
    public class PaymentService : IPaymentService
    {
        public readonly Dictionary<string, Payment> _payment = [];
        private readonly ITokenGenerator _tokenGenerator;
        public readonly TokenService _tokenService;

        public PaymentService(ITokenGenerator tokenGenerator, TokenService tokenService)
        {
            _tokenGenerator = tokenGenerator;
            _tokenService = tokenService;
        }

        public PaymentTransactionStatus CheckPayment(string subjectId)
        {
            if (!_payment.TryGetValue(subjectId, out var payment))
                return payment.Status;
            return PaymentTransactionStatus.Pending;
        }

        public string MakePayment(string subjectId)
        {
            var payment = new Payment
            {
                PaymentId = Guid.NewGuid().ToString(),
                SubjectId = subjectId,
                Status = PaymentTransactionStatus.Completed,
                CreatedAt = DateTime.UtcNow,
                PaidAt = DateTime.UtcNow
            };
            _payment[subjectId] = payment;

            var tokenString = _tokenGenerator.GenerateToken(subjectId, 24);
            var token = new Token
            {
                TokenId = tokenString,
                SubjectId = subjectId,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddHours(24),
                Used = false
            };

            _tokenService.AddToken(token);

            return tokenString;
        }
    }
}
