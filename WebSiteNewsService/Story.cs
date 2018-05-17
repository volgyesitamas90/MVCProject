using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace WebSiteNewsService
{
    [Route("/Story")]
    public class Story
    {
        public string Headline { get; set; }
        public DateTime StoryDate { get; set; }
    }

    public class StoryResponse
    {
        public int Id { get; set; }
        public DateTime StoryDate { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }
    }
}