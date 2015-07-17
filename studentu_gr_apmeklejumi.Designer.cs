namespace naus
{
    partial class studentu_gr_apmeklejumi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox gb_filtret_apmeklejumus;
        private System.Windows.Forms.TextBox tb_apmeklejumi_teksts;
        private System.Windows.Forms.Button b_atiestatit_apmeklejumi;
        private System.Windows.Forms.Label l_f_apm_teksts;
        private System.Windows.Forms.DataGridView dgv_gr_apmeklejumi;
        private System.Windows.Forms.Label l_gr_apm;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_filtret_apmeklejumus = new System.Windows.Forms.GroupBox();
            this.tb_apmeklejumi_teksts = new System.Windows.Forms.TextBox();
            this.b_atiestatit_apmeklejumi = new System.Windows.Forms.Button();
            this.l_f_apm_teksts = new System.Windows.Forms.Label();
            this.dgv_gr_apmeklejumi = new System.Windows.Forms.DataGridView();
            this.l_gr_apm = new System.Windows.Forms.Label();
            this.gb_filtret_apmeklejumus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gr_apmeklejumi)).BeginInit();
            this.SuspendLayout();
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
            this.gb_filtret_apmeklejumus.TabIndex = 0;
            this.gb_filtret_apmeklejumus.TabStop = false;
            this.gb_filtret_apmeklejumus.Text = "Filtrēt studējošo grupas apmeklējuma datus";
            // 
            // tb_apmeklejumi_teksts
            // 
            this.tb_apmeklejumi_teksts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_apmeklejumi_teksts.Location = new System.Drawing.Point(238, 19);
            this.tb_apmeklejumi_teksts.MaxLength = 50;
            this.tb_apmeklejumi_teksts.Name = "tb_apmeklejumi_teksts";
            this.tb_apmeklejumi_teksts.Size = new System.Drawing.Size(190, 20);
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
            this.l_f_apm_teksts.Size = new System.Drawing.Size(226, 15);
            this.l_f_apm_teksts.TabIndex = 0;
            this.l_f_apm_teksts.Text = "Matrikulas nr./Studējošais/Studiju programma:";
            this.l_f_apm_teksts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_gr_apmeklejumi
            // 
            this.dgv_gr_apmeklejumi.AllowUserToAddRows = false;
            this.dgv_gr_apmeklejumi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_gr_apmeklejumi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_gr_apmeklejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_gr_apmeklejumi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_gr_apmeklejumi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_gr_apmeklejumi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_gr_apmeklejumi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_gr_apmeklejumi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_gr_apmeklejumi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_gr_apmeklejumi.Location = new System.Drawing.Point(12, 79);
            this.dgv_gr_apmeklejumi.MultiSelect = false;
            this.dgv_gr_apmeklejumi.Name = "dgv_gr_apmeklejumi";
            this.dgv_gr_apmeklejumi.ReadOnly = true;
            this.dgv_gr_apmeklejumi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_gr_apmeklejumi.Size = new System.Drawing.Size(560, 321);
            this.dgv_gr_apmeklejumi.TabIndex = 2;
            // 
            // l_gr_apm
            // 
            this.l_gr_apm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_gr_apm.Location = new System.Drawing.Point(12, 61);
            this.l_gr_apm.Name = "l_gr_apm";
            this.l_gr_apm.Size = new System.Drawing.Size(560, 15);
            this.l_gr_apm.TabIndex = 1;
            this.l_gr_apm.Text = "Studējošo grupas apmeklējumi:";
            this.l_gr_apm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // studentu_gr_apmeklejumi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.l_gr_apm);
            this.Controls.Add(this.dgv_gr_apmeklejumi);
            this.Controls.Add(this.gb_filtret_apmeklejumus);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "studentu_gr_apmeklejumi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Studiju kursa nodarbības apmeklējuma datu pārskats";
            this.gb_filtret_apmeklejumus.ResumeLayout(false);
            this.gb_filtret_apmeklejumus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gr_apmeklejumi)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
