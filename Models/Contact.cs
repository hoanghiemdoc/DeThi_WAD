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

        public int Id { get; set; }

        // validate form
        [Required(ErrorMessage = "Vui lòng nhập ten")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập so")]
        public int ContactNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập gropuName")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngay thue")]
        public string HireDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngay sinh")]
        public string Birthday { get; set; }
    }
}