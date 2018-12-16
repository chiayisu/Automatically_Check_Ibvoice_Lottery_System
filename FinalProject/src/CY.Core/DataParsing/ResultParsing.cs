using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CY.Core.Const;

namespace CY.Core.DataParsing
{
    public class ResultParsing
    {
        List<string> _winingNumber;
        List<string> _winingNumberName;
        List<string> _losedNumber;
        ConstDictionary _constDict;

        public ResultParsing()
        {
            _winingNumber = new List<string>();
            _winingNumberName = new List<string>();
            _losedNumber = new List<string>();
            _constDict = new ConstDictionary();
        }

        public List<string> getWiningNumber(Dictionary<string,int> data)
        {
            foreach(var item in data)
            {
                _winingNumber.Add(item.Key);
            }
            return _winingNumber;
        }

        public List<string> getWiningNumberName(Dictionary<string, int> data)
        {
            foreach (var item in data)
            {
                _winingNumberName.Add(_constDict.getStringPrizeType(item.Value));
            }
            return _winingNumberName;
        }

        public List<string> getLosedNumber(List<string> userData, Dictionary<string, int> winedNumber)
        {
           foreach(var data in userData)
            {
                if (!winedNumber.ContainsKey(data))
                {
                    _losedNumber.Add(data);
                }
            }
            return _losedNumber;
        }
    }
}
