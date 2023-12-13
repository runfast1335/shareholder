using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using BusinesEntity;


namespace bll
{
    public class bl_user
    {
        dl_user dl_user1 = new dl_user();
        public List<user> read()
        {
            
           return dl_user1.read();
        }
        public bool user_check(user form)
        {
            //تایید هویت ورود به نرم افزار
            var q = from i in dl_user1.read() select i;
            foreach (var item in q)
            {
              
               if ( form.password == item.password && form.username == item.username)
               {
                    
                    return true;
               }
                
                
            }
            return false;
        }
        public void creat(user form)
        {
            bl_user bl_user1 = new bl_user();
                if (bl_user1.exist_username(form)==false)
                {

                    dl_user1.creat(form);

                }
        }
        public user read(string txt)
        {
            return dl_user1.read(txt);
        }
        public int update(user user)
        {
           return dl_user1.update(user);
        }
        public bool exist_username(user form)
        {
            if (dl_user1.read()!=null)
            {
                var q = from i in dl_user1.read() where i.username == form.username select i;
                if (q.Count() == 1)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
