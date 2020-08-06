using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Managmnt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hospital_Managmnt.Controllers
{
    public class DoctorsController : Controller
    {
        HospitalDBContext db = new HospitalDBContext();

        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctors doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index", "Doctors");

            }
            // return RedirectToAction("Index", "Doctors");
            return View();
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Doctors doctor = db.Doctors.Where(s => s.DoctorId == id).First();
                db.Doctors.Remove(doctor);
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

            return View(db.Doctors.Where(s => s.DoctorId == id).FirstOrDefault());

        }

        [HttpPost]
        public ActionResult Update(Doctors doctor)
        {
           if (ModelState.IsValid)
            {

           
            Doctors d = db.Doctors.Where(s => s.DoctorId == doctor.DoctorId).FirstOrDefault();
            d.Name = doctor.Name;
            d.Email = doctor.Email;
            d.Phone = doctor.Phone;
            d.Specilaist = doctor.Specilaist;
            db.SaveChanges();
            return RedirectToAction("Index", "Doctors");

           }

            return View(doctor);
        }
    }
}