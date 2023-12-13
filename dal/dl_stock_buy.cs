using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesEntity;

namespace dal
{
    public class dl_stock_buy
    {
        public void creat(stock_buy form)
        {
            
            db db1 = new db();
            db1.stock_buy.Add(form);
            db1.SaveChanges();
        }
        public List<stock_buy> read(int user_id)
        {
            db db1 = new db();
            return ((from i in db1.stock_buy where (i.user_id == user_id) orderby i.row ascending select i).ToList());

        }
        public void update(int id, stock_buy newstock_buy)
        {
            
            db db1 = new db();
            var q = db1.stock_buy.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                stock_buy sb = new stock_buy();
                sb = q.Single();
                sb.stock_name = newstock_buy.stock_name;
                sb.date_buy = newstock_buy.date_buy;
                sb.numb_buy = newstock_buy.numb_buy;
                sb.rate_buy = newstock_buy.rate_buy;
                sb.shareholder = newstock_buy.shareholder;
                sb.user_id = newstock_buy.user_id;
                sb.Percentageofwage_buy = newstock_buy.Percentageofwage_buy;
                sb.Percentageofwage_sell = sb.Percentageofwage_sell;
                db1.SaveChanges();
            }
            
        }
        public void update_shareholder(int id, stock_buy newstock_buy)
        {

            db db1 = new db();
            var q = db1.stock_buy.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                stock_buy sb = new stock_buy();
                sb = q.Single();
                sb.shareholder = newstock_buy.shareholder;
                db1.SaveChanges();
            }

        }
        public stock_buy read(int id, int user_id)
        {
            db db1 = new db();
            if ((from i in db1.stock_buy where (i.id == id) && (i.user_id == user_id) select i).Count()!=0)
            {
                return ((from i in db1.stock_buy where (i.id == id) && (i.user_id == user_id) select i).Single());
            }
            return null;
        }
        public void delete(int id, int user_id)
        {
            db db1 = new db();
            var q = db1.stock_buy.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                var z = (from i in db1.stock_buy where i.user_id == user_id && i.id == id select i).Single().row;// شماره ردیف حذفی
                var x = (from i in db1.stock_buy where (i.user_id == user_id) select i.row).Max();// شماره بزرگترین ردیف
                var u = (from e in db1.stock_sell where (e.user_id == user_id) select e).Count();

                db1.stock_buy.Remove(q.Single());
                db1.SaveChanges();

                
                if (u > 1)
                {
                    
                    for (int a = z; a <= x; a++)
                    {
                        stock_buy sb = new stock_buy();
                        var c = (from r in db1.stock_buy where r.user_id == user_id && r.row == a + 1 select r);

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
        public List<stock_buy> read(string txt, int user_id)
        {
            db db1 = new db();
            return (from i in db1.stock_buy where ((i.shareholder == txt ) && (i.user_id==user_id)) orderby i.row ascending select i).ToList();
        }
        
        //__________________________________________________
        public int row_number(int user_id)
        {
            db db1 = new db();
            
            if (db1.stock_buy.Count()!=0 && read(user_id).Count() != 0)
            {
                
                var q = (read(user_id).Max(i => i.row));
                return q;
            }
            return 0; 
        }
        public void rowchange_manfi(int user_id, int id,int newrow)
        {
            db db1 = new db();
            var w = (read(user_id).Max(i => i.row));
            var z = (from i in db1.stock_buy where i.user_id == user_id && i.id == id select i).Single().row;
            for (int i = z; newrow <= i ; i--)
            {
               stock_buy sb = new stock_buy();
                z = i;
                var a = (from o in db1.stock_buy where o.user_id == user_id && o.id != id && o.row == z select o);
                
                if (a.Count() == 1)
                {
                    sb = a.Single();
                    sb.row = z+1 ;
                    db1.SaveChanges();
                    if (i == newrow)
                    {
                        break;

                    }
                }

            }

            
            var q = db1.stock_buy.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                stock_buy sb = new stock_buy();
                sb = q.Single();
                sb.row = newrow;
                db1.SaveChanges();

            }



        }
        public void rowchange_mosbat(int user_id, int id, int newrow)
        {
            db db1 = new db();
            var z = (from i in db1.stock_buy where i.user_id == user_id && i.id == id select i).Single().row;
            for (int i = z; newrow >= i; i++)
            {
                stock_buy sb = new stock_buy();
                z = i;
                var a = (from o in db1.stock_buy where o.user_id == user_id && o.id != id && o.row == z select o);

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


            var q = db1.stock_buy.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                stock_buy sb = new stock_buy();
                sb = q.Single();
                sb.row = newrow;
                db1.SaveChanges();

            }



        }
        public bool exist(string txt, int user_id)
        {
            db db1 = new db();
            if ((from i in db1.stock_buy where (i.shareholder == txt) && (i.user_id == user_id) select i).Count() != 0)
            {
                return true;
            }
            return false;
        }
        public bool exist(int id, int user_id)
        {
            db db1 = new db();
            if ((from i in db1.stock_buy where (i.id == id) && (i.user_id == user_id) select i).Count() != 0)
            {
                return true;
            }
            return false;
        }


    }
}
