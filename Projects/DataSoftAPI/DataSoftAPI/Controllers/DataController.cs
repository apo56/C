using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace DataSoftAPI.Controllers
{
    public class DataController : Controller
    {
        WebClient client = new WebClient();
        string adresse = @"https://public.opendatasoft.com/api/records/1.0/search/?dataset=crimes-et-delits-enregistres-par-les-forces-de-securite-en-2016-par-departement&facet=departement&facet=libelle_departement&refine.departement=";


        // GET: Data
        public ActionResult Index()
        {
            //var adresse = @"https://public.opendatasoft.com/api/records/1.0/search/?dataset=crimes-et-delits-enregistres-par-les-forces-de-securite-en-2016-par-departement&facet=departement&facet=libelle_departement&refine.departement=" +NumDepartement;

            var NumDepartement = "";

            var json = client.DownloadString(adresse+ NumDepartement);
            RootObject jsonRootObject = JsonConvert.DeserializeObject<RootObject>(json);

            //jsonRootObject.records.GroupBy(record => record.fields);


            //var jsonRST =jsonRootObject.records.GroupBy(l => l.fields)
            //    .ToList();

            

            return View(jsonRootObject.records);
        }

        // GET: Data/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
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

        // GET: Data/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Data/Edit/5
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

        // GET: Data/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Data/Delete/5
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
