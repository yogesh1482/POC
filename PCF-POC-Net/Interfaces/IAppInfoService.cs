using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCF_POC.Interfaces
{
    public interface IAppInfoService
    {
        IEnumerable<T> GetData<T>();
        T GetById<T>();
        IEnumerable<T> GetEquipments<T>();
    }
}
