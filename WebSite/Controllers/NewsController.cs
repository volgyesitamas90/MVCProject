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
    public class NewsController : Controller
    {
        //
        // GET: /News/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /News/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /News/Create
        [HttpPost]
        public ActionResult Create(NewsStory newsStory)
        {
            try
            {
                var service = new JsonServiceClient("http://localhost:59068/");
                service.Send<SubmissionResponse>(new Submission()
                {
                    Body = newsStory.Text,
                    Headline = newsStory.Headline,
                    SubmissionTime = newsStory.Date
                });
               
                // retrieve
                var storyResponse = service.Post<StoryResponse>("story", new Story() {Headline = newsStory.Headline});
                ViewBag.Headline = storyResponse.Headline;
                ViewBag.Date = storyResponse.StoryDate;
                ViewBag.Body = storyResponse.Body;
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

        //
        // GET: /News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /News/Edit/5
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

        //
        // GET: /News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /News/Delete/5
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
