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
           // var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
            var usdata = _candidaterepo.get_postdata();
           
            managecandidatedata managecandidatedata = new managecandidatedata();

            managecandidatedata.getposts = JsonConvert.DeserializeObject<IList<getpost>>(usdata);
            
            return View(managecandidatedata);
        }
       
        [HttpPost]
        public async Task<IActionResult> candidate(managecandidatedata data)
        {
            if (ModelState.IsValid)
            {
                var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
               
                    var asd = _candidaterepo.InsertpostData(data, reg_no);            
                                             
               
                return View("candidate_dashboard", "Candidatedata");

            }
            return View();
        }


        [HttpGet]
        public IActionResult usview()
        {
           // var reg_no = HttpContext.Session.GetString("Reg_no").ToString();
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

        [HttpGet]
        public IActionResult candidate_preview()
        {
            var usdata = _candidaterepo.get_postdata();

            managecandidatedata managecandidatedata = new managecandidatedata();

            managecandidatedata.getposts = JsonConvert.DeserializeObject<IList<getpost>>(usdata);

            return View(managecandidatedata);
           // return View();
        }

        [HttpPost]
        public async Task<IActionResult> candidate_preview(managecandidatedata data)
        {
            if (ModelState.IsValid)
            {
                var reg_no = HttpContext.Session.GetString("Reg_no").ToString();

                var asd = _candidaterepo.InsertpostData(data, reg_no);


                return View("candidate_dashboard", "Candidatedata");

            }
            return View();
        }
    }
}
