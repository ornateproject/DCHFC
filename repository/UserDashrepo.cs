﻿using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class UserDashrepo
    {

        private string connectionString;

        public UserDashrepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string get_listdata()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[getdeptreg]", con))
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
