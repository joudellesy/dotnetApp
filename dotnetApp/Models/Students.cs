using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetApp.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Section{ get; set; }
        public DateTime EnrolledDate{ get; set; }
        public DateTime DateCreated{ get; set; }


    }
}
