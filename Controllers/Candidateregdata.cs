using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class Candidateregdata : Controller
    {
        private readonly candidateregistration_repo _us2repo;
        public Candidateregdata(IConfiguration configuration)
        {
            _us2repo = new candidateregistration_repo(configuration);


        }



        [HttpGet]
        public IActionResult candidateregdata(int id)
        {
            var usdata = _us2repo.get_deparment(id);

            List<DeptRegistration> dept = JsonConvert.DeserializeObject<List<DeptRegistration>>(usdata);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                //var p = new ExcelPackage();
                var sheetName = "Sheet1";
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add(sheetName);
                //var worksheet = excelPackage.CreateWorksheet("Sheet1");

                // Write headers
                ws.Cells[1, 1].Value = "Ministry";
                ws.Cells[1, 2].Value = "Department";
                ws.Cells[1, 3].Value = "Name";
                ws.Cells[1, 4].Value = "Mobile_no";
                ws.Cells[1, 5].Value = "Email";
                ws.Cells[1, 6].Value = "Upload_doc";
                ws.Cells[1, 7].Value = "Status";



                // Write data
                int row = 2;
                foreach (var item in dept)
                {
                    ws.Cells[row, 1].Value = item.Ministry;
                    ws.Cells[row, 2].Value = item.Department;
                    ws.Cells[row, 3].Value = item.Name;
                    ws.Cells[row, 4].Value = item.Mobile_no;
                    ws.Cells[row, 5].Value = item.Email;
                    ws.Cells[row, 6].Value = item.Upload_doc;
                    ws.Cells[row, 7].Value = item.Status;
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
