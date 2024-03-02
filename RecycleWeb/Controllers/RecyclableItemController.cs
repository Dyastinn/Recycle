using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleWeb.Controllers
{
    
    public class RecyclableItemController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();


        public ActionResult List() {
            var ItemList = _db.RecyclableItems.ToList();

            return View(ItemList);
        }

        [HttpGet]
        public ActionResult Add() {
            var TypeList = _db.RecyclableTypes.ToList();
            ViewBag.TypesList = new SelectList(TypeList, "Id", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult Add(RecyclableItem item) {

            var recyclableType = _db.RecyclableTypes.Find(item.RecyclableTypeId);


            if (item.Weight < recyclableType.MinKg || item.Weight > recyclableType.MaxKg) {
                ModelState.AddModelError("Weight", "Weight must be within the Minimum Kg ("+recyclableType.MinKg+ ") and Maxaximum Kg ("+recyclableType.MaxKg+") range.");
                var TypeList = _db.RecyclableTypes.ToList();
                ViewBag.TypesList = new SelectList(TypeList, "Id", "Type");
                return View(item);
            }

            if (ModelState.IsValid) {

                item.ComputedRate = recyclableType.Rate * item.Weight;


                _db.RecyclableItems.Add(item);
                _db.SaveChanges();

                return RedirectToAction("List"); 
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var item = _db.RecyclableItems.Where(x => x.Id == id).FirstOrDefault();
            var TypeList = _db.RecyclableTypes.ToList();
            ViewBag.TypesList = new SelectList(TypeList, "Id", "Type");
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(RecyclableItem item) {
            var data = _db.RecyclableItems.Where(x => x.Id == item.Id).FirstOrDefault();

            var recyclableType = _db.RecyclableTypes.Find(item.RecyclableTypeId);

            if (item.Weight < recyclableType.MinKg || item.Weight > recyclableType.MaxKg) {
                ModelState.AddModelError("Weight", "Weight must be within the Minimum Kg (" + recyclableType.MinKg + ") and Maxaximum Kg (" + recyclableType.MaxKg + ") range.");
                var TypeList = _db.RecyclableTypes.ToList();
                ViewBag.TypesList = new SelectList(TypeList, "Id", "Type");
                return View(item);
            }

            if (ModelState.IsValid && data != null) {

                item.ComputedRate = recyclableType.Rate * item.Weight;

                data.Weight = item.Weight;
                data.RecyclableTypeId = item.RecyclableTypeId;
                data.ItemDescription = item.ItemDescription;
                data.ComputedRate = item.ComputedRate;
                _db.SaveChanges();

                return RedirectToAction("List"); 
            }
            return View();
        }

        public ActionResult GetRateData(int id) {
            var type = _db.RecyclableTypes.FirstOrDefault(t => t.Id == id);
            if (type != null) {
                ViewBag.ratetype = type.Rate;
            }
            return View();
        }



        public ActionResult Delete(int id) {
            var data = _db.RecyclableItems.Where(x => x.Id == id).FirstOrDefault();
            _db.RecyclableItems.Remove(data);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        #region API CALLS

        [HttpGet]
        public ActionResult GetAll() {
            _db.Configuration.ProxyCreationEnabled = false;
            List<RecyclableItem> objItemList = _db.RecyclableItems.ToList();
            return Json(new { data = objItemList }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}