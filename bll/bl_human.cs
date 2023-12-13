using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using BusinesEntity;

namespace bll
{
    public class bl_human
    {
        dl_human dl_human1 = new dl_human();
        public void creat(human form)
        {
           dl_human1.creat(form);
        }
        public List<human> read(int user_id)
        {
           return dl_human1.read(user_id);
        }
        public human read(int id, int user_id)
        {
            return dl_human1.read(id, user_id);

        }
        public void update(int id, human human1)
        {

            dl_human1.update(id, human1);

        }
        public void delete(int id)
        {
            dl_human1.delete(id);
        }
    }
}
