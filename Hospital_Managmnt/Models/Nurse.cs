using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managmnt.Models
{
    public partial class Nurse
    {
        public Nurse()
        {
            Patients = new HashSet<Patients>();
        }

        public int NurseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
            ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"\+?\d[\d -]{8,12}\d",
            ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        public ICollection<Patients> Patients { get; set; }
    }
}
