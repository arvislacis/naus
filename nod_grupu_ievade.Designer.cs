namespace naus
{
    partial class nod_grupu_ievade
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button b_pievienot;
        private System.Windows.Forms.Label l_grupa;
        private System.Windows.Forms.ComboBox cb_grupa;
        private System.Windows.Forms.Label l_kurss;
        private System.Windows.Forms.ComboBox cb_kurss;
        private System.Windows.Forms.ComboBox cb_stud_prog;
        private System.Windows.Forms.Label l_stud_prog;
        private System.Windows.Forms.Label l_stud_kurss;
        private System.Windows.Forms.Label l_nod_veids;
        private System.Windows.Forms.Label l_dat_no;
        private System.Windows.Forms.Label l_dat_lidz;
        private System.Windows.Forms.Label l_ned_diena;
        private System.Windows.Forms.Label l_laiks;
        private System.Windows.Forms.Label l_stud_kurss_nosauk;
        private System.Windows.Forms.Label l_nod_veida_nosauk;
        private System.Windows.Forms.Label l_dat_no_vert;
        private System.Windows.Forms.Label l_dat_lidz_vert;
        private System.Windows.Forms.Label l_ned_diena_vert;
        private System.Windows.Forms.Label l_laiks_vert;
        private System.Windows.Forms.Label l_macsp;
        private System.Windows.Forms.Label l_macsp_nosauk;
        
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
            this.b_pievienot = new System.Windows.Forms.Button();
            this.l_grupa = new System.Windows.Forms.Label();
            this.cb_grupa = new System.Windows.Forms.ComboBox();
            this.l_kurss = new System.Windows.Forms.Label();
            this.cb_kurss = new System.Windows.Forms.ComboBox();
            this.cb_stud_prog = new System.Windows.Forms.ComboBox();
            this.l_stud_prog = new System.Windows.Forms.Label();
            this.l_stud_kurss = new System.Windows.Forms.Label();
            this.l_nod_veids = new System.Windows.Forms.Label();
            this.l_dat_no = new System.Windows.Forms.Label();
            this.l_dat_lidz = new System.Windows.Forms.Label();
            this.l_ned_diena = new System.Windows.Forms.Label();
            this.l_laiks = new System.Windows.Forms.Label();
            this.l_stud_kurss_nosauk = new System.Windows.Forms.Label();
            this.l_nod_veida_nosauk = new System.Windows.Forms.Label();
            this.l_dat_no_vert = new System.Windows.Forms.Label();
            this.l_dat_lidz_vert = new System.Windows.Forms.Label();
            this.l_ned_diena_vert = new System.Windows.Forms.Label();
            this.l_laiks_vert = new System.Windows.Forms.Label();
            this.l_macsp = new System.Windows.Forms.Label();
            this.l_macsp_nosauk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_pievienot
            // 
            this.b_pievienot.Location = new System.Drawing.Point(12, 206);
            this.b_pievienot.Name = "b_pievienot";
            this.b_pievienot.Size = new System.Drawing.Size(360, 23);
            this.b_pievienot.TabIndex = 20;
            this.b_pievienot.Text = "&Pievienot studējošo grupas datus";
            this.b_pievienot.UseVisualStyleBackColor = true;
            this.b_pievienot.Click += new System.EventHandler(this.B_pievienotClick);
            // 
            // l_grupa
            // 
            this.l_grupa.Location = new System.Drawing.Point(226, 177);
            this.l_grupa.Name = "l_grupa";
            this.l_grupa.Size = new System.Drawing.Size(42, 23);
            this.l_grupa.TabIndex = 18;
            this.l_grupa.Text = "Grupa:";
            this.l_grupa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_grupa
            // 
            this.cb_grupa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_grupa.FormattingEnabled = true;
            this.cb_grupa.Location = new System.Drawing.Point(274, 179);
            this.cb_grupa.Name = "cb_grupa";
            this.cb_grupa.Size = new System.Drawing.Size(98, 21);
            this.cb_grupa.TabIndex = 19;
            // 
            // l_kurss
            // 
            this.l_kurss.Location = new System.Drawing.Point(12, 177);
            this.l_kurss.Name = "l_kurss";
            this.l_kurss.Size = new System.Drawing.Size(104, 23);
            this.l_kurss.TabIndex = 16;
            this.l_kurss.Text = "Kurss:";
            this.l_kurss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_kurss
            // 
            this.cb_kurss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kurss.FormattingEnabled = true;
            this.cb_kurss.Location = new System.Drawing.Point(122, 179);
            this.cb_kurss.Name = "cb_kurss";
            this.cb_kurss.Size = new System.Drawing.Size(98, 21);
            this.cb_kurss.TabIndex = 17;
            // 
            // cb_stud_prog
            // 
            this.cb_stud_prog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_stud_prog.FormattingEnabled = true;
            this.cb_stud_prog.Location = new System.Drawing.Point(122, 152);
            this.cb_stud_prog.Name = "cb_stud_prog";
            this.cb_stud_prog.Size = new System.Drawing.Size(250, 21);
            this.cb_stud_prog.TabIndex = 15;
            // 
            // l_stud_prog
            // 
            this.l_stud_prog.Location = new System.Drawing.Point(12, 150);
            this.l_stud_prog.Name = "l_stud_prog";
            this.l_stud_prog.Size = new System.Drawing.Size(104, 23);
            this.l_stud_prog.TabIndex = 14;
            this.l_stud_prog.Text = "Studiju programma:";
            this.l_stud_prog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_stud_kurss
            // 
            this.l_stud_kurss.Location = new System.Drawing.Point(12, 29);
            this.l_stud_kurss.Name = "l_stud_kurss";
            this.l_stud_kurss.Size = new System.Drawing.Size(104, 20);
            this.l_stud_kurss.TabIndex = 2;
            this.l_stud_kurss.Text = "Studiju kurss:";
            this.l_stud_kurss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_nod_veids
            // 
            this.l_nod_veids.Location = new System.Drawing.Point(12, 49);
            this.l_nod_veids.Name = "l_nod_veids";
            this.l_nod_veids.Size = new System.Drawing.Size(104, 20);
            this.l_nod_veids.TabIndex = 4;
            this.l_nod_veids.Text = "Nodarbības veids:";
            this.l_nod_veids.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_dat_no
            // 
            this.l_dat_no.Location = new System.Drawing.Point(12, 69);
            this.l_dat_no.Name = "l_dat_no";
            this.l_dat_no.Size = new System.Drawing.Size(104, 20);
            this.l_dat_no.TabIndex = 6;
            this.l_dat_no.Text = "Datums no:";
            this.l_dat_no.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_dat_lidz
            // 
            this.l_dat_lidz.Location = new System.Drawing.Point(12, 89);
            this.l_dat_lidz.Name = "l_dat_lidz";
            this.l_dat_lidz.Size = new System.Drawing.Size(104, 20);
            this.l_dat_lidz.TabIndex = 8;
            this.l_dat_lidz.Text = "Datums līdz:";
            this.l_dat_lidz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_ned_diena
            // 
            this.l_ned_diena.Location = new System.Drawing.Point(12, 109);
            this.l_ned_diena.Name = "l_ned_diena";
            this.l_ned_diena.Size = new System.Drawing.Size(104, 20);
            this.l_ned_diena.TabIndex = 10;
            this.l_ned_diena.Text = "Nedēļas diena:";
            this.l_ned_diena.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_laiks
            // 
            this.l_laiks.Location = new System.Drawing.Point(12, 129);
            this.l_laiks.Name = "l_laiks";
            this.l_laiks.Size = new System.Drawing.Size(104, 20);
            this.l_laiks.TabIndex = 12;
            this.l_laiks.Text = "Laiks:";
            this.l_laiks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_stud_kurss_nosauk
            // 
            this.l_stud_kurss_nosauk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_stud_kurss_nosauk.Location = new System.Drawing.Point(122, 29);
            this.l_stud_kurss_nosauk.Name = "l_stud_kurss_nosauk";
            this.l_stud_kurss_nosauk.Size = new System.Drawing.Size(250, 20);
            this.l_stud_kurss_nosauk.TabIndex = 3;
            this.l_stud_kurss_nosauk.Text = "Studiju kursa nosaukums";
            this.l_stud_kurss_nosauk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_nod_veida_nosauk
            // 
            this.l_nod_veida_nosauk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_nod_veida_nosauk.Location = new System.Drawing.Point(122, 49);
            this.l_nod_veida_nosauk.Name = "l_nod_veida_nosauk";
            this.l_nod_veida_nosauk.Size = new System.Drawing.Size(250, 20);
            this.l_nod_veida_nosauk.TabIndex = 5;
            this.l_nod_veida_nosauk.Text = "Nodarbības veida nosaukums";
            this.l_nod_veida_nosauk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_dat_no_vert
            // 
            this.l_dat_no_vert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_dat_no_vert.Location = new System.Drawing.Point(122, 69);
            this.l_dat_no_vert.Name = "l_dat_no_vert";
            this.l_dat_no_vert.Size = new System.Drawing.Size(250, 20);
            this.l_dat_no_vert.TabIndex = 7;
            this.l_dat_no_vert.Text = "Datums no";
            this.l_dat_no_vert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_dat_lidz_vert
            // 
            this.l_dat_lidz_vert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_dat_lidz_vert.Location = new System.Drawing.Point(122, 89);
            this.l_dat_lidz_vert.Name = "l_dat_lidz_vert";
            this.l_dat_lidz_vert.Size = new System.Drawing.Size(250, 20);
            this.l_dat_lidz_vert.TabIndex = 9;
            this.l_dat_lidz_vert.Text = "Datums līdz";
            this.l_dat_lidz_vert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_ned_diena_vert
            // 
            this.l_ned_diena_vert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_ned_diena_vert.Location = new System.Drawing.Point(122, 109);
            this.l_ned_diena_vert.Name = "l_ned_diena_vert";
            this.l_ned_diena_vert.Size = new System.Drawing.Size(250, 20);
            this.l_ned_diena_vert.TabIndex = 11;
            this.l_ned_diena_vert.Text = "Ned. diena";
            this.l_ned_diena_vert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_laiks_vert
            // 
            this.l_laiks_vert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_laiks_vert.Location = new System.Drawing.Point(122, 129);
            this.l_laiks_vert.Name = "l_laiks_vert";
            this.l_laiks_vert.Size = new System.Drawing.Size(250, 20);
            this.l_laiks_vert.TabIndex = 13;
            this.l_laiks_vert.Text = "Laiks";
            this.l_laiks_vert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_macsp
            // 
            this.l_macsp.Location = new System.Drawing.Point(12, 9);
            this.l_macsp.Name = "l_macsp";
            this.l_macsp.Size = new System.Drawing.Size(104, 20);
            this.l_macsp.TabIndex = 0;
            this.l_macsp.Text = "Mācībspēks:";
            this.l_macsp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_macsp_nosauk
            // 
            this.l_macsp_nosauk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.l_macsp_nosauk.Location = new System.Drawing.Point(122, 9);
            this.l_macsp_nosauk.Name = "l_macsp_nosauk";
            this.l_macsp_nosauk.Size = new System.Drawing.Size(250, 20);
            this.l_macsp_nosauk.TabIndex = 1;
            this.l_macsp_nosauk.Text = "Mācībspēks";
            this.l_macsp_nosauk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nod_grupu_ievade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 232);
            this.Controls.Add(this.l_macsp_nosauk);
            this.Controls.Add(this.l_macsp);
            this.Controls.Add(this.l_laiks_vert);
            this.Controls.Add(this.l_ned_diena_vert);
            this.Controls.Add(this.l_dat_lidz_vert);
            this.Controls.Add(this.l_dat_no_vert);
            this.Controls.Add(this.l_nod_veida_nosauk);
            this.Controls.Add(this.l_stud_kurss_nosauk);
            this.Controls.Add(this.l_laiks);
            this.Controls.Add(this.l_ned_diena);
            this.Controls.Add(this.l_dat_lidz);
            this.Controls.Add(this.l_dat_no);
            this.Controls.Add(this.l_nod_veids);
            this.Controls.Add(this.l_stud_kurss);
            this.Controls.Add(this.b_pievienot);
            this.Controls.Add(this.l_grupa);
            this.Controls.Add(this.cb_grupa);
            this.Controls.Add(this.l_kurss);
            this.Controls.Add(this.cb_kurss);
            this.Controls.Add(this.cb_stud_prog);
            this.Controls.Add(this.l_stud_prog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 270);
            this.Name = "nod_grupu_ievade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pievienot studējošo grupu";
            this.ResumeLayout(false);

        }
    }
}
