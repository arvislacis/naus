﻿namespace naus
{
    partial class macibspeku_ievade
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_idmacsp;
        private System.Windows.Forms.TextBox tb_idmacsp;
        private System.Windows.Forms.TextBox tb_vards;
        private System.Windows.Forms.TextBox tb_uzvards;
        private System.Windows.Forms.Label l_vards;
        private System.Windows.Forms.Label l_uzvards;
        private System.Windows.Forms.TextBox tb_zin_grads;
        private System.Windows.Forms.Label l_zin_grads;
        private System.Windows.Forms.TextBox tb_amats;
        private System.Windows.Forms.Label l_amats;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(macibspeku_ievade));
            this.l_idmacsp = new System.Windows.Forms.Label();
            this.tb_idmacsp = new System.Windows.Forms.TextBox();
            this.tb_vards = new System.Windows.Forms.TextBox();
            this.tb_uzvards = new System.Windows.Forms.TextBox();
            this.l_vards = new System.Windows.Forms.Label();
            this.l_uzvards = new System.Windows.Forms.Label();
            this.tb_zin_grads = new System.Windows.Forms.TextBox();
            this.l_zin_grads = new System.Windows.Forms.Label();
            this.tb_amats = new System.Windows.Forms.TextBox();
            this.l_amats = new System.Windows.Forms.Label();
            this.b_pievienot = new System.Windows.Forms.Button();
            this.ep_kluda = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).BeginInit();
            this.SuspendLayout();
            // 
            // l_idmacsp
            // 
            this.l_idmacsp.Location = new System.Drawing.Point(12, 10);
            this.l_idmacsp.Name = "l_idmacsp";
            this.l_idmacsp.Size = new System.Drawing.Size(104, 23);
            this.l_idmacsp.TabIndex = 0;
            this.l_idmacsp.Text = "Lietotājvārds:";
            this.l_idmacsp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_idmacsp
            // 
            this.tb_idmacsp.Location = new System.Drawing.Point(122, 12);
            this.tb_idmacsp.MaxLength = 20;
            this.tb_idmacsp.Name = "tb_idmacsp";
            this.tb_idmacsp.Size = new System.Drawing.Size(250, 20);
            this.tb_idmacsp.TabIndex = 1;
            this.tb_idmacsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // l_vards
            // 
            this.l_vards.Location = new System.Drawing.Point(12, 36);
            this.l_vards.Name = "l_vards";
            this.l_vards.Size = new System.Drawing.Size(104, 23);
            this.l_vards.TabIndex = 2;
            this.l_vards.Text = "Vārds:";
            this.l_vards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // tb_zin_grads
            // 
            this.tb_zin_grads.Location = new System.Drawing.Point(122, 90);
            this.tb_zin_grads.MaxLength = 20;
            this.tb_zin_grads.Name = "tb_zin_grads";
            this.tb_zin_grads.Size = new System.Drawing.Size(250, 20);
            this.tb_zin_grads.TabIndex = 7;
            this.tb_zin_grads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_zin_grads
            // 
            this.l_zin_grads.Location = new System.Drawing.Point(12, 88);
            this.l_zin_grads.Name = "l_zin_grads";
            this.l_zin_grads.Size = new System.Drawing.Size(104, 23);
            this.l_zin_grads.TabIndex = 6;
            this.l_zin_grads.Text = "Zinātniskais grāds:";
            this.l_zin_grads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_amats
            // 
            this.tb_amats.Location = new System.Drawing.Point(122, 116);
            this.tb_amats.MaxLength = 50;
            this.tb_amats.Name = "tb_amats";
            this.tb_amats.Size = new System.Drawing.Size(250, 20);
            this.tb_amats.TabIndex = 9;
            this.tb_amats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_amats
            // 
            this.l_amats.Location = new System.Drawing.Point(12, 114);
            this.l_amats.Name = "l_amats";
            this.l_amats.Size = new System.Drawing.Size(104, 23);
            this.l_amats.TabIndex = 8;
            this.l_amats.Text = "Amats:";
            this.l_amats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_pievienot
            // 
            this.b_pievienot.Location = new System.Drawing.Point(12, 142);
            this.b_pievienot.Name = "b_pievienot";
            this.b_pievienot.Size = new System.Drawing.Size(360, 23);
            this.b_pievienot.TabIndex = 10;
            this.b_pievienot.Text = "&Pievienot mācībspēka datus";
            this.b_pievienot.UseVisualStyleBackColor = true;
            this.b_pievienot.Click += new System.EventHandler(this.B_pievienotClick);
            // 
            // ep_kluda
            // 
            this.ep_kluda.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ep_kluda.ContainerControl = this;
            this.ep_kluda.Icon = ((System.Drawing.Icon)(resources.GetObject("ep_kluda.Icon")));
            // 
            // macibspeku_ievade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 172);
            this.Controls.Add(this.b_pievienot);
            this.Controls.Add(this.l_amats);
            this.Controls.Add(this.tb_amats);
            this.Controls.Add(this.l_zin_grads);
            this.Controls.Add(this.tb_zin_grads);
            this.Controls.Add(this.l_uzvards);
            this.Controls.Add(this.l_vards);
            this.Controls.Add(this.tb_uzvards);
            this.Controls.Add(this.tb_vards);
            this.Controls.Add(this.tb_idmacsp);
            this.Controls.Add(this.l_idmacsp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 210);
            this.Name = "macibspeku_ievade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pievienot mācībspēku";
            ((System.ComponentModel.ISupportInitialize)(this.ep_kluda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
