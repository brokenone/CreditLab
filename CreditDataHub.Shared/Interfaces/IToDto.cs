using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditDataHub.Shared.Interfaces
{
    /// <summary>
    /// Converts Core objects to Data Transfer Objects (DTOs).
    /// </summary>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) to which the object will be converted.</typeparam>
    public interface IToDto<TDto>
    {
        TDto ToDto();
    }
}
