using PCF_POC.DAL;
using PCF_POC.DAL.Contracts;
using PCF_POC.DAL.Implementations;
using PCF_POC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.Repository
{
    public class PackageEquipmentMappingRepository : Repository<PackageEquipmentMapping>, IPackageEquipmentMappingRepository
    {
        private PcfDatabaseEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public PackageEquipmentMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected PcfDatabaseEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        //public IEnumerable<PackageEquipmentMapping> GetEquipmentMappingByPackageId(int id)
        //{
        //    //return dataContext.PackageEquipmentMappings.Where()
        //}
    }
    public interface IPackageEquipmentMappingRepository : IRepository<PackageEquipmentMapping>
    {
        //IEnumerable<PackageEquipmentMapping> GetEquipmentMappingByPackageId(int id);
    }
}
