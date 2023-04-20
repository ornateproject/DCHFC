using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace ssc.repository
{
    public class us3MTSrepo
    {
        private string connectionString;

        public us3MTSrepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_MTSdetails()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[Get_MTSdata]", con))
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

       
    }
}

