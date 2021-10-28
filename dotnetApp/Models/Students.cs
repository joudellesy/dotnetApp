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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address{ get; set; }
        [Required]
        public string Section{ get; set; }
        [Required]
        public DateTime EnrolledDate{ get; set; }
        public DateTime DateCreated{ get; set; }


    }
}
