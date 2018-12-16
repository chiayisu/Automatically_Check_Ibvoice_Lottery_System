using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CY.Core.Regularization;
using CY.Core.Service;
using Microsoft.AspNetCore.Mvc;
using CY.Core.Models;
using CY.Core.DataParsing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class LotteryNumberController : Controller
    {

        LotteryDataRegularization _lotteryDataRegularization;
        PrizeNumber _prizeNumber;
        List<string> _prizeNumberList;
        public LotteryNumberController()
        {
            _lotteryDataRegularization = new LotteryDataRegularization();
            _prizeNumber = new PrizeNumber();
            _prizeNumberList = new List<string>();
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index(string year, string month)
        {

            getPrizeNumberList(year, month);
            if (_prizeNumberList != null && _prizeNumberList.Count != 0)
            {
                _prizeNumberList = _lotteryDataRegularization.regularString(_prizeNumberList);
                _prizeNumber.SpecialPrize = _prizeNumberList[0];
                _prizeNumber.GrandPrize = _prizeNumberList[1];
                _prizeNumber.FirstPrize = new List<string>();
                _prizeNumber.AddtionalSixthPrize = new List<string>();
                for (int i = 2; i < 5; i++)
                {
                    _prizeNumber.FirstPrize.Add(_prizeNumberList[i]);
                }
                for (int i = 5; i < _prizeNumberList.Count; i++)
                {
                    _prizeNumber.AddtionalSixthPrize.Add(_prizeNumberList[i]);
                }
                showPrizeInfo(_prizeNumber);
            }
            else
            {
                ViewBag.NULL = "請輸入日期資訊。";
            }
            return View();
        }
       [HttpGet]
        public IActionResult CheckLottery()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CheckLottery(UserInfo userInfo)
        {
            #region Variable
            LotteryNumberJudgment lotteryNumber;
            List<string> userData;
            Dictionary<string, int> result;
            UserResponse userResponse;
            ResultParsing resultParsing;
            #endregion

            getPrizeNumberList(userInfo.Year, userInfo.Month);
            if (_prizeNumberList != null && _prizeNumberList.Count != 0)
            {
                _prizeNumberList = _lotteryDataRegularization.regularString(_prizeNumberList);
                userData = new List<string>();
                userData = _lotteryDataRegularization.processUserData(userInfo.UserLotteryNumbernth);
                lotteryNumber = new LotteryNumberJudgment(userData);
                result = new Dictionary<string, int>();
                userResponse = new UserResponse();
                result = lotteryNumber.decidePrizeType(_prizeNumberList);
                resultParsing = new ResultParsing();
                userResponse.WonNumbers= resultParsing.getWiningNumber(result);
                userResponse.WonName = resultParsing.getWiningNumberName(result);
                userResponse.LosedNumber = resultParsing.getLosedNumber(userData, result);
                showResult(userResponse);
            }
            return View();
        }

        private void getPrizeNumberList(string year, string month)
        {
            month = _lotteryDataRegularization.regularizeMonth(month);
            string urlAddress = "https://www.etax.nat.gov.tw/etw-main/web/ETW183W2_" +
               year + month + "/";
            WebService webService = new WebService();
            string html = webService.getHTML(urlAddress, Encoding.UTF8);
            if (html != "")
            {
                HtmlService htmlService = new HtmlService(html);
                _prizeNumberList = htmlService.getPrizeNumber();
            }
        }

        private void showPrizeInfo(PrizeNumber prizeNumber)
        {
            ViewBag.SpecialPrize = prizeNumber.SpecialPrize;
            ViewBag.GrandPrize = prizeNumber.GrandPrize;
            ViewBag.FirstPrizes = prizeNumber.FirstPrize;
            ViewBag.AdditionSixthPrizes = prizeNumber.AddtionalSixthPrize;
        }

        private void showResult(UserResponse response)
        {
            ViewBag.WonNumbers = response.WonNumbers;
            ViewBag.WonNames = response.WonName;
            ViewBag.LosedNumbers = response.LosedNumber;
        }

 
    }
}
