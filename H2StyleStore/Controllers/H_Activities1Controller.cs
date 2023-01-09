using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using H2StyleStore.Models.EFModels;

namespace H2StyleStore.Controllers
{
    public class H_Activities1Controller : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: H_Activities1
        public ActionResult Index()
        {
            var h_Activities = db.H_Activities.Include(h => h.H_CheckIns);
            return View(h_Activities.ToList());
        }

        // GET: H_Activities1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H_Activities h_Activities = db.H_Activities.Find(id);
            if (h_Activities == null)
            {
                return HttpNotFound();
            }
            return View(h_Activities);
        }

        // GET: H_Activities1/Create
        public ActionResult Create()
        {
            ViewBag.H_Activity_Id = new SelectList(db.H_CheckIns, "CheckIn_H_Id", "CheckIn_H_Id");
            return View();
        }

        // POST: H_Activities1/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "H_Activity_Id,Activity_Name,Activity_Describe,H_Value")] H_Activities h_Activities)
        {
            if (ModelState.IsValid)
            {
                db.H_Activities.Add(h_Activities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.H_Activity_Id = new SelectList(db.H_CheckIns, "CheckIn_H_Id", "CheckIn_H_Id", h_Activities.H_Activity_Id);
            return View(h_Activities);
        }

        // GET: H_Activities1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H_Activities h_Activities = db.H_Activities.Find(id);
            if (h_Activities == null)
            {
                return HttpNotFound();
            }
            ViewBag.H_Activity_Id = new SelectList(db.H_CheckIns, "CheckIn_H_Id", "CheckIn_H_Id", h_Activities.H_Activity_Id);
            return View(h_Activities);
        }

        // POST: H_Activities1/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "H_Activity_Id,Activity_Name,Activity_Describe,H_Value")] H_Activities h_Activities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h_Activities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.H_Activity_Id = new SelectList(db.H_CheckIns, "CheckIn_H_Id", "CheckIn_H_Id", h_Activities.H_Activity_Id);
            return View(h_Activities);
        }

        // GET: H_Activities1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H_Activities h_Activities = db.H_Activities.Find(id);
            if (h_Activities == null)
            {
                return HttpNotFound();
            }
            return View(h_Activities);
        }

        // POST: H_Activities1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            H_Activities h_Activities = db.H_Activities.Find(id);
            db.H_Activities.Remove(h_Activities);
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
