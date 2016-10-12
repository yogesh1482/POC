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
    public class EquipmentService : IEquipmentService
    {
        IUnitOfWork _unitOfWork;
        IEquipmentRepository _equipmentRepository;

        public EquipmentService(IUnitOfWork unitOfWork, IEquipmentRepository equipmentRepository)
        {
            _unitOfWork = unitOfWork;
            _equipmentRepository = equipmentRepository;
        }
        public IEnumerable<Equipment> GetAll()
        {
            return _equipmentRepository.GetAll();
        }


    }
}
