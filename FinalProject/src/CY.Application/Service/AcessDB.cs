using CY.Core.Regularization;
using CY.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CY.Application.Service
{
    public class AcessDB:IAccesscs
    {
        private List<string> result;
        private EFPrizeNumberRepository _EFPrizeNumberRepository;
        LotteryDataRegularization regularization;
        public AcessDB()
        {
            result = new List<string>();
            _EFPrizeNumberRepository = new EFPrizeNumberRepository();
            regularization = new LotteryDataRegularization();
        }

        public List<string> getPrizeNumber(string year, string month)
        {
            string temp = _EFPrizeNumberRepository.Select(year, month);
            result = regularization.processDBData(temp);
            return result;
        }
        
    }
}
