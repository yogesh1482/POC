using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.BL.Contracts
{
    public interface IPackageService
    {
        IEnumerable<DAL.Package> GetAll();
        DAL.Package GetById(long id);
    }
}
