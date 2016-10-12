using PCF_POC.BL.Contracts;
using PCF_POC.DAL;
using PCF_POC.DAL.Contracts;
using PCF_POC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.BL.Implementations
{
    public class PackageEquipmentMappingService : IPackageEquipmentMappingService
    {
        IUnitOfWork _unitOfWork;
        IPackageEquipmentMappingRepository _packageEquipmentMappingRepository;

        public PackageEquipmentMappingService(IUnitOfWork unitOfWork, IPackageEquipmentMappingRepository packageEquipmentMappingRepository)
        {
            _unitOfWork = unitOfWork;
            _packageEquipmentMappingRepository = packageEquipmentMappingRepository;
        }
        public IEnumerable<PackageEquipmentMapping> GetAll()
        {

            try
            {
                return _packageEquipmentMappingRepository.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //get equipment IDs
        public IEnumerable<int> GetEquipmentMappingByPackageId(int id)
        {
            List<PackageEquipmentMapping>  equipments = GetAll().ToList();
            return equipments.Where(e => e.PackageId == id).Select(e=>e.EquipmentId);
        }
    }
}
