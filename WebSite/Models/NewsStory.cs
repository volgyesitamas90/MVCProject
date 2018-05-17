using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class NewsStory
    {
        public DateTime Date { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
    }
}