using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeThi_WAD.Models
{
    public class Contact
    {
        [Key]
        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        public string GroupName { get; set; }

        public string HireDate { get; set; }

        public string Birthday { get; set; }
    }
}