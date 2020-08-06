using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Managmnt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital_Managmnt.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly HospitalDBContext _context;
        public AttendancesController(HospitalDBContext context)
        {
            _context = context;
        }
        HospitalDBContext db = new HospitalDBContext();

        public ActionResult Index()
        {
            var list = db.Attendance.ToList();
            List<Attendance> list1 = new List<Attendance>();
            foreach (var items in list)
            {

                items.Patient = db.Patients.Find(items.PatientId);
                Attendance obj = new Attendance();
                obj = items;
                list1.Add(obj);
            }
            return View(list1);
        }


        [HttpGet]
        public ActionResult Create()
        {
            List<Patients> plist = new List<Patients>();
            plist = (from p in _context.Patients
                     select p).ToList();
            plist.Insert(0, new Patients { PatientId = 0, Name = "" });
            
            ViewBag.listofitem = new SelectList(plist, "PatientId", "Name");
            return View();
        }

        //public ActionResult Details(int id)
        //{
        //    return View(db.Attendance.Where(s => s.Id == id).First());
        //}

        [HttpPost]
        public ActionResult Create(Attendance attendance)
        {
            if(ModelState.IsValid)
            { 

            db.Attendance.Add(attendance);
            db.SaveChanges();
            return RedirectToAction("Index", "Attendances");  //Index ->methodname , Attendences -> ControllerName 
            }
           
            List<Patients> plist = new List<Patients>();
            plist = (from p in _context.Patients
                     select p).ToList();
            plist.Insert(0, new Patients { PatientId = 0, Name = "" });

            ViewBag.listofitem = new SelectList(plist, "PatientId", "Name");
            return View();

        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Attendance patient = db.Attendance.Where(s => s.Id == id).First();
                db.Attendance.Remove(patient);
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
            return View(db.Attendance.Where(s => s.Id == id).First());
        }

        [HttpPost]
        public ActionResult Update(Attendance attendance)
        {
            if(ModelState.IsValid)
            { 
            
                Attendance att = db.Attendance.Where(s => s.Id == attendance.Id).First();
                att.HospitalRemarks = attendance.HospitalRemarks;
                att.Diagnosis = attendance.Diagnosis;
                att.SecondDiagonsis = attendance.SecondDiagonsis;
                att.Theraphy = attendance.Theraphy;
                att.Date = attendance.Date;
                att.PatientId = attendance.PatientId;
                att.Patient = db.Patients.Where(s => s.PatientId == attendance.PatientId).FirstOrDefault();
                db.SaveChanges();
                return RedirectToAction("Index", "Attendances");
            }
            return View(attendance);



        }
    }
}