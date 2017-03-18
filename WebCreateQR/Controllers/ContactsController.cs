using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCreateQR.Models;
using ZXing;

namespace WebCreateQR.Controllers
{
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,DisplayName,PhoneNumber,EmailAdress")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                db.SaveChanges();
                Bitmap storedQr;
                string qrData = "contact" + "," + @contacts.DisplayName + "," + @contacts.PhoneNumber + "," + @contacts.EmailAdress;
                storedQr = QrCreate(qrData);
                SaveQr();
                return RedirectToAction("Index");
            }

            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,DisplayName,PhoneNumber,EmailAdress")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                Bitmap storedQr;
                string qrData = "contact" + "," + @contacts.DisplayName + "," + @contacts.PhoneNumber + "," + @contacts.EmailAdress;
                storedQr = QrCreate(qrData);
                SaveQr();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacts contacts = db.Contacts.Find(id);
            db.Contacts.Remove(contacts);
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
        //creates the qr
        public Bitmap QrCreate(string qr)
        {
            Bitmap storedQr;
            var writer = new ZXing.BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 400,
                    Width = 400
                }
            };
            storedQr = writer.Write(qr);
            return storedQr;
        }

        public ActionResult SaveQr()
        {
            string name = Server.MapPath("storedQr.bmp");

            return File(name, "image/bmp");

        }
    }
}
