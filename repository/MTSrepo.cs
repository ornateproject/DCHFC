using Microsoft.Data.SqlClient;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class MTSrepo
    {
        private string connectionString;

        public MTSrepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string InsertpostData(MTSselection department)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[all_mtsvacancy]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@post_name", department.post_name);
                    cmd.Parameters.AddWithValue("@pay_matrix", department.pay_matrix);
                    cmd.Parameters.AddWithValue("@age_limit", department.age_limit);
                    cmd.Parameters.AddWithValue("@post_classification", department.post_classification);
                    cmd.Parameters.AddWithValue("@initial_post", department.initial_post);
                    cmd.Parameters.AddWithValue("@AISL", department.AISL);
                    cmd.Parameters.AddWithValue("@vacancy_ariesn", department.vacancy_ariesn);
                    cmd.Parameters.AddWithValue("@identified_post", department.identified_post);
                    cmd.Parameters.AddWithValue("@disability_type", department.disability_type);
                    cmd.Parameters.AddWithValue("@PWD_suitable", department.PWD_suitable);
                    cmd.Parameters.AddWithValue("@permissible_disability", department.permissible_disability);
                    cmd.Parameters.AddWithValue("@UR", department.UR);
                    cmd.Parameters.AddWithValue("@OBC", department.OBC);
                    cmd.Parameters.AddWithValue("@SC", department.SC);
                    cmd.Parameters.AddWithValue("@ST", department.ST);
                    cmd.Parameters.AddWithValue("@EWS", department.EWS);
                    cmd.Parameters.AddWithValue("@TOTAL", department.TOTAL);
                    cmd.Parameters.AddWithValue("@VH", department.VH);
                    cmd.Parameters.AddWithValue("@HH", department.HH);
                    cmd.Parameters.AddWithValue("@OH", department.OH);
                    cmd.Parameters.AddWithValue("@OTHERS", department.OTHERS);
                    cmd.Parameters.AddWithValue("@Total_vacancy", department.Total_vacancy);
                    cmd.Parameters.AddWithValue("@ESM_number", department.ESM_number);
                    cmd.Parameters.AddWithValue("@probation_period", department.probation_period);
                    cmd.Parameters.AddWithValue("@Essential", department.Essential);
                    cmd.Parameters.AddWithValue("@desirable", department.desirable);
                    cmd.Parameters.AddWithValue("@relaxation", department.relaxation);
                    cmd.Parameters.AddWithValue("@Age_requirment", department.Age_requirment);
                    cmd.Parameters.AddWithValue("@other_requirment", department.other_requirment);
                    cmd.Parameters.AddWithValue("@subsequent_oders", department.subsequent_oders);
                    cmd.Parameters.AddWithValue("@CCS_rules", department.CCS_rules);
                    cmd.Parameters.AddWithValue("@reserved_vacancies", department.reserved_vacancies);
                    cmd.Parameters.AddWithValue("@DOPT_refrence", department.DOPT_refrence);
                    cmd.Parameters.AddWithValue("@Persons_disabilities", department.Persons_disabilities);
                    cmd.Parameters.AddWithValue("@Previous_requisition", department.Previous_requisition);
                    cmd.Parameters.AddWithValue("@candidates_nominated", department.candidates_nominated);
                   
                    con.Open();
                    int xdvf = cmd.ExecuteNonQuery();
                    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //sda.Fill(dt);
                    con.Close();

                }

                return "1";
            }
        }
    }
}
