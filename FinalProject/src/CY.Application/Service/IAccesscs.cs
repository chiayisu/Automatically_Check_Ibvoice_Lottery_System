using System;
using System.Collections.Generic;
using System.Text;
using CY.Core.Models;

namespace CY.Application.Service
{
    public interface IAccesscs
    {
        List<PrizeNumberDto> getPrizeNumber(string year, string month);
    }
}
