using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesEntity
{
    public class user:human 
    {
       
        public string username { get; set; }
        public string password { get; set; }
        public bool gender { get; set; }
        public byte age { get; set; }
        public int kodemelli { get; set; }
        public int mobile { get; set; }
        public string email { get; set; }

    }
}
