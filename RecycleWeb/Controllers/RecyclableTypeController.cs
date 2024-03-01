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

            _db.RecyclableTypes.Add(item);
            _db.SaveChanges();
 
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var item = _db.RecyclableTypes.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(RecyclableType item) {
            var data = _db.RecyclableTypes.Where(x => x.Id == item.Id).FirstOrDefault();
            if(data != null) {
                data.Type = item.Type;
                data.Rate = item.Rate;
                data.MinKg = item.MinKg;
                data.MaxKg = item.MaxKg;
                _db.SaveChanges();
            }
            return RedirectToAction("List");


        }



        public ActionResult Delete(int id) {
            var data = _db.RecyclableTypes.Where(x => x.Id == id).FirstOrDefault();
            _db.RecyclableTypes.Remove(data);
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}