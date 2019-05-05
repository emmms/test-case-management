using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCaseManagementApp.Models;

namespace TestCaseManagementApp.Controllers
{
    public class TestCaseController : Controller
    {
        private TestDBContext db = new TestDBContext();
        // GET: TestCase
        public ActionResult List()
        {
            var testCase = from tc in db.TestCases
                           orderby tc.TestCaseID
                           select tc;
            return View(testCase);
        }

        // GET: TestCase/Details/5
        public ActionResult Details(int id)
        {
            var tc = db.TestCases.Single(t => t.TestCaseID == id);
            return View(tc);
        }

        public ActionResult TestSteps(int id)
        {
            ViewBag.TestCaseID = id;
            var testStep = from tc in db.TestSteps
                           where tc.TestCaseID == id
                           orderby tc.StepNumber
                           select tc;
            return View(testStep);
        }

        // GET: TestCase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestCase/Create
        [HttpPost]
        public ActionResult Create(TestCaseModel testCase)
        {
            try
            {
                db.TestCases.Add(testCase);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestCase/Edit/5
        public ActionResult Edit(int id)
        {
            var testCase = db.TestCases.Single(m => m.TestCaseID == id);
            return View(testCase);
        }

        // POST: TestCase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TestCaseModel testCase)
        {
            try
            {
                var tc = db.TestCases.Single(m => m.TestCaseID == id);
                if (TryUpdateModel(tc))
                {
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
                return View(tc);
            }
            catch
            {
                return View();
            }
        }

        // GET: TestCase/Delete/5
        public ActionResult Delete(int id)
        {
            var tc = db.TestCases.Single(m => m.TestCaseID == id);
            return Delete(tc);
        }

        // POST: TestCase/Delete/5
        [HttpPost]
        public ActionResult Delete( TestCaseModel testCase)
        {
            try
            {
                db.TestCases.Remove(testCase);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
