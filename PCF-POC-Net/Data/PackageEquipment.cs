using System;

namespace PCF_POC.Data
{
    public class PackageEquipment
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public Nullable<int> PackageId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Package Package { get; set; }
    }
}
