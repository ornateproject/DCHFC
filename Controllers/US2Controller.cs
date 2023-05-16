using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;


namespace ssc.Controllers
{
    public class US2Controller : Controller
    {
        private readonly US2repo _us2repo;
        public US2Controller(IConfiguration configuration)
        {
            _us2repo = new US2repo(configuration);

        }
        [HttpGet]
        public IActionResult us2()
        {
            {

                var user = HttpContext.Session.GetString("userType").ToString();
                if (@user == "2")
                {
                    var usdata = _us2repo.get_deparment();
                    List<UserDepartment> depart = new List<UserDepartment>();
                    depart = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata);

                    return View(depart);
                }
                else if (@user == "3")
                {
                    var department = HttpContext.Session.GetString("department").ToString();
                    var postdata = _us2repo.getpost_data(department);
                    List<UserDepartment> dept = new List<UserDepartment>();
                    dept = JsonConvert.DeserializeObject<List<UserDepartment>>(postdata);
                    return View(dept);
                }

                return View();

            }
        }

        [HttpGet]
        public IActionResult downloadexcel()
        {
            var usdata = _us2repo.get_execldata();

            List<UserDepartment> dept = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata);
            // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                //var p = new ExcelPackage();
                var sheetName = "Sheet1";
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add(sheetName);
                //var worksheet = excelPackage.CreateWorksheet("Sheet1");
 
                ws.Cells[1, 1].Value = "postcode_reg";
                ws.Cells[1, 2].Value = "post_name";
                ws.Cells[1, 3].Value = "SC";
                ws.Cells[1, 4].Value = "ST";
                ws.Cells[1, 5].Value = "OBC";
                ws.Cells[1, 6].Value = "UR";
                ws.Cells[1, 7].Value = "EWS";
                ws.Cells[1, 8].Value = "VH";
                ws.Cells[1, 9].Value = "HH";
                ws.Cells[1, 10].Value = "OH";
                ws.Cells[1, 11].Value = "OTHERS";
                ws.Cells[1, 12].Value = "TOTAL";
                ws.Cells[1, 13].Value = "submit_date";
                ws.Cells[1, 14].Value = "dep_name";
                ws.Cells[1, 15].Value = "ministry_name";

                // Write data
                int row = 2;
                foreach (var item in dept)
                {
                    ws.Cells[row, 1].Value = item.postcode_reg;
                    ws.Cells[row, 2].Value = item.post_name;
                    ws.Cells[row, 3].Value = item.SC;
                    ws.Cells[row, 4].Value = item.ST;
                    ws.Cells[row, 5].Value = item.OBC;
                    ws.Cells[row, 6].Value = item.UR;
                    ws.Cells[row, 7].Value = item.EWS;
                    ws.Cells[row, 8].Value = item.VH;
                    ws.Cells[row, 9].Value = item.HH;
                    ws.Cells[row, 10].Value = item.OH;
                    ws.Cells[row, 11].Value = item.OTHERS;
                    ws.Cells[row, 12].Value = item.TOTAL;
                    ws.Cells[row, 13].Value = item.submit_date;
                    ws.Cells[row, 14].Value = item.dep_name;
                    ws.Cells[row, 15].Value = item.ministry_name;
                   
                    row++;
                }

                // Save Excel file
                byte[] fileContents = excelPackage.GetAsByteArray();
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mydata.xlsx");
                //  return View(dept);



            }
        }
    }
}

