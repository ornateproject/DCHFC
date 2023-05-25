using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using ssc.Models;
using System.Data;
using System.Data.SqlClient;

namespace ssc.repository
{


    public class DB_Repo
    {

        private string connectionString;

        public DB_Repo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }

        public string getselectedcandidatelist(string post_id)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[DB]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 1);
                    cmd.Parameters.AddWithValue("@post_id", post_id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    con.Close();

                }
            }
            return JsonConvert.SerializeObject(dt);

        }
        public string get_postdata(string depart)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[Getpost_data]", con))
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
        public string getselecteddata(string Reg_no)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[DB]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 2);
                  //  cmd.Parameters.AddWithValue("@Reg_no", post_id);
                    cmd.Parameters.AddWithValue("@Reg_no", Reg_no);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    con.Close();

                }
            }
            var asfd = dt.Rows[0];
            return JsonConvert.SerializeObject(dt);

        }
        public string getcandidate_data(string Reg_no)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[DB]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 4);
                    //  cmd.Parameters.AddWithValue("@Reg_no", post_id);
                    cmd.Parameters.AddWithValue("@Roll_no", Reg_no);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    con.Close();

                }
            }
            var asfd = dt.Rows[0];
            return JsonConvert.SerializeObject(dt);

        }
        public string InsertpostData(DBModel model)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[DB]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@callval", 3);
                    cmd.Parameters.AddWithValue("@Roll_no", model.Reg_no);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Candidate_remark", model.Candidate_remark);
                    cmd.Parameters.AddWithValue("@Father_name", model.Father_name);
                    cmd.Parameters.AddWithValue("@father_remark", model.father_remark);
                    cmd.Parameters.AddWithValue("@Mother_name", model.Mother_name);
                    cmd.Parameters.AddWithValue("@Mother_remark", model.Mother_remark);
                    cmd.Parameters.AddWithValue("@Matric_rollno", model.Matric_rollno);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@Category_cat1", model.Category_cat1);
                    cmd.Parameters.AddWithValue("@Reason_changecategory", model.Reason_changecategory);
                    cmd.Parameters.AddWithValue("@ESM_cat2", model.ESM_cat2);
                    cmd.Parameters.AddWithValue("@AF_joining", model.AF_joining);
                    cmd.Parameters.AddWithValue("@Date_discharge", model.Date_discharge);
                    cmd.Parameters.AddWithValue("@Lenght_service", model.Lenght_service);
                    cmd.Parameters.AddWithValue("@Gov_civilside", model.Gov_civilside);
                    cmd.Parameters.AddWithValue("@Civilpost_joining", model.Civilpost_joining);
                    cmd.Parameters.AddWithValue("@Formsubmission_date", model.Formsubmission_date);
                    cmd.Parameters.AddWithValue("@Self_declaration", model.Self_declaration);
                    cmd.Parameters.AddWithValue("@Reservedpost_ESM", model.Reservedpost_ESM);
                    cmd.Parameters.AddWithValue("@Persondisability_PWD", model.Persondisability_PWD);
                    cmd.Parameters.AddWithValue("@Region_Code", model.Region_Code);
                    cmd.Parameters.AddWithValue("@Typewriting_test", model.Typewriting_test);
                    cmd.Parameters.AddWithValue("@DVschedule_date", model.DVschedule_date);
                    cmd.Parameters.AddWithValue("@DVactual_date", model.DVactual_date);
                    cmd.Parameters.AddWithValue("@highest_qualification", model.highest_qualification);
                    cmd.Parameters.AddWithValue("@Qualifying_education", model.Qualifying_education);
                    cmd.Parameters.AddWithValue("@University", model.University);
                    cmd.Parameters.AddWithValue("@Nameof_board", model.Nameof_board);
                    cmd.Parameters.AddWithValue("@Subjects", model.Subjects);
                    cmd.Parameters.AddWithValue("@Rollno_highestqualification", model.Rollno_highestqualification);
                    cmd.Parameters.AddWithValue("@Passing_Year", model.Passing_Year);
                    cmd.Parameters.AddWithValue("@Percentage", model.Percentage);
                    cmd.Parameters.AddWithValue("@CGPA", model.CGPA);
                    cmd.Parameters.AddWithValue("@Eligiblepost_code", model.Eligiblepost_code);
                    cmd.Parameters.AddWithValue("@Order_prefrence", model.Order_prefrence);
                    cmd.Parameters.AddWithValue("@Post_prefrence", model.Post_prefrence);
                    cmd.Parameters.AddWithValue("@AGE", model.AGE);
                    cmd.Parameters.AddWithValue("@Relaxation_age", model.Relaxation_age);
                    cmd.Parameters.AddWithValue("@Distance_education", model.Distance_education);
                    cmd.Parameters.AddWithValue("@Document_DOB", model.Document_DOB);
                    cmd.Parameters.AddWithValue("@Essential_qualification", model.Essential_qualification);
                    cmd.Parameters.AddWithValue("@Document_caste", model.Document_caste);
                    cmd.Parameters.AddWithValue("@OBC_certificate", model.OBC_certificate);
                    cmd.Parameters.AddWithValue("@ESMdischarge_certificate", model.ESMdischarge_certificate);
                    cmd.Parameters.AddWithValue("@PWD_status", model.PWD_status);
                    cmd.Parameters.AddWithValue("@NOCproduced_Central", model.NOCproduced_Central);
                    cmd.Parameters.AddWithValue("@Civilianemployee_status", model.Civilianemployee_status);
                    cmd.Parameters.AddWithValue("@Candidature_status", model.Candidature_status);
                    cmd.Parameters.AddWithValue("@Reject_reason", model.Reject_reason);
                    cmd.Parameters.AddWithValue("@Remarks", model.Remarks);
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
