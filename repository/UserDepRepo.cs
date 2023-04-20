
using Microsoft.Data.SqlClient;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class UserDepRepo
    {
        private string connectionString;

        public UserDepRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }
        public string InsertpostData(UserDepartment department)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[allvacancy_post]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@post_name", department.post_name);
                    cmd.Parameters.AddWithValue("@pay_matrix", department.pay_matrix);
                    cmd.Parameters.AddWithValue("@post_class", department.post_class);
                    cmd.Parameters.AddWithValue("@post_nature", department.post_nature);
                    cmd.Parameters.AddWithValue("@initial_place", department.initial_place);
                    cmd.Parameters.AddWithValue("@aisl", department.aisl);
                    cmd.Parameters.AddWithValue("@vacancy_ariesn", department.vacancy_ariesn);
                    cmd.Parameters.AddWithValue("@UR", department.UR);
                    cmd.Parameters.AddWithValue("@OBC", department.OBC);
                    cmd.Parameters.AddWithValue("@SC", department.SC);
                    cmd.Parameters.AddWithValue("@ST", department.ST);
                    cmd.Parameters.AddWithValue("@EWS", department.EWS);
                    cmd.Parameters.AddWithValue("@TOTAL", department.TOTAL);
                    cmd.Parameters.AddWithValue("@identified_post", department.identified_post);
                    cmd.Parameters.AddWithValue("@disability_type", department.disability_type);
                    cmd.Parameters.AddWithValue("@suitable_pwd", department.suitable_pwd);
                    cmd.Parameters.AddWithValue("@permissible", department.permissible);
                    cmd.Parameters.AddWithValue("@VH", department.VH);
                    cmd.Parameters.AddWithValue("@HH", department.HH);
                    cmd.Parameters.AddWithValue("@OH", department.OH);
                    cmd.Parameters.AddWithValue("@OTHERS", department.OTHERS);
                    cmd.Parameters.AddWithValue("@Total_vacancy", department.Total_vacancy);
                    cmd.Parameters.AddWithValue("@reserved_vacancy", department.reserved_vacancy);
                    cmd.Parameters.AddWithValue("@pwd_number", department.pwd_number);
                    cmd.Parameters.AddWithValue("@pwdvertical_category", department.pwdvertical_category);
                    cmd.Parameters.AddWithValue("@totalesm_number", department.totalesm_number);
                    cmd.Parameters.AddWithValue("@esm_number", department.esm_number);
                    cmd.Parameters.AddWithValue("@esmvertical_category", department.esmvertical_category);
                    cmd.Parameters.AddWithValue("@probation1", department.probation1);
                    cmd.Parameters.AddWithValue("@Essential", department.Essential);
                    cmd.Parameters.AddWithValue("@Desirable", department.Desirable);
                    cmd.Parameters.AddWithValue("@Relaxation", department.Relaxation);
                    cmd.Parameters.AddWithValue("@Regional_office", department.Regional_office);
                    cmd.Parameters.AddWithValue("@Age_limit", department.Age_limit);
                    cmd.Parameters.AddWithValue("@Requirment", department.Requirment);
                    cmd.Parameters.AddWithValue("@Name", department.Name);
                    cmd.Parameters.AddWithValue("@Desigantion", department.Desigantion);
                    cmd.Parameters.AddWithValue("@Address", department.Address);
                    cmd.Parameters.AddWithValue("@Mobile_no", department.Mobile_no);
                    cmd.Parameters.AddWithValue("@Email", department.Email);
                    cmd.Parameters.AddWithValue("@subsequent_orders", department.subsequent_orders);
                    cmd.Parameters.AddWithValue("@DOPT_letter", department.DOPT_letter);
                    cmd.Parameters.AddWithValue("@no_ofvacancy", department.no_ofvacancy);
                    cmd.Parameters.AddWithValue("@pwd_esm", department.pwd_esm);
                    cmd.Parameters.AddWithValue("@person_disabilities", department.person_disabilities);
                    cmd.Parameters.AddWithValue("@letter_no", department.letter_no);
                    cmd.Parameters.AddWithValue("@office_department", department.office_department);
                    cmd.Parameters.AddWithValue("@dep", department.ID);


                    con.Open();
                    int xdvf=cmd.ExecuteNonQuery();
                    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //sda.Fill(dt);
                    con.Close();

                }

                return "1";
            }
        }
    }
}
