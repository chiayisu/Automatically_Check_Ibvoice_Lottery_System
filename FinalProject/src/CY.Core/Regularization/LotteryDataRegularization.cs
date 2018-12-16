using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CY.Core.Regularization
{
    public class LotteryDataRegularization
    {
        private List<string> _userData;
        private List<string> _prizeNumberData;
        public LotteryDataRegularization()
        {
            _userData = new List<string>();
            _prizeNumberData = new List<string>();
        }

        public List<string> processUserData(string userData)
        {
            _userData = userData.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return _userData;
        }

        public List<string> regularString( List<string> dataList)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                _prizeNumberData.Add(dataList[i].Trim());
            }

            return _prizeNumberData;
        }

        public string regularizeMonth(string month)
        {
            if(!string.IsNullOrEmpty(month) && month.Length <2)
            {
                month = "0" + month;
            }
            return month;
        }
    }
}
