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
       
        [HttpPost]
        public async Task<IActionResult> candidate(IList<getpost> data)
        {
            if (ModelState.IsValid)
            {
                var reg_no = HttpContext.Session.GetString("Reg_no").ToString();             

                foreach (getpost posts in data) 
                {
                 
                    var asd = _candidaterepo.InsertpostData(posts, reg_no);
                }
                return View("candidate_dashboard", "Candidatedata");

            }
            return View();
        }


        [HttpGet]
        public IActionResult usview()
        {
            var usdata = _candidaterepo.get_postdata();
            List<getpost> dept = new List<getpost>();
            dept = JsonConvert.DeserializeObject<List<getpost>>(usdata);
            return View(dept);

        }
        [HttpGet]
        public IActionResult getcandidatedata()
        {
         return View();
        }
        [HttpGet]
        public IActionResult getcandidatedatadept()
        {
            //var usdata = _candidaterepo.get_data();
            //List<candidate> dept = new List<candidate>();
            //dept = JsonConvert.DeserializeObject<List<candidate>>(usdata);
            //return View(dept);
          return View();
        }

        [HttpGet]
        public IActionResult getcandidatelist(string id)
        {
           var usdata = _candidaterepo.getcandidatelist(id);
            List<getpost> dept = new List<getpost>();
           dept = JsonConvert.DeserializeObject<List<getpost>>(usdata);
            return View(dept);            
        }
        [HttpGet]
        public IActionResult getuscandidatelist()
        {
            return View();
        }

        [HttpGet]
        public IActionResult candidate_dashboard()
        {
            return View();
        }

    }
}
