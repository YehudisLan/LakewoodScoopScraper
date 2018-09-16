using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LakewoodScoopWebsiteScraper.API;

namespace LakewoodScoopWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var scraper = new SecondScraper();
            return View(scraper.GetNewsStories());
        }
    }
}