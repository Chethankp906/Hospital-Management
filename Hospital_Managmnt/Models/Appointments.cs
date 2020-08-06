using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managmnt.Models
{
    public partial class Appointments
    {
        public int Id { get; set; }
        [Required]
       [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }
        [Required]
        public string Details { get; set; }
        [Required(ErrorMessage=("Status field must be true or false") )]
        public bool? Status { get; set; }

        [Required]
        public int? PatientId { get; set; }
        [Required]
        public int? DoctorId { get; set; }

        public Doctors Doctor { get; set; }
        public Patients Patient { get; set; }
    }
}
