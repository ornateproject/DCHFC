using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class UserDashrepo
    {

        private string connectionString;

        public UserDashrepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_listdata(DeptRegistration deptRegistration)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[userdeptdash]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@status");
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
