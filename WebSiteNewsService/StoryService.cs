using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;

namespace WebSiteNewsService
{
    public class StoryService : Service
    {
        public DataRepository Repo { get; set; }
        public object Any(Story request)
        {
            return Repo.GetStory(request.StoryDate);
        }
    }
}