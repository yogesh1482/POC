using PCF_POC.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCF_POC.DAL.Implementations
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private PcfDatabaseEntities dataContext;


        //Changes-----------------------------------------
        public UnitOfWork()
        {
            this.databaseFactory = new DatabaseFactory();
        }
        //-------------------------------------------------

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected PcfDatabaseEntities DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }



    }

}
