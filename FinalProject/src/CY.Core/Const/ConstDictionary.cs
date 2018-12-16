using System;
using System.Collections.Generic;
using System.Text;
using CY.Core.Const;

namespace CY.Core.Const
{
    public  class ConstDictionary
    {
        private Dictionary<int, string> _mapDictionary;
        public ConstDictionary()
        {
            _mapDictionary = new Dictionary<int, string>();
            addDictionary();
        }
        public string getStringPrizeType(int prizeType)
        {
            string stringPrizeType = "";
            stringPrizeType = _mapDictionary[prizeType];
            return stringPrizeType;
        }

        private void addDictionary()
        {
            _mapDictionary.Add(PrizeTypeDefinition.firstPrize, PrizeTypeReturnDefinition.firstPrize);
            _mapDictionary.Add(PrizeTypeDefinition.fivePrize, PrizeTypeReturnDefinition.fivePrize);
            _mapDictionary.Add(PrizeTypeDefinition.fourPrize, PrizeTypeReturnDefinition.fourPrize);
            _mapDictionary.Add(PrizeTypeDefinition.grandPrize, PrizeTypeReturnDefinition.grandPrize);
            _mapDictionary.Add(PrizeTypeDefinition.sixPrize, PrizeTypeReturnDefinition.sixPrize);
            _mapDictionary.Add(PrizeTypeDefinition.specialPrize, PrizeTypeReturnDefinition.specialPrize);
            _mapDictionary.Add(PrizeTypeDefinition.threePrize, PrizeTypeReturnDefinition.threePrize);
            _mapDictionary.Add(PrizeTypeDefinition.twoPrize, PrizeTypeReturnDefinition.twoPrize);
        }
    }
}
