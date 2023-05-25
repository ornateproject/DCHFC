using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace ssc.repository
{


    public class DB_Repo
    {

        private string connectionString;

        public DB_Repo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }

        public string getselectedcandidatelist(string post_id)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[DB]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 1);
                    cmd.Parameters.AddWithValue("@post_id", post_id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    con.Close();

                }
            }
            return JsonConvert.SerializeObject(dt);

        }
        public string get_postdata(string depart)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[Getpost_data]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Department", depart);
                    cmd.Parameters.AddWithValue("@callval", 2);
                    // cmd.Parameters.AddWithValue("@Reg_no", reg_no);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();

                }
            }
            return JsonConvert.SerializeObject(dt);

        }
        public string getselecteddata(string Reg_no)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[DB]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 2);
                  //  cmd.Parameters.AddWithValue("@Reg_no", post_id);
                    cmd.Parameters.AddWithValue("@Reg_no", Reg_no);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    con.Close();

                }
            }
            var asfd = dt.Rows[0];
            return JsonConvert.SerializeObject(dt);

        }
    }
}
