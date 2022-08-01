using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;
using System.IO;

namespace Elearn.Controllers
{
    public class LecturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lectures
        public ActionResult Index()
        {
            var videos = db.Videos.Include(l => l.Playlist);
            return View(videos.ToList());
        }

        // GET: Lectures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Videos.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // GET: Lectures/Create
        public ActionResult Create(int ID)
        {
           
            ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name");
            Lecture lecture = new Lecture();
            lecture.PlaylistId = ID;
            return PartialView(lecture);
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Lecture lecture, HttpPostedFileBase VideoFile)
        {
            if (ModelState.IsValid)
            {
                if (VideoFile != null)
                {
                    string name = Path.GetFileName(VideoFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Videoes"), name);
                    VideoFile.SaveAs(path);
                    lecture.VideoFile = name;
                }
                db.Videos.Add(lecture);
                db.SaveChanges();
                 
                return RedirectToAction("Details", "playlists",new { id = lecture.PlaylistId });
            }
         
             return View(lecture);
        }

        // GET: Lectures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Videos.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", lecture.PlaylistId);
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaylistId = new SelectList(db.Playlists, "Id", "Name", lecture.PlaylistId);
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Videos.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecture lecture = db.Videos.Find(id);
            db.Videos.Remove(lecture);
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
