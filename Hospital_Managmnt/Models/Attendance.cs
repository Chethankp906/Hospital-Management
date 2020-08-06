using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managmnt.Models
{
    public partial class Attendance
    {
        
        public int Id { get; set; }
        [Required]
        public string HospitalRemarks { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string SecondDiagonsis { get; set; }
        [Required]
        public string Theraphy { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public int? PatientId { get; set; } //? is given to make that property as Nullable

        public Patients Patient { get; set; }
    }
}
