using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class LoginRepo
    {
        private string connectionString;
        public LoginRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
            
        }

        public DataTable LoginCheck(UserModel model)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[loginpage]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", model.UserName);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                }
            }
            return dt;
              
        }

        public string selection_post()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[post_selection]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    //con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                    con.Close();
                }
            }
            return JsonConvert.SerializeObject(dt);
        }
        public DataTable userlogin(UserModel model)
        {
           
                DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[logindept]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", model.UserName);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    //cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@loginfor", model.post);
                    if (model.post=="selectionpost")
                    {
                        cmd.Parameters.AddWithValue("@phase", model.phase);

                    }
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                   // int xdvf = cmd.ExecuteNonQuery();
                    sda.Fill(dt);
                    con.Close();
                }
            }
            return dt;

        }

        public string getdatelist(string Reg_no)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[canddata]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@Reg_no",Reg_no);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();

                }
            }
            return JsonConvert.SerializeObject(dt);

        }

        public void UpdatecandidateStatus(int id, string status)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // string query = "UPDATE DeptRegistration SET Status = @Status WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand("[candidate_status]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@status", status == "Approved" ? 1 : 2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable candidatelogin(candidate model)
        {
            
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[candidatelogin]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Reg_no", model.Reg_no);
                    cmd.Parameters.AddWithValue("@DOB", model.DOB);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                }
            }
            return dt;

        }

    }
}
