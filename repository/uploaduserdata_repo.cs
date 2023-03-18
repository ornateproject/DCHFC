using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.Word;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class uploaduserdata_repo
    {
        private string connectionString;

        public uploaduserdata_repo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string InsertpostData(uploadcandidate model)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("[sscpost].[candidate_data]", con);
                        var fileName = Path.GetFileName(model.Upload_doc?.FileName);
                           var filePath = Path.GetExtension(fileName);
                     byte[] fileBytes = File.ReadAllBytes(filePath);
                     //   string fileContents = File.ReadAllText(filePath);
                        using (MemoryStream fileStream = new MemoryStream(fileBytes))
                        {
                            using (var package = new ExcelPackage(fileStream))
                            {
                                var worksheet = package.Workbook.Worksheets[0];
                                var rowCount = worksheet.Dimension.Rows;

                                for (int row = 1; row <= rowCount; row++)
                                {
                                    var reg = worksheet.Cells[row, 1].Value.ToString();
                                    var name = worksheet.Cells[row, 2].Value.ToString();
                                    var dob = worksheet.Cells[row, 3].Value.ToString();
                                    var email = worksheet.Cells[row, 4].Value.ToString();
                                    var mobile = worksheet.Cells[row, 5].Value.ToString();                                  
                                    var address = worksheet.Cells[row, 5].Value.ToString();
                                    
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@reg_no", reg);
                                    cmd.Parameters.AddWithValue("@Name", name);
                                    cmd.Parameters.AddWithValue("@DOb", dob);
                                    cmd.Parameters.AddWithValue("@Email", email);
                                    cmd.Parameters.AddWithValue("@Mobile_no", mobile);
                                    cmd.Parameters.AddWithValue("@Address", address);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();

                        return ("Index");

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                    }
                    return "ok";
                }
            }
        }
    }
}
    

       
