using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Managmnt.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managmnt.Controllers
{
    public class PatientsController : Controller
    {
        HospitalDBContext db = new HospitalDBContext();

        public IActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(Patients patient)
        {
            if(ModelState.IsValid)
            { 
            db.Patients.Add(patient);
            db.SaveChanges();
            return RedirectToAction("Index", "Patients");
            }
            return View();
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Patients patient = db.Patients.Where(p => p.PatientId == id).First();
                db.Patients.Remove(patient);
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
            return View(db.Patients.Where(p => p.PatientId == id).First());
        }

        [HttpPost]
        public ActionResult Update(Patients patient)
        {
            if(ModelState.IsValid)
            { 
            Patients pat = db.Patients.Where(p => p.PatientId == patient.PatientId).First();
            pat.Name = patient.Name;
            pat.Phone = patient.Phone;
            pat.Age = patient.Age;
            pat.DoctorId = patient.DoctorId;
            pat.NurseId = patient.NurseId;
            db.SaveChanges();
            return RedirectToAction("Index", "Patients");
            }

            return View(patient);
        }

    }
}