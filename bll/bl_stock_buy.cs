using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesEntity;
using dal;

namespace bll
{
    public class bl_stock_buy
    {
        dl_stock_buy dl_stock_buy1 = new dl_stock_buy();
        public void creat(stock_buy form)
        {
            dl_stock_buy1.creat(form);
        }
        public List<stock_buy> read(int user_id)
        {
            return dl_stock_buy1.read(user_id);
        }
        public int row_number(int user_id)
        {
            return dl_stock_buy1.row_number(user_id);
        }
        public void update(int id, stock_buy stock_buy)
        {
            dl_stock_buy1.update(id, stock_buy);
        }
        public stock_buy read(int id, int user_id)
        {
            return dl_stock_buy1.read(id, user_id);
        }
        public void delete(int id, int user_id)
        {
            dl_stock_buy1.delete(id, user_id);
        }
        public List<stock_buy> read(string txt, int user_id)
        {
            return dl_stock_buy1.read( txt, user_id);
        }
        public void rowchange_manfi(int user_id, int id, int newrow)
        {
            dl_stock_buy1.rowchange_manfi(user_id,id, newrow);
        }
        public void rowchange_mosbat(int user_id, int id, int newrow)
        {
            dl_stock_buy1.rowchange_mosbat(user_id, id, newrow);
        }
        public long total_fp_buy_byshareholder( string txt,  int user_id)
        {
            
            return (dl_stock_buy1.read(txt, user_id).Sum((i) => i.fp_buy));

        }//جمع ستون قیمت خرید
        public long total_fp_buy( int user_id)
        {

            return (dl_stock_buy1.read( user_id).Sum((i) => i.fp_buy));

        }//جمع ستون قیمت خرید
        public void update_shareholder(int id, stock_buy newstock_buy)
        {

            dl_stock_buy1.update_shareholder(id, newstock_buy);

        }
        public bool exist(string txt, int user_id)
        {
            return dl_stock_buy1.exist(txt,user_id);
        }
        public bool exist(int id, int user_id)
        {
            return dl_stock_buy1.exist(id, user_id);
        }

    }
}
