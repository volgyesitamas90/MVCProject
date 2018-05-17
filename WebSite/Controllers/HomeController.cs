using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.ServiceClient.Web;
using WebSite.Models;
using WebSiteNewsService;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Msg = "Hello World";
            return View();
        }

        public ActionResult UnderConstruction()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult News()
        {
            var service = new JsonServiceClient("http://localhost:59068/");
            var storyResponses = service.Post<List<StoryResponse>>("story",
                new Story() {StoryDate = new DateTime(2013, 10, 20)});
            ViewBag.Stories = storyResponses;
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contactModel)
        {
            if (SendMail(contactModel))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

        private bool SendMail(ContactModel model)
        {
            return true;
        }

    }
}