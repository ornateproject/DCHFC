using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class Dataupload_deptreg : Controller
    {
        private readonly uploadDeptRepo _us2repo;
        public Dataupload_deptreg(IConfiguration configuration)
        {
            _us2repo = new uploadDeptRepo(configuration);


        }



        [HttpGet]
        public IActionResult uploadDeptdata()


        {
            var usdata = _us2repo.get_deparment();
            List<DeptRegistration> dept = new List<DeptRegistration>();
            dept = JsonConvert.DeserializeObject<List<DeptRegistration>>(usdata);
            return View(dept);
        }
        
    }
}
