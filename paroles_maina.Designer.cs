namespace naus
{
    partial class paroles_maina
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_pasreizeja;
        private System.Windows.Forms.Label l_jauna;
        private System.Windows.Forms.Label l_atkartoti;
        private System.Windows.Forms.Button b_mainit;
        private System.Windows.Forms.Button b_atcelt;
        private System.Windows.Forms.TextBox tb_pasreizeja;
        private System.Windows.Forms.TextBox tb_jauna;
        private System.Windows.Forms.TextBox tb_atkartoti;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(paroles_maina));
            this.l_pasreizeja = new System.Windows.Forms.Label();
            this.l_jauna = new System.Windows.Forms.Label();
            this.l_atkartoti = new System.Windows.Forms.Label();
            this.b_mainit = new System.Windows.Forms.Button();
            this.b_atcelt = new System.Windows.Forms.Button();
            this.tb_pasreizeja = new System.Windows.Forms.TextBox();
            this.tb_jauna = new System.Windows.Forms.TextBox();
            this.tb_atkartoti = new System.Windows.Forms.TextBox();
            this.ep_kluda = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).BeginInit();
            this.SuspendLayout();
            // 
            // l_pasreizeja
            // 
            this.l_pasreizeja.Location = new System.Drawing.Point(12, 15);
            this.l_pasreizeja.Name = "l_pasreizeja";
            this.l_pasreizeja.Size = new System.Drawing.Size(119, 23);
            this.l_pasreizeja.TabIndex = 0;
            this.l_pasreizeja.Text = "Pašreizējā parole:";
            // 
            // l_jauna
            // 
            this.l_jauna.Location = new System.Drawing.Point(12, 41);
            this.l_jauna.Name = "l_jauna";
            this.l_jauna.Size = new System.Drawing.Size(120, 23);
            this.l_jauna.TabIndex = 2;
            this.l_jauna.Text = "Jaunā parole:";
            // 
            // l_atkartoti
            // 
            this.l_atkartoti.Location = new System.Drawing.Point(12, 67);
            this.l_atkartoti.Name = "l_atkartoti";
            this.l_atkartoti.Size = new System.Drawing.Size(120, 23);
            this.l_atkartoti.TabIndex = 4;
            this.l_atkartoti.Text = "Jaunā parole atkārtoti:";
            // 
            // b_mainit
            // 
            this.b_mainit.Location = new System.Drawing.Point(12, 97);
            this.b_mainit.Name = "b_mainit";
            this.b_mainit.Size = new System.Drawing.Size(195, 23);
            this.b_mainit.TabIndex = 6;
            this.b_mainit.Text = "&Mainīt paroli";
            this.b_mainit.UseVisualStyleBackColor = true;
            this.b_mainit.Click += new System.EventHandler(this.B_mainitClick);
            // 
            // b_atcelt
            // 
            this.b_atcelt.Location = new System.Drawing.Point(213, 97);
            this.b_atcelt.Name = "b_atcelt";
            this.b_atcelt.Size = new System.Drawing.Size(74, 23);
            this.b_atcelt.TabIndex = 7;
            this.b_atcelt.Text = "&Atcelt";
            this.b_atcelt.UseVisualStyleBackColor = true;
            this.b_atcelt.Click += new System.EventHandler(this.B_atceltClick);
            // 
            // tb_pasreizeja
            // 
            this.tb_pasreizeja.Location = new System.Drawing.Point(137, 12);
            this.tb_pasreizeja.MaxLength = 20;
            this.tb_pasreizeja.Name = "tb_pasreizeja";
            this.tb_pasreizeja.Size = new System.Drawing.Size(150, 20);
            this.tb_pasreizeja.TabIndex = 1;
            this.tb_pasreizeja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_pasreizeja.UseSystemPasswordChar = true;
            // 
            // tb_jauna
            // 
            this.tb_jauna.Location = new System.Drawing.Point(137, 38);
            this.tb_jauna.MaxLength = 20;
            this.tb_jauna.Name = "tb_jauna";
            this.tb_jauna.Size = new System.Drawing.Size(150, 20);
            this.tb_jauna.TabIndex = 3;
            this.tb_jauna.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_jauna.UseSystemPasswordChar = true;
            // 
            // tb_atkartoti
            // 
            this.tb_atkartoti.Location = new System.Drawing.Point(137, 64);
            this.tb_atkartoti.MaxLength = 20;
            this.tb_atkartoti.Name = "tb_atkartoti";
            this.tb_atkartoti.Size = new System.Drawing.Size(150, 20);
            this.tb_atkartoti.TabIndex = 5;
            this.tb_atkartoti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_atkartoti.UseSystemPasswordChar = true;
            this.tb_atkartoti.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_atkartotiKeyDown);
            // 
            // ep_kluda
            // 
            this.ep_kluda.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ep_kluda.ContainerControl = this;
            this.ep_kluda.Icon = ((System.Drawing.Icon)(resources.GetObject("ep_kluda.Icon")));
            // 
            // paroles_maina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 132);
            this.Controls.Add(this.tb_atkartoti);
            this.Controls.Add(this.tb_jauna);
            this.Controls.Add(this.tb_pasreizeja);
            this.Controls.Add(this.b_atcelt);
            this.Controls.Add(this.b_mainit);
            this.Controls.Add(this.l_atkartoti);
            this.Controls.Add(this.l_jauna);
            this.Controls.Add(this.l_pasreizeja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 170);
            this.Name = "paroles_maina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lietotāja paroles maiņa";
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
