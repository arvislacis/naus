namespace naus
{
    partial class studejoso_ievade
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_matr_nr;
        private System.Windows.Forms.TextBox tb_matr_nr;
        private System.Windows.Forms.Label l_vards;
        private System.Windows.Forms.TextBox tb_vards;
        private System.Windows.Forms.TextBox tb_uzvards;
        private System.Windows.Forms.Label l_uzvards;
        private System.Windows.Forms.Label l_stud_prog;
        private System.Windows.Forms.ComboBox cb_stud_prog;
        private System.Windows.Forms.ComboBox cb_kurss;
        private System.Windows.Forms.Label l_kurss;
        private System.Windows.Forms.ComboBox cb_grupa;
        private System.Windows.Forms.Label l_grupa;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studejoso_ievade));
            this.l_matr_nr = new System.Windows.Forms.Label();
            this.tb_matr_nr = new System.Windows.Forms.TextBox();
            this.l_vards = new System.Windows.Forms.Label();
            this.tb_vards = new System.Windows.Forms.TextBox();
            this.tb_uzvards = new System.Windows.Forms.TextBox();
            this.l_uzvards = new System.Windows.Forms.Label();
            this.l_stud_prog = new System.Windows.Forms.Label();
            this.cb_stud_prog = new System.Windows.Forms.ComboBox();
            this.cb_kurss = new System.Windows.Forms.ComboBox();
            this.l_kurss = new System.Windows.Forms.Label();
            this.cb_grupa = new System.Windows.Forms.ComboBox();
            this.l_grupa = new System.Windows.Forms.Label();
            this.b_pievienot = new System.Windows.Forms.Button();
            this.ep_kluda = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).BeginInit();
            this.SuspendLayout();
            // 
            // l_matr_nr
            // 
            this.l_matr_nr.Location = new System.Drawing.Point(12, 10);
            this.l_matr_nr.Name = "l_matr_nr";
            this.l_matr_nr.Size = new System.Drawing.Size(104, 23);
            this.l_matr_nr.TabIndex = 0;
            this.l_matr_nr.Text = "Matrikulas numurs:";
            this.l_matr_nr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_matr_nr
            // 
            this.tb_matr_nr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_matr_nr.Location = new System.Drawing.Point(122, 12);
            this.tb_matr_nr.MaxLength = 7;
            this.tb_matr_nr.Name = "tb_matr_nr";
            this.tb_matr_nr.Size = new System.Drawing.Size(250, 20);
            this.tb_matr_nr.TabIndex = 1;
            this.tb_matr_nr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_vards
            // 
            this.l_vards.Location = new System.Drawing.Point(12, 36);
            this.l_vards.Name = "l_vards";
            this.l_vards.Size = new System.Drawing.Size(104, 23);
            this.l_vards.TabIndex = 2;
            this.l_vards.Text = "Vārds:";
            this.l_vards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_vards
            // 
            this.tb_vards.Location = new System.Drawing.Point(122, 38);
            this.tb_vards.MaxLength = 25;
            this.tb_vards.Name = "tb_vards";
            this.tb_vards.Size = new System.Drawing.Size(250, 20);
            this.tb_vards.TabIndex = 3;
            this.tb_vards.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_uzvards
            // 
            this.tb_uzvards.Location = new System.Drawing.Point(122, 64);
            this.tb_uzvards.MaxLength = 20;
            this.tb_uzvards.Name = "tb_uzvards";
            this.tb_uzvards.Size = new System.Drawing.Size(250, 20);
            this.tb_uzvards.TabIndex = 5;
            this.tb_uzvards.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_uzvards
            // 
            this.l_uzvards.Location = new System.Drawing.Point(12, 62);
            this.l_uzvards.Name = "l_uzvards";
            this.l_uzvards.Size = new System.Drawing.Size(104, 23);
            this.l_uzvards.TabIndex = 4;
            this.l_uzvards.Text = "Uzvārds:";
            this.l_uzvards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_stud_prog
            // 
            this.l_stud_prog.Location = new System.Drawing.Point(12, 88);
            this.l_stud_prog.Name = "l_stud_prog";
            this.l_stud_prog.Size = new System.Drawing.Size(104, 23);
            this.l_stud_prog.TabIndex = 6;
            this.l_stud_prog.Text = "Studiju programma:";
            this.l_stud_prog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_stud_prog
            // 
            this.cb_stud_prog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_stud_prog.FormattingEnabled = true;
            this.cb_stud_prog.Location = new System.Drawing.Point(122, 90);
            this.cb_stud_prog.Name = "cb_stud_prog";
            this.cb_stud_prog.Size = new System.Drawing.Size(250, 21);
            this.cb_stud_prog.TabIndex = 7;
            // 
            // cb_kurss
            // 
            this.cb_kurss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kurss.FormattingEnabled = true;
            this.cb_kurss.Location = new System.Drawing.Point(122, 117);
            this.cb_kurss.Name = "cb_kurss";
            this.cb_kurss.Size = new System.Drawing.Size(98, 21);
            this.cb_kurss.TabIndex = 9;
            // 
            // l_kurss
            // 
            this.l_kurss.Location = new System.Drawing.Point(12, 115);
            this.l_kurss.Name = "l_kurss";
            this.l_kurss.Size = new System.Drawing.Size(104, 23);
            this.l_kurss.TabIndex = 8;
            this.l_kurss.Text = "Kurss:";
            this.l_kurss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_grupa
            // 
            this.cb_grupa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_grupa.FormattingEnabled = true;
            this.cb_grupa.Location = new System.Drawing.Point(272, 117);
            this.cb_grupa.Name = "cb_grupa";
            this.cb_grupa.Size = new System.Drawing.Size(98, 21);
            this.cb_grupa.TabIndex = 11;
            // 
            // l_grupa
            // 
            this.l_grupa.Location = new System.Drawing.Point(226, 115);
            this.l_grupa.Name = "l_grupa";
            this.l_grupa.Size = new System.Drawing.Size(40, 23);
            this.l_grupa.TabIndex = 10;
            this.l_grupa.Text = "Grupa:";
            this.l_grupa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_pievienot
            // 
            this.b_pievienot.Location = new System.Drawing.Point(12, 144);
            this.b_pievienot.Name = "b_pievienot";
            this.b_pievienot.Size = new System.Drawing.Size(360, 23);
            this.b_pievienot.TabIndex = 12;
            this.b_pievienot.Text = "&Pievienot studējošā datus";
            this.b_pievienot.UseVisualStyleBackColor = true;
            this.b_pievienot.Click += new System.EventHandler(this.B_pievienotClick);
            // 
            // ep_kluda
            // 
            this.ep_kluda.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ep_kluda.ContainerControl = this;
            this.ep_kluda.Icon = ((System.Drawing.Icon)(resources.GetObject("ep_kluda.Icon")));
            // 
            // studejoso_ievade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 172);
            this.Controls.Add(this.b_pievienot);
            this.Controls.Add(this.l_grupa);
            this.Controls.Add(this.cb_grupa);
            this.Controls.Add(this.l_kurss);
            this.Controls.Add(this.cb_kurss);
            this.Controls.Add(this.cb_stud_prog);
            this.Controls.Add(this.l_stud_prog);
            this.Controls.Add(this.l_uzvards);
            this.Controls.Add(this.tb_uzvards);
            this.Controls.Add(this.tb_vards);
            this.Controls.Add(this.l_vards);
            this.Controls.Add(this.tb_matr_nr);
            this.Controls.Add(this.l_matr_nr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 210);
            this.Name = "studejoso_ievade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pievienot studējošo";
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
