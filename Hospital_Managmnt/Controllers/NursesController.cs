using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Managmnt.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managmnt.Controllers
{
    public class NursesController : Controller
    {
        HospitalDBContext db = new HospitalDBContext();

        public ActionResult Index()
        {
            return View(db.Nurse.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Nurse nurse)
        {
            if (ModelState.IsValid)
            {

            db.Nurse.Add(nurse);
            db.SaveChanges();
            return RedirectToAction("Index","Nurses");
            }
            return View(nurse);
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Nurse nurse = db.Nurse.Where(o => o.NurseId == id).First();
                db.Remove(nurse);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(db.Nurse.Where(o => o.NurseId == id).First());
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Update(Nurse nurse)
        {
            if(ModelState.IsValid)
            {
            Nurse nu = db.Nurse.Where(o => o.NurseId == nurse.NurseId).First();
            nu.Name = nurse.Name;
            nu.Email = nurse.Email;
            nu.Password = nurse.Password;
            nu.Phone = nurse.Phone;
            db.SaveChanges();
            return RedirectToAction("Index", "Nurses");
            }
            return View(nurse);
           // return RedirectToAction("Index", "Nurses");

        }
    }
}