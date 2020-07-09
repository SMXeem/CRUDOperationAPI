using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    public class HomeController : Controller
    {
        RdlcReportEntities aStudentEntities = new RdlcReportEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Getall()
        {
            ViewBag.Message = "Your contact page.";
            List<Student> astudentList = aStudentEntities.Students.ToList();
            return View(astudentList);
        }
    }
}