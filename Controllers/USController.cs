using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class USController : Controller
    {
        private readonly USRepo _usrepo;
        private readonly DeptDashrepo _usdashrepo;
        public USController(IConfiguration configuration)
        {
            _usrepo = new USRepo(configuration);
            _usdashrepo = new DeptDashrepo(configuration);


        }
       

        [HttpGet]
        public IActionResult Index()
        {
            var usdata = _usrepo.get_deparment();
            List<DeptRegistration> deptRegistration = new List<DeptRegistration>();
            deptRegistration = JsonConvert.DeserializeObject<List<DeptRegistration>>(usdata);
            return View(deptRegistration);
            
        }

        [HttpGet]
        public IActionResult dashboard()
        {
            var usdata = _usdashrepo.get_listdata();
            List<DepartmentData> dept = new List<DepartmentData>();
            dept = JsonConvert.DeserializeObject<List<DepartmentData>>(usdata);
            return View("~/views/DeptRegDashboard/UserDeptDash.cshtml", dept);

        }
    }
}
