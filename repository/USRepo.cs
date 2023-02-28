using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;
using System.Text;

namespace ssc.repository
{
    public class USRepo
    {

        private string connectionString;

        public USRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_deparment()
        {               
                       
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[Get_deptregistration]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var FilePath = (string)cmd.ExecuteScalar();
                    var pdfData = System.IO.File.ReadAllBytes(FilePath);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                   // return FilePath(pdfData, "application/pdf", "document.pdf");
                }
            }
            return JsonConvert.SerializeObject(dt);
           
        }
    }
}
