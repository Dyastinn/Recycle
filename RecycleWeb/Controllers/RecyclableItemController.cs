using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleWeb.Controllers
{
    
    public class RecyclableItemController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: RecyclableItem
        public ActionResult List() {
            var ItemList = _db.RecyclableItems.ToList();
            return View(ItemList);
        }

        [HttpGet]
        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RecyclableItem item) {

            _db.RecyclableItems.Add(item);
            _db.SaveChanges();
 
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var item = _db.RecyclableItems.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(RecyclableItem item) {
            var data = _db.RecyclableItems.Where(x => x.Id == item.Id).FirstOrDefault();
            if(data != null) {
                data.Weight = item.Weight;
                data.RecyclableTypeId = item.RecyclableTypeId;
                data.ItemDescription = item.ItemDescription;
                data.ComputedRate = item.ComputedRate;
                _db.SaveChanges();
            }
            return RedirectToAction("List");


        }



        public ActionResult Delete(int id) {
            var data = _db.RecyclableItems.Where(x => x.Id == id).FirstOrDefault();
            _db.RecyclableItems.Remove(data);
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}