using Orion.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orion.Northwind.Entities.Concrete;
using Orion.Northwind.DataAccess.Abstract;
using Orion.Northwind.Business.ValidationRules.FluentValidation;
using System.Transactions;
using Orion.Core.Aspect.Postsharp.ValidationAspects;
using Orion.Core.Aspect.Postsharp.TransactionAspects;
using Orion.Core.Aspect.Postsharp.CacheAspects;
using Orion.Core.CrossCuttingConcerns.Caching.Microsoft;
using Orion.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Orion.Core.Aspect.Postsharp.LogAspect;

namespace Orion.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            _productDal.Add(product);
            return product;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAll()
        {
            var result = _productDal.GetList();
            return result;
        }

        public Product GetById(int id)
        {
            var result = _productDal.Get(x => x.ProductId == id);
            return result;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            var result = _productDal.Update(product);
            return result;
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //Business methods
            _productDal.Add(product2);
        }
    }
}
