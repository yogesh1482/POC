using System;
using System.Threading.Tasks;

namespace PCF_POC.Interfaces
{
    public interface IBaseService
    {
        Task<String> ExecuteRequestAsync(string query);
    }
}
