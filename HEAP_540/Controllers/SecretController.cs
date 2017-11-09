using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HEAP_540.Controllers
{
    public class SecretController : Controller
    {
        [Authorize]
       public ContentResult Secret()
        {
            return Content("This is a secret.......");
        }
        public ContentResult Overt()
        {
            return Content("This is not a secret!");
        }
    }
}