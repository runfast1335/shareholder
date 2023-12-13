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
    public partial class form_register : Form
    {
        int g;
        bl_user bl_user1 = new bl_user();

        private void buttonX1_Click(object sender, EventArgs e)
        {
            user user2 = new user();
            user2.username = (textBoxX8.Text);

            if (textBoxX7.Text != textBoxX9.Text)
            {
                MessageBox.Show("رمز عبور را یکسان وارد کنید");
                textBoxX7.Clear();
                textBoxX9.Clear();
                textBoxX9.Focus();
            }
            else if (textBoxX3.Text.Length != 10)
            {
                MessageBox.Show("کد ملی صحیح وارد نشده");
                textBoxX3.Focus();
            }
            else if (textBoxX4.Text.Length != 11)
            {
                MessageBox.Show("شماره موبایل صحیح وارد نشده");
                textBoxX4.Focus();
            }
            else if ((textBoxX5.Text.Contains("@") && textBoxX5.Text.Contains(".")) != true)
            {
                MessageBox.Show("ایمیل صحیح وارد نشده");
                textBoxX5.Focus();
            }
            else if (textBoxX7.Text.Length < 8)
            {
                MessageBox.Show("پسورد باید بیشتر از 8 حرف باشد");
                textBoxX7.Focus();
            }
            else if (textBoxX9.Text.Length < 8)
            {
                MessageBox.Show("پسورد باید بیشتر از 8 حرف باشد");
                textBoxX9.Focus();
            }
            else if (textBoxX1.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا نام خود را وارد نمایید");
                textBoxX1.Focus();
            }
            else if (textBoxX2.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا فامیلی خود را وارد نمایید");
                textBoxX2.Focus();
            }
            else if (textBoxX3.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا کد ملی خود را وارد نمایید");
                textBoxX3.Focus();
            }
            else if (textBoxX4.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا شماره موبایل خود را وارد نمایید");
                textBoxX4.Focus();
            }
            else if (textBoxX5.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا ایمیل خود را وارد نمایید");
                textBoxX5.Focus();
            }
            else if (textBoxX6.Text.Trim().Length == 0 && byte.Parse(textBoxX6.Text) > 150)
            {
                MessageBox.Show("لطفا سن خود را وارد نمایید");
                textBoxX6.Focus();
            }
            else if (textBoxX7.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا تکرار پسورد خود را وارد نمایید");
                textBoxX7.Focus();
            }
            else if (textBoxX8.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا نام کاربری خود را وارد نمایید");
                textBoxX8.Focus();
            }
            else if (textBoxX9.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا  پسورد خود را وارد نمایید");
                textBoxX9.Focus();
            }
            else if (bl_user1.exist_username(user2))
            {

                MessageBox.Show("لطفا از نام کاربری دیگری استفاده کنید");
                textBoxX8.Focus();
            }
            else
            {

                user user1 = new user();
                user1.age = byte.Parse(textBoxX6.Text);
                user1.email = (textBoxX5.Text);
                user1.family = (textBoxX2.Text);
                user1.kodemelli = (textBoxX3.Text);
                user1.mobile = (textBoxX4.Text);
                user1.name = (textBoxX1.Text);
                user1.password = (textBoxX9.Text);
                user1.username = (textBoxX8.Text);
                user1.user_id = 0;
                if (radioButton1.Checked)
                {
                    user1.gender = true;
                }
                if (radioButton2.Checked)
                {
                    user1.gender = false;
                }
                
                bl_user blu = new bl_user();
                blu.creat(user1);

                foreach (var item in Controls)
                {
                    if (item.GetType().ToString() == "DevComponents.DotNetBar.Controls.TextBoxX")
                    {
                        (item as TextBox).Clear();
                    }
                    // پاک کردن تکست باکس ها
                }


                this.Hide();
                form_login flogin = new form_login();
                flogin.Show();
            }
          
        }
        //___________________________________________________________
        private void onlynumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

            // mahdood kardane vroodi textbox be adad

        }
        private void onlytext(object sender, KeyPressEventArgs e)
        {
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9'))

                    e.Handled = true;
            }

            // mahdood kardane vroodi textbox be horoof
        }
        //___________________________________________________________
        public form_register()
        {
            InitializeComponent();
        }

        private void form_register_FormClosing(object sender, FormClosingEventArgs e)
        {
            form_login flogin = new form_login();
            flogin.Show();
        }
    }
}
