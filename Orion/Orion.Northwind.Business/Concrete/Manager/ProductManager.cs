using Orion.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orion.Northwind.Entities.Concrete;
using Orion.Northwind.DataAccess.Abstract;

namespace Orion.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public Product Add(Product product)
        {
            _productDal.Add(product);
            return product;
        }

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
    }
}
