using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class Deptregrepo
    {
        private string connectionString;
        
        public Deptregrepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        //public List<DeptRegistration> GetRegistration()
        //{
        //    List<DeptRegistration> Registrationlist = new List<DeptRegistration>();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("[sscpost].[Reg_record]", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@post_name", department.post_name);
        //                cmd.Parameters.AddWithValue("@pay_matrix", department.pay_matrix);
        //            }
        //            return Registrationlist;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
       
        public string InsertpostData(DeptRegistration department)
        {
            var cRepo = new Ministryrepo();
            //var ministry = new DeptRegistration()
            //{

            //    ministry_name = cRepo.Getrecord()
            //};
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[allvacancy_post]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ministry", department.Ministry);
                    cmd.Parameters.AddWithValue("@Department", department.Department);
                    cmd.Parameters.AddWithValue("@Name", department.Name);
                    cmd.Parameters.AddWithValue("@Mobile_no", department.Mobile_no);
                    cmd.Parameters.AddWithValue("@Email", department.Email);
                    cmd.Parameters.AddWithValue("@Upload_doc", department.Upload_doc);
                    con.Open();
                    int xdvf = cmd.ExecuteNonQuery();
                    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //sda.Fill(dt);
                    con.Close();
                }
            }
            return "1";
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

