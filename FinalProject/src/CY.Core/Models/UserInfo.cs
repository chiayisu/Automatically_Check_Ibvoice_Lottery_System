using System;
using System.Collections.Generic;
using System.Text;

namespace CY.Core.Models
{
    public class UserInfo
    {

        private string _year;
        private string _month;
        private string _userLotteryNumber;
        public UserInfo() { }
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

        public string UserLotteryNumbernth
        {
            get
            {
                return _userLotteryNumber;
            }
            set
            {
                _userLotteryNumber = value;
            }
        }
    }
}
    

