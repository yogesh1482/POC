using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.Models
{
    public class PackageEquipmentsViewModel
    {
        public int PackageId { get; set; }

        public int EquipmentId { get; set; }

        public string EquipmentDescription { get; set; }

        public string PackageDescription { get; set; }
    }
}
