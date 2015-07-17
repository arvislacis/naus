namespace naus
{
    partial class stud_kursu_ievade
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_kkods;
        private System.Windows.Forms.TextBox tb_kkods;
        private System.Windows.Forms.TextBox tb_k_nosauk;
        private System.Windows.Forms.Label l_k_nosauk;
        private System.Windows.Forms.NumericUpDown nud_kp;
        private System.Windows.Forms.Label l_kp;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stud_kursu_ievade));
            this.l_kkods = new System.Windows.Forms.Label();
            this.tb_kkods = new System.Windows.Forms.TextBox();
            this.tb_k_nosauk = new System.Windows.Forms.TextBox();
            this.l_k_nosauk = new System.Windows.Forms.Label();
            this.nud_kp = new System.Windows.Forms.NumericUpDown();
            this.l_kp = new System.Windows.Forms.Label();
            this.b_pievienot = new System.Windows.Forms.Button();
            this.ep_kluda = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nud_kp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).BeginInit();
            this.SuspendLayout();
            // 
            // l_kkods
            // 
            this.l_kkods.Location = new System.Drawing.Point(12, 10);
            this.l_kkods.Name = "l_kkods";
            this.l_kkods.Size = new System.Drawing.Size(104, 23);
            this.l_kkods.TabIndex = 0;
            this.l_kkods.Text = "Kursa kods:";
            this.l_kkods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_kkods
            // 
            this.tb_kkods.Location = new System.Drawing.Point(122, 12);
            this.tb_kkods.MaxLength = 8;
            this.tb_kkods.Name = "tb_kkods";
            this.tb_kkods.Size = new System.Drawing.Size(250, 20);
            this.tb_kkods.TabIndex = 1;
            this.tb_kkods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_k_nosauk
            // 
            this.tb_k_nosauk.Location = new System.Drawing.Point(122, 38);
            this.tb_k_nosauk.MaxLength = 50;
            this.tb_k_nosauk.Name = "tb_k_nosauk";
            this.tb_k_nosauk.Size = new System.Drawing.Size(250, 20);
            this.tb_k_nosauk.TabIndex = 3;
            this.tb_k_nosauk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_k_nosauk
            // 
            this.l_k_nosauk.Location = new System.Drawing.Point(12, 36);
            this.l_k_nosauk.Name = "l_k_nosauk";
            this.l_k_nosauk.Size = new System.Drawing.Size(104, 23);
            this.l_k_nosauk.TabIndex = 2;
            this.l_k_nosauk.Text = "Nosaukums:";
            this.l_k_nosauk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_kp
            // 
            this.nud_kp.DecimalPlaces = 2;
            this.nud_kp.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nud_kp.Location = new System.Drawing.Point(122, 64);
            this.nud_kp.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nud_kp.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nud_kp.Name = "nud_kp";
            this.nud_kp.Size = new System.Drawing.Size(250, 20);
            this.nud_kp.TabIndex = 5;
            this.nud_kp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_kp.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // l_kp
            // 
            this.l_kp.Location = new System.Drawing.Point(12, 61);
            this.l_kp.Name = "l_kp";
            this.l_kp.Size = new System.Drawing.Size(104, 23);
            this.l_kp.TabIndex = 4;
            this.l_kp.Text = "Kredītpunkti:";
            this.l_kp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_pievienot
            // 
            this.b_pievienot.Location = new System.Drawing.Point(12, 90);
            this.b_pievienot.Name = "b_pievienot";
            this.b_pievienot.Size = new System.Drawing.Size(360, 23);
            this.b_pievienot.TabIndex = 6;
            this.b_pievienot.Text = "&Pievienot studiju kursa datus";
            this.b_pievienot.UseVisualStyleBackColor = true;
            this.b_pievienot.Click += new System.EventHandler(this.B_pievienotClick);
            // 
            // ep_kluda
            // 
            this.ep_kluda.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ep_kluda.ContainerControl = this;
            this.ep_kluda.Icon = ((System.Drawing.Icon)(resources.GetObject("ep_kluda.Icon")));
            // 
            // stud_kursu_ievade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 122);
            this.Controls.Add(this.b_pievienot);
            this.Controls.Add(this.l_kp);
            this.Controls.Add(this.nud_kp);
            this.Controls.Add(this.l_k_nosauk);
            this.Controls.Add(this.tb_k_nosauk);
            this.Controls.Add(this.tb_kkods);
            this.Controls.Add(this.l_kkods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 160);
            this.Name = "stud_kursu_ievade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pievienot studiju kursu";
            ((System.ComponentModel.ISupportInitialize)(this.nud_kp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
