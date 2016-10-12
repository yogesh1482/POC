using Newtonsoft.Json;
using PCF_POC.Data;
using PCF_POC.Interfaces;
using System;
using System.Collections.Generic;

namespace PCF_POC.Services
{
    public class EquipmentService : IAppInfoService
    {
        private IBaseService _service;
        public IPackageService _equipmentService;
        public EquipmentService(IBaseService service, IPackageService equipmentService)
        {            
            _service = service;
            _equipmentService = equipmentService;
        }
        public IEnumerable<Equipment> GetData<Equipment>()
        {
            try
            {
                var query = "api/equipment/get";
                var equipments = JsonConvert.DeserializeObject<IEnumerable<Equipment>>(_service.ExecuteRequestAsync(query).Result);
                return equipments;
            }
            catch(Exception)
            {
                return new List<Equipment>();
            }
        }

        public IEnumerable<PackageEquipment> GetPackagesByEquipmentId<PackageEquipment>(int id)
        {
            try
            {
                var query = "api/equipment/get?"+id;
                var equipmentPackages = JsonConvert.DeserializeObject<IEnumerable<PackageEquipment>>(_service.ExecuteRequestAsync(query).Result);
                foreach (var item in equipmentPackages)
                {
                    
                }
                return equipmentPackages;
            }
            catch (Exception ex)
            {
                return new List<PackageEquipment>();
            }
            
        }
        public IEnumerable<Equipment> GetEquipments<Equipment>()
        {
            try
            {
                var query = "api/Equipment";
                var equipments = JsonConvert.DeserializeObject<IEnumerable<Equipment>>(_service.ExecuteRequestAsync(query).Result);
                return equipments;
            }
            catch (Exception ex)
            {
                return new List<Equipment>();
            }
        }

        public Equipment GetById<Equipment>()
        {
            throw new NotImplementedException();
        }
    }
}
