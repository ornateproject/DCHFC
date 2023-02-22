using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class MTS_postDash : Controller
    {
        private readonly MTSdash_Repo _mtsdahrepo;
        public MTS_postDash(IConfiguration configuration)
        {
            _mtsdahrepo = new MTSdash_Repo(configuration);


        }

        [HttpGet]
        public IActionResult MTSdash()
        {
            var usdata = _mtsdahrepo.get_listdata();
            List<DepartmentData> dept = new List<DepartmentData>();
            dept = JsonConvert.DeserializeObject<List<DepartmentData>>(usdata);
            return View(dept);
        }

        
    }
}
