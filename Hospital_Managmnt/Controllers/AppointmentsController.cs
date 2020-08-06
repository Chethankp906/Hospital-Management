using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Managmnt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital_Managmnt.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HospitalDBContext _context;
        public AppointmentsController(HospitalDBContext context)
        {
            _context = context;
        }

        HospitalDBContext db = new HospitalDBContext();

        public ActionResult Index()
        {
           var list = db.Appointments.ToList();
           List<Appointments> _list = new List<Appointments>();
           foreach(var item in list)
            {
               item.Patient = db.Patients.Find(item.PatientId);
               item.Doctor = db.Doctors.Find(item.DoctorId);
               Appointments obj = new Appointments();
                obj = item;
                _list.Add(obj);
            }
            return View(_list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Doctors> list = new List<Doctors>();
            list = (from t in _context.Doctors select t).ToList();
            list.Insert(0, new Doctors { DoctorId = 0, Name = "" });
            ViewBag.message = new SelectList(list, "DoctorId", "Name");


            List<Patients> plist = new List<Patients>();
            plist = (from p in _context.Patients select p).ToList();
            plist.Insert(0, new Patients { PatientId = 0, Name = "" });
            ViewBag.listofitem = new SelectList(plist, "PatientId", "Name");
            return View();

        }

        //public ActionResult Details(int id)
        //{
        //    return View(db.Appointments.Where(s => s.AppointmentId == id).First());
        //}

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Appointments appointment)
        {
            if (ModelState.IsValid)
            {
               
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index", "Appointments");

            }
            List<Doctors> list = new List<Doctors>();
            list = (from t in _context.Doctors select t).ToList();
            list.Insert(0, new Doctors { DoctorId = 0, Name = "" });
            ViewBag.message = new SelectList(list, "DoctorId", "Name");


            List<Patients> plist = new List<Patients>();
            plist = (from p in _context.Patients select p).ToList();
            plist.Insert(0, new Patients { PatientId = 0, Name = "" });
            ViewBag.listofitem = new SelectList(plist, "PatientId", "Name");

            return View();
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
               Appointments appointment = db.Appointments.Where(s => s.Id == id).First();
                db.Appointments.Remove(appointment);
                db.SaveChanges();
                return true;

            }
            catch(System.Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(db.Appointments.Where(s => s.Id == id).First());
        }

        [HttpPost]
        public ActionResult Update(Appointments appointment)
        {
            if (ModelState.IsValid)
            {

            
            Appointments a = db.Appointments.Where(s => s.Id == appointment.Id).First();
            a.StartDateTime = appointment.StartDateTime;
            a.Details = appointment.Details;
            a.Status = appointment.Status;

            //a.DoctorId = appointment.DoctorId;  //Both are Correct
            //a.PatientId = appointment.PatientId;
            a.Doctor = appointment.Doctor;
            a.Doctor = db.Doctors.Where(p => p.DoctorId == appointment.DoctorId).FirstOrDefault();
            a.Patient = appointment.Patient;
            a.Patient = db.Patients.Where(p => p.PatientId == appointment.PatientId).FirstOrDefault();
            db.SaveChanges();
            return RedirectToAction("Index", "Appointments");
            }
            List<Doctors> list = new List<Doctors>();
            list = (from t in _context.Doctors select t).ToList();
            list.Insert(0, new Doctors { DoctorId = 0, Name = "" });
            ViewBag.message = new SelectList(list, "DoctorId", "Name");


            List<Patients> plist = new List<Patients>();
            plist = (from p in _context.Patients select p).ToList();
            plist.Insert(0, new Patients { PatientId = 0, Name = "" });
            ViewBag.listofitem = new SelectList(plist, "PatientId", "Name");

            return View(appointment);
        }
    }
}