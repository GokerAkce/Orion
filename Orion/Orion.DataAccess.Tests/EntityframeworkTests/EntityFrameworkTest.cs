﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Northwind.DataAccess.Concrete.EntityFramework;

namespace Orion.DataAccess.Tests.EntityframeworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList();

            Assert.AreEqual(79, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList(x => x.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void Get_all_returns_all_categories()
        {
             EfCategoryDal categoryDal = new EfCategoryDal();

            var result = categoryDal.GetList();

            Assert.AreEqual(8, result.Count);
        }
    }
}
