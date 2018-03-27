using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API;
using Newtonsoft.Json;

namespace DataSoftAPI.Controllers
{
    public class RecordController : Controller
    {

        WebClient client = new WebClient();
        string adresse = @"https://public.opendatasoft.com/api/records/1.0/search/?dataset=crimes-et-delits-enregistres-par-les-forces-de-securite-en-2016-par-departement&facet=departement&facet=libelle_departement&refine.departement=";


        public ActionResult SelectDep()
        {
            


            return View();
        }

        // GET: Record
        public ActionResult Index(string Departement)
        {
            //adresse = (Departement.HasValue) ? adresse : adresse + (string) Departement;

            string adresse="";
            //string adresse = "";
            if (Departement.Length==0)
            {
                adresse = @"https://public.opendatasoft.com/api/records/1.0/search/?dataset=crimes-et-delits-enregistres-par-les-forces-de-securite-en-2016-par-departement&facet=departement&facet=libelle_departement&refine.departement=35";

            }
            else
            {
                adresse = @"https://public.opendatasoft.com/api/records/1.0/search/?dataset=crimes-et-delits-enregistres-par-les-forces-de-securite-en-2016-par-departement&facet=departement&facet=libelle_departement&refine.departement="+Departement;
            }

            var json = client.DownloadString(adresse);
            var obj = JsonConvert.DeserializeObject<RootObject>(json);

            //Record listRecord  obj.records.ToList();

            var listField = obj.records.Select(m => m.fields.GetName()).ToList();

            
            return View(obj.records);
        }

        // GET: Record/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Record/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Record/Create
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

        // GET: Record/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Record/Edit/5
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

        // GET: Record/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Record/Delete/5
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
