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
using System.Globalization;


namespace Shareholder
{
    public partial class form_home : Form
    {

        double wage_buy;
        double wage_sell;
        /// <summary>
        /// گرفتن ایدی خرید در سهام فروخطه شده
        /// </summary>
        int datagrid_cell_buyid;
        /// <summary>
        /// گرفتن ابدی مربوط به ردیف راست کلیک شده
        /// </summary>
        int datagrid_cell_id_rightclick=0;
        /// <summary>
        /// گرفتن ابدی مربوط به ردیف چپ کلیک شده
        /// </summary>
        int datagrid_cell_id_leftclickc;
        /// <summary>
        /// گرفتن ابدی مربوط به ردیف راست کلیک شده در دیتا گرید هیومن
        /// </summary>
        int datagrid_cell_id_human_rightclick = 0;
        int i_btn_buyoredit = 1;
        int i_btn_selloreditortransfer = 1;
        int i_btn_shareholder = 1;
        /// <summary>
        /// ایدی فردی که لاگین کرده
        /// </summary>
        public int user_id;
        /// <summary>
        /// تاریخ روز به شمسی
        /// </summary>
        public string datenow;
        /// <summary>
        /// سهامداری که از دیتا گرید هییومن گرفته میشه
        /// </summary>
        string shareholderfix;
        Double total_fp;
        stock_buy stockbuy_help = new stock_buy();
        stock_sell stocksell_help = new stock_sell();
        PersianCalendar pc = new PersianCalendar();
        DateTime datetime = new DateTime();



        //_________________________void_for_form______________________________
        public string ShamsiToMiladi(string ShamsiDate)
        {
            try
            {
                PersianCalendar PDate = new PersianCalendar();
                Int32 y = 0;
                Int32 m = 0;
                Int32 d = 0;
                if (ShamsiDate.Length == 10)
                {
                    y = Int32.Parse(ShamsiDate.Substring(0, 4));
                    m = Int32.Parse(ShamsiDate.Substring(5, 2));
                    d = Int32.Parse(ShamsiDate.Substring(8, 2));
                }
                else
                {
                    return null;
                }
                return PDate.ToDateTime(y, m, d, 1, 1, 1, 1, 1).ToShortDateString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void datagrid_stockbuy_load()
        {

            datagrid_stockbuy.Columns["id"].Visible = false;
            datagrid_stockbuy.Columns["user_id"].Visible = false;
            datagrid_stockbuy.Columns["human"].Visible = false;

            // this.datagrid_stockbuy.Columns["row"].SortMode = DataGridViewColumnSortMode.Automatic;


            datagrid_stockbuy.Columns["row"].HeaderText = "      ردیف";
            datagrid_stockbuy.Columns["stock_name"].HeaderText = "     نام سهم";
            datagrid_stockbuy.Columns["date_buy"].HeaderText = "      تاریخ خرید";
            datagrid_stockbuy.Columns["numb_buy"].HeaderText = "      تعداد خرید";
            datagrid_stockbuy.Columns["rate_buy"].HeaderText = "      قیمت خرید";
            datagrid_stockbuy.Columns["wage_buy"].HeaderText = "       کارمزد خرید ";
            datagrid_stockbuy.Columns["fp_buy"].HeaderText = "      ق ت خرید";
            datagrid_stockbuy.Columns["Percentageofwage_buy"].HeaderText = "    کارمزد خرید %";
            datagrid_stockbuy.Columns["Percentageofwage_sell"].HeaderText = "  کارمزد فروش % ";
            datagrid_stockbuy.Columns["price_BEP"].HeaderText = "   نقطه سر به سر";
            datagrid_stockbuy.Columns["shareholder"].HeaderText = "      صاحب سهم";


            datagrid_stockbuy.Columns["numb_buy"].DefaultCellStyle.Format = ("#,0");
            datagrid_stockbuy.Columns["rate_buy"].DefaultCellStyle.Format = ("#,0");
            datagrid_stockbuy.Columns["wage_buy"].DefaultCellStyle.Format = ("#,0");
            datagrid_stockbuy.Columns["fp_buy"].DefaultCellStyle.Format = ("#,0");
            datagrid_stockbuy.Columns["price_BEP"].DefaultCellStyle.Format= ("#,0");

        }
        public void datagrid_stocksell_load()
        { 
                datagrid_stocksell.Columns["id"].Visible = false;
                datagrid_stocksell.Columns["user_id"].Visible = false;
                datagrid_stocksell.Columns["buy_id"].Visible = false;
                datagrid_stocksell.Columns["human"].Visible = false;

                datagrid_stocksell.Columns["row"].HeaderText = "   ردیف";
                datagrid_stocksell.Columns["stock_name"].HeaderText = "   نام سهم";
                datagrid_stocksell.Columns["date_buy"].HeaderText = "   تاریخ خرید";
                datagrid_stocksell.Columns["numb_buy"].HeaderText = "    تعداد خرید";
                datagrid_stocksell.Columns["rate_buy"].HeaderText = "   قیمت خرید";
                datagrid_stocksell.Columns["wage_buy"].HeaderText = "   کارمزد خرید ";
                datagrid_stocksell.Columns["fp_buy"].HeaderText = "    ق ت خرید";
                datagrid_stocksell.Columns["Percentageofwage_buy"].HeaderText = "   کارمزد خرید %";
                datagrid_stocksell.Columns["Percentageofwage_sell"].HeaderText = "    کارمزد فروش % ";
                datagrid_stocksell.Columns["shareholder"].HeaderText = "   صاحب سهم";
                datagrid_stocksell.Columns["date_sell"].HeaderText = "    تاریخ فروش";
                datagrid_stocksell.Columns["rate_sell"].HeaderText = "    قیمت فروش";
                datagrid_stocksell.Columns["numb_sell"].HeaderText = "    تعداد فروش";
                datagrid_stocksell.Columns["wage_sell"].HeaderText = "    کارمزد فروش";
                datagrid_stocksell.Columns["fp_sell"].HeaderText = "    فروش کل";
                datagrid_stocksell.Columns["ProfitORloss"].HeaderText = "    سود یا زیان";


            datagrid_stocksell.Columns["numb_buy"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["rate_buy"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["wage_buy"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["rate_sell"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["numb_sell"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["wage_sell"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["fp_sell"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["ProfitORloss"].DefaultCellStyle.Format = ("#,0");
            datagrid_stocksell.Columns["fp_buy"].DefaultCellStyle.Format = ("#,0");
        }
        public void datagrid_human_load()
        {
            
                datagrid_human.Columns["fullname"].Visible = false;
                datagrid_human.Columns["id"].Visible = false;
                datagrid_human.Columns["user_id"].Visible = false;


                datagrid_human.Columns["name"].HeaderText = "   نام ";
                datagrid_human.Columns["family"].HeaderText = "    فامیل";



                //datagrid_human.Columns["name"].Width = 90;
                //datagrid_human.Columns["family"].Width = 90;


            

        }
        public void default_dsine()
        {
            txt_stock_name.Clear();
            txt_row.Clear();
            txt_numb_buy.Clear();
            txt_fp_buy.Clear();
            txt_rate_buy.Clear();
            txt_wage_buy.Clear();
            txt_rate_sell.Clear();
            txt_numb_sell.Clear();
            txt_wage_sell.Clear();
            txtx_fp_sell.Clear();
            txt_ProfitORloss.Clear();
            txt_price_BEP1.Clear();
            dateTimeSelector_buy.Text = datenow;
            dateTimeSelector_sell.Text = datenow;
            maskTXT_wage_buy.Text = wage_buy.ToString();
            maskTXT_wage_sell.Text = wage_sell.ToString();
            comboBoxEx1.ResetText();
            txt_stock_name.ReadOnly = false;
            txt_numb_buy.ReadOnly = false;
            txt_rate_buy.ReadOnly = false;
            txt_numb_sell.ReadOnly = false;
            txt_rate_sell.ReadOnly = false;

            btn_selloredit.Text = "فروش";
            btn_buyoredit.Text = "ثبت سهام";
            btn_buyoredit.Show();

            panel4.Hide();

            
        }
        //_____________________________button_________________________________
        private void btn_shareholder_Click(object sender, EventArgs e)
        {
            if (txt_shareholder_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("نام خالی است");
                txt_shareholder_name.Focus();
            }
            else if (txt_shareholder_famly.Text.Trim().Length == 0)
            {
                MessageBox.Show("فامیل  خالی است");
                txt_shareholder_famly.Focus();
            }
            else
            {
                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                bl_human bl_human1 = new bl_human();


                if (i_btn_shareholder  == 1)
                {
                    human human1 = new human();
                    human1.name = txt_shareholder_name.Text;
                    human1.family = txt_shareholder_famly.Text;
                    human1.user_id = user_id;

                    bl_human1.creat(human1);
                }
                if (datagrid_cell_id_human_rightclick != 0 && i_btn_shareholder == 2)
                {
                   
                        human human1 = new human();
                        human1.name = txt_shareholder_name.Text;
                        human1.family = txt_shareholder_famly.Text;
                        bl_human1.update(datagrid_cell_id_human_rightclick, human1);


                        foreach (var item in bl_stock_buy1.read(user_id))
                        {
                            if (item.shareholder == shareholderfix)
                            {
                                stock_buy sb = new stock_buy();
                                sb.shareholder = human1.fullname;
                                bl_stock_buy1.update_shareholder(item.id, sb);
                            }
                        }
                        foreach (var item in bl_stock_sell1.read(user_id))
                        {
                            if (item.shareholder == shareholderfix)
                            {
                                stock_sell ss = new stock_sell();
                                ss.shareholder = human1.fullname;
                                bl_stock_sell1.update_shareholder(item.id, ss);
                            }
                        }

                    i_btn_shareholder = 1;
                    datagrid_cell_id_human_rightclick = 0;
                }
               


                txt_shareholder_name.Clear();
                txt_shareholder_famly.Clear();

                datagrid_human.DataSource = null;
                datagrid_human.DataSource = bl_human1.read(user_id);
                datagrid_human_load();
                datagrid_stockbuy.DataSource = null;
                datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                datagrid_stockbuy_load();

                btn_shareholder.Text = "ثبت سهامدار";
            }


            //namayesh e etelaat shareholder dar combobox va gereftane id
            bl_human blh = new bl_human();
            comboBoxEx1.DataSource = blh.read(user_id);
            comboBoxEx1.DisplayMember = "fullname";
            comboBoxEx1.ValueMember = "id";
            comboBoxEx2.DataSource = blh.read(user_id);
            comboBoxEx2.DisplayMember = "fullname";
            comboBoxEx2.ValueMember = "id";
            comboBoxEx3.DataSource = blh.read(user_id);
            comboBoxEx3.DisplayMember = "fullname";
            comboBoxEx3.ValueMember = "id";
        }
        private void btn_buyoredit_Click(object sender, EventArgs e)
        {
            bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
            if (comboBoxEx1.Text.Trim().Length == 0)
            {
                MessageBox.Show("نام صاحب سهم خالی است");
                comboBoxEx1.Focus();
            }
            else if (txt_stock_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("نام  سهم خالی است");
                txt_stock_name.Focus();
            }
            else if (txt_rate_buy.Text.Trim().Length == 0)
            {
                MessageBox.Show("نرخ خرید خالی است");
                txt_rate_buy.Focus();
            }
            else if (txt_numb_buy.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تعداد خرید خالی است ");
                txt_numb_buy.Focus();
            }
            else if (dateTimeSelector_buy.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تاریخ مشخص نشده ");
                dateTimeSelector_buy.Focus();
            }
            else
            {

                if (i_btn_buyoredit == 1)
                {
                    stock_buy stock_buy1 = new stock_buy();


                    stock_buy1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);
                    stock_buy1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                    stock_buy1.stock_name = txt_stock_name.Text;
                    stock_buy1.row = bl_stock_buy1.row_number(user_id) + 1;
                    stock_buy1.date_buy = dateTimeSelector_buy.Text;
                    stock_buy1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;
                    stock_buy1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                    stock_buy1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                    stock_buy1.user_id = user_id;


                    bl_stock_buy1.creat(stock_buy1);

                    default_dsine();

                    datagrid_cell_id_rightclick = 0;

                    i_btn_buyoredit = 1;
                    i_btn_selloreditortransfer = 1;
                    i_btn_shareholder = 1;

                }//kharide saham
                else
                {
                    stock_buy stock_buy1 = new stock_buy();

                    stock_buy1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                    stock_buy1.stock_name = txt_stock_name.Text;//
                    stock_buy1.row = int.Parse(txt_row.Text);//
                    stock_buy1.date_buy = dateTimeSelector_buy.Text;//
                    stock_buy1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                    stock_buy1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                    stock_buy1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                    stock_buy1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                    stock_buy1.user_id = user_id;
                    bl_stock_buy1.update(datagrid_cell_id_rightclick, stock_buy1);

                    default_dsine();

                    datagrid_cell_id_rightclick = 0;

                    i_btn_buyoredit = 1;
                    i_btn_selloreditortransfer = 1;
                    i_btn_shareholder = 1;
                }//virayeshe saham

                datagrid_stockbuy.DataSource = null;
                datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                datagrid_stockbuy_load();
                sideNavItem2.Select();
            }

            

        }
        private void btn_selloredit_Click(object sender, EventArgs e)
        {
            if (comboBoxEx1.Text.Trim().Length == 0)
            {
                MessageBox.Show("نام صاحب سهم خالی است");
                comboBoxEx1.Focus();
            }
            else if (txt_stock_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("نام  سهم خالی است");
                txt_stock_name.Focus();
            }
            else if (txt_rate_buy.Text.Trim().Length == 0)
            {
                MessageBox.Show("نرخ خرید خالی است");
                txt_rate_buy.Focus();
            }
            else if (txt_numb_buy.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تعداد خرید خالی است ");
                txt_numb_buy.Focus();
            }
            else if (dateTimeSelector_buy.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تاریخ مشخص نشده ");
                dateTimeSelector_buy.Focus();
            }
            else if (txt_rate_sell.Text.Trim().Length == 0)
            {
                MessageBox.Show(" قیمت فروش خالی است ");
                txt_rate_sell.Focus();
            }
            else if (txt_numb_sell.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تعداد فروش خالی است ");
                txt_numb_sell.Focus();
            }
            else if (dateTimeSelector_sell.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تاریخ مشخص نشده ");
                dateTimeSelector_sell.Focus();
            }
            else
            {
                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                if (i_btn_selloreditortransfer == 1)
                {
                    stock_sell stock_sell1 = new stock_sell();
                    if (Convert.ToInt64((txt_numb_buy.Text).Replace(",", "")) > Convert.ToInt64((txt_numb_sell.Text).Replace(",", "")))
                    {

                        stock_buy stock_buy1 = new stock_buy();
                        stock_buy1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                        stock_buy1.Percentageofwage_buy = double.Parse(maskTXT_wage_sell.Text);
                        stock_buy1.stock_name = txt_stock_name.Text;//
                        stock_buy1.date_buy = dateTimeSelector_buy.Text;//
                        stock_buy1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                        stock_buy1.numb_buy = (Int64.Parse(txt_numb_buy.Text.Replace(",", "")) - Int64.Parse(txt_numb_sell.Text.Replace(",", "")));//
                        stock_buy1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));//
                        stock_buy1.user_id = user_id;
                        foreach (var item in bl_stock_buy1.read(user_id))
                        {
                            if (item.id == datagrid_cell_id_rightclick)
                            {
                                stock_buy1.row = item.row;
                            }
                        }
                        bl_stock_buy1.update(datagrid_cell_id_rightclick, stock_buy1);

                        stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);
                        stock_sell1.stock_name = txt_stock_name.Text;
                        stock_sell1.row = bl_stock_sell1.row_number(user_id) + 1;
                        stock_sell1.date_buy = dateTimeSelector_buy.Text;
                        stock_sell1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;
                        stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                        stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                        stock_sell1.date_sell = dateTimeSelector_sell.Text;
                        stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                        stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                        stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));
                        stock_sell1.user_id = user_id;
                        stock_sell1.buy_id = int.Parse(label1.Text);

                        bl_stock_sell1.creat(stock_sell1);
                        datagrid_stockbuy.DataSource = null;
                        datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                        datagrid_stockbuy_load();
                        datagrid_stocksell.DataSource = null;
                        datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                        datagrid_stocksell_load();

                        default_dsine();

                        datagrid_cell_id_rightclick = 0;

                        i_btn_buyoredit = 1;
                        i_btn_selloreditortransfer = 1;
                        i_btn_shareholder = 1;

                        sideNavItem3.Select();
                    }
                    else if (Convert.ToInt64((txt_numb_buy.Text).Replace(",", "")) == Convert.ToInt64((txt_numb_sell.Text).Replace(",", "")))
                    {

                        stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);
                        stock_sell1.stock_name = txt_stock_name.Text;
                        stock_sell1.row = bl_stock_sell1.row_number(user_id) + 1;
                        stock_sell1.date_buy = dateTimeSelector_buy.Text;
                        stock_sell1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;
                        stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                        stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                        stock_sell1.date_sell = dateTimeSelector_sell.Text;
                        stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                        stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                        stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));
                        stock_sell1.user_id = user_id;
                        stock_sell1.buy_id = int.Parse(label1.Text);
                        bl_stock_sell1.creat(stock_sell1);


                        bl_stock_buy1.delete(datagrid_cell_id_rightclick, user_id);

                        datagrid_stockbuy.DataSource = null;
                        datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                        datagrid_stockbuy_load();
                        datagrid_stocksell.DataSource = null;
                        datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                        datagrid_stocksell_load();

                        default_dsine();

                        datagrid_cell_id_rightclick = 0;

                        i_btn_buyoredit = 1;
                        i_btn_selloreditortransfer = 1;
                        i_btn_shareholder = 1;

                        sideNavItem3.Select();
                    }
                    else if (Convert.ToInt64((txt_numb_buy.Text).Replace(",", "")) < Convert.ToInt64((txt_numb_sell.Text).Replace(",", "")))
                    {
                        MessageBox.Show("تعداد سهام وارد شده بیشتر از سهام موجود است");
                        
                    }
                    
                }//forooshe sahme mojood
                if (i_btn_selloreditortransfer == 2)
                {
                    stock_sell stock_sell1 = new stock_sell();
                    if ((Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) == 0)
                    {
                        MessageBox.Show("شما میتوانید از گزینه بازگردانی سهم استفاده کنید");
                        default_dsine();

                       
                    }
                    else if ((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id)).buy_id != 0 && (Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) > 0)
                    {
                        if (bl_stock_buy1.exist(datagrid_cell_buyid, user_id))
                        {
                            if (bl_stock_buy1.read(datagrid_cell_buyid, user_id).numb_buy < ((Convert.ToInt64((txt_numb_sell.Text).Replace(",", "")))-stocksell_help.numb_sell))
                            {
                                MessageBox.Show("تعداد فروش وارد شده بیشتر از سهام موجود است");
                                
                            }
                            else if (bl_stock_buy1.read(datagrid_cell_buyid, user_id).numb_buy >= ((Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) - stocksell_help.numb_sell))
                            {
                                stock_buy stock_buy1 = new stock_buy();
                                stock_buy1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                                stock_buy1.Percentageofwage_buy = double.Parse(maskTXT_wage_sell.Text);
                                stock_buy1.stock_name = txt_stock_name.Text;//
                                stock_buy1.date_buy = dateTimeSelector_buy.Text;//
                                stock_buy1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                                stock_buy1.numb_buy = bl_stock_buy1.read(datagrid_cell_buyid, user_id).numb_buy - (Convert.ToInt64((txt_numb_sell.Text).Replace(",", "")) - stocksell_help.numb_sell);//
                                stock_buy1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));//
                                stock_buy1.user_id = user_id;
                                foreach (var item in bl_stock_buy1.read(user_id))
                                {
                                    if (item.id == datagrid_cell_buyid)
                                    {
                                        stock_buy1.row = item.row;
                                    }
                                }

                                
                                if (bl_stock_buy1.read(datagrid_cell_buyid, user_id).numb_buy > ((Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) - stocksell_help.numb_sell))
                                {
                                    bl_stock_buy1.update(datagrid_cell_buyid, stock_buy1);
                                }
                                if(bl_stock_buy1.read(datagrid_cell_buyid, user_id).numb_buy <= ((Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) - stocksell_help.numb_sell))
                                {
                                    bl_stock_buy1.delete(datagrid_cell_buyid, user_id);
                                }

                                stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                                stock_sell1.stock_name = txt_stock_name.Text;//
                                stock_sell1.row = int.Parse(txt_row.Text);//
                                stock_sell1.date_buy = dateTimeSelector_buy.Text;//
                                stock_sell1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                                stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                                stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                                stock_sell1.user_id = user_id;
                                stock_sell1.buy_id = datagrid_cell_buyid;
                                stock_sell1.date_sell = dateTimeSelector_sell.Text;
                                stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                                stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                                stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));

                                bl_stock_sell1.update(datagrid_cell_id_rightclick, stock_sell1);

                                datagrid_stockbuy.DataSource = null;
                                datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                                datagrid_stockbuy_load();
                                datagrid_stocksell.DataSource = null;
                                datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                                datagrid_stocksell_load();

                                default_dsine();

                                sideNavItem3.Select();
                            }
                        }
                        else if (bl_stock_buy1.exist(datagrid_cell_buyid, user_id)==false)
                        {
                            if (bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id).numb_buy < ((Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) - stocksell_help.numb_sell))
                            {
                                MessageBox.Show("تعداد فروش وارد شده بیشتر از سهام موجود است");

                            }
                            else if (bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id).numb_buy >= ((Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) - stocksell_help.numb_sell))
                            {
                                if (stocksell_help.numb_sell> (Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))))
                                {
                                    stock_buy stock_buy1 = new stock_buy();
                                    stock_buy1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                                    stock_buy1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                                    stock_buy1.stock_name = txt_stock_name.Text;//
                                    stock_buy1.date_buy = dateTimeSelector_buy.Text;//
                                    stock_buy1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                                    stock_buy1.numb_buy = stocksell_help.numb_sell - (Convert.ToInt64((txt_numb_sell.Text).Replace(",", "")));
                                    stock_buy1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));//
                                    stock_buy1.user_id = user_id;
                                    stock_buy1.row = bl_stock_buy1.row_number(user_id) + 1;
                                    
                                    bl_stock_buy1.creat(stock_buy1);

                                    stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                                    stock_sell1.stock_name = txt_stock_name.Text;//
                                    stock_sell1.row = int.Parse(txt_row.Text);//
                                    stock_sell1.date_buy = dateTimeSelector_buy.Text;//
                                    stock_sell1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                                    stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                                    stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                                    stock_sell1.user_id = user_id;
                                    stock_sell1.buy_id = stock_buy1.id;//////////////
                                    stock_sell1.date_sell = dateTimeSelector_sell.Text;
                                    stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                                    stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                                    stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));

                                    bl_stock_sell1.update(datagrid_cell_id_rightclick, stock_sell1);

                                   
                                    datagrid_stockbuy.DataSource = null;
                                    datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                                    datagrid_stockbuy_load();
                                    datagrid_stocksell.DataSource = null;
                                    datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                                    datagrid_stocksell_load();

                                    default_dsine();
                                }
                                else
                                {
                                    stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                                    stock_sell1.stock_name = txt_stock_name.Text;//
                                    stock_sell1.row = int.Parse(txt_row.Text);//
                                    stock_sell1.date_buy = dateTimeSelector_buy.Text;//
                                    stock_sell1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                                    stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                                    stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                                    stock_sell1.user_id = user_id;
                                    stock_sell1.date_sell = dateTimeSelector_sell.Text;
                                    stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                                    stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                                    stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));

                                    bl_stock_sell1.update(datagrid_cell_id_rightclick, stock_sell1);
                                   
                                    datagrid_stockbuy.DataSource = null;
                                    datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                                    datagrid_stockbuy_load();
                                    datagrid_stocksell.DataSource = null;
                                    datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                                    datagrid_stocksell_load();

                                    default_dsine();
                                }
                                sideNavItem3.Select();
                            }
                        }
                        
                    }
                    else if((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id)).buy_id == 0 && (Convert.ToInt64((txt_numb_sell.Text).Replace(",", ""))) > 0)
                    {
                        stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                        stock_sell1.stock_name = txt_stock_name.Text;//
                        stock_sell1.row = int.Parse(txt_row.Text);//
                        stock_sell1.date_buy = dateTimeSelector_buy.Text;//
                        stock_sell1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                        stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                        stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                        stock_sell1.user_id = user_id;
                        stock_sell1.buy_id = datagrid_cell_buyid;
                        stock_sell1.date_sell = dateTimeSelector_sell.Text;
                        stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                        stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                        stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));

                        bl_stock_sell1.update(datagrid_cell_id_rightclick, stock_sell1);


                        btn_selloredit.Text = "فروش";

                        datagrid_stockbuy.DataSource = null;
                        datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                        datagrid_stockbuy_load();
                        datagrid_stocksell.DataSource = null;
                        datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                        datagrid_stocksell_load();

                        default_dsine();

                        sideNavItem3.Select();
                    }///////////////////////

                    datagrid_cell_id_rightclick = 0;

                    i_btn_buyoredit = 1;
                    i_btn_selloreditortransfer = 1;
                    i_btn_shareholder = 1;

                    
                }//virayesh sahme forookhte shode
                if (i_btn_selloreditortransfer == 3)
                {
                    stock_sell stock_sell1 = new stock_sell();
                    if (stockbuy_help.shareholder == ((human)(comboBoxEx1.SelectedItem)).fullname)
                    {
                        MessageBox.Show("لطفا نام صاحب جدید سهم فروخته شده را وارد کنید");
                    }
                    else
                    {
                        stock_buy stock_buy1 = new stock_buy();
                        stock_buy1.Percentageofwage_sell = stockbuy_help.Percentageofwage_sell;//
                        stock_buy1.Percentageofwage_buy = 0.00000;
                        stock_buy1.stock_name = txt_stock_name.Text;//
                        stock_buy1.date_buy = dateTimeSelector_sell.Text;//
                        stock_buy1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                        stock_buy1.numb_buy = (Int64.Parse(txt_numb_sell.Text.Replace(",", "")));//
                        stock_buy1.rate_buy = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));//
                        stock_buy1.user_id = user_id;
                        foreach (var item in bl_stock_buy1.read(user_id))
                        {
                            if (item.id == datagrid_cell_id_rightclick)
                            {
                                stock_buy1.row = item.row;
                            }
                        }
                        bl_stock_buy1.update(datagrid_cell_id_rightclick, stock_buy1);

                        stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);
                        stock_sell1.stock_name = txt_stock_name.Text;
                        stock_sell1.row = bl_stock_sell1.row_number(user_id) + 1;
                        stock_sell1.date_buy = dateTimeSelector_buy.Text;
                        stock_sell1.shareholder = stockbuy_help.shareholder;
                        stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                        stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                        stock_sell1.date_sell = dateTimeSelector_sell.Text;
                        stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                        stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                        stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));
                        stock_sell1.user_id = user_id;
                        stock_sell1.buy_id = 0;

                        bl_stock_sell1.creat(stock_sell1);
                        datagrid_stockbuy.DataSource = null;
                        datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                        datagrid_stockbuy_load();
                        datagrid_stocksell.DataSource = null;
                        datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                        datagrid_stocksell_load();

                        default_dsine();

                        datagrid_cell_id_rightclick = 0;

                        i_btn_buyoredit = 1;
                        i_btn_selloreditortransfer = 1;
                        i_btn_shareholder = 1;

                        sideNavItem2.Select();
                        
                    }
                }//enteqale tamame sahm
                if (i_btn_selloreditortransfer == 4)
                {

                    if (stockbuy_help.shareholder == ((human)(comboBoxEx1.SelectedItem)).fullname)
                    {
                        MessageBox.Show("لطفا نام صاحب جدید سهم فروخته شده را وارد کنید");
                    }
                    else
                    {

                        stock_buy stock_buy1 = new stock_buy();
                        stock_buy1.Percentageofwage_sell = stockbuy_help.Percentageofwage_sell;//
                        stock_buy1.Percentageofwage_buy = 0.00000;//
                        stock_buy1.stock_name = txt_stock_name.Text;//
                        stock_buy1.date_buy = dateTimeSelector_sell.Text;//
                        stock_buy1.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;//
                        stock_buy1.numb_buy = (Int64.Parse(txt_numb_sell.Text.Replace(",", "")));//
                        stock_buy1.rate_buy = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));//
                        stock_buy1.user_id = user_id;//
                        stock_buy1.row = bl_stock_buy1.row_number(user_id) + 1;//
                        bl_stock_buy1.creat(stock_buy1);

                        stock_buy stock_buy2 = new stock_buy();
                        stock_buy2.Percentageofwage_sell = stockbuy_help.Percentageofwage_sell;
                        stock_buy2.Percentageofwage_buy = stockbuy_help.Percentageofwage_buy;
                        stock_buy2.stock_name = txt_stock_name.Text;
                        stock_buy2.date_buy = dateTimeSelector_buy.Text;
                        stock_buy2.shareholder = stockbuy_help.shareholder;
                        stock_buy2.numb_buy = (Int64.Parse(txt_numb_buy.Text.Replace(",", "")) - Int64.Parse(txt_numb_sell.Text.Replace(",", "")));
                        stock_buy2.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                        stock_buy2.user_id = user_id;
                        foreach (var item in bl_stock_buy1.read(user_id))
                        {
                            if (item.id == datagrid_cell_buyid)
                            {
                                stock_buy1.row = item.row;
                            }
                        }
                        bl_stock_buy1.update(datagrid_cell_id_rightclick, stock_buy2);

                        stock_sell stock_sell1 = new stock_sell();
                        stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);
                        stock_sell1.stock_name = txt_stock_name.Text;
                        stock_sell1.row = bl_stock_sell1.row_number(user_id) + 1;
                        stock_sell1.date_buy = dateTimeSelector_buy.Text;
                        stock_sell1.shareholder = stockbuy_help.shareholder;
                        stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                        stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                        stock_sell1.date_sell = dateTimeSelector_sell.Text;
                        stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                        stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));
                        stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));
                        stock_sell1.user_id = user_id;
                        stock_sell1.buy_id = 0;

                        bl_stock_sell1.creat(stock_sell1);

                        datagrid_stockbuy.DataSource = null;
                        datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                        datagrid_stockbuy_load();
                        datagrid_stocksell.DataSource = null;
                        datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                        datagrid_stocksell_load();

                        default_dsine();

                        datagrid_cell_id_rightclick = 0;

                        i_btn_buyoredit = 1;
                        i_btn_selloreditortransfer = 1;
                        i_btn_shareholder = 1;

                        sideNavItem2.Select();
                    }
                    
                }//enteqale qesmati sahm
            }
        }
        private void btn_stockshow_buy_Click(object sender, EventArgs e)
        {
            bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
            datagrid_stockbuy.DataSource = null;
            datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
            datagrid_stockbuy_load();
            total_fp = bl_stock_buy1.total_fp_buy(user_id);

            default_dsine();

            datagrid_cell_id_rightclick = 0;

            i_btn_buyoredit = 1;
            i_btn_selloreditortransfer = 1;
            i_btn_shareholder = 1;
        }
        private void btn_stockshow_sell_Click(object sender, EventArgs e)
        {

            bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
            datagrid_stocksell.DataSource = null;
            datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
            datagrid_stocksell_load();

            default_dsine();

            datagrid_cell_id_rightclick = 0;

            i_btn_buyoredit = 1;
            i_btn_selloreditortransfer = 1;
            i_btn_shareholder = 1;
        }
        private void btn_chartbuy_Click(object sender, EventArgs e)
        {
            bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
            if ((bl_stock_buy1.read(((human)(comboBoxEx2.SelectedItem)).fullname, user_id)).Count <= 0)
            {
                MessageBox.Show(" سهامی برای نمایش در نمودار ندارد " + ((human)(comboBoxEx2.SelectedItem)).fullname);
                default_dsine();

                datagrid_cell_id_rightclick = 0;

                i_btn_buyoredit = 1;
                i_btn_selloreditortransfer = 1;
                i_btn_shareholder = 1;
            }
            else
            {
                Form_chart f = new Form_chart();
                var q = bl_stock_buy1.read(((human)(comboBoxEx2.SelectedItem)).fullname, user_id);
                f.q = q;
                f.user_id = user_id;
                f.shareholder_selected = ((human)(comboBoxEx2.SelectedItem)).fullname;
                f.ShowDialog();

                default_dsine();

                datagrid_cell_id_rightclick = 0;

                i_btn_buyoredit = 1;
                i_btn_selloreditortransfer = 1;
                i_btn_shareholder = 1;

            }


        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            default_dsine();

            datagrid_cell_id_rightclick = 0;

            i_btn_buyoredit = 1;
            i_btn_selloreditortransfer = 1;
            i_btn_shareholder = 1;
        }
        private void btn_setting_Click(object sender, EventArgs e)
        {
            {
                default_dsine();

                datagrid_cell_id_rightclick = 0;

                i_btn_buyoredit = 1;
                i_btn_selloreditortransfer = 1;
                i_btn_shareholder = 1;

                txt_shareholder_name.Clear();
                txt_shareholder_famly.Clear();
                btn_shareholder.Text = "ثبت سهامدار";
                datagrid_cell_id_human_rightclick = 0;
                i_btn_shareholder = 1;
            }
            
            form_setting fsetting = new form_setting();
            fsetting.ShowDialog();

            form_setting fs = new form_setting();
            wage_buy = Double.Parse(fs.maskTXT_wage_buy.Text);
            wage_sell = Double.Parse(fs.maskTXT_wage_sell.Text);
            maskTXT_wage_buy.Text = fs.maskTXT_wage_buy.Text;
            maskTXT_wage_sell.Text = fs.maskTXT_wage_sell.Text;

            
        }
        //___________________________nav_item_________________________________
        private void Available_stock_nav_Click(object sender, EventArgs e)
        {
            default_dsine();

            datagrid_cell_id_rightclick = 0;

            i_btn_buyoredit = 1;
            i_btn_selloreditortransfer = 1;
            i_btn_shareholder = 1;

            txt_shareholder_name.Clear();
            txt_shareholder_famly.Clear();
            btn_shareholder.Text = "ثبت سهامدار";
            datagrid_cell_id_human_rightclick = 0;
        }
        private void sell_histori_nav_Click(object sender, EventArgs e)
        {
            default_dsine();

            datagrid_cell_id_rightclick = 0;

            i_btn_buyoredit = 1;
            i_btn_selloreditortransfer = 1;
            i_btn_shareholder = 1;

            txt_shareholder_name.Clear();
            txt_shareholder_famly.Clear();
            btn_shareholder.Text = "ثبت سهامدار";
            datagrid_cell_id_human_rightclick = 0;
        }
        private void Create_shareholder_nav_Click(object sender, EventArgs e)
        {
            default_dsine();

            datagrid_cell_id_rightclick = 0;

            i_btn_buyoredit = 1;
            i_btn_selloreditortransfer = 1;
           
        }
        private void Trading_stock_nav_Click(object sender, EventArgs e)
        {

            txt_shareholder_name.Clear();
            txt_shareholder_famly.Clear();
            btn_shareholder.Text = "ثبت سهامدار";
            datagrid_cell_id_human_rightclick = 0;
            i_btn_shareholder = 1;

        }
        //_____________________________menu___________________________________
        private void ویرایشToolStripMenu_buy_Click(object sender, EventArgs e)
        {

            default_dsine();

            if (datagrid_cell_id_rightclick != 0)
            {
                stock_buy stock_buy1 = new stock_buy();
                i_btn_buyoredit = 2;
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                stock_buy1 = bl_stock_buy1.read(datagrid_cell_id_rightclick, user_id);
                bl_human bh = new bl_human();
                human h = new human();
                txt_stock_name.Text = stock_buy1.stock_name;
                txt_rate_buy.Text = stock_buy1.rate_buy.ToString();
                txt_numb_buy.Text = stock_buy1.numb_buy.ToString();
                txt_row.Text = stock_buy1.row.ToString();
                txt_fp_buy.Text = stock_buy1.fp_buy.ToString();
                txt_wage_buy.Text = stock_buy1.wage_buy.ToString();
                txt_price_BEP1.Text = stock_buy1.price_BEP.ToString();
                dateTimeSelector_buy.Text = stock_buy1.date_buy;
                maskTXT_wage_buy.Text = stock_buy1.Percentageofwage_buy.ToString();
                maskTXT_wage_sell.Text = stock_buy1.Percentageofwage_sell.ToString();
                foreach (var item in bh.read(user_id))
                {
                    if (item.fullname == stock_buy1.shareholder)
                    {
                        comboBoxEx1.SelectedValue = item.id;
                    }
                }
                btn_buyoredit.Text = "ویرایش";
                sideNavItem4.Select();
            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }

            

            

        }
        private void فروشToolStripMenu_buy_Click(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_rightclick != 0)
            {
                panel4.Show();
                stock_buy stock_buy1 = new stock_buy();
                i_btn_selloreditortransfer = 1;
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                stock_buy1 = bl_stock_buy1.read(datagrid_cell_id_rightclick, user_id);
                bl_human bh = new bl_human();
                human h = new human();
                txt_stock_name.Text = stock_buy1.stock_name;
                txt_rate_buy.Text = stock_buy1.rate_buy.ToString();
                txt_numb_buy.Text = stock_buy1.numb_buy.ToString();
                txt_fp_buy.Text = stock_buy1.fp_buy.ToString();
                txt_wage_buy.Text = stock_buy1.wage_buy.ToString();
                txt_price_BEP1.Text = stock_buy1.price_BEP.ToString();
                dateTimeSelector_buy.Text = stock_buy1.date_buy;
                maskTXT_wage_buy.Text = stock_buy1.Percentageofwage_buy.ToString();
                maskTXT_wage_sell.Text = stock_buy1.Percentageofwage_sell.ToString();
                foreach (var item in bh.read(user_id))
                {
                    if (item.fullname == stock_buy1.shareholder)
                    {
                        comboBoxEx1.SelectedValue = item.id;
                    }
                }
                label1.Hide();
                label1.Text = stock_buy1.id.ToString();
                btn_buyoredit.Hide();
                txt_stock_name.ReadOnly = true;
                txt_numb_buy.ReadOnly = true;
                txt_rate_buy.ReadOnly = true;
                txt_numb_sell.ReadOnly = false;
                sideNavItem4.Select();
            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }
            
        }
        private void حذفToolStripMenu_buy_Click(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_rightclick != 0)
            {
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                stock_buy sb = new stock_buy();
                sb = bl_stock_buy1.read(datagrid_cell_id_rightclick,user_id);//
                DialogResult result;
                result = MessageBox.Show(@" ایا از حذف کردن " + " " + (sb.stock_name + " به مالکیت " +  sb.shareholder) + " " + " اطمینان دارید؟ "
                  , "حذف سهامدار", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    
                    bl_stock_buy1.delete(datagrid_cell_id_rightclick, user_id);
                    datagrid_stockbuy.DataSource = null;
                    datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                    datagrid_stockbuy_load();

                    datagrid_cell_id_rightclick = 0;

                    i_btn_buyoredit = 1;
                    i_btn_selloreditortransfer = 1;
                    i_btn_shareholder = 1;

                }
                
            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }
            
        }
        private void تغییرردیفToolStripMenu_buy_Click(object sender, EventArgs e)
        {
            if (datagrid_cell_id_rightclick != 0)
            {
                Form_rowchange frc = new Form_rowchange();
                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();

                frc.order = 1;
                frc.user_id = user_id;
                frc.datagrid_cell_id = datagrid_cell_id_rightclick;
                frc.ShowDialog();



                datagrid_stockbuy.DataSource = null;
                datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                datagrid_stockbuy_load();

                datagrid_cell_id_rightclick = 0;

                i_btn_buyoredit = 1;
                i_btn_selloreditortransfer = 1;
                i_btn_shareholder = 1;
            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }
            

        }//
        private void تمامسهمToolStripMenu_buy_Click(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_rightclick != 0)
            {
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                stock_buy sb = new stock_buy();
                sb = bl_stock_buy1.read(datagrid_cell_id_rightclick, user_id);//
                DialogResult result;
                result = MessageBox.Show(" ایا از انتقال " + " " + (sb.stock_name + " به مالکیت " +  sb.shareholder) + " " + " اطمینان دارید؟ "
                  , "انتقال سهم", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    panel4.Show();
                    stock_buy stock_buy1 = new stock_buy();
                    stock_buy stock_buy2 = new stock_buy();
                    i_btn_selloreditortransfer = 3;
                    
                    stock_buy1 = bl_stock_buy1.read(datagrid_cell_id_rightclick, user_id);
                    bl_human bh = new bl_human();
                    human h = new human();

                    txt_stock_name.Text = stock_buy1.stock_name;
                    txt_rate_buy.Text = stock_buy1.rate_buy.ToString();
                    txt_numb_buy.Text = stock_buy1.numb_buy.ToString();
                    txt_fp_buy.Text = stock_buy1.fp_buy.ToString();
                    txt_wage_buy.Text = stock_buy1.wage_buy.ToString();
                    dateTimeSelector_buy.Text = stock_buy1.date_buy;
                    maskTXT_wage_buy.Text = stock_buy1.Percentageofwage_buy.ToString();
                    maskTXT_wage_sell.Text = "0.00000";
                    stock_buy2.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text); ;
                    stock_buy2.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                    stock_buy2.rate_buy = stock_buy1.rate_buy;
                    txt_price_BEP1.Text = stock_buy2.price_BEP.ToString();
                    txt_numb_sell.Text = stock_buy1.numb_buy.ToString();
                    foreach (var item in bh.read(user_id))
                    {
                        if (item.fullname == stock_buy1.shareholder)
                        {
                            comboBoxEx1.SelectedValue = item.id;
                            stockbuy_help.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;
                        }
                    }
                    stockbuy_help.id = stock_buy1.id;
                    stockbuy_help.Percentageofwage_sell = stock_buy1.Percentageofwage_sell;

                    label1.Hide();
                    btn_buyoredit.Hide();
                    txt_stock_name.ReadOnly = true;
                    txt_numb_buy.ReadOnly = true;
                    txt_rate_buy.ReadOnly = true;
                    txt_numb_sell.ReadOnly = true;
                    btn_selloredit.Text = "انتقال";
                    sideNavItem4.Select();
                }

            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }

        }//enteqale tamame sahm
        private void قسمتیازسهمToolStripMenu_buy_Click(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_rightclick != 0)
            {
                panel4.Show();
                stock_buy stock_buy1 = new stock_buy();
                stock_buy stock_buy2 = new stock_buy();
                i_btn_selloreditortransfer = 4;
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                stock_buy1 = bl_stock_buy1.read(datagrid_cell_id_rightclick, user_id);
                bl_human bh = new bl_human();
                human h = new human();

                txt_stock_name.Text = stock_buy1.stock_name;
                txt_rate_buy.Text = stock_buy1.rate_buy.ToString();
                txt_numb_buy.Text = stock_buy1.numb_buy.ToString();
                txt_fp_buy.Text = stock_buy1.fp_buy.ToString();
                txt_wage_buy.Text = stock_buy1.wage_buy.ToString();
                dateTimeSelector_buy.Text = stock_buy1.date_buy;
                maskTXT_wage_buy.Text = stock_buy1.Percentageofwage_buy.ToString();
                maskTXT_wage_sell.Text = "0.00000";
                stock_buy2.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text); ;
                stock_buy2.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                stock_buy2.rate_buy = stock_buy1.rate_buy;
                txt_price_BEP1.Text = stock_buy2.price_BEP.ToString();
                foreach (var item in bh.read(user_id))
                {
                    if (item.fullname == stock_buy1.shareholder)
                    {
                        comboBoxEx1.SelectedValue = item.id;
                        stockbuy_help.shareholder = ((human)(comboBoxEx1.SelectedItem)).fullname;
                    }
                }
                stockbuy_help.id = stock_buy1.id;
                stockbuy_help.Percentageofwage_sell = stock_buy1.Percentageofwage_sell;
                stockbuy_help.Percentageofwage_buy = stock_buy1.Percentageofwage_buy;

                label1.Hide();
                btn_buyoredit.Hide();
                txt_stock_name.ReadOnly = true;
                txt_numb_buy.ReadOnly = true;
                txt_rate_buy.ReadOnly = true;
                txt_numb_sell.ReadOnly = false;
                btn_selloredit.Text = "انتقال";
                sideNavItem4.Select();
            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }

        }//enteqale qesmati az sahm
        private void حذفToolStripMenu_sell_Click(object sender, EventArgs e)
        {
            default_dsine();
           
            if (datagrid_cell_id_rightclick != 0)
            {
                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                stock_sell sb = new stock_sell();
                sb = bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id);//
                DialogResult result;
                result = MessageBox.Show(@" ایا از حذف کردن " + " " + (sb.stock_name + " به مالکیت " +  sb.shareholder) + " " + " اطمینان دارید؟ "
                  , "حذف سهامدار", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bl_stock_sell1.delete(datagrid_cell_id_rightclick, user_id);
                    datagrid_stocksell.DataSource = null;
                    datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                    datagrid_stocksell_load();


                    datagrid_cell_id_rightclick = 0;

                    i_btn_buyoredit = 1;
                    i_btn_selloreditortransfer = 1;
                    i_btn_shareholder = 1;
                }
                 
            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }
           
        }
        private void ویرایشToolStripMenu_sell_Click(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_rightclick != 0)
            {
                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                if ((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id)).buy_id != 0)
                {
                    panel4.Show();
                    stock_buy stock_buy1 = new stock_buy();
                    stock_sell stock_sell1 = new stock_sell();
                    i_btn_selloreditortransfer = 2;

                    stock_sell1 = bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id);
                    stocksell_help= bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id);
                    bl_human bh = new bl_human();
                    human h = new human();
                    stock_buy1.rate_buy = stock_sell1.rate_buy;
                    stock_buy1.Percentageofwage_buy = stock_sell1.Percentageofwage_buy;
                    stock_buy1.Percentageofwage_sell = stock_sell1.Percentageofwage_sell;
                    txt_stock_name.Text = stock_sell1.stock_name;
                    txt_row.Text = stock_sell1.row.ToString();
                    txt_rate_buy.Text = stock_sell1.rate_buy.ToString();
                    txt_numb_buy.Text = stock_sell1.numb_buy.ToString();
                    txt_fp_buy.Text = stock_sell1.fp_buy.ToString();
                    txt_wage_buy.Text = stock_sell1.wage_buy.ToString();
                    txt_price_BEP1.Text = stock_buy1.price_BEP.ToString();
                    dateTimeSelector_buy.Text = stock_sell1.date_buy;
                    dateTimeSelector_sell.Text = stock_sell1.date_sell;
                    maskTXT_wage_buy.Text = stock_sell1.Percentageofwage_buy.ToString();
                    maskTXT_wage_sell.Text = stock_sell1.Percentageofwage_sell.ToString();
                    txt_rate_sell.Text = stock_sell1.rate_sell.ToString();
                    txt_numb_sell.Text = stock_sell1.numb_sell.ToString();
                    txt_wage_sell.Text = stock_sell1.wage_sell.ToString();
                    txtx_fp_sell.Text = stock_sell1.fp_sell.ToString();
                    txt_ProfitORloss.Text = stock_sell1.ProfitORloss.ToString();
                    foreach (var item in bh.read(user_id))
                    {
                        if (item.fullname == stock_sell1.shareholder)
                        {
                            comboBoxEx1.SelectedValue = item.id;
                        }
                    }
                    btn_buyoredit.Hide();
                    txt_stock_name.ReadOnly = true;
                    txt_numb_buy.ReadOnly = true;
                    txt_rate_buy.ReadOnly = true;
                    btn_selloredit.Text = "ویرایش";
                    sideNavItem4.Select();
                }
                if ((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id)).buy_id == 0)
                {
                    panel4.Show();
                    stock_buy stock_buy1 = new stock_buy();
                    stock_sell stock_sell1 = new stock_sell();
                    i_btn_selloreditortransfer = 2;

                    stock_sell1 = bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id);
                    bl_human bh = new bl_human();
                    human h = new human();
                    stock_buy1.rate_buy = stock_sell1.rate_buy;
                    stock_buy1.Percentageofwage_buy = stock_sell1.Percentageofwage_buy;
                    stock_buy1.Percentageofwage_sell = stock_sell1.Percentageofwage_sell;
                    txt_stock_name.Text = stock_sell1.stock_name;
                    txt_row.Text = stock_sell1.row.ToString();
                    txt_rate_buy.Text = stock_sell1.rate_buy.ToString();
                    txt_numb_buy.Text = stock_sell1.numb_buy.ToString();
                    txt_fp_buy.Text = stock_sell1.fp_buy.ToString();
                    txt_wage_buy.Text = stock_sell1.wage_buy.ToString();
                    txt_price_BEP1.Text = stock_buy1.price_BEP.ToString();
                    dateTimeSelector_buy.Text = stock_sell1.date_buy;
                    dateTimeSelector_sell.Text = stock_sell1.date_sell;
                    maskTXT_wage_buy.Text = stock_sell1.Percentageofwage_buy.ToString();
                    maskTXT_wage_sell.Text = stock_sell1.Percentageofwage_sell.ToString();
                    txt_rate_sell.Text = stock_sell1.rate_sell.ToString();
                    txt_numb_sell.Text = stock_sell1.numb_sell.ToString();
                    txt_wage_sell.Text = stock_sell1.wage_sell.ToString();
                    txtx_fp_sell.Text = stock_sell1.fp_sell.ToString();
                    txt_ProfitORloss.Text = stock_sell1.ProfitORloss.ToString();
                    foreach (var item in bh.read(user_id))
                    {
                        if (item.fullname == stock_sell1.shareholder)
                        {
                            comboBoxEx1.SelectedValue = item.id;
                        }
                    }
                    btn_buyoredit.Hide();
                    txt_stock_name.ReadOnly = true;
                    txt_numb_buy.ReadOnly = true;
                    txt_rate_buy.ReadOnly = true;
                    txt_numb_sell.ReadOnly = true;
                    txt_rate_sell.ReadOnly = true;
                    maskTXT_wage_buy.ReadOnly = true;
                    maskTXT_wage_sell.ReadOnly = true;
                    btn_selloredit.Text = "ویرایش";
                    sideNavItem4.Select();
                }

            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }
            
        }
        private void بازگردانی_سهمToolStripMenu_sell_Click_1(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_rightclick != 0)
            {
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                stock_sell sb = new stock_sell();
                sb = bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id);//
                DialogResult result;
                result = MessageBox.Show(@" ایا از بازگردانی " + " " + ( sb.stock_name + " به مالکیت " + sb.shareholder) + " " + " اطمینان دارید؟ "
                  , "بازگردانی سهم", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                {
                    if ((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id)).buy_id == 0)
                    {
                        MessageBox.Show("این سهم به فرد دیگری منتقل شده و قابل بازگردانی نیست");
                    }
                    if ((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id)).buy_id != 0)
                    {
                        if (bl_stock_buy1.read((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id).buy_id), user_id) == null)
                        {


                            stock_sell stock_sell1 = new stock_sell();
                            stock_buy stock_buy1 = new stock_buy();


                            stock_sell1 = bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id);

                            stock_buy1.Percentageofwage_buy = stock_sell1.Percentageofwage_buy;
                            stock_buy1.Percentageofwage_sell = stock_sell1.Percentageofwage_sell;
                            stock_buy1.stock_name = stock_sell1.stock_name;
                            stock_buy1.row = bl_stock_buy1.row_number(user_id) + 1;
                            stock_buy1.date_buy = stock_sell1.date_buy;
                            stock_buy1.shareholder = stock_sell1.shareholder;
                            stock_buy1.numb_buy = stock_sell1.numb_buy;
                            stock_buy1.rate_buy = stock_sell1.rate_buy;
                            stock_buy1.user_id = user_id;

                            bl_stock_buy1.creat(stock_buy1);
                            bl_stock_sell1.delete(datagrid_cell_id_rightclick, user_id);

                            datagrid_stockbuy.DataSource = null;
                            datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                            datagrid_stockbuy_load();
                            datagrid_stocksell.DataSource = null;
                            datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                            datagrid_stocksell_load();

                            sideNavItem2.Select();
                        }
                        else
                        {



                            stock_sell stock_sell1 = new stock_sell();
                            stock_buy stock_buy1 = new stock_buy();

                            stock_sell1 = bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id);

                            stock_buy1.Percentageofwage_buy = stock_sell1.Percentageofwage_buy;
                            stock_buy1.Percentageofwage_sell = stock_sell1.Percentageofwage_sell;
                            stock_buy1.stock_name = stock_sell1.stock_name;
                            stock_buy1.row = bl_stock_buy1.read((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id).buy_id), user_id).row;
                            stock_buy1.date_buy = stock_sell1.date_buy;
                            stock_buy1.shareholder = stock_sell1.shareholder;
                            stock_buy1.numb_buy = (bl_stock_buy1.read((bl_stock_sell1.read(datagrid_cell_id_rightclick, user_id).buy_id), user_id).numb_buy) + stock_sell1.numb_sell;
                            stock_buy1.rate_buy = stock_sell1.rate_buy;
                            stock_buy1.user_id = user_id;

                            bl_stock_buy1.update(datagrid_cell_buyid, stock_buy1);
                            bl_stock_sell1.delete(datagrid_cell_id_rightclick, user_id);

                            datagrid_stockbuy.DataSource = null;
                            datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
                            datagrid_stockbuy_load();
                            datagrid_stocksell.DataSource = null;
                            datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                            datagrid_stocksell_load();

                            sideNavItem2.Select();
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }
          
        }
        private void تغییرردیفToolStripMenu_sell_Click(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_rightclick != 0)
            {
                Form_rowchange frc = new Form_rowchange();
                frc.order = 2;
                frc.user_id = user_id;
                frc.datagrid_cell_id = datagrid_cell_id_rightclick;
                frc.ShowDialog();

                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();



                datagrid_stocksell.DataSource = null;
                datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
                datagrid_stocksell_load();

                datagrid_cell_id_rightclick = 0;

                i_btn_buyoredit = 1;
                i_btn_selloreditortransfer = 1;
                i_btn_shareholder = 1;
            }
            else
            {
                MessageBox.Show("هیچ سهمی انتخاب نشده");
            }
            
        }//
        private void ویرایشToolStripMenu_human_Click(object sender, EventArgs e)
        {
            default_dsine();
            if (datagrid_cell_id_human_rightclick != 0)
            {
                bl_human blh = new bl_human();
                human h = new human();
                h = blh.read(datagrid_cell_id_human_rightclick, user_id);
                txt_shareholder_name.Text = h.name;
                txt_shareholder_famly.Text = h.family;
                shareholderfix = h.fullname;
                btn_shareholder.Text = "ویرایش";
                i_btn_shareholder = 2;
            }
            else
            {
                MessageBox.Show("هیچ سهامداری انتخاب نشده");
            }

            

        }
        private void حذفToolStripMenu_human_Click(object sender, EventArgs e)
        {
            default_dsine();
            
            if (datagrid_cell_id_human_rightclick != 0)
            {
                bl_human blh = new bl_human();
                human h = new human();
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                h = blh.read(datagrid_cell_id_human_rightclick, user_id);
                if (h.id==user_id)
                {
                    MessageBox.Show("مدیر سیستم قابل حذف نیست");
                }
                else
                {
                    if (bl_stock_buy1.exist(h.fullname, user_id))
                    {
                        DialogResult result;//
                        result = MessageBox.Show(@" ایا از حذف کردن " + " " + h.fullname + " " + " اطمینان دارید؟ " + "\n" +
                          "!!!تمام سهم های مربوط نیز پاک می شود ", "حذف سهامدار", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            foreach (var item in bl_stock_buy1.read(user_id))
                            {
                                if (item.shareholder == h.fullname)
                                {
                                    bl_stock_buy1.delete(item.id, user_id);
                                }
                            }
                            foreach (var item in bl_stock_sell1.read(user_id))
                            {
                                if (item.shareholder == h.fullname)
                                {
                                    bl_stock_sell1.deleteshareholder(item.id);
                                }
                            }

                            blh.delete(datagrid_cell_id_human_rightclick);

                        }
                    }
                    if (bl_stock_buy1.exist(h.fullname, user_id) == false)
                    {
                        blh.delete(datagrid_cell_id_human_rightclick);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("هیچ سهامداری انتخاب نشده");
            }
           

        }
        //_____________________________event__________________________________
        private void Allocation_buy_Keyup(object sender, KeyEventArgs e)
        {
            // نشاندادن نتایج در تکست باکس های  12 و 2 و 4 و 6
            if (txt_numb_buy.Text != "" && txt_rate_buy.Text != "")
            {
                stock_buy stock_buy1 = new stock_buy();
                stock_buy1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);
                stock_buy1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);
                stock_buy1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));
                stock_buy1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));
                txt_fp_buy.Text = stock_buy1.fp_buy.ToString();
                txt_wage_buy.Text = stock_buy1.wage_buy.ToString();
                txt_price_BEP1.Text = stock_buy1.price_BEP.ToString("N0");
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                if (i_btn_buyoredit == 1)
                {
                    txt_row.Text = (bl_stock_buy1.row_number(user_id) + 1).ToString();
                }

                
            }
        }
        private void Allocation_sell_KeyUp(object sender, KeyEventArgs e)
        {
            // نشاندادن نتایج در تکست باکس های 2 و 4 و 6  
            if (txt_rate_sell.Text != "" && txt_numb_sell.Text != "")
            {

                bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
                stock_sell stock_sell1 = new stock_sell();
                stock_sell1.Percentageofwage_buy = Double.Parse(maskTXT_wage_buy.Text);//
                stock_sell1.numb_buy = Int64.Parse(txt_numb_buy.Text.Replace(",", ""));//
                stock_sell1.rate_buy = Int64.Parse(txt_rate_buy.Text.Replace(",", ""));//
                stock_sell1.Percentageofwage_sell = Double.Parse(maskTXT_wage_sell.Text);//
                stock_sell1.numb_sell = Int64.Parse(txt_numb_sell.Text.Replace(",", ""));//
                stock_sell1.rate_sell = Int64.Parse(txt_rate_sell.Text.Replace(",", ""));//
                txt_wage_sell.Text = stock_sell1.wage_sell.ToString();
                txtx_fp_sell.Text = stock_sell1.fp_sell.ToString();
                txt_ProfitORloss.Text = stock_sell1.ProfitORloss.ToString();
                txt_row.Text = (bl_stock_sell1.row_number(user_id) + 1).ToString();
                if (stock_sell1.ProfitORloss > 0)
                {
                    txt_ProfitORloss.BackColor = Color.GreenYellow;
                }
                if (stock_sell1.ProfitORloss < 0)
                {
                    txt_ProfitORloss.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff705e");
                }



            }
        }
        private void onlynumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

        }// mahdood kardane vroodi textbox be adad
        private void onlytext(object sender, KeyPressEventArgs e)
        {
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9'))

                    e.Handled = true;
            }

            // mahdood kardane vroodi textbox be horoof
        }
        private void comboBoxEx1_error_null(object sender, EventArgs e)
        {
            bl_human b = new bl_human();
            if (b.read(user_id).Count == 0)
            {
                errorProvider1.SetError(comboBoxEx1, @"شما تابحال سهامداری را تعریف نکردید" + "\n" +
                    "لطفا ابتدا در تب تعریف سهامدار یک نفر را ثبت کنید");
            }
            else errorProvider1.Clear();

        }
        private void datagrid_stockbuy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1  && e.Button == MouseButtons.Right)
            {

                datagrid_cell_id_rightclick = (int)(datagrid_stockbuy.Rows[e.RowIndex].Cells[0].Value);
                //MessageBox.Show("right" + ((int)(datagrid_stockbuy.Rows[e.RowIndex].Cells[0].Value)).ToString());
            }
            if (e.RowIndex != -1  && e.Button == MouseButtons.Left)
            {

                datagrid_cell_id_leftclickc = (int)(datagrid_stockbuy.Rows[e.RowIndex].Cells[0].Value);
                //SMessageBox.Show("left" + ((int)(datagrid_stockbuy.Rows[e.RowIndex].Cells[0].Value)).ToString());
                stock_buy stock_buy1 = new stock_buy();
                bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
                stock_buy1 = bl_stock_buy1.read(datagrid_cell_id_leftclickc, user_id);

                labelX24.Text = "نام سهم : " + stock_buy1.stock_name;
                {
                    datetime = DateTime.Now;
                    String.Format("{0:MM/dd/yyyy}", datetime);

                    DateTime date_buy = DateTime.Parse(ShamsiToMiladi(stock_buy1.date_buy));
                    DateTime date_now = datetime;
                    int days = date_now.Day - date_buy.Day;
                    if (days < 0)
                    {
                        date_now = date_now.AddMonths(-1);
                        days += DateTime.DaysInMonth(date_now.Year, date_now.Month);
                    }
                    int months = date_now.Month - date_buy.Month;
                    if (months < 0)
                    {
                        date_now = date_now.AddYears(-1);
                        months += 12;
                    }
                    int years = date_now.Year - date_buy.Year;
                    labelX22.Text = "مدت مالکیت سهم :  " + days.ToString() + " روز و " + months.ToString() + " ماه و " + years.ToString() + " سال ";// 
                }// labelX22 محاسبه مقدار روزی که سهام رو در اختیار داشتیم
                Double darsad_kharid = (((double)stock_buy1.fp_buy * (double)100) / total_fp);
                labelX23.Text = " % خرید سهم از سبد : " + darsad_kharid.ToString("N2");
            }
            if (e.RowIndex == -1  && e.Button == MouseButtons.Right)
            {
                datagrid_cell_id_rightclick = 0;
            }
            
        }
        private void datagrid_stocksell_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.Button == MouseButtons.Right)
            {
                datagrid_cell_id_rightclick = (int)(datagrid_stocksell.Rows[e.RowIndex].Cells["id"].Value);
                datagrid_cell_buyid = (int)(datagrid_stocksell.Rows[e.RowIndex].Cells["buy_id"].Value);
                //MessageBox.Show(datagrid_cell_id.ToString());
            }
            if (e.RowIndex == -1 && e.Button == MouseButtons.Right)
            {
                datagrid_cell_id_rightclick = 0;
            }
        }
        private void datagrid_human_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.Button == MouseButtons.Right)
            {
                datagrid_cell_id_human_rightclick = (int)(datagrid_human.Rows[e.RowIndex].Cells[0].Value);
            }
            if (e.RowIndex == -1 && e.Button == MouseButtons.Right)
            {
                datagrid_cell_id_human_rightclick = 0;
            }
        }
        private void read_fullname(object sender, EventArgs e)
        {

            bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
            {
                datagrid_stockbuy.DataSource = null;
                datagrid_stockbuy.DataSource = bl_stock_buy1.read(((human)(comboBoxEx2.SelectedItem)).fullname, user_id);
                datagrid_stockbuy_load();
                total_fp = (Double)(bl_stock_buy1.total_fp_buy_byshareholder(((human)(comboBoxEx2.SelectedItem)).fullname, user_id));
            }

            bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
            {
                datagrid_stocksell.DataSource = null;
                datagrid_stocksell.DataSource = bl_stock_sell1.read(((human)(comboBoxEx3.SelectedItem)).fullname, user_id);
                datagrid_stocksell_load();
            }
        }
        private void form_home_Load(object sender, EventArgs e)
        {
            //namayesh e etelaat shareholder dar combobox va gereftane id
            bl_human blh = new bl_human();
            comboBoxEx1.DataSource = blh.read(user_id);
            comboBoxEx1.DisplayMember = "fullname";
            comboBoxEx1.ValueMember = "id";
            comboBoxEx2.DataSource = blh.read(user_id);
            comboBoxEx2.DisplayMember = "fullname";
            comboBoxEx2.ValueMember = "id";
            comboBoxEx3.DataSource = blh.read(user_id);
            comboBoxEx3.DisplayMember = "fullname";
            comboBoxEx3.ValueMember = "id";

            datetime = DateTime.Now;
            datenow = pc.GetYear(datetime) + " / " + pc.GetMonth(datetime) + " / " + pc.GetDayOfMonth(datetime);
            dateTimeSelector_buy.Text = datenow;
            dateTimeSelector_sell.Text = datenow;

            bl_stock_sell bl_stock_sell1 = new bl_stock_sell();
            bl_stock_buy bl_stock_buy1 = new bl_stock_buy();
            bl_human bl_human1 = new bl_human();

            datagrid_stockbuy.DataSource = null;
            datagrid_stockbuy.DataSource = bl_stock_buy1.read(user_id);
            datagrid_stockbuy_load();
            datagrid_stocksell.DataSource = null;
            datagrid_stocksell.DataSource = bl_stock_sell1.read(user_id);
            datagrid_stocksell_load();
            datagrid_human.DataSource = null;
            datagrid_human.DataSource = bl_human1.read(user_id);
            datagrid_human_load();

            total_fp = bl_stock_buy1.total_fp_buy(user_id);

            panel4.Hide();

            form_setting fs = new form_setting();
            wage_buy = Double.Parse(fs.maskTXT_wage_buy.Text);
            wage_sell= Double.Parse(fs.maskTXT_wage_sell.Text);
            maskTXT_wage_buy.Text = fs.maskTXT_wage_buy.Text;
            maskTXT_wage_sell.Text = fs.maskTXT_wage_sell.Text;

            sideNavItem2.Select();
            
        }
        private void form_home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Exit();


        }
        #region private void textBox_TextChanged(object sender, EventArgs e)
        // ا 3 عدد 3 عدد فاصله گذاری

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (txt_rate_buy.Text != string.Empty)
            {
                txt_rate_buy.Text = string.Format("{0:N0}", double.Parse(txt_rate_buy.Text.Replace(",", "")));
                txt_rate_buy.Select(txt_rate_buy.TextLength, 0);
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (txt_wage_buy.Text != string.Empty)
            {
                txt_wage_buy.Text = string.Format("{0:N0}", decimal.Parse(txt_wage_buy.Text.Replace(",", "")));
                txt_wage_buy.Select(txt_wage_buy.TextLength, 0);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (txt_fp_buy.Text != string.Empty)
            {
                txt_fp_buy.Text = string.Format("{0:N0}", double.Parse(txt_fp_buy.Text.Replace(",", "")));
                txt_fp_buy.Select(txt_fp_buy.TextLength, 0);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (txt_numb_buy.Text != string.Empty)
            {
                txt_numb_buy.Text = string.Format("{0:N0}", double.Parse(txt_numb_buy.Text.Replace(",", "")));
                txt_numb_buy.Select(txt_numb_buy.TextLength, 0);
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (txt_rate_sell.Text != string.Empty)
            {
                txt_rate_sell.Text = string.Format("{0:N0}", double.Parse(txt_rate_sell.Text.Replace(",", "")));
                txt_rate_sell.Select(txt_rate_sell.TextLength, 0);
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (txt_numb_sell.Text != string.Empty)
            {
                txt_numb_sell.Text = string.Format("{0:N0}", double.Parse(txt_numb_sell.Text.Replace(",", "")));
                txt_numb_sell.Select(txt_numb_sell.TextLength, 0);
            }

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (txt_wage_sell.Text != string.Empty)
            {
                txt_wage_sell.Text = string.Format("{0:N0}", double.Parse(txt_wage_sell.Text.Replace(",", "")));
                txt_wage_sell.Select(txt_wage_sell.TextLength, 0);
            }

        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (txtx_fp_sell.Text != string.Empty)
            {
                txtx_fp_sell.Text = string.Format("{0:N0}", double.Parse(txtx_fp_sell.Text.Replace(",", "")));
                txtx_fp_sell.Select(txtx_fp_sell.TextLength, 0);
            }

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (txt_ProfitORloss.Text != string.Empty)
            {
                txt_ProfitORloss.Text = string.Format("{0:N0}", double.Parse(txt_ProfitORloss.Text.Replace(",", "")));
                txt_ProfitORloss.Select(txt_ProfitORloss.TextLength, 0);
            }

        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (txt_price_BEP1.Text != string.Empty)
            {
                txt_price_BEP1.Text = string.Format("{0:N0}", double.Parse(txt_price_BEP1.Text.Replace("'", "")));
                txt_price_BEP1.Select(txt_price_BEP1.TextLength, 0);
            }
        }


        #endregion
        //__________________________harz_______________________________________
        public form_home()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
