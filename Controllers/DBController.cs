using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class DBController : Controller
    {

        private readonly DB_Repo _Dbrepo;

        public DBController(IConfiguration configuration)
        {
            _Dbrepo = new DB_Repo(configuration);
        }

        [HttpGet]
        public IActionResult selected_candidatedata(string id)
        {
            var usdata = _Dbrepo.getselectedcandidatelist(id);
            List<getpost> dept = new List<getpost>();
            dept = JsonConvert.DeserializeObject<List<getpost>>(usdata);
            return View(dept);
        }

        [HttpGet]
        public IActionResult selecteddata()
        {
            var depart = HttpContext.Session.GetString("dep_name").ToString();
            var usdata = _Dbrepo.get_postdata(depart);
            List<getpost> dept = new List<getpost>();
            dept = JsonConvert.DeserializeObject<List<getpost>>(usdata);
            return View(dept);
        }

    }
}
