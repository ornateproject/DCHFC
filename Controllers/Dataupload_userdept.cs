using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using ssc.Models;
using ssc.repository;
using System.IO;

namespace ssc.Controllers
{
    public class Dataupload_userdept : Controller
    {

        private readonly uploaduserdata_repo _us2repo;
        public Dataupload_userdept(IConfiguration configuration)
        {
            _us2repo = new uploaduserdata_repo(configuration);

        }

        [HttpGet]
        public IActionResult uploaduserdata()
        {
            var usdata = _us2repo.get_deparment();
            List<UserDepartment> dept = new List<UserDepartment>();
            dept = JsonConvert.DeserializeObject<List<UserDepartment>>(usdata);

            return View(dept);
            
        }


    }
}
