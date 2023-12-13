using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesEntity;
using dal;

namespace bll
{
    public class bl_stock_sell
    {
        dl_stock_sell dl_stock_sell1 = new dl_stock_sell();
        public void creat(stock_sell form)
        {
            dl_stock_sell1.creat(form);
        }
        public List<stock_sell> read(int user_id)
        {
            return dl_stock_sell1.read( user_id);
        }
        public List<stock_sell> read(string txt, int user_id)
        {
            return dl_stock_sell1.read(txt, user_id);
        }
        public void update(int id, stock_sell stock_sell)
        {
            dl_stock_sell1.update(id, stock_sell);
        }
        public void delete(int id, int user_id)
        {
            dl_stock_sell1.delete(id, user_id);
        }
        public stock_sell read(int id, int user_id)
        {
            return dl_stock_sell1.read(id, user_id);
        }
        public void update_shareholder(int id, stock_sell stock_sell)
        {

            dl_stock_sell1.update_shareholder(id, stock_sell);

        }
        public void deleteshareholder(int buy_id)
        {
            dl_stock_sell1.deleteshareholder(buy_id);
        }
        //________________________________________________________________
        public int row_number(int user_id)
        {
            return dl_stock_sell1.row_number(user_id);
        }
        public void rowchange_manfi(int user_id, int id, int newrow)
        {
            dl_stock_sell1.rowchange_manfi(user_id, id, newrow);
        }
        public void rowchange_mosbat(int user_id, int id, int newrow)
        {
            dl_stock_sell1.rowchange_mosbat(user_id, id, newrow);
        }

    }
}
