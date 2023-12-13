using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinesEntity;
using bll;

namespace Shareholder
{
    public partial class Form_rowchange : Form
    {
       public int user_id;
       public int datagrid_cell_id;
       public int order;
       

        public Form_rowchange()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
            bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
            if (order == 1)
            {
               
                if (int.Parse(textBoxX1.Text) < bl_stock_buy1.read(datagrid_cell_id, user_id).row)
                {
                    bl_stock_buy1.rowchange_manfi(user_id, datagrid_cell_id, int.Parse(textBoxX1.Text));
                }
                else if (int.Parse(textBoxX1.Text) > bl_stock_buy1.read(datagrid_cell_id, user_id).row)
                {
                    bl_stock_buy1.rowchange_mosbat(user_id, datagrid_cell_id, int.Parse(textBoxX1.Text));
                }
            }//tagire radife stock_buy
            if (order == 2)
            {
               
                if (int.Parse(textBoxX1.Text) < bl_stock_sell1.read(datagrid_cell_id, user_id).row)
                {
                    bl_stock_sell1.rowchange_manfi(user_id, datagrid_cell_id, int.Parse(textBoxX1.Text));
                }
                else if (int.Parse(textBoxX1.Text) > bl_stock_sell1.read(datagrid_cell_id, user_id).row)
                {
                    bl_stock_sell1.rowchange_mosbat(user_id, datagrid_cell_id, int.Parse(textBoxX1.Text));
                }
            }//tagire radife stock_sell

            form_home fh = new form_home();
            
           
           
            this.Close();

        }
        private void onlynumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

            // mahdood kardane vroodi textbox be adad

        }

        private void Form_rowchange_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        //public Double fg()
        //{

        //}
        private void Form_rowchange_Load(object sender, EventArgs e)
        {

        }
    }
}
