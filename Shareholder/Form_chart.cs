using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bll;
using BusinesEntity;


namespace Shareholder
{
    
    public partial class Form_chart : Form
    {
       public List <stock_buy> q = new List <stock_buy>(); 
       public int user_id;
       public string shareholder_selected;

       

        private void Form1_Load(object sender, EventArgs e)
        {
            bl_human blh = new bl_human();
            comboBoxEx1.DataSource = blh.read(user_id);
            comboBoxEx1.DisplayMember = "fullname";
            comboBoxEx1.ValueMember = "id";
            foreach (var item in blh.read(user_id))
            {
                if (item.fullname == shareholder_selected)
                {
                    comboBoxEx1.SelectedValue = item.id;
                }
            }

            for (int i = 0; i < q.Count; i++)
            {
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                chart1.Series[0].Points.AddXY(q[i].stock_name + " " + (((double)q[i].fp_buy * (double)100) / ((double)bl_stock_buy1.total_fp_buy_byshareholder(shareholder_selected, user_id))).ToString("N2") + "%", q[i].fp_buy);

            }
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            
        }

        private void read_fullname(object sender, EventArgs e)
        {
            bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
            if ((bl_stock_buy1.read(((human)(comboBoxEx1.SelectedItem)).fullname, user_id)).Count <= 0)
            {
                MessageBox.Show(" سهامی برای نمایش در نمودار ندارد " + ((human)(comboBoxEx1.SelectedItem)).fullname);
            }
            else
            {
                List<human> null1 = new List<human>();
                chart1.Series[0].Points.Clear();
                var q1 = bl_stock_buy1.read(((human)(comboBoxEx1.SelectedItem)).fullname, user_id);
                for (int i = 0; i < q1.Count; i++)
                {

                    chart1.Series[0].Points.AddXY(q1[i].stock_name + " "+ (((double)q1[i].fp_buy * (double)100) / ((double)bl_stock_buy1.total_fp_buy_byshareholder(((human)(comboBoxEx1.SelectedItem)).fullname,user_id))).ToString("N2") +"%", q1[i].fp_buy);

                }
                chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            }
           
           


        }
        public Form_chart()
        {
            InitializeComponent();
        }
    }
}
