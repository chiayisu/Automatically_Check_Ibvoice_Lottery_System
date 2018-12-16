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
using CY.Core.Repository;
using CY.Application.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class LotteryNumberController : Controller
    {

        LotteryDataRegularization _lotteryDataRegularization;
        PrizeNumberType _prizeNumber;
        List<string> _prizeNumberList;
        private EFPrizeNumberRepository _eFPrizeNumberRepository;
        PrizeNumberDto _prizeNumberDto;
        IAccesscs _prizeNumberAccess;
        public LotteryNumberController()
        {
            _lotteryDataRegularization = new LotteryDataRegularization();
            _prizeNumber = new PrizeNumberType();
            _prizeNumberList = new List<string>();
            _eFPrizeNumberRepository = new EFPrizeNumberRepository();
            _prizeNumberDto = new PrizeNumberDto();
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index(string year, string month)
        {
            month = _lotteryDataRegularization.regularizeMonth(month);
            bool IsPrizeNumberExist = _eFPrizeNumberRepository.IsDataExist(year, month);
            if (IsPrizeNumberExist)
            {
                _prizeNumberAccess = new AcessDB();
                _prizeNumberList = _prizeNumberAccess.getPrizeNumber(year, month);
                setShowingParameter();
                showPrizeInfo(_prizeNumber);
            }
            else
            {
                _prizeNumberAccess = new AccessWEB();
                _prizeNumberList = _prizeNumberAccess.getPrizeNumber(year, month);
                if (_prizeNumberList != null && _prizeNumberList.Count != 0)
                {
                    _prizeNumberList = _lotteryDataRegularization.regularString(_prizeNumberList);
                    saveData(year, month);
                    setShowingParameter();
                    showPrizeInfo(_prizeNumber);
                }
                else
                {
                    ViewBag.NULL = "請輸入日期資訊。";
                }
            }
            return View();
        }
       [HttpGet]
        public IActionResult CheckLottery()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CheckLottery(PrizeNumberInfo userInfo)
        {
            #region Variable
            LotteryNumberJudgment lotteryNumber;
            List<string> userData;
            Dictionary<string, int> result;
            UserResponse userResponse;
            ResultParsing resultParsing;
            #endregion

            userInfo.Month = _lotteryDataRegularization.regularizeMonth(userInfo.Month);
            bool IsPrizeNumberExist = _eFPrizeNumberRepository.IsDataExist(userInfo.Year, userInfo.Month);
            if (IsPrizeNumberExist)
            {
                _prizeNumberAccess = new AcessDB();
                _prizeNumberList = _prizeNumberAccess.getPrizeNumber(userInfo.Year, userInfo.Month);
            }
            else
            {
                _prizeNumberAccess = new AccessWEB();
                _prizeNumberList = _prizeNumberAccess.getPrizeNumber(userInfo.Year, userInfo.Month);
            }
            if (_prizeNumberList != null && _prizeNumberList.Count != 0)
            {
                _prizeNumberList = _lotteryDataRegularization.regularString(_prizeNumberList);
                userData = new List<string>();
                userData = _lotteryDataRegularization.processUserData(userInfo.LotteryNumberInfo);
                lotteryNumber = new LotteryNumberJudgment(userData);
                result = new Dictionary<string, int>();
                userResponse = new UserResponse();
                result = lotteryNumber.decidePrizeType(_prizeNumberList);
                resultParsing = new ResultParsing();
                userResponse.WonNumbers = resultParsing.getWiningNumber(result);
                userResponse.WonName = resultParsing.getWiningNumberName(result);
                userResponse.LosedNumber = resultParsing.getLosedNumber(userData, result);
                showResult(userResponse);
            }
            return View();
        }

        private void  saveData(string year, string month)
        {
            var IsDataExist = _eFPrizeNumberRepository.IsDataExist(year, month);
            if (!IsDataExist)
            {
                string prizeNumberString = "";
                foreach (var prizeNumber in _prizeNumberList)
                {
                    prizeNumberString += prizeNumber;
                    prizeNumberString += " ";
                }
                _prizeNumberDto.LotteryNumberInfo = prizeNumberString;
                _prizeNumberDto.Year = year;
                _prizeNumberDto.Month = month;
                _eFPrizeNumberRepository.Insert(_prizeNumberDto);
            }
        }

        private void setShowingParameter()
        {
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
        }

        private void showPrizeInfo(PrizeNumberType prizeNumber)
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
