namespace naus
{
    partial class stud_prog_ievade
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_prkods;
        private System.Windows.Forms.TextBox tb_prkods;
        private System.Windows.Forms.Label l_prog_nosauk;
        private System.Windows.Forms.TextBox tb_prog_nosauk;
        private System.Windows.Forms.ComboBox cb_prog_veids;
        private System.Windows.Forms.Label l_prog_veids;
        private System.Windows.Forms.Button b_pievienot;
        private System.Windows.Forms.ErrorProvider ep_kluda;
        
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stud_prog_ievade));
            this.l_prkods = new System.Windows.Forms.Label();
            this.tb_prkods = new System.Windows.Forms.TextBox();
            this.l_prog_nosauk = new System.Windows.Forms.Label();
            this.tb_prog_nosauk = new System.Windows.Forms.TextBox();
            this.cb_prog_veids = new System.Windows.Forms.ComboBox();
            this.l_prog_veids = new System.Windows.Forms.Label();
            this.b_pievienot = new System.Windows.Forms.Button();
            this.ep_kluda = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).BeginInit();
            this.SuspendLayout();
            // 
            // l_prkods
            // 
            this.l_prkods.Location = new System.Drawing.Point(12, 10);
            this.l_prkods.Name = "l_prkods";
            this.l_prkods.Size = new System.Drawing.Size(104, 23);
            this.l_prkods.TabIndex = 0;
            this.l_prkods.Text = "Programmas kods:";
            this.l_prkods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_prkods
            // 
            this.tb_prkods.Location = new System.Drawing.Point(122, 12);
            this.tb_prkods.MaxLength = 5;
            this.tb_prkods.Name = "tb_prkods";
            this.tb_prkods.Size = new System.Drawing.Size(150, 20);
            this.tb_prkods.TabIndex = 1;
            this.tb_prkods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_prog_nosauk
            // 
            this.l_prog_nosauk.Location = new System.Drawing.Point(12, 36);
            this.l_prog_nosauk.Name = "l_prog_nosauk";
            this.l_prog_nosauk.Size = new System.Drawing.Size(104, 23);
            this.l_prog_nosauk.TabIndex = 2;
            this.l_prog_nosauk.Text = "Nosaukums:";
            this.l_prog_nosauk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_prog_nosauk
            // 
            this.tb_prog_nosauk.Location = new System.Drawing.Point(122, 38);
            this.tb_prog_nosauk.MaxLength = 50;
            this.tb_prog_nosauk.Multiline = true;
            this.tb_prog_nosauk.Name = "tb_prog_nosauk";
            this.tb_prog_nosauk.Size = new System.Drawing.Size(150, 36);
            this.tb_prog_nosauk.TabIndex = 3;
            this.tb_prog_nosauk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_prog_veids
            // 
            this.cb_prog_veids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_prog_veids.FormattingEnabled = true;
            this.cb_prog_veids.Location = new System.Drawing.Point(122, 80);
            this.cb_prog_veids.Name = "cb_prog_veids";
            this.cb_prog_veids.Size = new System.Drawing.Size(150, 21);
            this.cb_prog_veids.TabIndex = 5;
            // 
            // l_prog_veids
            // 
            this.l_prog_veids.Location = new System.Drawing.Point(12, 78);
            this.l_prog_veids.Name = "l_prog_veids";
            this.l_prog_veids.Size = new System.Drawing.Size(104, 23);
            this.l_prog_veids.TabIndex = 4;
            this.l_prog_veids.Text = "Programmas veids:";
            this.l_prog_veids.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_pievienot
            // 
            this.b_pievienot.Location = new System.Drawing.Point(12, 107);
            this.b_pievienot.Name = "b_pievienot";
            this.b_pievienot.Size = new System.Drawing.Size(260, 23);
            this.b_pievienot.TabIndex = 6;
            this.b_pievienot.Text = "&Pievienot studiju programmas datus";
            this.b_pievienot.UseVisualStyleBackColor = true;
            this.b_pievienot.Click += new System.EventHandler(this.B_pievienotClick);
            // 
            // ep_kluda
            // 
            this.ep_kluda.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ep_kluda.ContainerControl = this;
            this.ep_kluda.Icon = ((System.Drawing.Icon)(resources.GetObject("ep_kluda.Icon")));
            // 
            // stud_prog_ievade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 137);
            this.Controls.Add(this.b_pievienot);
            this.Controls.Add(this.l_prog_veids);
            this.Controls.Add(this.cb_prog_veids);
            this.Controls.Add(this.tb_prog_nosauk);
            this.Controls.Add(this.l_prog_nosauk);
            this.Controls.Add(this.tb_prkods);
            this.Controls.Add(this.l_prkods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(305, 175);
            this.Name = "stud_prog_ievade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pievienot studiju programmu";
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
