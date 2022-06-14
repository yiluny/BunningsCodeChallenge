using CodingSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingSkills.Services
{
    public class ProductService : IProductService
    {
        public ProductService()
        {

        }
        private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ProductService));
        public List<MergedProduct> GetMergedProductsByDescription(IEnumerable<ProductBarcode> barcodesCompanyA, IEnumerable<ProductBarcode> barcodesCompanyB, IEnumerable<Product> productsCompanyA, IEnumerable<Product> productsCompanyB)
        {
            try
            {
                if (barcodesCompanyA?.Any() != true || barcodesCompanyB?.Any() != true || productsCompanyA?.Any() != true || productsCompanyB?.Any() != true)
                {
                    Log.Warn("One or more csv file(s) not returning data");
                    return null;
                }

                List<MergedProduct> result = barcodesCompanyA.Concat(barcodesCompanyB)
                    // get unique barcodes from both companies
                    .GroupBy(b => b.Barcode).Select(barcode => barcode.First())
                    .GroupBy(b => new { b.SKU, b.Source }).Select(i => i.First())
                    // join the catalog info from both companies then complete the merged the product
                    .Join(productsCompanyA.Concat(productsCompanyB),
                        barcode => barcode.SKU,
                        product => product.SKU,
                        (barcode, product) =>
                            new MergedProduct() { SKU = barcode.SKU, Description = product.Description, Source = barcode.Source })
                    .Distinct()
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                Log.Error("Could not process queries on method GetMergedProductsByDescription: " + ex.Message, ex);
            }

            return null;
        }
    }
}