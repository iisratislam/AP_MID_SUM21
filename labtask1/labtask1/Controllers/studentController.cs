using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using labtask1.Models;

using labtask1.Models.database;

namespace labtask1.Controllers
{
    public class studentController : Controller
    {
        private database database;

        public ActionResult Index()
        {
            database db = new database();
            var students = db.students.GetAll();
            return View(students);
        }

     public ActionResult create()
        {
            student s = new student();
            return View(s);
        }
        [HttpPost]
        public ActionResult create(student s)
        {
            database db = new database();
            db.students.Insert(s);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id )
        {
            database db= new database();
            var s = db.students.Get(id);

            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(student s)
        {
            
            database db = new database();
            db.students.update(s);
            return RedirectToAction("index");
        }
        public ActionResult delete(student s)
        {

            database db = new database();
            db.students.delete(s);
            return RedirectToAction("index");
        }



    }
}