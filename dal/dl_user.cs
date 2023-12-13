using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesEntity;

namespace dal
{
    public class dl_user
    {
        public void creat(user form)
        {
            db db1 = new db();
            db1.user.Add(form);
            db1.SaveChanges();
        }
        public List<user> read()
        {
            db db1 = new db();
           
           return db1.user.ToList();
            
        }
        public user read(string txt)
        {
            db db1 = new db();
            
                var q = (from i in db1.user where i.username == txt select i).Single();
                return q;
 
        }
        public int update( user user)
       {
            db db1 = new db();
            user user1 = new user();
            var q = db1.user.Where(i => i.username == user.username&& user.password == i.password);
            user1= q.Single();
            dl_user dl_user1 = new dl_user();
            user1.user_id = user1.id;
            db1.SaveChanges();
            return user1.id;




       }
        
        
    }
}
