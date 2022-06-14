using CodingSkills.Models;
using CodingSkills.Repositories;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CodingSkills
{
    public partial class _Default : Page
    {
        private IDataRepository _dataRepo;
        private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ExcelDataRepository));
        public _Default(IDataRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateResult_Click(Object sender, EventArgs e)
        {
            var result = _dataRepo.GetMergedProducts();
            if (result != null && result.Any())
            {
                generateResultCsv(result);
            }
            else
            {
                Log.Warn("No result returned");
            }
        }

        private void generateResultCsv(List<MergedProduct> products)
        {
            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, new CultureInfo("en-US", false)))
            {
                //csvWriter.Configuration.Delimiter = ";";

                csvWriter.WriteField("SKU");
                csvWriter.WriteField("Description");
                csvWriter.WriteField("Source");
                csvWriter.NextRecord();

                foreach (var product in products)
                {
                    csvWriter.WriteField(product.SKU);
                    csvWriter.WriteField(product.Description);
                    csvWriter.WriteField(product.Source);
                    csvWriter.NextRecord();
                }

                writer.Flush();

                Response.Clear();
                Response.ContentType = "text/csv"; 
                Response.AddHeader("content-disposition", "attachment;    filename=result_output.csv");
                Response.BinaryWrite(mem.ToArray());
                Response.End();
            }
        }

    }
}