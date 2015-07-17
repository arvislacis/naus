namespace naus
{
    partial class nodarbibu_ievade
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_idmacsp;
        private System.Windows.Forms.ComboBox cb_idmacsp;
        private System.Windows.Forms.ComboBox cb_nod_veids;
        private System.Windows.Forms.Label l_nod_veids;
        private System.Windows.Forms.DateTimePicker dtp_dat_no;
        private System.Windows.Forms.Label l_dat_no;
        private System.Windows.Forms.DateTimePicker dtp_dat_lidz;
        private System.Windows.Forms.Label l_dat_lidz;
        private System.Windows.Forms.ComboBox cb_ned_diena;
        private System.Windows.Forms.Label l_ned_diena;
        private System.Windows.Forms.ComboBox cb_laiks;
        private System.Windows.Forms.Label l_laiks;
        private System.Windows.Forms.Button b_pievienot;
        private System.Windows.Forms.Label l_idkkods;
        private System.Windows.Forms.ComboBox cb_idkkods;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nodarbibu_ievade));
            this.l_idmacsp = new System.Windows.Forms.Label();
            this.cb_idmacsp = new System.Windows.Forms.ComboBox();
            this.cb_nod_veids = new System.Windows.Forms.ComboBox();
            this.l_nod_veids = new System.Windows.Forms.Label();
            this.dtp_dat_no = new System.Windows.Forms.DateTimePicker();
            this.l_dat_no = new System.Windows.Forms.Label();
            this.dtp_dat_lidz = new System.Windows.Forms.DateTimePicker();
            this.l_dat_lidz = new System.Windows.Forms.Label();
            this.cb_ned_diena = new System.Windows.Forms.ComboBox();
            this.l_ned_diena = new System.Windows.Forms.Label();
            this.cb_laiks = new System.Windows.Forms.ComboBox();
            this.l_laiks = new System.Windows.Forms.Label();
            this.b_pievienot = new System.Windows.Forms.Button();
            this.l_idkkods = new System.Windows.Forms.Label();
            this.cb_idkkods = new System.Windows.Forms.ComboBox();
            this.ep_kluda = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).BeginInit();
            this.SuspendLayout();
            // 
            // l_idmacsp
            // 
            this.l_idmacsp.Location = new System.Drawing.Point(12, 37);
            this.l_idmacsp.Name = "l_idmacsp";
            this.l_idmacsp.Size = new System.Drawing.Size(104, 23);
            this.l_idmacsp.TabIndex = 2;
            this.l_idmacsp.Text = "Mācībspēks:";
            this.l_idmacsp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_idmacsp
            // 
            this.cb_idmacsp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_idmacsp.FormattingEnabled = true;
            this.cb_idmacsp.Location = new System.Drawing.Point(122, 39);
            this.cb_idmacsp.Name = "cb_idmacsp";
            this.cb_idmacsp.Size = new System.Drawing.Size(250, 21);
            this.cb_idmacsp.TabIndex = 3;
            // 
            // cb_nod_veids
            // 
            this.cb_nod_veids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nod_veids.FormattingEnabled = true;
            this.cb_nod_veids.Location = new System.Drawing.Point(122, 66);
            this.cb_nod_veids.Name = "cb_nod_veids";
            this.cb_nod_veids.Size = new System.Drawing.Size(250, 21);
            this.cb_nod_veids.TabIndex = 5;
            // 
            // l_nod_veids
            // 
            this.l_nod_veids.Location = new System.Drawing.Point(12, 64);
            this.l_nod_veids.Name = "l_nod_veids";
            this.l_nod_veids.Size = new System.Drawing.Size(104, 23);
            this.l_nod_veids.TabIndex = 4;
            this.l_nod_veids.Text = "Nodarbības veids:";
            this.l_nod_veids.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_dat_no
            // 
            this.dtp_dat_no.Location = new System.Drawing.Point(122, 93);
            this.dtp_dat_no.MaxDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtp_dat_no.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_dat_no.Name = "dtp_dat_no";
            this.dtp_dat_no.Size = new System.Drawing.Size(250, 20);
            this.dtp_dat_no.TabIndex = 7;
            this.dtp_dat_no.Value = new System.DateTime(2015, 5, 1, 0, 0, 0, 0);
            // 
            // l_dat_no
            // 
            this.l_dat_no.Location = new System.Drawing.Point(12, 94);
            this.l_dat_no.Name = "l_dat_no";
            this.l_dat_no.Size = new System.Drawing.Size(104, 23);
            this.l_dat_no.TabIndex = 6;
            this.l_dat_no.Text = "Datums no:";
            this.l_dat_no.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_dat_lidz
            // 
            this.dtp_dat_lidz.Location = new System.Drawing.Point(122, 119);
            this.dtp_dat_lidz.MaxDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtp_dat_lidz.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_dat_lidz.Name = "dtp_dat_lidz";
            this.dtp_dat_lidz.Size = new System.Drawing.Size(250, 20);
            this.dtp_dat_lidz.TabIndex = 9;
            this.dtp_dat_lidz.Value = new System.DateTime(2015, 5, 1, 0, 0, 0, 0);
            // 
            // l_dat_lidz
            // 
            this.l_dat_lidz.Location = new System.Drawing.Point(12, 120);
            this.l_dat_lidz.Name = "l_dat_lidz";
            this.l_dat_lidz.Size = new System.Drawing.Size(104, 23);
            this.l_dat_lidz.TabIndex = 8;
            this.l_dat_lidz.Text = "Datums līdz:";
            this.l_dat_lidz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_ned_diena
            // 
            this.cb_ned_diena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ned_diena.FormattingEnabled = true;
            this.cb_ned_diena.Location = new System.Drawing.Point(122, 145);
            this.cb_ned_diena.Name = "cb_ned_diena";
            this.cb_ned_diena.Size = new System.Drawing.Size(250, 21);
            this.cb_ned_diena.TabIndex = 11;
            // 
            // l_ned_diena
            // 
            this.l_ned_diena.Location = new System.Drawing.Point(12, 143);
            this.l_ned_diena.Name = "l_ned_diena";
            this.l_ned_diena.Size = new System.Drawing.Size(104, 23);
            this.l_ned_diena.TabIndex = 10;
            this.l_ned_diena.Text = "Nedēļas diena:";
            this.l_ned_diena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_laiks
            // 
            this.cb_laiks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_laiks.FormattingEnabled = true;
            this.cb_laiks.Location = new System.Drawing.Point(122, 172);
            this.cb_laiks.Name = "cb_laiks";
            this.cb_laiks.Size = new System.Drawing.Size(250, 21);
            this.cb_laiks.TabIndex = 13;
            // 
            // l_laiks
            // 
            this.l_laiks.Location = new System.Drawing.Point(12, 170);
            this.l_laiks.Name = "l_laiks";
            this.l_laiks.Size = new System.Drawing.Size(104, 23);
            this.l_laiks.TabIndex = 12;
            this.l_laiks.Text = "Laiks:";
            this.l_laiks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_pievienot
            // 
            this.b_pievienot.Location = new System.Drawing.Point(12, 199);
            this.b_pievienot.Name = "b_pievienot";
            this.b_pievienot.Size = new System.Drawing.Size(360, 23);
            this.b_pievienot.TabIndex = 14;
            this.b_pievienot.Text = "&Pievienot nodarbības datus";
            this.b_pievienot.UseVisualStyleBackColor = true;
            this.b_pievienot.Click += new System.EventHandler(this.B_pievienotClick);
            // 
            // l_idkkods
            // 
            this.l_idkkods.Location = new System.Drawing.Point(12, 10);
            this.l_idkkods.Name = "l_idkkods";
            this.l_idkkods.Size = new System.Drawing.Size(104, 23);
            this.l_idkkods.TabIndex = 0;
            this.l_idkkods.Text = "Studiju kurss:";
            this.l_idkkods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_idkkods
            // 
            this.cb_idkkods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_idkkods.FormattingEnabled = true;
            this.cb_idkkods.Location = new System.Drawing.Point(122, 12);
            this.cb_idkkods.Name = "cb_idkkods";
            this.cb_idkkods.Size = new System.Drawing.Size(250, 21);
            this.cb_idkkods.TabIndex = 1;
            // 
            // ep_kluda
            // 
            this.ep_kluda.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ep_kluda.ContainerControl = this;
            this.ep_kluda.Icon = ((System.Drawing.Icon)(resources.GetObject("ep_kluda.Icon")));
            // 
            // nodarbibu_ievade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 227);
            this.Controls.Add(this.cb_idkkods);
            this.Controls.Add(this.l_idkkods);
            this.Controls.Add(this.b_pievienot);
            this.Controls.Add(this.l_laiks);
            this.Controls.Add(this.cb_laiks);
            this.Controls.Add(this.l_ned_diena);
            this.Controls.Add(this.cb_ned_diena);
            this.Controls.Add(this.l_dat_lidz);
            this.Controls.Add(this.dtp_dat_lidz);
            this.Controls.Add(this.l_dat_no);
            this.Controls.Add(this.dtp_dat_no);
            this.Controls.Add(this.l_nod_veids);
            this.Controls.Add(this.cb_nod_veids);
            this.Controls.Add(this.cb_idmacsp);
            this.Controls.Add(this.l_idmacsp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 265);
            this.Name = "nodarbibu_ievade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pievienot nodarbību";
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
