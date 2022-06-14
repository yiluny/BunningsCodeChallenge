using CodingSkills.Models;
using CodingSkills.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CodingSkills.Repositories
{


    /// <summary>
    /// A data repository that processes products based on Excel format
    /// </summary>
    public class ExcelDataRepository : IDataRepository
    {
        public IEnumerable<ProductBarcode> BarcodesCompanyA { get; set; }
        

        public IEnumerable<ProductBarcode> BarcodesCompanyB { get; set; }

        public IEnumerable<Product> ProductsCompanyA { get; set; }


        public IEnumerable<Product> ProductsCompanyB { get; set; }


        private IProductService _productService;
        public ExcelDataRepository(IProductService productService)
        {
            _productService = productService;
        }

        
        public List<MergedProduct> GetMergedProducts()
        {
            //Retrive the Data from CSV file
            RetriveData();
            //apply the product info get the final merged products
            var result = _productService.GetMergedProductsByDescription(BarcodesCompanyA, BarcodesCompanyB, ProductsCompanyA, ProductsCompanyB);

            return result;
        }

        private void RetriveData()
        {
            //retrive excel data
            BarcodesCompanyA = File.ReadAllLines(HttpContext.Current.Server.MapPath("~/Input/barcodesA.csv")).Skip(1).Select(v => new ProductBarcode().FromCsv(v, "A"));
            BarcodesCompanyB = File.ReadAllLines(HttpContext.Current.Server.MapPath("~/Input/barcodesB.csv")).Skip(1).Select(v => new ProductBarcode().FromCsv(v, "B"));
            ProductsCompanyA = File.ReadAllLines(HttpContext.Current.Server.MapPath("~/Input/catalogA.csv")).Skip(1).Select(v => new Product().FromCsv(v, "A"));
            ProductsCompanyB = File.ReadAllLines(HttpContext.Current.Server.MapPath("~/Input/catalogB.csv")).Skip(1).Select(v => new Product().FromCsv(v, "B"));
        }

    }
}