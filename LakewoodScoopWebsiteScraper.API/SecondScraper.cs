using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System.Net;

namespace LakewoodScoopWebsiteScraper.API
{
     public class SecondScraper
    {

        public IEnumerable<NewsStory> GetNewsStories()
        {
            string url = "http://thelakewoodscoop.com/";
            var client = new WebClient();
            client.Headers[HttpRequestHeader.UserAgent] = "what!";
            var html = client.DownloadString(url);
            var parser = new HtmlParser();
            var document = parser.Parse(html);
            var posts = document.QuerySelectorAll(".post");
            return posts.Select(GetStory).Where(p => p != null);
            //var news = new List<NewsStory>();
            //List<NewsStory> stories = new List<NewsStory>();
            //foreach (var p in posts)
            //{
            //    stories.Add(GetStory(p));
            //}
            //return stories;

            //IEnumerable<IElement> posts = document.QuerySelectorAll(".post");
        }
        private NewsStory GetStory(IElement post)
        {
            var story = new NewsStory();
            var h2 = post.QuerySelector("h2");
            if (h2 != null)
            {
                story.Title = h2.TextContent;
            }
            var a = h2.QuerySelector("a");
            if (a != null)
            {
                story.Url = a.Attributes["href"].Value;
            }
            var p = post.QuerySelector("p");
            if (p != null)
            {
                story.Subscript = p.TextContent;
            }
            var image = p.QuerySelector("img");
            if (image != null)
            {
                story.Img = image.Attributes["src"].Value;
            }
            return story;
        }

    }
}
