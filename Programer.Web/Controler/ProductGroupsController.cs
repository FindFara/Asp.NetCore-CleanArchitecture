using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programer.Web.Controler
{
    
    public class ProductGroupsController : Controller
    {
        [Route("p/{id}/{title}")] 
        public IActionResult Index(int id , string title)
        {
            return View();
        }
    }
}
