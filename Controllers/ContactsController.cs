using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGTUTelephone;

namespace UGTUTelephone.Controllers
{
    public class ContactsController : Controller
    {
        private KadrRealTestEntities db = new KadrRealTestEntities();

        // GET: Contacts
        public ActionResult Index(int search)
        {
           
            return View(db.DepContacts.Where(x =>x.ID == search ).ToList());
        }

        public JsonResult GetLocation()
        {
            using (KadrRealTestEntities dc = new KadrRealTestEntities())
            {
                dc.Configuration.ProxyCreationEnabled = false;
                var v = dc.Locations.OrderBy(a => a.Title).ToList();
                return new JsonResult { Data = v, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepContact depContact = db.DepContacts.Find(id);
            if (depContact == null)
            {
                return HttpNotFound();
            }
            return View(depContact);
        }

        // GET: Contacts/Create
        public ActionResult Create(int idd, string isdp)
        {
            Session["id"] = idd;
            Session["isdp"] = isdp;
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Phone,IP_Phone,Email,Address,lat,long,IsDep")] DepContact depContact)
        {
            if (ModelState.IsValid)
            {
                db.DepContacts.Add(depContact);
                db.SaveChanges();

                return RedirectToAction("Index", "DeptEmploes");
            }

            return View(depContact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepContact depContact = db.DepContacts.Find(id);
            if (depContact == null)
            {
                return HttpNotFound();
            }
            return View(depContact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Phone,IP_Phone,Email,Address,lat,long")] DepContact depContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depContact).State = EntityState.Modified;
                db.SaveChanges();
                //TempData["Msg"] = "Данные были успешно обновлены";

                return RedirectToAction("Index","DeptEmploes");
            }
            return View(depContact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepContact depContact = db.DepContacts.Find(id);
            if (depContact == null)
            {
                return HttpNotFound();
            }
            return View(depContact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepContact depContact = db.DepContacts.Find(id);
            db.DepContacts.Remove(depContact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       


    }
}
