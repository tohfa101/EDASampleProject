using EDASampleProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EDASampleProject.Controllers
{
    public class StaffController : Controller
    {
        private StaffDBContext db = new StaffDBContext();

        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Viewall()
        {
            return View(db.staff01office_info.ToList());
        }

        IEnumerable<staff01office_info> GetAllStaff01Office_Info()
        {
            return db.staff01office_info.ToList<staff01office_info>();
            
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

        [HttpGet]
        public ActionResult AddStaff()
        {
            staff01office_info staff01Office_Info = new staff01office_info();
            return View(staff01Office_Info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStaff(staff01office_info staff01office_info)
        {
            try

            {
                if(staff01office_info.ImageUpload != null)
                { /*Get file name, add datetime.now to avoid duplicate file name, 
                   * save file path with new filename, 
                   * and save image in the Images folder */
                    string filename = Path.GetFileNameWithoutExtension(staff01office_info.ImageUpload.FileName);
                    string extension = Path.GetExtension(staff01office_info.ImageUpload.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    staff01office_info.staff01image_path = "~/Appfiles/Images/" + filename;
                    staff01office_info.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Appfiles/Images/"), filename));

                }
                
                db.staff01office_info.Add(staff01office_info);
                db.SaveChanges();
                
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Viewall", GetAllStaff01Office_Info()), message = "Added Successfully" }, JsonRequestBehavior.AllowGet);
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
                return RedirectToAction("Index");
                //return Json(new { success = false, html = GlobalClass.RenderRazorViewToString(this, "Viewall", GetAllStaff01Office_Info()), message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return View(staff01office_info);
        }
        [HttpGet]
        public ActionResult EditStaff(int Id)
        {
            using (StaffDBContext db = new StaffDBContext())
            {
                staff01office_info staff01Office_Info = db.staff01office_info.ToList<staff01office_info>().Where(x => x.staff01uin == Id).FirstOrDefault();
                return View(staff01Office_Info);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStaff( staff01office_info staff01office_info)
        {
            try

            {
                if (ModelState.IsValid)
                {
                    if (staff01office_info.ImageUpload != null)
                    { /*Get file name, add datetime.now to avoid duplicate file name, 
                   * save file path with new filename, 
                   * and save image in the Images folder */
                        string filename = Path.GetFileNameWithoutExtension(staff01office_info.ImageUpload.FileName);
                        string extension = Path.GetExtension(staff01office_info.ImageUpload.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                        staff01office_info.staff01image_path = "~/Appfiles/Images/" + filename;
                        staff01office_info.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Appfiles/Images/"), filename));

                    }
                    db.Entry(staff01office_info).State = EntityState.Modified;
                    db.SaveChanges();
                }                    
                 
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Viewall", GetAllStaff01Office_Info()), message = "Edited Successfully" }, JsonRequestBehavior.AllowGet);
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
                return RedirectToAction("Index");
                //return Json(new { success = false, html = GlobalClass.RenderRazorViewToString(this, "Viewall", GetAllStaff01Office_Info()), message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return View(staff01office_info);
        }

        // POST: OfficeInfo/Delete/5

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                staff01office_info staff01office_info = db.staff01office_info.Find(id);
                db.staff01office_info.Remove(staff01office_info);
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Viewall", GetAllStaff01Office_Info()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
                //return Json(new { success = false, html = GlobalClass.RenderRazorViewToString(this, "Viewall", GetAllStaff01Office_Info()), message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult AdditionDetail(int Id = 0)
        //{
        //    staff02personal_info staff02 = new staff02personal_info();
        //    if (Id != 0)
        //    {
        //        staff02 = db.staff02personal_info.Where(x => x.staff02uin == Id).FirstOrDefault();
        //    }
        //        return View("_AdditionDetailNew", staff02);
        //}
    }    
}