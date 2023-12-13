using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesEntity
{
    public class stock_buy
    {

        public int id { get; set; }
        /// <summary>
        ///ردیف
        /// </summary>
        public int row { get; set; }
        /// <summary>
        /// نام سهم
        /// </summary>
        public string stock_name { get; set; }
        /// <summary>
        /// تاریخ خرید سهام
        /// </summary>
        public string date_buy { get; set; }
        /// <summary>
        /// تعداد خرید
        /// </summary>
        public Int64 numb_buy { get; set; }
        /// <summary>
        /// نرخ خرید
        /// </summary>
        public Int64 rate_buy { get; set; }
        /// <summary>
        /// کارمزد خرید
        /// </summary>
        public Int64 wage_buy { get { return (Int64)((numb_buy * rate_buy)* Percentageofwage_buy); } set { } }
        /// <summary>
        /// قیمت تمام شده خرید
        /// </summary>
        public Int64 fp_buy { get { return (numb_buy * rate_buy) + (wage_buy); } set { } }
        /// <summary>
        /// درصد کارمزد خرید
        /// </summary>
        public Double Percentageofwage_buy { get; set; }
        /// <summary>
        /// درصد کارمزد فروش
        /// </summary>
        public Double Percentageofwage_sell { get; set; }
        /// <summary>
        /// نقطه سر به سر فروش
        /// </summary>
        public Double price_BEP
        {
            get
            {
                for (Double i = 0.1D; i < 1500000; i += 0.1D)
                {

                   
                    if (0 == (Int64)(i - (Double)rate_buy - (((Double)rate_buy * (Double)Percentageofwage_buy) + (i * (Double)Percentageofwage_sell))))
                    {
                        return Math.Ceiling(i) + 2;
                    }

                }
                return 0;
            }
            set { }
        }
        /// <summary>
        /// صاحب سهم
        /// </summary>
        public string shareholder { get; set; }
        /// <summary>
        /// صاحب سهم
        /// </summary>
        public human human { get; set; }
        public int user_id { get; set; }
    }
}
