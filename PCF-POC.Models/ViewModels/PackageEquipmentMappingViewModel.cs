using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.Models.ViewModels
{
    public class PackageEquipmentMappingViewModel
    {
        public int PackageId { get; set; }
        public string PackageDescription { get; set; }
        public List<EquipmentModel> Equipments { get; set; }
        public List<int> MappedEquipmentsId { get; set; }
    }
}
