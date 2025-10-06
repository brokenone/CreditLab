using Shared.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Interfaces
{
    public interface IMediatorService
    {
        Task<MediatorResultDto> ProcessCreditCheckAsync(string ssn, decimal requestedAmount);
    }
}
