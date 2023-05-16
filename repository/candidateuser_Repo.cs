using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class candidateuser_Repo
    {
        private string connectionString;

        public candidateuser_Repo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_deparment(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[getcandudateuser]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                }
            }
            return JsonConvert.SerializeObject(dt);

        }

        public List<string> savepdf(managecandidatedata data)
        {
            //-----------------------------------------------

            List<string> uploadedfiles = new List<string>();
            //================================file1===============================
            if (data.upload_doc.pdfFile1 != null)
            {
            
                 var fileName1 = Path.GetFileName(data.upload_doc.pdfFile1?.FileName);
                var doc_name1 = Path.GetFileName(data.upload_doc.doc_name1);
                var filenamewithoutextension1 = Path.GetFileNameWithoutExtension(fileName1);
               
                 var extension1 = Path.GetExtension(fileName1 + doc_name1);
                 string vardatetime1 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");
               
                 var newfilenamewithoutextension1 = vardatetime1 + filenamewithoutextension1;
               
                 //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                 var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension1 + extension1);
                 FileInfo file1 = new FileInfo(Path.Combine(path1));
                 var stream1 = new FileStream(path1, FileMode.Create);
                     data.upload_doc.pdfFile1.CopyTo(stream1);
                 uploadedfiles.Add(path1);
                 stream1.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file2===============================
            if (data.upload_doc.pdfFile2 != null)
            {
                var fileName2 = Path.GetFileName(data.upload_doc.pdfFile2?.FileName);
                var doc_name2 = Path.GetFileName(data.upload_doc.doc_name2);

                var filenamewithoutextension2 = Path.GetFileNameWithoutExtension(fileName2);

                var extension2 = Path.GetExtension(fileName2 + doc_name2);
                string vardatetime2 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension2 = vardatetime2 + filenamewithoutextension2;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension2 + extension2);
                FileInfo file2 = new FileInfo(Path.Combine(path2));
                var stream2 = new FileStream(path2, FileMode.Create);
                data.upload_doc.pdfFile2.CopyTo(stream2);
                uploadedfiles.Add(path2);
                stream2.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file3===============================
            if (data.upload_doc.pdfFile3 != null)
            {
                var fileName3 = Path.GetFileName(data.upload_doc.pdfFile3?.FileName);
                var filenamewithoutextension3 = Path.GetFileNameWithoutExtension(fileName3);

                var extension3 = Path.GetExtension(fileName3);
                string vardatetime3 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension3 = vardatetime3 + filenamewithoutextension3;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension3 + extension3);
                FileInfo file3 = new FileInfo(Path.Combine(path3));
                var stream3 = new FileStream(path3, FileMode.Create);
                data.upload_doc.pdfFile3.CopyTo(stream3);
                uploadedfiles.Add(path3);
                stream3.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file4===============================
            if (data.upload_doc.pdfFile4 != null)
            {
                var fileName4 = Path.GetFileName(data.upload_doc.pdfFile4?.FileName);
                var filenamewithoutextension4 = Path.GetFileNameWithoutExtension(fileName4);

                var extension4 = Path.GetExtension(fileName4);
                string vardatetime4 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension4 = vardatetime4 + filenamewithoutextension4;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path4 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension4 + extension4);
                FileInfo file4 = new FileInfo(Path.Combine(path4));
                var stream4 = new FileStream(path4, FileMode.Create);
                data.upload_doc.pdfFile4.CopyTo(stream4);
                uploadedfiles.Add(path4);
                stream4.Close();
            }
            //-------------------------------------------------------------------------------

            //================================file5===============================
            if (data.upload_doc.pdfFile5 != null)
            {
                var fileName5 = Path.GetFileName(data.upload_doc.pdfFile5?.FileName);
                var filenamewithoutextension5 = Path.GetFileNameWithoutExtension(fileName5);

                var extension5 = Path.GetExtension(fileName5);
                string vardatetime5 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension5 = vardatetime5 + filenamewithoutextension5;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path5 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension5 + extension5);
                FileInfo file5 = new FileInfo(Path.Combine(path5));
                var stream5 = new FileStream(path5, FileMode.Create);
                data.upload_doc.pdfFile5.CopyTo(stream5);
                uploadedfiles.Add(path5);
                stream5.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file6===============================
            if (data.upload_doc.pdfFile6 != null)
            {
                var fileName6 = Path.GetFileName(data.upload_doc.pdfFile6?.FileName);
                var filenamewithoutextension6 = Path.GetFileNameWithoutExtension(fileName6);

                var extension6 = Path.GetExtension(fileName6);
                string vardatetime6 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension6 = vardatetime6 + filenamewithoutextension6;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path6 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension6 + extension6);
                FileInfo file6 = new FileInfo(Path.Combine(path6));
                var stream6 = new FileStream(path6, FileMode.Create);
                data.upload_doc.pdfFile6.CopyTo(stream6);
                uploadedfiles.Add(path6);
                stream6.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file7===============================
            if (data.upload_doc.pdfFile7 != null)
            {
                var fileName7 = Path.GetFileName(data.upload_doc.pdfFile7?.FileName);
                var filenamewithoutextension7 = Path.GetFileNameWithoutExtension(fileName7);

                var extension7 = Path.GetExtension(fileName7);
                string vardatetime7 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension7 = vardatetime7 + filenamewithoutextension7;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path7 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension7 + extension7);
                FileInfo file7 = new FileInfo(Path.Combine(path7));
                var stream7 = new FileStream(path7, FileMode.Create);
                data.upload_doc.pdfFile7.CopyTo(stream7);
                uploadedfiles.Add(path7);
                stream7.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file8===============================
            if (data.upload_doc.pdfFile8 != null)
            {
                var fileName8 = Path.GetFileName(data.upload_doc.pdfFile8?.FileName);
                var filenamewithoutextension8 = Path.GetFileNameWithoutExtension(fileName8);

                var extension8 = Path.GetExtension(fileName8);
                string vardatetime8 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension8 = vardatetime8 + filenamewithoutextension8;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path8 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension8 + extension8);
                FileInfo file8 = new FileInfo(Path.Combine(path8));
                var stream8 = new FileStream(path8, FileMode.Create);
                data.upload_doc.pdfFile8.CopyTo(stream8);
                uploadedfiles.Add(path8);
                stream8.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file9===============================
            if (data.upload_doc.pdfFile9 != null)
            {
                var fileName9 = Path.GetFileName(data.upload_doc.pdfFile9?.FileName);
                var filenamewithoutextension9 = Path.GetFileNameWithoutExtension(fileName9);

                var extension9 = Path.GetExtension(fileName9);
                string vardatetime9 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension9 = vardatetime9 + filenamewithoutextension9;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path9 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension9 + extension9);
                FileInfo file9 = new FileInfo(Path.Combine(path9));
                var stream9 = new FileStream(path9, FileMode.Create);
                data.upload_doc.pdfFile9.CopyTo(stream9);
                uploadedfiles.Add(path9);
                stream9.Close();
            }
            //-------------------------------------------------------------------------------
            //================================file10===============================
            if (data.upload_doc.pdfFile10 != null)
            {
                var fileName10 = Path.GetFileName(data.upload_doc.pdfFile10?.FileName);
                var filenamewithoutextension10 = Path.GetFileNameWithoutExtension(fileName10);

                var extension10 = Path.GetExtension(fileName10);
                string vardatetime10 = DateTime.Now.ToString("ddMMyyyyHHmmssffff");

                var newfilenamewithoutextension10 = vardatetime10 + filenamewithoutextension10;

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                var path10 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/allpdf", newfilenamewithoutextension10 + extension10);
                FileInfo file10 = new FileInfo(Path.Combine(path10));
                var stream10 = new FileStream(path10, FileMode.Create);
                data.upload_doc.pdfFile10.CopyTo(stream10);
                uploadedfiles.Add(path10);
                stream10.Close();
            }
            //-------------------------------------------------------------------------------

            return uploadedfiles;
        }
    }
}
