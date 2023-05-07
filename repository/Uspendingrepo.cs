using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class Uspendingrepo
    {

        private string connectionString;

        public Uspendingrepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_approval(int user_id)
        {
             DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[getuserdata]", con))
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

        public void UpdateStatusData(int id, string status, string Remark)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // string query = "UPDATE DeptRegistration SET Status = @Status WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand("[approvdept]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Remark", Remark);
                    cmd.Parameters.AddWithValue("@Status", status == "Approved" ? 1 : 2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }


}
