namespace naus
{
    partial class autorizacija
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox gb_aut_info;
        private System.Windows.Forms.ComboBox cb_grupa;
        private System.Windows.Forms.Button b_iziet;
        private System.Windows.Forms.Button b_pieslegties;
        private System.Windows.Forms.Label l_grupa;
        private System.Windows.Forms.TextBox tb_parole;
        private System.Windows.Forms.TextBox tb_lietotajs;
        private System.Windows.Forms.Label l_lietotajs;
        private System.Windows.Forms.Label l_parole;
        private System.Windows.Forms.Label l_naus;
        private System.Windows.Forms.Label l_simbols;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(autorizacija));
            this.gb_aut_info = new System.Windows.Forms.GroupBox();
            this.l_parole = new System.Windows.Forms.Label();
            this.l_lietotajs = new System.Windows.Forms.Label();
            this.tb_parole = new System.Windows.Forms.TextBox();
            this.tb_lietotajs = new System.Windows.Forms.TextBox();
            this.b_pieslegties = new System.Windows.Forms.Button();
            this.l_grupa = new System.Windows.Forms.Label();
            this.b_iziet = new System.Windows.Forms.Button();
            this.cb_grupa = new System.Windows.Forms.ComboBox();
            this.l_naus = new System.Windows.Forms.Label();
            this.l_simbols = new System.Windows.Forms.Label();
            this.gb_aut_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_aut_info
            // 
            this.gb_aut_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_aut_info.Controls.Add(this.l_parole);
            this.gb_aut_info.Controls.Add(this.l_lietotajs);
            this.gb_aut_info.Controls.Add(this.tb_parole);
            this.gb_aut_info.Controls.Add(this.tb_lietotajs);
            this.gb_aut_info.Controls.Add(this.b_pieslegties);
            this.gb_aut_info.Controls.Add(this.l_grupa);
            this.gb_aut_info.Controls.Add(this.b_iziet);
            this.gb_aut_info.Controls.Add(this.cb_grupa);
            this.gb_aut_info.Location = new System.Drawing.Point(12, 52);
            this.gb_aut_info.Name = "gb_aut_info";
            this.gb_aut_info.Size = new System.Drawing.Size(280, 142);
            this.gb_aut_info.TabIndex = 2;
            this.gb_aut_info.TabStop = false;
            this.gb_aut_info.Text = "Autorizēšanās informācija";
            // 
            // l_parole
            // 
            this.l_parole.Location = new System.Drawing.Point(6, 85);
            this.l_parole.Name = "l_parole";
            this.l_parole.Size = new System.Drawing.Size(100, 23);
            this.l_parole.TabIndex = 4;
            this.l_parole.Text = "Parole:";
            // 
            // l_lietotajs
            // 
            this.l_lietotajs.Location = new System.Drawing.Point(6, 59);
            this.l_lietotajs.Name = "l_lietotajs";
            this.l_lietotajs.Size = new System.Drawing.Size(100, 23);
            this.l_lietotajs.TabIndex = 2;
            this.l_lietotajs.Text = "Lietotājvārds:";
            // 
            // tb_parole
            // 
            this.tb_parole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_parole.Location = new System.Drawing.Point(112, 82);
            this.tb_parole.MaxLength = 20;
            this.tb_parole.Name = "tb_parole";
            this.tb_parole.Size = new System.Drawing.Size(162, 20);
            this.tb_parole.TabIndex = 5;
            this.tb_parole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_parole.UseSystemPasswordChar = true;
            this.tb_parole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_paroleKeyDown);
            // 
            // tb_lietotajs
            // 
            this.tb_lietotajs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_lietotajs.Location = new System.Drawing.Point(112, 56);
            this.tb_lietotajs.MaxLength = 25;
            this.tb_lietotajs.Name = "tb_lietotajs";
            this.tb_lietotajs.Size = new System.Drawing.Size(162, 20);
            this.tb_lietotajs.TabIndex = 3;
            this.tb_lietotajs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_pieslegties
            // 
            this.b_pieslegties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_pieslegties.Location = new System.Drawing.Point(6, 113);
            this.b_pieslegties.Name = "b_pieslegties";
            this.b_pieslegties.Size = new System.Drawing.Size(180, 23);
            this.b_pieslegties.TabIndex = 6;
            this.b_pieslegties.Text = "&Pieslēgties sistēmai";
            this.b_pieslegties.UseVisualStyleBackColor = true;
            this.b_pieslegties.Click += new System.EventHandler(this.B_pieslegtiesClick);
            // 
            // l_grupa
            // 
            this.l_grupa.Location = new System.Drawing.Point(6, 32);
            this.l_grupa.Name = "l_grupa";
            this.l_grupa.Size = new System.Drawing.Size(100, 23);
            this.l_grupa.TabIndex = 0;
            this.l_grupa.Text = "Lietotāja grupa:";
            // 
            // b_iziet
            // 
            this.b_iziet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_iziet.Location = new System.Drawing.Point(192, 113);
            this.b_iziet.Name = "b_iziet";
            this.b_iziet.Size = new System.Drawing.Size(82, 23);
            this.b_iziet.TabIndex = 7;
            this.b_iziet.Text = "&Iziet";
            this.b_iziet.UseVisualStyleBackColor = true;
            this.b_iziet.Click += new System.EventHandler(this.B_izietClick);
            // 
            // cb_grupa
            // 
            this.cb_grupa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_grupa.DisplayMember = "1";
            this.cb_grupa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_grupa.FormattingEnabled = true;
            this.cb_grupa.Items.AddRange(new object[] {
            "Mācībspēks",
            "Vadība",
            "Students"});
            this.cb_grupa.Location = new System.Drawing.Point(112, 29);
            this.cb_grupa.Name = "cb_grupa";
            this.cb_grupa.Size = new System.Drawing.Size(162, 21);
            this.cb_grupa.TabIndex = 1;
            this.cb_grupa.SelectedIndexChanged += new System.EventHandler(this.Cb_grupaSelectedIndexChanged);
            // 
            // l_naus
            // 
            this.l_naus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_naus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_naus.Location = new System.Drawing.Point(115, 9);
            this.l_naus.Name = "l_naus";
            this.l_naus.Size = new System.Drawing.Size(120, 40);
            this.l_naus.TabIndex = 1;
            this.l_naus.Text = "NAUS";
            this.l_naus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_simbols
            // 
            this.l_simbols.Font = new System.Drawing.Font("Wingdings", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.l_simbols.Location = new System.Drawing.Point(69, 9);
            this.l_simbols.Name = "l_simbols";
            this.l_simbols.Size = new System.Drawing.Size(40, 40);
            this.l_simbols.TabIndex = 0;
            this.l_simbols.Text = "¾";
            this.l_simbols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autorizacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 206);
            this.Controls.Add(this.l_simbols);
            this.Controls.Add(this.l_naus);
            this.Controls.Add(this.gb_aut_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "autorizacija";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nodarbību apmeklējuma uzskaites sistēma";
            this.gb_aut_info.ResumeLayout(false);
            this.gb_aut_info.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
