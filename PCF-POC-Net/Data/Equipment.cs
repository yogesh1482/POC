using System.Collections.Generic;

namespace PCF_POC.Data
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Description { get; set; }        
        public virtual ICollection<PackageEquipment> PackageEquipmentMappings { get; set; }
    }
}
