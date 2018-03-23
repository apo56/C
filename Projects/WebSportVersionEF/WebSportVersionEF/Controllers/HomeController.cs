using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSportVersionEF.Models;

namespace WebSportVersionEF.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();

        public ActionResult RemoveAllDatas()
        {
            try
            {
                db.RemoveAllDatas();
            }
            catch (Exception e)
            {
                return Redirect("https://stackoverflow.com/search?q=[c#]" + e.Message);
            }
            
            return Index();
        }

        public ActionResult GenerateFakes()
        {
            try
            {
                db.GenerateFakesData();
            }
            catch (Exception e)
            {
                return Redirect("https://stackoverflow.com/search?q=[c#]" + e.Message);
            }
            
            return Index();
        }

        public ActionResult Index()
        {
            
            var vm = new ResumeVM()
            {
                NbRaces = db.Races.Count(),
                NbCompetitors = db.Competitors.Count(),
                NbOrganizers = db.Organizers.Count(),
                LastCompts = db.Competitors.OrderByDescending(c => c.Id).Take(5).ToList(),
                LastOrgs = db.Organizers.OrderByDescending(c => c.Id).Take(5).ToList(),
                LastRaces = db.Races.OrderByDescending(c => c.Id).Take(5).ToList()
            };
            return View(vm);
        }

        public FileContentResult UserImage()
        {
            ViewBag.Message = "Your application description page.";
            var webClient = new WebClient();
            
            var imageData = webClient.DownloadData("https://robohash.org/"+ Faker.Name.FirstName() + "?bgset=bg" + new Random().Next(1,3));
            var contentType = "image/jpeg";
            //Image image = (Bitmap)((new ImageConverter()).ConvertFrom(imageData));

            //ViewBag.image = image;

            return File(imageData, contentType);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}