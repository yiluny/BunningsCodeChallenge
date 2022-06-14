using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingSkills.Models
{
    public class ProductBarcode
    {
        public int SupplierID { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public string Source { get; set; }

        public ProductBarcode FromCsv(string csvLine, string source)
        {
            string[] values = csvLine.Split(',');
            ProductBarcode barcode = new ProductBarcode();
            barcode.SupplierID = Convert.ToInt32(values[0]);
            barcode.SKU = values[1];
            barcode.Barcode = values[2];
            barcode.Source = source;
            return barcode;
        }
    }
}