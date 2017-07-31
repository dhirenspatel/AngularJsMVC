using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJsWithMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Age { get; set; }

    }
}