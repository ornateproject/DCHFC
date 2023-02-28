using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;
using System.IO;

namespace ssc.Controllers
{
    public class Dataupload_userdept : Controller
    {

        private readonly uploaduserdata_repo _us2repo;
        public Dataupload_userdept(IConfiguration configuration)
        {
            _us2repo = new uploaduserdata_repo(configuration);


        }



        [HttpGet]
        public IActionResult uploaduserdata()
        {
            var usdata = _us2repo.get_deparment();
           // List<UserDepartment> dept = new List<UserDepartment>();
            List<UserDepartment> dept = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage()) 
            {
                //var p = new ExcelPackage();
                var sheetName = "Sheet1";
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add(sheetName);
                //var worksheet = excelPackage.CreateWorksheet("Sheet1");

                // Write headers
                ws.Cells[1, 1].Value = "post_name";
                ws.Cells[1, 2].Value = "pay_matrix";
                ws.Cells[1, 3].Value = "post_class";
                ws.Cells[1, 4].Value = "post_nature";
                ws.Cells[1, 5].Value = "initial_place"; 
                ws.Cells[1, 6].Value = "aisl";
                ws.Cells[1, 7].Value = "vacancy_ariesn";
                ws.Cells[1, 8].Value = "UR";
                ws.Cells[1, 9].Value = "OBC";
                ws.Cells[1, 10].Value = "SC";
                ws.Cells[1, 11].Value = "ST";
                ws.Cells[1, 12].Value = "EWS";
                ws.Cells[1, 13].Value = "TOTAL";
                ws.Cells[1, 14].Value = "suitable_pwd";
                ws.Cells[1, 15].Value = "disability_type";
                ws.Cells[1, 15].Value = "permissible";
                ws.Cells[1, 15].Value = "VH";
                ws.Cells[1, 15].Value = "HH";
                ws.Cells[1, 15].Value = "OTHERS";
                ws.Cells[1, 15].Value = "Total_vacancy";
                ws.Cells[1, 15].Value = "reserved_vacancy";
                ws.Cells[1, 15].Value = "pwd_number";
                ws.Cells[1, 15].Value = "pwdvertical_category";
                ws.Cells[1, 15].Value = "totalesm_number";
                ws.Cells[1, 15].Value = "esm_number";
                ws.Cells[1, 15].Value = "esmvertical_category";
                ws.Cells[1, 15].Value = "probation1";
                ws.Cells[1, 15].Value = "Essential";
                ws.Cells[1, 15].Value = "Desirable";
                ws.Cells[1, 15].Value = "Relaxation";
                ws.Cells[1, 15].Value = "Regional_office";
                ws.Cells[1, 15].Value = "Age_limit";
                ws.Cells[1, 15].Value = "Requirment";
                ws.Cells[1, 15].Value = "Name";
                ws.Cells[1, 15].Value = "Desigantion";
                ws.Cells[1, 15].Value = "Address";
                ws.Cells[1, 15].Value = "Mobile_no";
                ws.Cells[1, 15].Value = "Mobile_no";
                ws.Cells[1, 15].Value = "Mobile_no";
                ws.Cells[1, 15].Value = "Mobile_no";
                ws.Cells[1, 15].Value = "Mobile_no";
                ws.Cells[1, 15].Value = "Mobile_no";
                ws.Cells[1, 15].Value = "Mobile_no";


                // Write data
                int row = 2;
                foreach (var item in dept)
                {
                    ws.Cells[row, 1].Value = item.post_name;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, ].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    row++;
                }

                // Save Excel file
                byte[] fileContents = excelPackage.GetAsByteArray();
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mydata.xlsx");
                //  return View(dept);
            }
        }

        //[HttpPost]
        //public IActionResult uploaduserdata(UserDepartment department)
        //{
        //    var asd = _us2repo.candidatedata(department);
        //    return View();
        //}

    }
}
