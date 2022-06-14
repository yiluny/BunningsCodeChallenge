using CodingSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.Services
{
    public interface IProductService
    {
        List<MergedProduct> GetMergedProductsByDescription(IEnumerable<ProductBarcode> BarcodesCompanyA, IEnumerable<ProductBarcode> BarcodesCompanyB, IEnumerable<Product> productsCompanyA, IEnumerable<Product> productsCompanyB);
    }
}
