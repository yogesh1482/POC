using Newtonsoft.Json;
using PCF_POC.Data;
using PCF_POC.Interfaces;
using System;
using System.Collections.Generic;

namespace PCF_POC.Services
{
    public class PackageService : IAppInfoService
    {
        IBaseService _service;
        public PackageService(IBaseService service)
        {
            _service = service;
        }

        public Package GetById<Package>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Package> GetData<Package>()
        {
            try
            {
                var query = "api/package/get";
                var packages = JsonConvert.DeserializeObject<IEnumerable<Package>>(_service.ExecuteRequestAsync(query).Result);
                return packages;
            }
            catch(Exception ex)
            {
                return new List<Package>();
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
    }
}
