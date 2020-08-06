using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managmnt.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
            Patients = new HashSet<Patients>();
        }

        public int DoctorId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Doctors Name cannot exceed 20 chrs")]

        public string Name { get; set; } 

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
            ErrorMessage ="Invalid Email Format")]
        [Display(Name ="Doctor's Email")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"\+?\d[\d -]{8,12}\d",
            ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; } 
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Specilaist { get; set; } 

        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<Patients> Patients { get; set; }
    }
}
