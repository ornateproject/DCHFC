using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ssc.Models;
using ssc.repository;

namespace ssc.Controllers
{
    public class UserDeptDash : Controller
    {
        private readonly UserDeptDsah_repo _userdahrepo;
        public UserDeptDash(IConfiguration configuration)
        {
            _userdahrepo = new UserDeptDsah_repo(configuration);


        }

        [HttpGet]
        public IActionResult userdeptDash()
        {
            var usdata = _userdahrepo.get_listdata();
            List<DepartmentData> dept = new List<DepartmentData>();
            dept = JsonConvert.DeserializeObject<List<DepartmentData>>(usdata);
            return View(dept);
        }

        
    }
}
