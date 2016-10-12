using PCF_POC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.BL.Contracts
{
    public interface IPackageEquipmentMappingService
    {
        IEnumerable<PackageEquipmentMapping> GetAll();
        //get equipment Ids
        IEnumerable<int> GetEquipmentMappingByPackageId(int id);
    }
}
