using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class USController : Controller
    {
        private readonly USRepo _usrepo;
        public USController(IConfiguration configuration)
        {
            _usrepo = new USRepo(configuration);


        }

        [HttpGet]
        public IActionResult Index()
        {
            var usdata = _usrepo.get_deparment();
            List<DeptRegistration> deptRegistration = new List<DeptRegistration>();
            deptRegistration = JsonConvert.DeserializeObject<List<DeptRegistration>>(usdata);
            return View(deptRegistration);
        }
    }
}
