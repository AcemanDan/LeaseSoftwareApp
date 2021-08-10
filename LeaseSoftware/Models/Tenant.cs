using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeaseSoftware.Models
{
public class Tenant
{
        public int Id { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required, Phone, DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = "{0:999-999-9999}")]
        public string Phone { get; set; }

        [Required]
        public string Company { get; set; }

        [Required, Phone, DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = "{0:999-999-9999}"),
            Display(Name = "Business Phone")]
        public string BusinessPhone { get; set; }

        
    }
}
