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
           // string newFileName = "~/uploads";
            
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[Reg_record]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ministry", department.Ministry);
                    cmd.Parameters.AddWithValue("@Department", department.Department);
                    cmd.Parameters.AddWithValue("@Name", department.Name);
                    cmd.Parameters.AddWithValue("@Mobile_no", department.Mobile_no);
                    cmd.Parameters.AddWithValue("@Email", department.Email);
                     cmd.Parameters.AddWithValue("@Upload_doc", department.Upload_doc);
                    //string fileName = department.Upload_doc.FileName;

                    //var fileNames = Path.GetFileName(fileName);

                    //string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", fileNames);



                    //cmd.Parameters.AddWithValue("@Upload_doc", uploadpath);
                    con.Open();
                    int xdvf = cmd.ExecuteNonQuery();                   
                    con.Close();
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

