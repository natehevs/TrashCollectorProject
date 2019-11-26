using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollectorProject.Controllers
{
    [Authorize]
    public class usercontroller : Controller
    {
        // GET: usercontroller
        public ActionResult Index()
        {
            return View();
        }
    }
}