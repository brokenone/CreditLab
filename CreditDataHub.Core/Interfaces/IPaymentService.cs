using CreditDataHub.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Core.Interfaces
{
    public interface IPaymentService
    {
        PaymentTransactionStatus CheckPayment(string subjectId);
        string MakePayment(string subjectId);
    }
}
