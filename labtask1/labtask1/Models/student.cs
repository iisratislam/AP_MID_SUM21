using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using labtask1.Models.database;

namespace labtask1.Models
{
    public class student
    {
        public int ID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public int CGPA { get; set; }



    }
}