using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class CandidateuserdataController : Controller
    {
        private readonly candidateuser_Repo _us2repo;
        public CandidateuserdataController(IConfiguration configuration)
        {
            _us2repo = new candidateuser_Repo(configuration);


        }



        [HttpGet]
        public IActionResult candidateuserdata(int id)
        {
            var usdata = _us2repo.get_deparment(id);

            List<UserDepartment> dept = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata);
           // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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
                ws.Cells[1, 16].Value = "permissible";
                ws.Cells[1, 17].Value = "VH";
                ws.Cells[1, 18].Value = "HH";
                ws.Cells[1, 19].Value = "OTHERS";
                ws.Cells[1, 20].Value = "Total_vacancy";
                ws.Cells[1, 21].Value = "reserved_vacancy";
                ws.Cells[1, 22].Value = "pwd_number";
                ws.Cells[1, 23].Value = "pwdvertical_category";
                ws.Cells[1, 24].Value = "totalesm_number";
                ws.Cells[1, 25].Value = "esm_number";
                ws.Cells[1, 26].Value = "esmvertical_category";
                ws.Cells[1, 27].Value = "probation1";
                ws.Cells[1, 28].Value = "Essential";
                ws.Cells[1, 29].Value = "Desirable";
                ws.Cells[1, 30].Value = "Relaxation";
                ws.Cells[1, 31].Value = "Regional_office";
                ws.Cells[1, 32].Value = "Age_limit";
                ws.Cells[1, 33].Value = "Requirment";
                ws.Cells[1, 34].Value = "Name";
                ws.Cells[1, 35].Value = "Desigantion";
                ws.Cells[1, 36].Value = "Address";
                ws.Cells[1, 37].Value = "Mobile_no";
                ws.Cells[1, 38].Value = "Email";
                ws.Cells[1, 39].Value = "subsequent_orders";
                ws.Cells[1, 40].Value = "DOPT_letter";
                ws.Cells[1, 41].Value = "no_ofvacancy";
                ws.Cells[1, 42].Value = "pwd_esm";
                ws.Cells[1, 43].Value = "person_disabilities";
                ws.Cells[1, 44].Value = "letter_no";
                ws.Cells[1, 45].Value = "office_department";
                ws.Cells[1, 46].Value = "Status";


                // Write data
                int row = 2;
                foreach (var item in dept)
                {
                    // Write headers
                    ws.Cells[row, 1].Value = item.post_name;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 3].Value = item.post_class;
                    ws.Cells[row, 4].Value = item.post_nature;
                    ws.Cells[row, 5].Value = item.initial_place;
                    ws.Cells[row, 6].Value = item.aisl;
                    ws.Cells[row, 7].Value = item.vacancy_ariesn;
                    ws.Cells[row, 8].Value = item.UR;
                    ws.Cells[row, 9].Value = item.OBC;
                    ws.Cells[row, 10].Value = item.SC;
                    ws.Cells[row, 11].Value = item.ST;
                    ws.Cells[row, 12].Value = item.EWS;
                    ws.Cells[row, 13].Value = item.TOTAL;
                    ws.Cells[row, 14].Value = item.suitable_pwd;
                    ws.Cells[row, 15].Value = item.disability_type;
                    ws.Cells[row, 16].Value = item.permissible;
                    ws.Cells[row, 17].Value = item.VH;
                    ws.Cells[row, 18].Value = item.HH;
                    ws.Cells[row, 19].Value = item.OTHERS;
                    ws.Cells[row, 20].Value = item.Total_vacancy;
                    ws.Cells[row, 21].Value = item.reserved_vacancy;
                    ws.Cells[row, 22].Value = item.pwd_number;
                    ws.Cells[row, 23].Value = item.pwdvertical_category;
                    ws.Cells[row, 24].Value = item.totalesm_number;
                    ws.Cells[row, 25].Value = item.esm_number;
                    ws.Cells[row, 26].Value = item.esmvertical_category;
                    ws.Cells[row, 27].Value = item.probation1;
                    ws.Cells[row, 28].Value = item.Essential;
                    ws.Cells[row, 29].Value = item.Desirable;
                    ws.Cells[row, 30].Value = item.Relaxation;
                    ws.Cells[row, 31].Value = item.Regional_office;
                    ws.Cells[row, 32].Value = item.Age_limit;
                    ws.Cells[row, 33].Value = item.Requirment;
                    ws.Cells[row, 34].Value = item.Name;
                    ws.Cells[row, 35].Value = item.Desigantion;
                    ws.Cells[row, 36].Value = item.Address;
                    ws.Cells[row, 37].Value = item.Mobile_no;
                    ws.Cells[row, 38].Value = item.Email;
                    ws.Cells[row, 39].Value = item.subsequent_orders;
                    ws.Cells[row, 40].Value = item.DOPT_letter;
                    ws.Cells[row, 41].Value = item.no_ofvacancy;
                    ws.Cells[row, 42].Value = item.pwd_esm;
                    ws.Cells[row, 43].Value = item.person_disabilities;
                    ws.Cells[row, 44].Value = item.letter_no;
                    ws.Cells[row, 45].Value = item.office_department;
                    ws.Cells[row, 46].Value = item.Status;
                    row++;
                }

                // Save Excel file
                byte[] fileContents = excelPackage.GetAsByteArray();
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mydata.xlsx");
                //List<UserDepartment> dept = new List<UserDepartment>();
                //dept = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata);

                //return View(dept);

            }
        }
    }
}
