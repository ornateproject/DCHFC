using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
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
        public static List<SelectListItem> ministry_Dept(IFormFile myfile)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sscpost].[ministry_Dept]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ministry_name", myfile.ministry_name);

                }

            }
                return items;
        }
    }

}

