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
    public partial class form_login : Form
    {
        public int user_id;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            bl_user bl_user1 = new bl_user();
            user user1 = new user();
            user1.username = textBoxX1.Text;
            user1.password = textBoxX2.Text;
            if (bl_user1.read() == null)
            {
                MessageBox.Show("نام کاربری یا رمز ورود اشتباه است");
            }
            else if (bl_user1.user_check(user1) )
            {
                user_id = bl_user1.update(user1);
                form_home fhome = new form_home();
                fhome.user_id= user_id;
                this.Hide();
                fhome.Show();
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمز ورود اشتباه است");
            }
            

        }
        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    bl_user bl_user1 = new bl_user();
                    user user1 = new user();
                    user1.username = textBoxX1.Text;
                    user1.password = textBoxX2.Text;
                    if (bl_user1.read() == null)
                    {
                        MessageBox.Show("نام کاربری یا رمز ورود اشتباه است");
                    }
                    else if (bl_user1.user_check(user1))
                    {
                        user_id = bl_user1.update(user1);
                        form_home fhome = new form_home();
                        fhome.user_id = user_id;
                        this.Hide();
                        fhome.Show();
                    }
                    else
                    {
                        MessageBox.Show("نام کاربری یا رمز ورود اشتباه است");
                    }
                }


            }
        }
        private void form_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            
        }
        public form_login()
        {
            InitializeComponent();
        }

        private void labelX3_Click(object sender, EventArgs e)
        {
            form_register fregister = new form_register();
            this.Hide();
            fregister.Show();
        }

        private void form_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }
       //public double a()
       // {
       //     for (Double i = 0.1D; i < 1000000; i += 0.1D)
       //     {


       //         double rate_buy = 8985;
       //         double Percentageofwage_buy = 0.00464;
       //         double Percentageofwage_sell = 0.00975;
       //         if (0 == (Int64)(i - (Double)rate_buy - (((Double)rate_buy * (Double)Percentageofwage_buy) + (i * (Double)Percentageofwage_sell))))
       //         {
                    
       //             return Math.Ceiling(i)+2 ;
       //         }

       //     }
       //     return 0;
       // }
        private void form_login_Load(object sender, EventArgs e)
        {
            
           
           // MessageBox.Show(a().ToString());
        }

        private void labelX3_MouseMove(object sender, MouseEventArgs e)
        {
            labelX3.ForeColor = Color.Red;
        }

        private void labelX3_MouseLeave(object sender, EventArgs e)
        {
            labelX3.ForeColor = Color.Black;
        }
    }
}
