using Microsoft.Data.SqlClient;
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

            //public usermodel getuser(UserModel model)
            //{

            //    DataTable dt = new DataTable();
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        using (SqlCommand cmd = new SqlCommand("[sscpost].[loginuser]", con))
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@username", model.username);
            //            cmd.Parameters.AddWithValue("@password", model.password);
            //            con.Open();
            //            int log = cmd.ExecuteNonQuery();
                       
            //            con.Close();
            //        }
            //    }
            //}
        }
    }
}
