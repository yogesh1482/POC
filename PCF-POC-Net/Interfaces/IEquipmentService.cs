using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCF_POC.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<T> GetPackagesByEquipmentId<T>(int id);
    }
}
