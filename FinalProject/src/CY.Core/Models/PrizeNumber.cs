using System;
using System.Collections.Generic;
using System.Text;

namespace CY.Core.Models
{
    public class PrizeNumber
    {
        private string _specialPrize;
        private string _grandPrize;
        private List<string> _firstPrize;
        private List<string> _addtionalSixthPrize;
        public PrizeNumber() { }
        public string SpecialPrize
        {
            get
            {
                return _specialPrize;
            }
            set
            {
                _specialPrize = value;
            }
        }

        public string GrandPrize
        {
            get
            {
                return _grandPrize;
            }
            set
            {
                _grandPrize = value;
            }
        }

        public List<string> FirstPrize
        {
            get
            {
                return _firstPrize;
            }
            set
            {
                _firstPrize = value;
            }
        }

        public List<string> AddtionalSixthPrize
        {
            get
            {
                return _addtionalSixthPrize;
            }
            set
            {
                _addtionalSixthPrize = value;
            }
        }



    }
}
