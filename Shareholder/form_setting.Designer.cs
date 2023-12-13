namespace Shareholder
{
    partial class form_setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.maskTXT_wage_buy = new System.Windows.Forms.MaskedTextBox();
            this.maskTXT_wage_sell = new System.Windows.Forms.MaskedTextBox();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(134, 63);
            this.labelX11.Name = "labelX11";
            this.labelX11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX11.Size = new System.Drawing.Size(73, 20);
            this.labelX11.TabIndex = 57;
            this.labelX11.Text = "درصد کارمزد خرید";
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(119, 122);
            this.labelX15.Name = "labelX15";
            this.labelX15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX15.Size = new System.Drawing.Size(88, 23);
            this.labelX15.TabIndex = 58;
            this.labelX15.Text = "درصد کارمزد فروش";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.maskTXT_wage_buy);
            this.panelEx1.Controls.Add(this.labelX15);
            this.panelEx1.Controls.Add(this.labelX11);
            this.panelEx1.Controls.Add(this.maskTXT_wage_sell);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(284, 261);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 59;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 226);
            this.labelX1.Name = "labelX1";
            this.labelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX1.Size = new System.Drawing.Size(260, 23);
            this.labelX1.TabIndex = 60;
            this.labelX1.Text = "تنظیم درصد کارمزد خرید به صورت پیشفرض     ";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(96, 174);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(89, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 59;
            this.buttonX1.Text = "ذخیره";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // maskTXT_wage_buy
            // 
            this.maskTXT_wage_buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Shareholder.Properties.Settings.Default, "Percentageofwage_buy_defualt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maskTXT_wage_buy.Location = new System.Drawing.Point(77, 89);
            this.maskTXT_wage_buy.Mask = "0.00000";
            this.maskTXT_wage_buy.Name = "maskTXT_wage_buy";
            this.maskTXT_wage_buy.Size = new System.Drawing.Size(130, 20);
            this.maskTXT_wage_buy.TabIndex = 55;
            this.maskTXT_wage_buy.Text = global::Shareholder.Properties.Settings.Default.Percentageofwage_buy_defualt;
            this.maskTXT_wage_buy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskTXT_wage_sell
            // 
            this.maskTXT_wage_sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Shareholder.Properties.Settings.Default, "Percentageofwage_sell_default", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maskTXT_wage_sell.Location = new System.Drawing.Point(77, 148);
            this.maskTXT_wage_sell.Mask = "0.00000";
            this.maskTXT_wage_sell.Name = "maskTXT_wage_sell";
            this.maskTXT_wage_sell.Size = new System.Drawing.Size(130, 20);
            this.maskTXT_wage_sell.TabIndex = 56;
            this.maskTXT_wage_sell.Text = global::Shareholder.Properties.Settings.Default.Percentageofwage_sell_default;
            this.maskTXT_wage_sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // form_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panelEx1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "form_setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تنظیمات";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        public System.Windows.Forms.MaskedTextBox maskTXT_wage_buy;
        public System.Windows.Forms.MaskedTextBox maskTXT_wage_sell;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}