using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class USRepo
    {

        private string connectionString;

        public USRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_deparment()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[Get_deptregistration]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                }
            }
            return JsonConvert.SerializeObject(dt);
            //DataTable dt = new DataTable();
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("Get_deptregistration", con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Ministry", deptRegistration.Ministry);
            //        cmd.Parameters.AddWithValue("@Department", deptRegistration.Department);
            //        cmd.Parameters.AddWithValue("@Name", deptRegistration.Name);
            //        cmd.Parameters.AddWithValue("@Mobile_no", deptRegistration.Mobile_no);
            //        cmd.Parameters.AddWithValue("@Email", deptRegistration.Email);
            //        cmd.Parameters.AddWithValue("@Upload_doc", deptRegistration.Upload_doc);

            //        con.Open();
            //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //        sda.Fill(dt);
            //        con.Close();
            //    }
            //}
            //return dt;
        }
    }
}
