using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
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
        public string get_deparment()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[getuser_status]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                }
            }
            return JsonConvert.SerializeObject(dt);

        }

       //public string candidatedata(UserDepartment department)
       // {
       //     // Retrieve the JSON data from the database
       //     var jsonDataList = new List<UserDepartment>();
       //     using (var connection = new SqlConnection("connectionString"))
       //     {
               
       //         using (SqlCommand cmd = new SqlCommand("[sscpost].[getuser_status]", connection))
       //         {
       //             connection.Open();
       //             SqlDataReader reader = cmd.ExecuteReader();

       //             // Step 6: Create Excel workbook and worksheet
       //             var excelApp = new Microsoft.Office.Interop.Excel.Application();
       //             excelApp.Visible = false;
       //             var workbook = excelApp.Workbooks.Add();
       //             var worksheet = workbook.Worksheets.Add();

       //             // Step 7: Write data to worksheet
       //             int row = 1;
       //             for (int i = 0; i < reader.FieldCount; i++)
       //             {
       //                 worksheet.Cells[row, i + 1] = reader.GetName(i);
       //             }

       //             row++;

       //             while (reader.Read())
       //             {
       //                 for (int i = 0; i < reader.FieldCount; i++)
       //                 {
       //                     worksheet.Cells[row, i + 1] = reader[i];
       //                 }

       //                 row++;
       //             }

       //             // Step 8: Save workbook to file
       //             workbook.SaveAs("vacancy_post.xlsx");
       //             workbook.Close();
       //             excelApp.Quit();
       //         }

       //         return "ok";

       //     }
       // }
        
    }
}
