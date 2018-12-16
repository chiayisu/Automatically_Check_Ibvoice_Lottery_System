using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CY.Core.DataParsing;
using HtmlAgilityPack;

namespace CY.Core.Service
{
    public class HtmlService
    {
        private string _html;
        private List<string> _result;
        private HtmlParsing _htmlParsing;
        private List<string> _name;
        private List<string> _value;

        public HtmlService(string html)
        {
            _html = html;
            _result = new List<string>();
            _name = new List<string>();
            _value = new List<string>();
            _htmlParsing = new HtmlParsing();
        }

        public List<string> getPrizeNumber()
        {

            if (!string.IsNullOrEmpty(_html))
            {
                var tableBody = htmlProcessing(_html);
                var trNodeList = tableBody.ChildNodes.ToList();
                processTR(trNodeList);
                _result = processPrizeNumber(_value);
            }
            return _result;
        }

        private HtmlNode htmlProcessing(string html)
        {
            HtmlAgilityPack.HtmlDocument document;
            document = _htmlParsing.LoadData(html);
            var element = _htmlParsing.getElement(document, "tablet01");
            var nodeList = _htmlParsing.getNodeList(element);
            var attribute = _htmlParsing.getAttributeList(nodeList, 3);
            var ownerNode = _htmlParsing.getOwnerNode(attribute, 0);
            nodeList = ownerNode.ChildNodes.ToList();
            var tableBody = nodeList[3];
            return tableBody;
        }

        private void processTR(List<HtmlNode> trNodeLIST)
        {
            foreach (HtmlNode tr in trNodeLIST)
            {
                if (tr.Name == "#text")
                {
                    continue;
                }
                var tableNodeList = tr.ChildNodes.ToList();
                if (tableNodeList.Count == 5)
                    saveValue(tableNodeList);
            }
        }

        void saveValue(List<HtmlNode> tableNodeList)
        {
            foreach (HtmlNode tableNode in tableNodeList)
            {
                if (tableNode.Name == "#text")
                {
                    continue;
                }
                else if (tableNode.Name == "th")
                {
                    _name.Add(tableNode.InnerText);
                }
                else if (tableNode.Name == "td")
                {
                    _value.Add(tableNode.InnerText);
                }
            }
        }

        private List<string> processPrizeNumber(List<string> prizeValue)
        {
            List<string> temp = new List<string>();

            temp.Add(prizeValue[1]);
            temp.Add(prizeValue[2]);
            addToList(ref temp, processNumber(prizeValue[3]));
            addToList(ref temp, processNumber(prizeValue[9]));
            return temp;
        }

        private List<string> processNumber(string str)
        {
            List<string> processedNum = str.Split('、').ToList();
            return processedNum;
        }

        private void addToList(ref List<string> valueList, List<string> value)
        {
            foreach (string number in value)
            {
                valueList.Add(number);
            }
        }
    }
}
