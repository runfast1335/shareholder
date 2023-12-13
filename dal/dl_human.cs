using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesEntity;

namespace dal
{
   public class dl_human
    {
        public void creat(human form)
        {
            db db1 = new db();
            db1.human.Add(form);
            db1.SaveChanges();
            
        }
        public List<human> read(int user_id)
        {
            db db1 = new db();
          
            return ((from i in db1.human where i.user_id == user_id select i ).ToList());
            
                
        }
        public human read(int id, int user_id)
        {
            db db1 = new db();
            if ((from i in db1.human where (i.id == id) && (i.user_id == user_id) select i).Count() != 0)
            {
                return ((from i in db1.human where (i.id == id) && (i.user_id == user_id) select i).Single());
            }
            return null;
        }
        public void update(int id, human human1)
        {

            db db1 = new db();
            var q = db1.human.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                human sb = new human();
                sb = q.Single();
                sb.name = human1.name;
                sb.family = human1.family;

                db1.SaveChanges();
            }

        }
        public void delete(int id)
        {
            db db1 = new db();
            var q = db1.human.Where(i => i.id == id);
            if (q.Count() == 1)
            {

                db1.human.Remove(q.Single());
                db1.SaveChanges();
            }
        }

        //_____________________________internal________________________________


    }
}
