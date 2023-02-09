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

        public string LoginCheck(UserModel model)
        {
            DataTable dt = new DataTable();
           

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[loginpage]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", model.UserName);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    SqlParameter loging = new SqlParameter();
                    loging.ParameterName = "@Isvalid";
                    loging.SqlDbType = SqlDbType.Bit;
                    loging.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(loging);

                    int res = Convert.ToInt32(loging.Value);
                    //return res;
                    con.Open();
                    int xdvf = cmd.ExecuteNonQuery();
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        return ("success");
                    }
                    else
                    {
                        return ("no record found");
                    }
                }

            }
            return "ok";
              
        }

    }
}
