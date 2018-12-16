using System;
using System.Collections.Generic;
using System.Text;
using CY.Core.Models;

namespace CY.Application.Service
{
    public interface IAccesscs
    {
        List<string> getPrizeNumber(string year, string month);
    }
}
