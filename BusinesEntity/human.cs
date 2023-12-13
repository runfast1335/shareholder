using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinesEntity
{
    public class human
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string fullname { get { return name +" " +family; } set { } }
        public int user_id { get; set; }


    }
}
