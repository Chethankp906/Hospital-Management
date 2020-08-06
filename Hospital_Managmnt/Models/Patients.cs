using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managmnt.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
            Attendance = new HashSet<Attendance>();
        }

        public int PatientId { get; set; }
        [Required]
       
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"\+?\d[\d -]{8,12}\d",
            ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Age field is required")]
        public int? Age { get; set; }

        [Required(ErrorMessage="DoctorID field is required")]
        public int? DoctorId { get; set; }

        [Required(ErrorMessage = "NurseId field is required")]
        public int? NurseId { get; set; }

        public Doctors Doctor { get; set; }
        public Nurse Nurse { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
    }
}
