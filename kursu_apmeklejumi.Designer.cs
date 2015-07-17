namespace naus
{
    partial class kursu_apmeklejumi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_gr_apm;
        private System.Windows.Forms.DataGridView dgv_kursu_apmeklejumi;
        private System.Windows.Forms.GroupBox gb_filtret_apmeklejumus;
        private System.Windows.Forms.TextBox tb_apmeklejumi_teksts;
        private System.Windows.Forms.Button b_atiestatit_apmeklejumi;
        private System.Windows.Forms.Label l_f_apm_teksts;
        
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.l_gr_apm = new System.Windows.Forms.Label();
            this.dgv_kursu_apmeklejumi = new System.Windows.Forms.DataGridView();
            this.gb_filtret_apmeklejumus = new System.Windows.Forms.GroupBox();
            this.tb_apmeklejumi_teksts = new System.Windows.Forms.TextBox();
            this.b_atiestatit_apmeklejumi = new System.Windows.Forms.Button();
            this.l_f_apm_teksts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kursu_apmeklejumi)).BeginInit();
            this.gb_filtret_apmeklejumus.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_gr_apm
            // 
            this.l_gr_apm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_gr_apm.Location = new System.Drawing.Point(12, 61);
            this.l_gr_apm.Name = "l_gr_apm";
            this.l_gr_apm.Size = new System.Drawing.Size(560, 15);
            this.l_gr_apm.TabIndex = 4;
            this.l_gr_apm.Text = "Studiju kursu apmeklējumi:";
            this.l_gr_apm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_kursu_apmeklejumi
            // 
            this.dgv_kursu_apmeklejumi.AllowUserToAddRows = false;
            this.dgv_kursu_apmeklejumi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_kursu_apmeklejumi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_kursu_apmeklejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_kursu_apmeklejumi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_kursu_apmeklejumi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_kursu_apmeklejumi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_kursu_apmeklejumi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_kursu_apmeklejumi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_kursu_apmeklejumi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_kursu_apmeklejumi.Location = new System.Drawing.Point(12, 79);
            this.dgv_kursu_apmeklejumi.MultiSelect = false;
            this.dgv_kursu_apmeklejumi.Name = "dgv_kursu_apmeklejumi";
            this.dgv_kursu_apmeklejumi.ReadOnly = true;
            this.dgv_kursu_apmeklejumi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_kursu_apmeklejumi.Size = new System.Drawing.Size(560, 321);
            this.dgv_kursu_apmeklejumi.TabIndex = 5;
            // 
            // gb_filtret_apmeklejumus
            // 
            this.gb_filtret_apmeklejumus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_filtret_apmeklejumus.Controls.Add(this.tb_apmeklejumi_teksts);
            this.gb_filtret_apmeklejumus.Controls.Add(this.b_atiestatit_apmeklejumi);
            this.gb_filtret_apmeklejumus.Controls.Add(this.l_f_apm_teksts);
            this.gb_filtret_apmeklejumus.Location = new System.Drawing.Point(12, 12);
            this.gb_filtret_apmeklejumus.Name = "gb_filtret_apmeklejumus";
            this.gb_filtret_apmeklejumus.Size = new System.Drawing.Size(560, 46);
            this.gb_filtret_apmeklejumus.TabIndex = 3;
            this.gb_filtret_apmeklejumus.TabStop = false;
            this.gb_filtret_apmeklejumus.Text = "Filtrēt mācībspēka studiju kursu apmeklējuma datus";
            // 
            // tb_apmeklejumi_teksts
            // 
            this.tb_apmeklejumi_teksts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_apmeklejumi_teksts.Location = new System.Drawing.Point(153, 18);
            this.tb_apmeklejumi_teksts.MaxLength = 50;
            this.tb_apmeklejumi_teksts.Name = "tb_apmeklejumi_teksts";
            this.tb_apmeklejumi_teksts.Size = new System.Drawing.Size(275, 20);
            this.tb_apmeklejumi_teksts.TabIndex = 1;
            this.tb_apmeklejumi_teksts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_apmeklejumi_teksts.TextChanged += new System.EventHandler(this.Tb_apmeklejumi_tekstsTextChanged);
            // 
            // b_atiestatit_apmeklejumi
            // 
            this.b_atiestatit_apmeklejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_atiestatit_apmeklejumi.Location = new System.Drawing.Point(434, 18);
            this.b_atiestatit_apmeklejumi.Name = "b_atiestatit_apmeklejumi";
            this.b_atiestatit_apmeklejumi.Size = new System.Drawing.Size(120, 21);
            this.b_atiestatit_apmeklejumi.TabIndex = 2;
            this.b_atiestatit_apmeklejumi.Text = "Atiestatīt &filtru";
            this.b_atiestatit_apmeklejumi.UseVisualStyleBackColor = true;
            this.b_atiestatit_apmeklejumi.Click += new System.EventHandler(this.B_atiestatit_apmeklejumiClick);
            // 
            // l_f_apm_teksts
            // 
            this.l_f_apm_teksts.Location = new System.Drawing.Point(6, 21);
            this.l_f_apm_teksts.Name = "l_f_apm_teksts";
            this.l_f_apm_teksts.Size = new System.Drawing.Size(141, 15);
            this.l_f_apm_teksts.TabIndex = 0;
            this.l_f_apm_teksts.Text = "Kursa kods/Nosaukums:";
            this.l_f_apm_teksts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kursu_apmeklejumi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.l_gr_apm);
            this.Controls.Add(this.dgv_kursu_apmeklejumi);
            this.Controls.Add(this.gb_filtret_apmeklejumus);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "kursu_apmeklejumi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mācībspēka pasniegto studiju kursu apmeklējuma datu pārskats";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kursu_apmeklejumi)).EndInit();
            this.gb_filtret_apmeklejumus.ResumeLayout(false);
            this.gb_filtret_apmeklejumus.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
