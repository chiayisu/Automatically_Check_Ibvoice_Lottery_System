using System;
using System.Collections.Generic;
using System.Text;

namespace CY.Core.Models
{
    public class PrizeNumberDto
    {
        private int _id;
        private string _year;
        private string _month;
        private string _lotteryNumberInfo;
        public PrizeNumberDto() { }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }

        public string Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
            }
        }

        public string LotteryNumberInfo
        {
            get
            {
                return _lotteryNumberInfo;
            }
            set
            {
                _lotteryNumberInfo = value;
            }
        }
    }
}
