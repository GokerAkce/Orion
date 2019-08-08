using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Orion.Northwind.DataAccess.Abstract;
using Orion.Northwind.Business.Concrete.Manager;
using Orion.Northwind.Entities.Concrete;
using FluentValidation;

namespace Orion.Northwind.Business.Tests
{
    /// <summary>
    /// Summary description for ProductManagerTests
    /// </summary>
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
      
    }
}
