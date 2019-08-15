using Ninject.Modules;
using Orion.Core.DataAccess;
using Orion.Core.DataAccess.EntityFramework;
using Orion.Northwind.Business.Abstract;
using Orion.Northwind.Business.Concrete.Manager;
using Orion.Northwind.DataAccess.Abstract;
using Orion.Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
        }
    }
}
