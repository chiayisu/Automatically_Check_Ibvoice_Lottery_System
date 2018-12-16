using CY.Core.Regularization;
using CY.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CY.Application.Service
{
    public class AccessWEB:IAccesscs
    {
        private  List<string> result;
        private LotteryDataRegularization _regularization;
        public AccessWEB()
        {
            result = new List<string>();
            _regularization = new LotteryDataRegularization();
        }

        public List<string> getPrizeNumber(string year, string month)
        {
            month = _regularization.regularizeMonth(month);
            string urlAddress = "https://www.etax.nat.gov.tw/etw-main/web/ETW183W2_" +
               year + month + "/";
            WebService webService = new WebService();
            string html = webService.getHTML(urlAddress, Encoding.UTF8);
            if (html != "")
            {
                HtmlService htmlService = new HtmlService(html);
                result = htmlService.getPrizeNumber();
            }
            return result;
        }
    }
}
