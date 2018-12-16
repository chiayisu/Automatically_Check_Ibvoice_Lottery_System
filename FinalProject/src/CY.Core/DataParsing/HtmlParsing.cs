using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace CY.Core.DataParsing
{
    public class HtmlParsing
    {
        public HtmlDocument LoadData(string html)
        {
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            return document;
        }

        public HtmlNode getElement(HtmlDocument doc, string id)
        {
            var element = doc.GetElementbyId(id);
            return element;
        }

        public List<HtmlNode> getNodeList(HtmlNode node)
        {
            return node.ChildNodes.ToList();
        }

        public List<HtmlAttribute> getAttributeList(List<HtmlNode> nodeList, int index)
        {
            return nodeList[index].Attributes.ToList();
        }

        public HtmlNode getOwnerNode(List<HtmlAttribute> attributeList, int index)
        {
            return attributeList[index].OwnerNode;
        }
    }
}
