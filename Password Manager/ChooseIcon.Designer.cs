namespace Password_Manager
{
    partial class ChooseIcon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseIcon));
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(297, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 247);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose icon and click OK";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "document_empty.png");
            this.imageList1.Images.SetKeyName(1, "acoustic_guitar.png");
            this.imageList1.Images.SetKeyName(2, "address_block.png");
            this.imageList1.Images.SetKeyName(3, "advanced_data_grid.png");
            this.imageList1.Images.SetKeyName(4, "anchor.png");
            this.imageList1.Images.SetKeyName(5, "android.png");
            this.imageList1.Images.SetKeyName(6, "apple_corp.png");
            this.imageList1.Images.SetKeyName(7, "application_form.png");
            this.imageList1.Images.SetKeyName(8, "application_home.png");
            this.imageList1.Images.SetKeyName(9, "application_key.png");
            this.imageList1.Images.SetKeyName(10, "application_lightning.png");
            this.imageList1.Images.SetKeyName(11, "balance.png");
            this.imageList1.Images.SetKeyName(12, "barchart.png");
            this.imageList1.Images.SetKeyName(13, "basket_shopping.png");
            this.imageList1.Images.SetKeyName(14, "bibliography.png");
            this.imageList1.Images.SetKeyName(15, "blackberry.png");
            this.imageList1.Images.SetKeyName(16, "blank_report.png");
            this.imageList1.Images.SetKeyName(17, "cactus.png");
            this.imageList1.Images.SetKeyName(18, "car.png");
            this.imageList1.Images.SetKeyName(19, "card_back.png");
            this.imageList1.Images.SetKeyName(20, "card_bank.png");
            this.imageList1.Images.SetKeyName(21, "chart_bar.png");
            this.imageList1.Images.SetKeyName(22, "clock.png");
            this.imageList1.Images.SetKeyName(23, "coins_in_hand.png");
            this.imageList1.Images.SetKeyName(24, "comment_facebook.png");
            this.imageList1.Images.SetKeyName(25, "cutlery.png");
            this.imageList1.Images.SetKeyName(26, "email.png");
            this.imageList1.Images.SetKeyName(27, "facebook.png");
            this.imageList1.Images.SetKeyName(28, "globe_place.png");
            this.imageList1.Images.SetKeyName(29, "hamburger.png");
            this.imageList1.Images.SetKeyName(30, "ilike.png");
            this.imageList1.Images.SetKeyName(31, "information.png");
            this.imageList1.Images.SetKeyName(32, "iphone.png");
            this.imageList1.Images.SetKeyName(33, "key.png");
            this.imageList1.Images.SetKeyName(34, "lcd_tv.png");
            this.imageList1.Images.SetKeyName(35, "linkedin.png");
            this.imageList1.Images.SetKeyName(36, "lorry_flatbed.png");
            this.imageList1.Images.SetKeyName(37, "luggage.png");
            this.imageList1.Images.SetKeyName(38, "network_tools.png");
            this.imageList1.Images.SetKeyName(39, "network_wireless.png");
            this.imageList1.Images.SetKeyName(40, "palette.png");
            this.imageList1.Images.SetKeyName(41, "sport_basketball.png");
            this.imageList1.Images.SetKeyName(42, "text_document.png");
            this.imageList1.Images.SetKeyName(43, "youtube.png");
            // 
            // ChooseIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChooseIcon";
            this.Text = "Choose Icon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
    }
}