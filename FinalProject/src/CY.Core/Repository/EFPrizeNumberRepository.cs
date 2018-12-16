using CY.Core.DataBase;
using CY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CY.Core.Repository
{
    public class EFPrizeNumberRepository
    {
        private PrizeNumberDbContext PrizeNumberDbContext { get; set; }
        public EFPrizeNumberRepository()
        {
            PrizeNumberDbContext = new PrizeNumberDbContext();
        }
        public void Insert(PrizeNumberDto item)
        {
            PrizeNumberDbContext.InvoiceLottery.Add(item);
            PrizeNumberDbContext.SaveChanges();
        }

        public string Select(string year, string month)
        {

            var result = new PrizeNumberDto();
           var query = PrizeNumberDbContext.InvoiceLottery.AsQueryable();
            var temp = query.Where(x => x.Year == year && x.Month == month).ToList();
            if (temp.Count > 0 && temp != null)
                result = temp[0];
            return result.LotteryNumberInfo;
        }

        public bool IsDataExist(string year, string month)
        {
            bool IsExist =false;
            var result = new List<PrizeNumberDto>();
            var query = PrizeNumberDbContext.InvoiceLottery.AsQueryable();
            result = query.Where(x => x.Year == year && x.Month == month).ToList();
            if (result.Count > 0)
                IsExist = true;
            return IsExist;

        }
    }
}
