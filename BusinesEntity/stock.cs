using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesEntity
{
    public class stock
    {
        public int id { get; set; }
        /// <summary>
        /// صاحب سهم
        /// </summary>
        public human human { get; set; }
        /// <summary>
        ///ردیف
        /// </summary>
        public int row { get; set; }
        /// <summary>
        /// نام سهم
        /// </summary>
        public int stock_name { get; set; }
        /// <summary>
        /// تاریخ خرید سهام
        /// </summary>
        public int date_buy { get; set; }
        /// <summary>
        /// تعداد خرید
        /// </summary>
        public int numb_buy { get; set; }
        /// <summary>
        /// نرخ خرید
        /// </summary>
        public int rate_buy { get; set; }
        /// <summary>
        /// کارمزد خرید
        /// </summary>
        public int wage_buy { get; set; }
        /// <summary>
        /// قیمت تمام شده خرید
        /// </summary>
        public int fp_buy { get; set; }
        /// <summary>
        /// درصد کارمزد خرید
        /// </summary>
        public int Percentageofwage_buy { get; set; }
        /// <summary>
        /// تاریخ فروش
        /// </summary>
        public int date_sell { get; set; }
        /// <summary>
        /// قیمت فروش هر واحد
        /// </summary>
        public int unitprice_sell { get; set; }
        /// <summary>
        /// کرمزد فروش
        /// </summary>
        public int wage_sell { get; set; }
        /// <summary>
        /// درصد کارمزد فروش
        /// </summary>
        public int Percentageofwage_sell { get; set; }
        /// <summary>
        /// فروش کل
        /// </summary>
        public int fp_sell { get; set; }


    }
}
