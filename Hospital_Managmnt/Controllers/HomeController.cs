using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hospital_Managmnt.Models;
using Hospital_Managmnt.Views.Home.Viewmodels;

namespace Hospital_Managmnt.Controllers
{
    public class HomeController : Controller
    {
         private HospitalDBContext db = new HospitalDBContext();
        public IActionResult Index()
        {
            DashboradViewModel dashborad = new DashboradViewModel();

            dashborad.doctors_count = db.Doctors.Count();
            dashborad.patients_count = db.Patients.Count();
            dashborad.nurses_count = db.Nurse.Count();
            return View(dashborad);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
