using Newtonsoft.Json;
using ssc.Models;
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

        public string getcandidatelist()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[candidate_data]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 2);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    
                    con.Close();

                }
            }
            return JsonConvert.SerializeObject(dt);

        }
        public string get_data()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[getcandidatedata]", con))
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

        public string InsertpostData(getpost data)
        {
            DataTable dt = new DataTable();
           
           using (SqlConnection con = new SqlConnection(connectionString))
           {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[candidate_document]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //var fileName = Path.GetFileName(data.Upload_doc?.FileName);

                    //var filenamewithoutextension = Path.GetFileNameWithoutExtension(fileName);

                    //var extension = Path.GetExtension(fileName);
                    //string vardatetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");



                    //var newfilenamewithoutextension = vardatetime + filenamewithoutextension;

                    ////var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                    //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/document", newfilenamewithoutextension + extension);
                    //FileInfo file = new FileInfo(Path.Combine(path));
                    //var stream = new FileStream(path, FileMode.Create);
                    //data.Upload_doc.CopyTo(stream);
                    //stream.Close();

                    //........................file upload end................................

                   // cmd.Parameters.AddWithValue("@Upload_doc", newfilenamewithoutextension + extension);

                    con.Open();
                    int xdvf = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "ok";
           }
                
            

        }
    }
}
