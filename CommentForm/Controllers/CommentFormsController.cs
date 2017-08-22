using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommentForm.Models;

namespace CommentForm.Controllers
{
    public class CommentFormsController : Controller
    {
        private CommentFormContext db = new CommentFormContext();

        // GET: CommentForms
        public ActionResult Index()
        {
            var commentForms = db.CommentForms.Include(c => c.Procedure);
            return View(commentForms.ToList());
        }

        // GET: CommentForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentForms commentForms = db.CommentForms.Find(id);
            if (commentForms == null)
            {
                return HttpNotFound();
            }
            return View(commentForms);
        }

        // GET: CommentForms/Create
        public ActionResult Create()
        {
            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Title");
            return View();
        }

        // POST: CommentForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,Name,Comment,Priority,ProcedureID")] CommentForms commentForms)
        {
            if (ModelState.IsValid)
            {
                db.CommentForms.Add(commentForms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Title", commentForms.ProcedureID);
            return View(commentForms);
        }

        // GET: CommentForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentForms commentForms = db.CommentForms.Find(id);
            if (commentForms == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Title", commentForms.ProcedureID);
            return View(commentForms);
        }

        // POST: CommentForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,Name,Comment,Priority,ProcedureID")] CommentForms commentForms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentForms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProcedureID = new SelectList(db.Procedures, "ProcedureID", "Title", commentForms.ProcedureID);
            return View(commentForms);
        }

        // GET: CommentForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentForms commentForms = db.CommentForms.Find(id);
            if (commentForms == null)
            {
                return HttpNotFound();
            }
            return View(commentForms);
        }

        // POST: CommentForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentForms commentForms = db.CommentForms.Find(id);
            db.CommentForms.Remove(commentForms);
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
