using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeThi_WAD.Models;

namespace DeThi_WAD.Controllers
{
    public class ContactController : Controller
        
    {
        private DataContext context = new DataContext();
        // GET: Contact
        public ActionResult Contact()
        {
            var list = context.Contacts.ToList();
        
            return View(list);  // parse sing model category
            
        }
    }
}