using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Scraping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RegexOptions options = RegexOptions.None;
            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;
            HtmlDocument Doc = website.Load("http://ourairports.com/data/");

            var section = Doc.DocumentNode.Descendants("dl").First().Descendants("dt");

            foreach(var d in section)
            {
                //string searchWord = "modified ";
                var spanText = d.Descendants("span").First().InnerText;
                var url = d.Descendants("a").First().Attributes["href"].Value;

                var datetimeinString = spanText.Substring(spanText.Length - 13, 12);
                Regex regex = new Regex("[ ]{2,}", options);
                string time = regex.Replace(datetimeinString, " ");
                Console.WriteLine(datetimeinString);
                DateTime updatedAt = DateTime.ParseExact(time, "MMM d, yyyy", null);

                Console.WriteLine(updatedAt);
                Console.WriteLine(url);
            }
            
        }
    }
}
