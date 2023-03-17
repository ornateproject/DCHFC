using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;
using System.Web;

namespace ssc.repository
{
    public class Deptregrepo
    {
        private string connectionString;


        public Deptregrepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }


        public string InsertpostData(DeptRegistration department)
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[sscpost].[Reg_record]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ministry", department.Ministry);
                        cmd.Parameters.AddWithValue("@Department", department.Department);
                        cmd.Parameters.AddWithValue("@Name", department.Name);
                        cmd.Parameters.AddWithValue("@Mobile_no", department.Mobile_no);

                        cmd.Parameters.AddWithValue("@Email", department.Email + "@"+department.Emailtype);
                        cmd.Parameters.AddWithValue("@phases",  department.phases);
                        cmd.Parameters.AddWithValue("@Year", department.Year);
                        cmd.Parameters.AddWithValue("@post", department.post);
                        // cmd.Parameters.AddWithValue("@Upload_doc", department.Upload_doc);
                        //string fileName = department.Upload_doc.FileName;
                        //var fileNames = Path.GetFileName(fileName);
                        //string uploadpath = Path.Combine("wwwroot/pdf", fileNames);
                        // con.Open();

                        //var stream = new FileStream(uploadpath, FileMode.Create);

                        //department.Upload_doc.CopyToAsync(stream);
                        //stream.Close();

                        //......................file upload start...........................


                        var fileName = Path.GetFileName(department.Upload_doc?.FileName);

                        var filenamewithoutextension = Path.GetFileNameWithoutExtension(fileName);

                        var extension = Path.GetExtension(fileName);
                        string vardatetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");
                       


                        var newfilenamewithoutextension = vardatetime + filenamewithoutextension;

                        //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf", newfilenamewithoutextension + extension);
                        FileInfo file = new FileInfo(Path.Combine(path));
                        var stream = new FileStream(path, FileMode.Create);
                        department.Upload_doc.CopyTo(stream);
                        stream.Close();

                        //........................file upload end................................

                        cmd.Parameters.AddWithValue("@Upload_doc", newfilenamewithoutextension + extension);

                        con.Open();
                        int xdvf = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return "ok";

            }

            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627) //catch duplicate key error
                {
                    // ModelState.AddModelError("Email", "Email address already exists");
                }
                else
                {
                    throw;
                }
            }


            return "ok";

        }


        public string get_ministry()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[ministry_Dept]", con))
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

        public string selection_post()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[post_selection]", con))
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
        public DataTable get_deparment(int ministryt_id)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("get_Dept", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ministry", ministryt_id);
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