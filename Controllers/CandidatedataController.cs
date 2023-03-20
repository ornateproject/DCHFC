using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class CandidatedataController : Controller
    {
        private readonly candidatedata_repo _candidaterepo;
        public CandidatedataController(IConfiguration configuration)
        {
            _candidaterepo = new candidatedata_repo(configuration);
           // _usdashrepo = new DeptDashrepo(configuration);


        }


        [HttpGet]
        public IActionResult candidate()
        {
            var usdata = _candidaterepo.get_postdata();
            List<getpost> dept = new List<getpost>();
            dept = JsonConvert.DeserializeObject<List<getpost>>(usdata);
            return View(dept);
        }

      
        public IActionResult getcandidatedata()
        {
            return View();
        }
        public IActionResult getcandidatedatadept()
        {
            return View();
        }
    }
}
