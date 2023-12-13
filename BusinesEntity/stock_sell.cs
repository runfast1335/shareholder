using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesEntity
{
    public class stock_sell
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
        public Int64 wage_buy { get { return (Int64)((numb_buy * rate_buy) * Percentageofwage_buy); } set { } }
        /// <summary>
        /// قیمت تمام شده خرید
        /// </summary>
        public Int64 fp_buy { get { return (numb_buy * rate_buy) + (wage_buy); } set { } }
        /// <summary>
        /// درصد کارمزد خرید
        /// </summary>
        public Double Percentageofwage_buy { get; set; }
        /// <summary>
        /// تاریخ فروش
        /// </summary>
        public string date_sell { get; set; }
        /// <summary>
        /// قیمت فروش هر واحد
        /// </summary>
        public Int64 rate_sell { get; set; }
        /// <summary>
        /// تعداد فروش
        /// </summary>
        public Int64 numb_sell { get; set; }
        /// <summary>
        /// کارمزد فروش
        /// </summary>
        public Int64 wage_sell { get { return (Int64)((numb_sell * rate_sell) * Percentageofwage_sell); } set { } }
        /// <summary>
        /// درصد کارمزد فروش
        /// </summary>
        public Double Percentageofwage_sell { get; set; }
        /// <summary>
        /// فروش کل
        /// </summary>
        public Int64 fp_sell { get { return (numb_sell * rate_sell) - (wage_sell); } set { } }
        /// <summary>
        /// سود یا زیان
        /// </summary>
        public Int64 ProfitORloss { get { return ((fp_sell) - ((numb_sell * rate_buy) + ((Int64)((numb_sell * rate_buy) * Percentageofwage_buy)))); } set { } }
        /// <summary>
        /// صاحب سهم
        /// </summary>
        public string shareholder { get; set; }
        /// <summary>
        /// صاحب سهم
        /// </summary>
        public human human { get; set; }
        public int user_id { get; set; }
        public int buy_id { get; set; }
    }
}
