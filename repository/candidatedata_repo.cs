using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace ssc.repository
{
    public class candidatedata_repo
    {
          private string connectionString;

            public candidatedata_repo(IConfiguration configuration)
            {
                connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

            }
            public string get_postdata()
            {

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[sscpost].[Getpost_data]", con))
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
