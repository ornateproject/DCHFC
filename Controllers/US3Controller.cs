using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class US3Controller : Controller
    {
        private readonly us3MTSrepo _us3repo;
        public US3Controller(IConfiguration configuration)
        {
            _us3repo = new us3MTSrepo(configuration);


        }

        [HttpGet]
        public IActionResult us3()

        {
            {

                var user = HttpContext.Session.GetString("userType").ToString();
                if (@user == "2")
                {
                    var usdata = _us3repo.get_MTSdetails();
                    List<MTSselection> dept = new List<MTSselection>();
                    dept = JsonConvert.DeserializeObject<List<MTSselection>>(usdata);
                    return View(dept);
                }
                else if (@user == "3")
                {
                    var department = HttpContext.Session.GetString("department").ToString();
                    var usdata = _us3repo.MTS_postdetails(department);
                    List<MTSselection> dept = new List<MTSselection>();
                    dept = JsonConvert.DeserializeObject<List<MTSselection>>(usdata);
                    return View(dept);
                }

                return View();

            }
            
        }
    }
}
