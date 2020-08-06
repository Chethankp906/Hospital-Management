using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Managmnt.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managmnt.Controllers
{
    public class AccountController : Controller
    {
        HospitalDBContext db = new HospitalDBContext();
        public IActionResult Login()
        {
            return View();
        }

       
        public ActionResult Validate(Admin admin)
        {
            var _admin = db.Admin.Where(s => s.Email == admin.Email);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Password == admin.Password).Any())
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
            }
        }

    }
}