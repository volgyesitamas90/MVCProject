using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.OrmLite;

namespace WebSiteNewsService
{
    public class DataRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }
        public int AddSubmission(Submission request)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.CreateTable<Submission>();
                db.Insert(request);
                return (int) db.GetLastInsertId();
            }
        }

        public List<StoryResponse> GetStory(DateTime storyDateTime)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                var responses = new List<StoryResponse>();
                var submissions = db.Select<Submission>(e => e.SubmissionTime == storyDateTime);
                foreach (Submission submission in submissions)
                {
                    responses.Add(new StoryResponse()
                    {
                        Headline = submission.Headline,
                        StoryDate = submission.SubmissionTime,
                        Id = submission.Id,
                        Body = submission.Body
                    });
                }
                return responses;
            }
        }

        public StoryResponse GetStory(string headline)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                var submission = db.Select<Submission>(e => e.Headline == headline).Last();
                return new StoryResponse()
                {
                    Headline = headline,
                    StoryDate = submission.SubmissionTime,
                    Id = submission.Id,
                    Body = submission.Body
                };
            }
        }
    }
}