using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EDASampleProject.Models;

namespace EDASampleProject.Controllers
{
    public class OfficeInfoController : Controller
    {
        private StaffDBContext db = new StaffDBContext();

        // GET: OfficeInfo
        public ActionResult Index()
        {
            return View(db.staff01office_info.ToList());
        }
        public ActionResult Viewall()
        {
            return View(db.staff01office_info.ToList());
        }

        public void saveFile(staff01office_info staff01office_info)
        {

            /*Get file name, add datetime.now to avoid duplicate file name, 
           * save file path with new filename, 
           * and save image in the Images folder */
            string filename = Path.GetFileNameWithoutExtension(staff01office_info.ImageUpload.FileName);
            string extension = Path.GetExtension(staff01office_info.ImageUpload.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            staff01office_info.staff01image_path = "~/Appfiles/Images/" + filename;
            staff01office_info.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Appfiles/Images/"), filename));
        }

        // GET: OfficeInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff01office_info staff01office_info = db.staff01office_info.Find(id);
            if (staff01office_info == null)
            {
                return HttpNotFound();
            }
            return View(staff01office_info);
        }

        // GET: OfficeInfo/Create
        public ActionResult AddStaff()
        {
            staff01office_info staff01Office_Info = new staff01office_info();
            return View(staff01Office_Info); 
        }

        // POST: OfficeInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStaff([Bind(Include = "staff01uin,staff01name,staff01position,staff01depart,staff01salary,staff01image_path")] staff01office_info staff01office_info)
        {
            try

            {
                if (staff01office_info.ImageUpload != null)
                {
                    saveFile(staff01office_info);
                }

                db.staff01office_info.Add(staff01office_info);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        ModelState.AddModelError("", string.Format("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage));
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View(staff01office_info);
        }

        // GET: OfficeInfo/Edit/5
        public ActionResult EditStaff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff01office_info staff01office_info = db.staff01office_info.Find(id);
            if (staff01office_info == null)
            {
                return HttpNotFound();
            }
            return View(staff01office_info);
        }

        // POST: OfficeInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStaff([Bind(Include = "staff01uin,staff01name,staff01position,staff01depart,staff01salary,staff01image_path")] staff01office_info staff01office_info)
        {
            if (staff01office_info.ImageUpload != null)
            {
                saveFile(staff01office_info);
            }

            if (ModelState.IsValid)
            {
                db.Entry(staff01office_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff01office_info);
        }

        // GET: OfficeInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff01office_info staff01office_info = db.staff01office_info.Find(id);
            if (staff01office_info == null)
            {
                return HttpNotFound();
            }
            return View(staff01office_info);
        }

        // POST: OfficeInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            staff01office_info staff01office_info = db.staff01office_info.Find(id);
            db.staff01office_info.Remove(staff01office_info);
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
