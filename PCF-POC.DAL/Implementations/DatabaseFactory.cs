using PCF_POC.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.DAL.Implementations
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private PcfDatabaseEntities dataContext;
        public PcfDatabaseEntities Get()
        {
            return dataContext ?? (dataContext = new PcfDatabaseEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }



    }

}
