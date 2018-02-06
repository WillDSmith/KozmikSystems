using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KozmikSystems.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        public String Position { get; set; }
        public String Department { get; set; }
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; }
        public String ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Employee()
        {
            ImagePath = "~/Images/default.png";
        }
    }
}