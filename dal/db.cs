using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusinesEntity;


namespace dal
{
    public class db : DbContext
    {
        public db() : base("conect") { }
        public DbSet<user> user { get; set; }
        public DbSet<human> human { get; set; }
        public DbSet<stock_buy> stock_buy { get; set; }
        public DbSet<stock_sell> stock_sell { get; set; }
        
    }
}
