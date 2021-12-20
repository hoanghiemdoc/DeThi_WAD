using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DeThi_WAD.Models;


namespace DeThi_WAD.Controllers
{
    public class ContactController : Controller
        
    {
        private DataContext context = new DataContext();
        private object db;

        // GET: Contact
        public ActionResult Contact()
        {
            var list = context.Contacts.ToList();
        
            return View(list);  // parse sing model category
            
        }

        // search form contact
        [HttpGet]
        public async Task<ActionResult> Contact(string Empsearch)
        {
            ViewData["Getemployeedetails"] = Empsearch;
            var empquery = from x in context.Contacts select x;
            if (!string.IsNullOrEmpty(Empsearch))
            {
                empquery = empquery.Where(x => x.ContactName.Contains(Empsearch) || x.ContactNumber.Contains(Empsearch) || x.GroupName.Contains(Empsearch)  || x.Birthday.Contains(Empsearch) || x.HireDate.Contains(Empsearch));
            }

            return View(await empquery.AsNoTracking().ToListAsync());
        }


        public ActionResult Create()
        {
          

            return View();  // parse sing model category

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                // khi dữ liệu gửi lên thỏa mãn yêu cầu (yêu cầu theo Model) -> lưu vào DB
                context.Contacts.Add(contact);
                context.SaveChanges();

                return RedirectToAction("Contact");
            }
            return View(contact);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            // Dựa vào id để tìm category
            Contact contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // khong can phai goi ben edit o edit.cshtml vi mo hinh mvc da co
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View(contact);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Contact contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Contact");
        }

    }
}