using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class US2Controller : Controller
    {
        private readonly US2repo _us2repo;
        public US2Controller(IConfiguration configuration)
        {
            _us2repo = new US2repo(configuration);


        }



        [HttpGet]
        public IActionResult us2()
        {
            var usdata = _us2repo.get_deparment();
            List<UserDepartment> dept = new List<UserDepartment>();
            dept = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata);
            return View(dept);
        }


    }
}
