﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;

namespace Race.Controllers
{
    public class RaceController : Controller
    {
        //private static List<Race> races= new List<Race>();
        private static List<Race> races = new List<Race>;

        // GET: Race
        public ActionResult Index()
        {
            return View();
        }

        // GET: Race/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Race/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Race/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Race/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Race/Edit/5
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

        // GET: Race/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Race/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
