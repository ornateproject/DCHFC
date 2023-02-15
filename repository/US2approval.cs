using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace ssc.repository
{
    public class US2approval
    {

        private string connectionString;

        public US2approval(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_approval(int user_id)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[getus2user]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                }
            }
            var asfd = dt.Rows[0];
            //var zsdf= JsonConvert.SerializeObject(dt.Rows);
            //var szad= JsonConvert.SerializeObject(Convert.ToString(dt.Rows[0]));
            return JsonConvert.SerializeObject(dt);
        }
    }
}

