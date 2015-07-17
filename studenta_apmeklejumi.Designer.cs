namespace naus
{
    partial class studenta_apmeklejumi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabc_cilnes;
        private System.Windows.Forms.TabPage tb_ped_kavejumi;
        private System.Windows.Forms.DataGridView dgv_ped_kavejumi;
        private System.Windows.Forms.Label l_ped_kav;
        private System.Windows.Forms.TabPage tb_ped_apmeklejumi;
        private System.Windows.Forms.DataGridView dgv_ped_apmeklejumi;
        private System.Windows.Forms.Label l_ped_apm;
        private System.Windows.Forms.TabPage tb_parskats;
        private System.Windows.Forms.DataGridView dgv_parskats;
        private System.Windows.Forms.Label l__apm_parskats;
        private System.Windows.Forms.GroupBox gb_filtret_kavejumus;
        private System.Windows.Forms.TextBox tb_kavejumi_teksts;
        private System.Windows.Forms.Button b_atiestatit_kavejumus;
        private System.Windows.Forms.Label l_f_kav_teksts;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabc_cilnes = new System.Windows.Forms.TabControl();
            this.tb_parskats = new System.Windows.Forms.TabPage();
            this.dgv_parskats = new System.Windows.Forms.DataGridView();
            this.l__apm_parskats = new System.Windows.Forms.Label();
            this.tb_ped_kavejumi = new System.Windows.Forms.TabPage();
            this.gb_filtret_kavejumus = new System.Windows.Forms.GroupBox();
            this.tb_kavejumi_teksts = new System.Windows.Forms.TextBox();
            this.b_atiestatit_kavejumus = new System.Windows.Forms.Button();
            this.l_f_kav_teksts = new System.Windows.Forms.Label();
            this.dgv_ped_kavejumi = new System.Windows.Forms.DataGridView();
            this.l_ped_kav = new System.Windows.Forms.Label();
            this.tb_ped_apmeklejumi = new System.Windows.Forms.TabPage();
            this.gb_filtret_apmeklejumus = new System.Windows.Forms.GroupBox();
            this.tb_apmeklejumi_teksts = new System.Windows.Forms.TextBox();
            this.b_atiestatit_apmeklejumi = new System.Windows.Forms.Button();
            this.l_f_apm_teksts = new System.Windows.Forms.Label();
            this.dgv_ped_apmeklejumi = new System.Windows.Forms.DataGridView();
            this.l_ped_apm = new System.Windows.Forms.Label();
            this.tabc_cilnes.SuspendLayout();
            this.tb_parskats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_parskats)).BeginInit();
            this.tb_ped_kavejumi.SuspendLayout();
            this.gb_filtret_kavejumus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_kavejumi)).BeginInit();
            this.tb_ped_apmeklejumi.SuspendLayout();
            this.gb_filtret_apmeklejumus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_apmeklejumi)).BeginInit();
            this.SuspendLayout();
            // 
            // tabc_cilnes
            // 
            this.tabc_cilnes.Controls.Add(this.tb_parskats);
            this.tabc_cilnes.Controls.Add(this.tb_ped_kavejumi);
            this.tabc_cilnes.Controls.Add(this.tb_ped_apmeklejumi);
            this.tabc_cilnes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc_cilnes.Location = new System.Drawing.Point(0, 0);
            this.tabc_cilnes.Name = "tabc_cilnes";
            this.tabc_cilnes.SelectedIndex = 0;
            this.tabc_cilnes.Size = new System.Drawing.Size(584, 412);
            this.tabc_cilnes.TabIndex = 0;
            // 
            // tb_parskats
            // 
            this.tb_parskats.BackColor = System.Drawing.SystemColors.Control;
            this.tb_parskats.Controls.Add(this.dgv_parskats);
            this.tb_parskats.Controls.Add(this.l__apm_parskats);
            this.tb_parskats.Location = new System.Drawing.Point(4, 22);
            this.tb_parskats.Name = "tb_parskats";
            this.tb_parskats.Padding = new System.Windows.Forms.Padding(3);
            this.tb_parskats.Size = new System.Drawing.Size(576, 386);
            this.tb_parskats.TabIndex = 1;
            this.tb_parskats.Text = "Nodarbību apmeklējuma pārskats";
            // 
            // dgv_parskats
            // 
            this.dgv_parskats.AllowUserToAddRows = false;
            this.dgv_parskats.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_parskats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_parskats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_parskats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_parskats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_parskats.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_parskats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_parskats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_parskats.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_parskats.Location = new System.Drawing.Point(6, 21);
            this.dgv_parskats.MultiSelect = false;
            this.dgv_parskats.Name = "dgv_parskats";
            this.dgv_parskats.ReadOnly = true;
            this.dgv_parskats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_parskats.Size = new System.Drawing.Size(564, 359);
            this.dgv_parskats.TabIndex = 1;
            // 
            // l__apm_parskats
            // 
            this.l__apm_parskats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l__apm_parskats.Location = new System.Drawing.Point(6, 3);
            this.l__apm_parskats.Name = "l__apm_parskats";
            this.l__apm_parskats.Size = new System.Drawing.Size(564, 15);
            this.l__apm_parskats.TabIndex = 0;
            this.l__apm_parskats.Text = "Studējošā studiju kursu nodarbību apmeklējuma pārskats:";
            this.l__apm_parskats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_ped_kavejumi
            // 
            this.tb_ped_kavejumi.BackColor = System.Drawing.SystemColors.Control;
            this.tb_ped_kavejumi.Controls.Add(this.gb_filtret_kavejumus);
            this.tb_ped_kavejumi.Controls.Add(this.dgv_ped_kavejumi);
            this.tb_ped_kavejumi.Controls.Add(this.l_ped_kav);
            this.tb_ped_kavejumi.Location = new System.Drawing.Point(4, 22);
            this.tb_ped_kavejumi.Name = "tb_ped_kavejumi";
            this.tb_ped_kavejumi.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ped_kavejumi.Size = new System.Drawing.Size(576, 386);
            this.tb_ped_kavejumi.TabIndex = 0;
            this.tb_ped_kavejumi.Text = "Pēdējie nodarbību kavējumi";
            // 
            // gb_filtret_kavejumus
            // 
            this.gb_filtret_kavejumus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_filtret_kavejumus.Controls.Add(this.tb_kavejumi_teksts);
            this.gb_filtret_kavejumus.Controls.Add(this.b_atiestatit_kavejumus);
            this.gb_filtret_kavejumus.Controls.Add(this.l_f_kav_teksts);
            this.gb_filtret_kavejumus.Location = new System.Drawing.Point(6, 6);
            this.gb_filtret_kavejumus.Name = "gb_filtret_kavejumus";
            this.gb_filtret_kavejumus.Size = new System.Drawing.Size(564, 46);
            this.gb_filtret_kavejumus.TabIndex = 0;
            this.gb_filtret_kavejumus.TabStop = false;
            this.gb_filtret_kavejumus.Text = "Filtrēt kavējuma datus";
            // 
            // tb_kavejumi_teksts
            // 
            this.tb_kavejumi_teksts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_kavejumi_teksts.Location = new System.Drawing.Point(242, 19);
            this.tb_kavejumi_teksts.MaxLength = 50;
            this.tb_kavejumi_teksts.Name = "tb_kavejumi_teksts";
            this.tb_kavejumi_teksts.Size = new System.Drawing.Size(192, 20);
            this.tb_kavejumi_teksts.TabIndex = 1;
            this.tb_kavejumi_teksts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_kavejumi_teksts.TextChanged += new System.EventHandler(this.Tb_kavejumi_tekstsTextChanged);
            // 
            // b_atiestatit_kavejumus
            // 
            this.b_atiestatit_kavejumus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_atiestatit_kavejumus.Location = new System.Drawing.Point(438, 18);
            this.b_atiestatit_kavejumus.Name = "b_atiestatit_kavejumus";
            this.b_atiestatit_kavejumus.Size = new System.Drawing.Size(120, 21);
            this.b_atiestatit_kavejumus.TabIndex = 2;
            this.b_atiestatit_kavejumus.Text = "Atiestatīt &filtru";
            this.b_atiestatit_kavejumus.UseVisualStyleBackColor = true;
            this.b_atiestatit_kavejumus.Click += new System.EventHandler(this.B_atiestatit_kavejumusClick);
            // 
            // l_f_kav_teksts
            // 
            this.l_f_kav_teksts.Location = new System.Drawing.Point(6, 21);
            this.l_f_kav_teksts.Name = "l_f_kav_teksts";
            this.l_f_kav_teksts.Size = new System.Drawing.Size(230, 15);
            this.l_f_kav_teksts.TabIndex = 0;
            this.l_f_kav_teksts.Text = "Studiju kurss/Nodarbības veids/Mācībspēks:";
            this.l_f_kav_teksts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_ped_kavejumi
            // 
            this.dgv_ped_kavejumi.AllowUserToAddRows = false;
            this.dgv_ped_kavejumi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_ped_kavejumi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ped_kavejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ped_kavejumi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ped_kavejumi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_ped_kavejumi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ped_kavejumi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ped_kavejumi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ped_kavejumi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ped_kavejumi.Location = new System.Drawing.Point(6, 73);
            this.dgv_ped_kavejumi.MultiSelect = false;
            this.dgv_ped_kavejumi.Name = "dgv_ped_kavejumi";
            this.dgv_ped_kavejumi.ReadOnly = true;
            this.dgv_ped_kavejumi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ped_kavejumi.Size = new System.Drawing.Size(564, 307);
            this.dgv_ped_kavejumi.TabIndex = 2;
            // 
            // l_ped_kav
            // 
            this.l_ped_kav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ped_kav.Location = new System.Drawing.Point(6, 55);
            this.l_ped_kav.Name = "l_ped_kav";
            this.l_ped_kav.Size = new System.Drawing.Size(564, 15);
            this.l_ped_kav.TabIndex = 1;
            this.l_ped_kav.Text = "Studējošā nodarbību kavējumi:";
            this.l_ped_kav.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_ped_apmeklejumi
            // 
            this.tb_ped_apmeklejumi.BackColor = System.Drawing.SystemColors.Control;
            this.tb_ped_apmeklejumi.Controls.Add(this.gb_filtret_apmeklejumus);
            this.tb_ped_apmeklejumi.Controls.Add(this.dgv_ped_apmeklejumi);
            this.tb_ped_apmeklejumi.Controls.Add(this.l_ped_apm);
            this.tb_ped_apmeklejumi.Location = new System.Drawing.Point(4, 22);
            this.tb_ped_apmeklejumi.Name = "tb_ped_apmeklejumi";
            this.tb_ped_apmeklejumi.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ped_apmeklejumi.Size = new System.Drawing.Size(576, 386);
            this.tb_ped_apmeklejumi.TabIndex = 2;
            this.tb_ped_apmeklejumi.Text = "Pēdējie nodarbību apmeklējumi";
            // 
            // gb_filtret_apmeklejumus
            // 
            this.gb_filtret_apmeklejumus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_filtret_apmeklejumus.Controls.Add(this.tb_apmeklejumi_teksts);
            this.gb_filtret_apmeklejumus.Controls.Add(this.b_atiestatit_apmeklejumi);
            this.gb_filtret_apmeklejumus.Controls.Add(this.l_f_apm_teksts);
            this.gb_filtret_apmeklejumus.Location = new System.Drawing.Point(6, 6);
            this.gb_filtret_apmeklejumus.Name = "gb_filtret_apmeklejumus";
            this.gb_filtret_apmeklejumus.Size = new System.Drawing.Size(564, 46);
            this.gb_filtret_apmeklejumus.TabIndex = 0;
            this.gb_filtret_apmeklejumus.TabStop = false;
            this.gb_filtret_apmeklejumus.Text = "Filtrēt apmeklējuma datus";
            // 
            // tb_apmeklejumi_teksts
            // 
            this.tb_apmeklejumi_teksts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_apmeklejumi_teksts.Location = new System.Drawing.Point(242, 19);
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
            this.b_atiestatit_apmeklejumi.Location = new System.Drawing.Point(438, 18);
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
            this.l_f_apm_teksts.Size = new System.Drawing.Size(230, 15);
            this.l_f_apm_teksts.TabIndex = 0;
            this.l_f_apm_teksts.Text = "Studiju kurss/Nodarbības veids/Mācībspēks:";
            this.l_f_apm_teksts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_ped_apmeklejumi
            // 
            this.dgv_ped_apmeklejumi.AllowUserToAddRows = false;
            this.dgv_ped_apmeklejumi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_ped_apmeklejumi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_ped_apmeklejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ped_apmeklejumi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ped_apmeklejumi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_ped_apmeklejumi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ped_apmeklejumi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ped_apmeklejumi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ped_apmeklejumi.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_ped_apmeklejumi.Location = new System.Drawing.Point(6, 73);
            this.dgv_ped_apmeklejumi.MultiSelect = false;
            this.dgv_ped_apmeklejumi.Name = "dgv_ped_apmeklejumi";
            this.dgv_ped_apmeklejumi.ReadOnly = true;
            this.dgv_ped_apmeklejumi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ped_apmeklejumi.Size = new System.Drawing.Size(564, 307);
            this.dgv_ped_apmeklejumi.TabIndex = 2;
            // 
            // l_ped_apm
            // 
            this.l_ped_apm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ped_apm.Location = new System.Drawing.Point(6, 55);
            this.l_ped_apm.Name = "l_ped_apm";
            this.l_ped_apm.Size = new System.Drawing.Size(564, 15);
            this.l_ped_apm.TabIndex = 1;
            this.l_ped_apm.Text = "Studējošā nodarbību apmeklējumi:";
            this.l_ped_apm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // studenta_apmeklejumi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.tabc_cilnes);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "studenta_apmeklejumi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Studējošā individuālo apmeklējuma datu pārskats";
            this.tabc_cilnes.ResumeLayout(false);
            this.tb_parskats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_parskats)).EndInit();
            this.tb_ped_kavejumi.ResumeLayout(false);
            this.gb_filtret_kavejumus.ResumeLayout(false);
            this.gb_filtret_kavejumus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_kavejumi)).EndInit();
            this.tb_ped_apmeklejumi.ResumeLayout(false);
            this.gb_filtret_apmeklejumus.ResumeLayout(false);
            this.gb_filtret_apmeklejumus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_apmeklejumi)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
