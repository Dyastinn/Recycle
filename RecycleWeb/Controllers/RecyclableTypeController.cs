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
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Add() {
            return View();
        }
        public ActionResult Edit() {
            return View();
        }
        public ActionResult Delete() {
            return View();
        }
    }
}