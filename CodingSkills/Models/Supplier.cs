using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingSkills.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static Supplier FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Supplier supplier = new Supplier();
            supplier.ID = Convert.ToInt32(values[0]);
            supplier.Name = values[1];
            return supplier;
        }
    }
}