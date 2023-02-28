using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class Candidatemtsdata : Controller
    {
        private readonly candidatemts_Repo _us2repo;
        public Candidatemtsdata(IConfiguration configuration)
        {
            _us2repo = new candidatemts_Repo(configuration);


        }

        [HttpGet]
        public IActionResult candidatemts()


        {
            var usdata = _us2repo.get_deparment();
            List<MTSselection> dept = new List<MTSselection>();
            dept = JsonConvert.DeserializeObject<List<MTSselection>>(usdata);
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
                ws.Cells[1, 3].Value = "age_limit";
                ws.Cells[1, 4].Value = "post_classification";
                ws.Cells[1, 5].Value = "initial_post";
                ws.Cells[1, 6].Value = "AISL";
                ws.Cells[1, 7].Value = "vacancy_ariesn";
                ws.Cells[1, 8].Value = "identified_post";
                ws.Cells[1, 9].Value = "disability_type";
                ws.Cells[1, 10].Value = "PWD_suitable";
                ws.Cells[1, 11].Value = "permissible_disability";
                ws.Cells[1, 12].Value = "UR";
                ws.Cells[1, 13].Value = "OBC";
                ws.Cells[1, 14].Value = "SC";
                ws.Cells[1, 15].Value = "ST";
                ws.Cells[1, 16].Value = "EWS";
                ws.Cells[1, 17].Value = "TOTAL";
                ws.Cells[1, 18].Value = "VH";
                ws.Cells[1, 19].Value = "HH";
                ws.Cells[1, 20].Value = "OH";
                ws.Cells[1, 21].Value = "OTHERS";
                ws.Cells[1, 22].Value = "Total_vacancy";
                ws.Cells[1, 23].Value = "ESM_number";
                ws.Cells[1, 24].Value = "probation_period";
                ws.Cells[1, 1].Value = "Essential";
                ws.Cells[1, 25].Value = "desirable";
                ws.Cells[1, 26].Value = "relaxation";
                ws.Cells[1, 27].Value = "Age_requirment";
                ws.Cells[1, 28].Value = "other_requirment";
                ws.Cells[1, 29].Value = "subsequent_oders";
                ws.Cells[1, 30].Value = "CCS_rules";
                ws.Cells[1, 31].Value = "reserved_vacancies";
                ws.Cells[1, 32].Value = "DOPT_refrence";
                ws.Cells[1, 33].Value = "Persons_disabilities";
                ws.Cells[1, 34].Value = "candidates_nominated";


                // Write data
                int row = 2;
                foreach (var item in dept)
                {
                    ws.Cells[row, 1].Value = item.post_name;
                    ws.Cells[row, 2].Value = item.pay_matrix;
                    ws.Cells[row, 3].Value = item.age_limit;
                    ws.Cells[row, 4].Value = item.post_classification;
                    ws.Cells[row, 5].Value = item.initial_post;
                    ws.Cells[row, 6].Value = item.AISL;
                    ws.Cells[row, 7].Value = item.vacancy_ariesn;
                    ws.Cells[row, 8].Value = item.identified_post;
                    ws.Cells[row, 9].Value = item.disability_type;
                    ws.Cells[row, 10].Value = item.PWD_suitable;
                    ws.Cells[row, 11].Value = item.permissible_disability;
                    ws.Cells[row, 12].Value = item.UR;
                    ws.Cells[row, 13].Value = item.OBC;
                    ws.Cells[row, 14].Value = item.SC;
                    ws.Cells[row, 15].Value = item.ST;
                    ws.Cells[row, 16].Value = item.EWS;
                    ws.Cells[row, 17].Value = item.TOTAL;
                    ws.Cells[row, 18].Value = item.VH;
                    ws.Cells[row, 19].Value = item.HH;
                    ws.Cells[row, 20].Value = item.OH;
                    ws.Cells[row, 21].Value = item.OTHERS;
                    ws.Cells[row, 22].Value = item.Total_vacancy;
                    ws.Cells[row, 23].Value = item.ESM_number;
                    ws.Cells[row, 24].Value = item.probation_period;
                    ws.Cells[row, 1].Value = item.Essential;
                    ws.Cells[row, 25].Value = item.desirable;
                    ws.Cells[row, 26].Value = item.relaxation;
                    ws.Cells[row, 27].Value = item.Age_requirment;
                    ws.Cells[row, 28].Value = item.other_requirment;
                    ws.Cells[row, 29].Value = item.subsequent_oders;
                    ws.Cells[row, 30].Value = item.CCS_rules;
                    ws.Cells[row, 31].Value = item.reserved_vacancies;
                    ws.Cells[row, 32].Value = item.DOPT_refrence;
                    ws.Cells[row, 33].Value = item.Persons_disabilities;
                    ws.Cells[row, 34].Value = item.candidates_nominated;
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
