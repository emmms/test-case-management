using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCaseManagementApp.Models;

namespace TestCaseManagementApp.Controllers
{
    public class TestStepController : Controller
    {
        private TestDBContext db = new TestDBContext();

        public ActionResult TestSteps(int id)
        {
            ViewBag.TestCaseID = id;
            var testStep = from tc in db.TestSteps
                           where tc.TestCaseID == id
                           orderby tc.StepNumber
                           select tc;
            return PartialView(testStep);
        }

        // GET: TestStep/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: TestStep/Create
        [HttpPost]
        public ActionResult Create(TestStep ts)
        {
            try
            {
                db.TestSteps.Add(ts);
                db.SaveChanges();
                return RedirectToAction("Details", "TestCase", new { id = ts.TestCaseID });
            }
            catch
            {
                return View();
            }
        }

        // GET: TestStep/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestStep/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestStep/Delete/5
        public ActionResult Delete(int id)
        {
            var ts = db.TestSteps.Single(m => m.TestStepID == id);
            return Delete(ts);
        }

        // POST: TestStep/Delete/5
        [HttpPost]
        public ActionResult Delete(TestStep ts)
        {
            try
            {
                db.TestSteps.Remove(ts);
                db.SaveChanges();
                return RedirectToAction("Details", "TestCase", new { id = ts.TestCaseID });
            }
            catch
            {
                return View();
            }
        }
    }
}
