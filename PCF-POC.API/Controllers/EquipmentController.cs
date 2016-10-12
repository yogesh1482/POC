using PCF_POC.BL.Contracts;
using PCF_POC.DAL;
using PCF_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PCF_POC.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EquipmentController : ApiController
    {
        IEquipmentService _equiptmentService;
        IPackageService _packageService;
        IPackageEquipmentMappingService _packageEquipmentService;
        public EquipmentController(IEquipmentService equiptmentService, IPackageService packageService, IPackageEquipmentMappingService packageEquipmentService)
        {
            _equiptmentService = equiptmentService;
            _packageService = packageService;
            _packageEquipmentService = packageEquipmentService;
        }


        [HttpGet]
        public IEnumerable<Equipment> GetDetails()
        {
            return _equiptmentService.GetAll();
        }

        [HttpGet]
        public IEnumerable<PackageEquipmentsViewModel> GetPackagesByEquipmentId(int id)
        {
            var equiptmentService = _equiptmentService.GetAll();

            var packageService = _packageService.GetAll();

            var packageEquipmentService = _packageEquipmentService.GetAll();

            var result = (from p in packageService.ToList()
                          join PE in packageEquipmentService.ToList()
                          on p.Id equals PE.PackageId
                          join E in equiptmentService.ToList()
                          on PE.EquipmentId equals E.Id
                          where E.Id == id
                          select new PackageEquipmentsViewModel
                          {
                              //PackageDescription = p.Description,
                              //EquipmentDescription = E.Description,
                              PackageId = p.Id
                              //EquipmentId = E.Id
                          }).ToList();
            

            return result;
        }
    }
}
