using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;

namespace WebSiteNewsService
{
    public class SubmissionService : Service
    {
        public DataRepository Repo { get; set; }
        public object Any(Submission submission)
        {
            int id = Repo.AddSubmission(submission);
            return new SubmissionResponse() {Id = id};
        }
    }
}