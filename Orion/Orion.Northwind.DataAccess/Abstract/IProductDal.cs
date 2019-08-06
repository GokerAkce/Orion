using Orion.Core.DataAccess;
using Orion.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Northwind.DataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>
    {

    }
}
