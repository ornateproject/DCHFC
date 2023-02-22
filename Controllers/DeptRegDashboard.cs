using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class DeptRegDashboard : Controller
    {

        private readonly DeptDashrepo _usdashrepo;
        public DeptRegDashboard(IConfiguration configuration)
        {
            _usdashrepo = new DeptDashrepo(configuration);


        }

        [HttpGet]
        public IActionResult UserDeptDash()
        {
            var usdata = _usdashrepo.get_listdata();
            List<DepartmentData> dept = new List<DepartmentData>();
            dept = JsonConvert.DeserializeObject<List<DepartmentData>>(usdata);
            return View(dept);
        }
        

    }
}
