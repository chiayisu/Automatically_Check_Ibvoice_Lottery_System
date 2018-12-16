using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CY.Core.Models;
using CY.Core.Const;

namespace CY.Core.DataBase
{
    public class PrizeNumberDbContext:DbContext
    {
        private string _prizeNumberDB;
        public PrizeNumberDbContext() : base()
        {
            _prizeNumberDB = ConnectionString.PrizeNumberDb;
        }
        public DbSet<PrizeNumberDto> InvoiceLottery { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_prizeNumberDB);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
