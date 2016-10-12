using PCF_POC.BL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCF_POC.DAL;
using PCF_POC.DAL.Contracts;
using PCF_POC.Repository;

namespace PCF_POC.BL.Implementations
{
    public class PackageService : IPackageService
    {
        IUnitOfWork _unitOfWork;
        IPackageRepository _packageRepository;

        public PackageService(IUnitOfWork unitOfWork, IPackageRepository packageRepository)
        {
            _unitOfWork = unitOfWork;
            _packageRepository = packageRepository;
        }
        public IEnumerable<Package> GetAll()
        {
            return _packageRepository.GetAll();
        }

        public Package GetById(long id)
        {
            return _packageRepository.GetById(id);
        }
    }
}
