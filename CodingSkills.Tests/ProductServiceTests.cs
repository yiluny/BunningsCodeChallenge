using CodingSkills.Models;
using CodingSkills.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using System.Linq;

namespace CodingSkills.Tests
{
    /// <summary>
    /// Summary description for ProductServiceTests
    /// </summary>
    [TestClass]
    public class ProductServiceTests
    {
        private IEnumerable<ProductBarcode> BarcodesCompanyA;
        private IEnumerable<ProductBarcode> BarcodesCompanyB;
        private IEnumerable<Product> ProductsCompanyA;
        private IEnumerable<Product> ProductsCompanyB;

        Mock<IProductService> productService = new Mock<IProductService>();
        public ProductServiceTests()
        {
            BarcodesCompanyA = JsonConvert.DeserializeObject<IEnumerable<ProductBarcode>>(GetInputFileData("barcodesA.json"));
            BarcodesCompanyB = JsonConvert.DeserializeObject<IEnumerable<ProductBarcode>>(GetInputFileData("barcodesB.json"));
            ProductsCompanyA = JsonConvert.DeserializeObject<IEnumerable<Product>>(GetInputFileData("catalogA.json"));
            ProductsCompanyB = JsonConvert.DeserializeObject<IEnumerable<Product>>(GetInputFileData("catalogB.json"));

            var result = JsonConvert.DeserializeObject<IEnumerable<MergedProduct>>(GetInputFileData("output_result.json"));

            productService.Setup(o => o.GetMergedProductsByDescription(BarcodesCompanyA, BarcodesCompanyB, ProductsCompanyA, ProductsCompanyB)).Returns(result.ToList());
        }
        private static string GetInputFileData(string filename)
        {
            return new StreamReader(string.Format("{0}/Data/{1}", Environment.CurrentDirectory, filename)).ReadToEnd();
        }

        //Mock Testing
        [TestMethod]
        public void GetMergedProductsByDescriptionService_Test()
        {
            var result = productService.Object.GetMergedProductsByDescription(BarcodesCompanyA, BarcodesCompanyB, ProductsCompanyA, ProductsCompanyB);
            Assert.AreEqual(7, result.Count);
        }

        //Intergration Testing
        [TestMethod]
        public void GetMergedProductsByDescription_Test()
        {
            var service = new ProductService();
            var result = service.GetMergedProductsByDescription(BarcodesCompanyA, BarcodesCompanyB, ProductsCompanyA, ProductsCompanyB);
            Assert.AreEqual(7, result.Count);
        }

        [TestMethod]
        public void GetMergedProductsByDescription_WhenEmptyCSV_Test()
        {
            BarcodesCompanyA = new List<ProductBarcode>();
            var service = new ProductService();
            var result = service.GetMergedProductsByDescription(BarcodesCompanyA, BarcodesCompanyB, ProductsCompanyA, ProductsCompanyB);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Barcode_FromCsv_Test()
        {
            string csvLine = "00001,647-vyk-317,z2783613083817";
            string source = "A";
            ProductBarcode barcode = new ProductBarcode().FromCsv(csvLine, source);
            Assert.IsNotNull(barcode);
            Assert.AreEqual("647-vyk-317", barcode.SKU);
        }
    }
}
