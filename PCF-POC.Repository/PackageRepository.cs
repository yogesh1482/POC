using PCF_POC.DAL;
using PCF_POC.DAL.Contracts;
using PCF_POC.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        private PcfDatabaseEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public PackageRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected PcfDatabaseEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface IPackageRepository : IRepository<Package>
    {
    }
}

