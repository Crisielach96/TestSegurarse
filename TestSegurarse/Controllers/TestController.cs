using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestSegurarse.Models;

namespace TestSegurarse.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var service = new Service();
            var response = service.Test(user.name,user.lastname);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

    }
}
