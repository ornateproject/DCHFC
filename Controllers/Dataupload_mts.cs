using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class Dataupload_mts : Controller
    {

        private readonly uploadmts_repo _us2repo;
        public Dataupload_mts(IConfiguration configuration)
        {
            _us2repo = new uploadmts_repo(configuration);


        }



        [HttpGet]
        public IActionResult uploadmtsdata()
        {
            var usdata = _us2repo.get_deparment();
            List<MTSselection> dept = new List<MTSselection>();
            dept = JsonConvert.DeserializeObject<List<MTSselection>>(usdata);
             return View(dept);
            
        }

       
    }
}
