using PCF_POC.BL.Contracts;
using PCF_POC.DAL;
using PCF_POC.Models;
using PCF_POC.Models.ViewModels;
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
    [RoutePrefix("api/package")]
    public class PackagesController : ApiController
    {
        IPackageService _packageInfo;
        IPackageService _packageService;
        IPackageEquipmentMappingService _packageEquipmentService;
        IEquipmentService _equiptmentService;
        public PackagesController(IPackageService packageInfo, IPackageService packageService, IPackageEquipmentMappingService packageEquipmentService, IEquipmentService equiptmentService)
        {
            
            _packageInfo = packageInfo;
            _packageService = packageService;
            _packageEquipmentService = packageEquipmentService;
            _equiptmentService = equiptmentService;
        }
        [Route("get")]
        public IEnumerable<Package> GetDetails()
        {
            return _packageInfo.GetAll();
          
        }

        //[Route("get/{id}")]
        //public Package GetDetails(int id)
        //{
        //    return _packageInfo.GetById(id);

        //}
        

        [Route("get/{id}")]
        public IEnumerable<PackageEquipmentMappingViewModel> GetEquipmentsByPackageId(int id)
        {
            try
            {
                var package = _packageService.GetById(id);

                var eq1 = _equiptmentService.GetAll();

                List<EquipmentModel> equipmentsForPackage = new List<EquipmentModel>();

                foreach (var item in eq1)
                {
                    equipmentsForPackage.Add(new EquipmentModel()
                    {
                        Id = item.Id,
                        Description = item.Description
                    });
                }

                var packageEquipmentMapping = _packageEquipmentService.GetEquipmentMappingByPackageId(id);
                List<PackageEquipmentMappingViewModel> result = new List<PackageEquipmentMappingViewModel>();
                //result.Equipments = equipmentsForPackage;
                //result.MappedEquipmentsId = packageEquipmentMapping.ToList<int>();
                //result.PackageId = id;
                //result.PackageDescription = package.Description;

                result.Add(new PackageEquipmentMappingViewModel()
                {
                    Equipments = equipmentsForPackage,
                    MappedEquipmentsId = packageEquipmentMapping.ToList<int>(),
                    PackageId = id,
                    PackageDescription = package.Description
                });


                ////List<EquipmentModel> equipmentsForPackage = new List<EquipmentModel>();
                //var equipments = _equiptmentService.GetAll();
                //foreach (int equipmentId in packageEquipmentMapping)
                //{
                //    var eq = equipments.Where(e => e.Id == equipmentId);
                //    foreach (var item in eq) { 
                //        equipmentsForPackage.Add(new EquipmentModel() {
                //            Id = item.Id,
                //            Description = item.Description
                //        });
                //    }
                //}

                //List<PackageEquipmentMappingViewModel> result = new List<PackageEquipmentMappingViewModel>();
                //foreach (var item in equipmentsForPackage)
                //{
                //    result.Add(new PackageEquipmentMappingViewModel()
                //    {
                //        PackageId = id,
                //        PackageDescription = package.Description,
                //        Equipments = equipmentsForPackage
                //    });
                //}

                return result;
            }
            catch (Exception ex)
            {
                return new List<PackageEquipmentMappingViewModel>();
            }
        }



    }
}
