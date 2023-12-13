using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesEntity;

namespace dal
{
    public class dl_stock_sell
    {
        public void creat(stock_sell form)
        {

            db db1 = new db();
            db1.stock_sell.Add(form);
            db1.SaveChanges();
        }
        public List<stock_sell> read(int user_id)
        {
            db db1 = new db();
            return ((from i in db1.stock_sell where (i.user_id == user_id) orderby i.row ascending select i).ToList());

        }
        public List<stock_sell> read(string txt, int user_id)
        {
            db db1 = new db();
            return (from i in db1.stock_sell where (i.shareholder == txt && i.user_id == user_id) select i).ToList();
        }
        public void update(int id, stock_sell newstock_sell)
        {

            db db1 = new db();
            var q = db1.stock_sell.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                stock_sell ss = new stock_sell();
                ss = q.Single();
                ss.numb_sell = newstock_sell.numb_sell;
                ss.rate_sell = newstock_sell.rate_sell;
                ss.Percentageofwage_sell = newstock_sell.Percentageofwage_sell;
                ss.date_sell = newstock_sell.date_sell;
                ss.shareholder = newstock_sell.shareholder;
                ss.date_buy = newstock_sell.date_buy;
                ss.Percentageofwage_buy = newstock_sell.Percentageofwage_buy;
                db1.SaveChanges();
            }

        }
        public void update_shareholder(int id, stock_sell newstock_sell)
        {

            db db1 = new db();
            var q = db1.stock_sell.Where(i => i.buy_id == id);
            if (q.Count() == 1)
            {
                stock_sell sb = new stock_sell();
                sb = q.Single();
                sb.shareholder = newstock_sell.shareholder;
                db1.SaveChanges();
            }

        }
        public void delete(int id,int user_id)
        {
            db db1 = new db();
            var q = db1.stock_sell.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                var z = (from i in db1.stock_sell where i.user_id == user_id && i.id == id select i).Single().row;// شماره ردیف حذفی
                var x = (from i in db1.stock_sell where (i.user_id == user_id) select i.row).Max();// شماره بزرگترین ردیف
                var u = (from e in db1.stock_sell where (e.user_id == user_id) select e).Count();

                db1.stock_sell.Remove(q.Single());
                db1.SaveChanges();
                
                if (u>1 )
                {
                    
                    for (int a = z; a <= x; a++)
                    {
                        stock_sell sb = new stock_sell();
                        int t = a + 1;
                        var c = (from o in db1.stock_sell where o.user_id == user_id && o.row == t select o);

                        if (c.Count() == 1)
                        {
                            sb = c.Single();
                            sb.row = a;
                            db1.SaveChanges();
                            if (a == x)
                            {
                                break;

                            }
                        }
                    }
                }
                

                
            }
        }
        public void deleteshareholder(int buy_id)
        {
            db db1 = new db();
            var q = db1.stock_sell.Where(i => i.buy_id == buy_id);
            if (q.Count() == 1)
            {
                db1.stock_sell.Remove(q.Single());
                db1.SaveChanges();
            }
        }
        public stock_sell read(int id, int user_id)
        {
            db db1 = new db();
            return ((from i in db1.stock_sell where (i.id == id) && (i.user_id == user_id) select i).Single());
            
        }
        //__________________________________________________
        public int row_number(int user_id)
        {
            db db1 = new db();

            if (db1.stock_sell.Count() != 0 && read(user_id).Count() != 0)
            {
                var q = (read(user_id).Max(i => i.row));
                return q;
            }
            return 0;
        }
        public void rowchange_manfi(int user_id, int id, int newrow)
        {
            db db1 = new db();
            var z = (from i in db1.stock_sell where i.user_id == user_id && i.id == id select i).Single().row;
            for (int i = z; newrow <= i; i--)
            {
                stock_sell sb = new stock_sell();
                z = i;
                var a = (from o in db1.stock_sell where o.user_id == user_id && o.id != id && o.row == z select o);

                if (a.Count() == 1)
                {
                    sb = a.Single();
                    sb.row = z + 1;
                    db1.SaveChanges();
                    if (i == newrow)
                    {
                        break;

                    }
                }

            }


            var q = db1.stock_sell.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                stock_sell sb = new stock_sell();
                sb = q.Single();
                sb.row = newrow;
                db1.SaveChanges();

            }



        }
        public void rowchange_mosbat(int user_id, int id, int newrow)
        {
            db db1 = new db();
            var z = (from i in db1.stock_sell where i.user_id == user_id && i.id == id select i).Single().row;
            for (int i = z; newrow >= i; i++)
            {
                stock_sell sb = new stock_sell();
                z = i;
                var a = (from o in db1.stock_sell where o.user_id == user_id && o.id != id && o.row == z select o);

                if (a.Count() == 1)
                {
                    sb = a.Single();
                    sb.row = z - 1;
                    db1.SaveChanges();
                    if (i == newrow)
                    {
                        break;

                    }
                }

            }


            var q = db1.stock_sell.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                stock_sell sb = new stock_sell();
                sb = q.Single();
                sb.row = newrow;
                db1.SaveChanges();

            }



        }
        
    }
}
