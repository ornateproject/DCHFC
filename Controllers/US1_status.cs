using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;

namespace ssc.Controllers
{
    public class US1_status : Controller
    {
        public IActionResult Status()
        {
            return View();
        }
    }
   
}