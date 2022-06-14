using CodingSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSkills.Repositories
{
    public interface IDataRepository
    {
        /// <summary>
        /// Get the merged products from both company A and Company B
        /// </summary>
        /// <returns>A list of products that are combined</returns>
        List<MergedProduct> GetMergedProducts();

    }
}
