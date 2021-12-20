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