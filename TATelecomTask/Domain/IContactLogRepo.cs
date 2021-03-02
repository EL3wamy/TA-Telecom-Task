using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TATelecomTask.Domain
{
    public interface IContactLogRepo
    {
        Task<bool> AddContanctLogAsync(string message);
    }
}
