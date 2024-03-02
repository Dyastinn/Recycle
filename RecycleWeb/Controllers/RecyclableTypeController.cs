using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleWeb.Controllers
{
    public class RecyclableTypeController : Controller
    {
        // GET: Recycle
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: RecyclableType
        public ActionResult List() {
            var TypeList = _db.RecyclableTypes.ToList();
            return View(TypeList);
        }

        [HttpGet]
        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RecyclableType item) {
            if (item.MinKg >= item.MaxKg) {
                ModelState.AddModelError("MaxKg", "Max weight must be greater than Min weight.");
                return View(item);
            }

            _db.RecyclableTypes.Add(item);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var item = _db.RecyclableTypes.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(RecyclableType item) {
            if (item.MinKg >= item.MaxKg) {
                ModelState.AddModelError("MaxKg", "Max weight must be greater than Min weight.");
                return View(item);
            }

            var data = _db.RecyclableTypes.Where(x => x.Id == item.Id).FirstOrDefault();
            if (data != null) {
                data.Type = item.Type;
                data.Rate = item.Rate;
                data.MinKg = item.MinKg;
                data.MaxKg = item.MaxKg;
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }



        public ActionResult Delete(int id) {
            var recyclableType = _db.RecyclableTypes.Find(id);

            if (recyclableType == null) {
                return HttpNotFound();
            }
            var associatedItems = _db.RecyclableItems.Where(item => item.RecyclableTypeId == id);

            _db.RecyclableItems.RemoveRange(associatedItems);

            _db.RecyclableTypes.Remove(recyclableType);

            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}