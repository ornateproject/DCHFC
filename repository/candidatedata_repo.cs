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
        public string get_postdata(string depart)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[Getpost_data]", con))
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
        public string get_uspostdata()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[Getpost_data]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 1);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();

                }
            }
            return JsonConvert.SerializeObject(dt);

        }
        public string get_postcanddata(string reg_no)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[Getpost_data]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@Department", depart);
                    cmd.Parameters.AddWithValue("@Reg_no", reg_no);
                    cmd.Parameters.AddWithValue("@callval", 3);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();

                }
            }
            return JsonConvert.SerializeObject(dt);

        }
        public string getcandidatelist( string post_id)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[candidate_data]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 2);
                    cmd.Parameters.AddWithValue("@post_id", post_id);
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

        public string InsertpostData(managecandidatedata data, string reg_no)
        {
            DataTable dt = new DataTable();
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("[sscpost].[candidate_document]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (getpost posts in data.getposts)
                    {
                        if (posts.Upload_doc != null)
                        {
                            var doc_fileName = Path.GetFileName(posts.Upload_doc?.FileName);

                            var doc_filenamewithoutextension = Path.GetFileNameWithoutExtension(doc_fileName);

                            var doc_extension = Path.GetExtension(doc_fileName);
                            string varDatetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                            var newfilenamewithoutextensiondoc = varDatetime + doc_filenamewithoutextension;

                            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                            var doc_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/document", newfilenamewithoutextensiondoc + doc_extension);
                            FileInfo doc_file = new FileInfo(Path.Combine(doc_path));
                            var doc_stream = new FileStream(doc_path, FileMode.Create);
                            posts.Upload_doc.CopyTo(doc_stream);
                            doc_stream.Close();
                            cmd.Parameters.AddWithValue("@Doc_path", newfilenamewithoutextensiondoc + doc_extension);


                            cmd.Parameters.AddWithValue("@post_id", posts.post_id);

                            //........................file upload end................................cmd.Parameters.AddWithValue("@Upload_doc", newfilenamewithoutextension + extension);

                            cmd.Parameters.AddWithValue("@post_name", posts.post_name);
                            cmd.Parameters.AddWithValue("@Reg_no", reg_no);

                        }


                    }
                    //........................marksheet upload started................................cmd.Parameters.AddWithValue("@Upload_doc", newfilenamewithoutextension + extension);

                    var fileName = Path.GetFileName(data.candetails.adhar_card?.FileName);

                    var filenamewithoutextension = Path.GetFileNameWithoutExtension(fileName);

                    var extension = Path.GetExtension(fileName);
                    string vardatetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                    var newfilenamewithoutextension = vardatetime + filenamewithoutextension;

                    //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/adharcard", newfilenamewithoutextension + extension);
                    FileInfo file = new FileInfo(Path.Combine(path));
                    var stream = new FileStream(path, FileMode.Create);
                    data.candetails.adhar_card.CopyTo(stream);
                    stream.Close();
                    //........................file upload end................................cmd.Parameters.AddWithValue("@Upload_doc", newfilenamewithoutextension + extension);

                    cmd.Parameters.AddWithValue("@adhar_card", newfilenamewithoutextension + extension);

                    //........................ upload adharcard started................................cmd.Parameters.AddWithValue("@Upload_doc", newfilenamewithoutextension + extension);

                    var markfile = Path.GetFileName(data.candetails.marksheet?.FileName);

                    var marksheetfilename = Path.GetFileNameWithoutExtension(markfile);

                    var filenameextension = Path.GetExtension(markfile);
                    string datetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                    var newmarksheetfilename = markfile + filenameextension;

                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/marksheet", newmarksheetfilename + filenameextension);
                    FileInfo File = new FileInfo(Path.Combine(filepath));
                    var Stream = new FileStream(path, FileMode.Create);
                    data.candetails.marksheet.CopyTo(Stream);
                    stream.Close();
                    //........................file upload end................................cmd.Parameters.AddWithValue("@Upload_doc", newfilenamewithoutextension + extension);

                    cmd.Parameters.AddWithValue("@marksheet", newmarksheetfilename + filenameextension);
                    int xdvf = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "ok";
            }                 
            

        }
    }
}
