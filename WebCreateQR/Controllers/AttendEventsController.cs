using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCreateQR.Models;

namespace WebCreateQR.Controllers
{
    public class AttendEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AttendEvents
        public ActionResult Index()
        {
            var attendEvents = db.AttendEvents.Include(a => a.Events);
            return View(attendEvents.ToList());
        }

        // GET: AttendEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendEvent attendEvent = db.AttendEvents.Find(id);
            if (attendEvent == null)
            {
                return HttpNotFound();
            }
            return View(attendEvent);
        }

        // GET: AttendEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            return View();
        }

        // POST: AttendEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberId,EventId,email,ticketCount")] AttendEvent attendEvent)
        {
            if (ModelState.IsValid)
            {
                db.AttendEvents.Add(attendEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", attendEvent.EventId);
            return View(attendEvent);
        }

        // GET: AttendEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendEvent attendEvent = db.AttendEvents.Find(id);
            if (attendEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", attendEvent.EventId);
            return View(attendEvent);
        }

        // POST: AttendEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memberId,EventId,email,ticketCount")] AttendEvent attendEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", attendEvent.EventId);
            return View(attendEvent);
        }

        // GET: AttendEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendEvent attendEvent = db.AttendEvents.Find(id);
            if (attendEvent == null)
            {
                return HttpNotFound();
            }
            return View(attendEvent);
        }

        // POST: AttendEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendEvent attendEvent = db.AttendEvents.Find(id);
            db.AttendEvents.Remove(attendEvent);
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

        public ActionResult AttendMobile()
        {
            string name = Request.QueryString["eventName"];
            string id = Request.QueryString["eventId"];
            string location = Request.QueryString["location"];
            string time = Request.QueryString["time"];
            if (name == null || id == null || location == null || time == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.eventName = name;
                ViewBag.time = time;
                List<string> eventList = new List<string>();
                eventList.Add(name);

                int a = int.Parse(id);
                List<int> eventListId = new List<int>();
                eventListId.Add(a);

                ViewBag.EventId = new SelectList(eventList, eventListId);
                return View();
            }
        }

        // POST: AttendEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttendMobile([Bind(Include = "memberId,EventId,email,ticketCount")] AttendEvent attendEvent)
        {
            if (ModelState.IsValid)
            {
                db.AttendEvents.Add(attendEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", attendEvent.EventId);
            return View(attendEvent);
        }
    }
}


