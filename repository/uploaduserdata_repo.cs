using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.Word;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using System.Data;

namespace ssc.repository
{
    public class uploaduserdata_repo
    {
        private string connectionString;

        public uploaduserdata_repo(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

        }

        public string InsertpostData(uploadcandidate model)
        {
            var fileName = Path.GetFileName(model.Upload_doc.FileName);

            var filenamewithoutextension = Path.GetFileNameWithoutExtension(model.Upload_doc.FileName);

            var extension = Path.GetExtension(model.Upload_doc.FileName);
            string vardatetime = DateTime.Now.ToString("ddMMyyyyHHmmssffff");
            int rowcount = 1;




            var newfilenamewithoutextension =   vardatetime+ filenamewithoutextension;

            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/candidate_exel", newfilenamewithoutextension + extension);
            FileInfo file = new FileInfo(Path.Combine(path));
            var stream = new FileStream(path, FileMode.Create);
            model.Upload_doc.CopyTo(stream);
            stream.Close();



            DataTable table = new DataTable();
            using (ExcelPackage epPackage = new ExcelPackage(file))
            {



                var worksheet = epPackage.Workbook.Worksheets[1];
                epPackage.SaveAs(file);


                int maxRows = worksheet.Dimension.Rows;
                int maxColumns = worksheet.Dimension.End.Column;

                ExcelCellAddress startCell = worksheet.Dimension.Start;
                ExcelCellAddress endCell = worksheet.Dimension.End;







                //SaveData(ExcelList);
                //return table;
                DataTable dt = new DataTable();
                // DataTable errortable = new DataTable();
                // ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

                //check if the worksheet is completely empty
                if (worksheet.Dimension == null)
                {
                    // return dt;
                }

                //create a list to hold the column names
                List<string> columnNames = new List<string>();

                //needed to keep track of empty column headers
                int currentColumn = 1;
                //loop all columns in the sheet and add them to the datatable
                foreach (var cell in worksheet.Cells[1,1,1, worksheet.Dimension.End.Column])
                {
                    string columnName = cell.Text.Trim();

                    //check if the previous header was empty and add it if it was
                    if (cell.Start.Column != currentColumn)
                    {
                        columnNames.Add("Header_" + currentColumn);
                        dt.Columns.Add("Header_" + currentColumn);
                        //errortable.Columns.Add("Header_" + currentColumn);
                        currentColumn++;
                    }

                    //add the column name to the list to count the duplicates
                    columnNames.Add(columnName);


                    //count the duplicate column names and make them unique to avoid the exception
                    //A column named 'Name' already belongs to this DataTable
                    int occurrences = columnNames.Count(x => x.Equals(columnName));
                    if (occurrences > 1)
                    {
                        columnName = columnName + "_" + occurrences;
                    }

                    //add the column to the datatable
                    dt.Columns.Add(columnName);
                    // errortable.Columns.Add(columnName);
                    //dt.Columns.Add("Invoice");
                    currentColumn++;
                }



                //start adding the contents of the excel file to the datatable
                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                    DataRow newRow = dt.NewRow();

                    //DataRow errorrow = errortable.NewRow();
                    //loop all cells in the row
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;

                        //errorrow[cell.Start.Column - 1] = cell.Text;
                    }

                    dt.Rows.Add(newRow);

                    //errortable.Rows.Add(errorrow);
                }
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("[sscpost].[candidate_data]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Reg_no",Convert.ToString(dt.Rows[j]["Reg_no"]));
                            cmd.Parameters.AddWithValue("@Name", Convert.ToString(dt.Rows[j]["Name"]));
                            cmd.Parameters.AddWithValue("@DOB", Convert.ToString(dt.Rows[j]["DOB"]));
                            cmd.Parameters.AddWithValue("@Email", Convert.ToString(dt.Rows[j]["Email"]));
                            cmd.Parameters.AddWithValue("@Mobile_no", Convert.ToString(dt.Rows[j]["Mobile_no"]));
                            cmd.Parameters.AddWithValue("@Address", Convert.ToString(dt.Rows[j]["Address"]));
                            cmd.Parameters.AddWithValue("@phases", model.phases);
                            //cmd.Parameters.AddWithValue("@post",model.post);
                            cmd.Parameters.AddWithValue("@callval", 1); 
                            con.Open();
                            int xdvf = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                return "ok";


            }
                
            
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
    }
}
    

       
