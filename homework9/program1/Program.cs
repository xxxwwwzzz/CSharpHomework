using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace program1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl1 = "http://www.cnblogs.com/dstang2000/";
            string startUrl2 = "https://www.imooc.com/learn/122";
            if (args.Length >= 1) startUrl1 = args[0];
            if (args.Length >= 1) startUrl2 = args[1];
            myCrawler.urls.Add(startUrl1, false);
            myCrawler.urls.Add(startUrl2, false);
            //new Thread(myCrawler.Crawl()).Start();
            Parallel.Invoke(new Action[]{
                    ()=> myCrawler.Crawl(startUrl1),
                    ()=> myCrawler.Crawl(startUrl2)});
        }
        private void Crawl(string starturl)
        {
            Console.WriteLine("开始爬行了....");
            while(true)
            {
                string current = null;
                current = starturl;
                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面！");
                string html = DownLoad(current);
                urls[current] = true;
                count++;
                Parse(html);
            }
            Console.WriteLine("爬行结束");
            Thread.Sleep(2000);
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(herf|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=')+ 1).Trim('"','\','#','','>'));
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
