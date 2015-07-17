namespace naus
{
    partial class datu_ielade
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label l_process;
        private System.Windows.Forms.ProgressBar pb_progress;
        
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
            this.l_process = new System.Windows.Forms.Label();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // l_process
            // 
            this.l_process.Location = new System.Drawing.Point(12, 9);
            this.l_process.Name = "l_process";
            this.l_process.Size = new System.Drawing.Size(260, 23);
            this.l_process.TabIndex = 0;
            this.l_process.Text = "Notiek datu ielāde...";
            this.l_process.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_progress
            // 
            this.pb_progress.Location = new System.Drawing.Point(12, 35);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(260, 23);
            this.pb_progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_progress.TabIndex = 1;
            // 
            // datu_ielade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 66);
            this.ControlBox = false;
            this.Controls.Add(this.l_process);
            this.Controls.Add(this.pb_progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "datu_ielade";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lūdzu uzgaidiet, notiek datu ielāde...";
            this.ResumeLayout(false);

        }
    }
}
