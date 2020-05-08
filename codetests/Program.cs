using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace codetests
{
    class Program
    {
        private const string ChannelTag = "channel";
        private const string TitleTag = "title";
        private const string LinkTag = "link";
        private const string ItemTag = "item";
        private const string DescriptionTag = "description";
        private const string PublishDateTag = "pubDate";
        private const string CategoryTag = "category";
        private readonly string feedUrl;

        static void Main(string[] args)
        {
            var url = @"feed.txt";
            XmlDocument developerNewsXml = new XmlDocument();
            developerNewsXml.Load(url);

            var channel = developerNewsXml.SelectSingleNode("//channel");
            var title = channel.SelectSingleNode(TitleTag);
            var link = channel.SelectSingleNode(LinkTag);

            var itemNodes = channel.SelectNodes(ItemTag);
            foreach (XmlNode item in itemNodes)
            {
                var itemTitle = item.SelectSingleNode(TitleTag).InnerText;
                var itemLink = item.SelectSingleNode(LinkTag).InnerText;
                var itemDescription = item.SelectSingleNode(DescriptionTag).InnerText;
                var itemPublishDate = item.SelectSingleNode(PublishDateTag).InnerText;
                var itemCategory = item.SelectSingleNode(CategoryTag).InnerText;
            }
        }
    }
}
