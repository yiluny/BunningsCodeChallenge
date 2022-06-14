using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingSkills.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }

        public Product FromCsv(string csvLine, string source)
        {
            string[] values = csvLine.Split(',');
            Product product = new Product();
            product.SKU = values[0];
            product.Description = values[1];
            product.Source = source;
            return product;
        }
    }
}