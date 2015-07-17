namespace naus
{
    partial class students
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip ms_izvelne;
        private System.Windows.Forms.StatusStrip ss_josla;
        private System.Windows.Forms.TabControl tabc_cilnes;
        private System.Windows.Forms.TabPage tb_ped_kavejumi;
        private System.Windows.Forms.TabPage tb_parskats;
        private System.Windows.Forms.ToolStripStatusLabel sl_lietotajs;
        private System.Windows.Forms.ToolStripStatusLabel sl_statuss;
        private System.Windows.Forms.ToolStripMenuItem datneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem palīdzībaToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel sl_datums_laiks;
        private System.Windows.Forms.Timer t_laiks;
        private System.Windows.Forms.ToolStripMenuItem parToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rīkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainītParoliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resursiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem izietToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sūtītAtsauksmiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lLUNodarbībuSarakstsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skatsToolStripMenuItem;
        private System.Windows.Forms.Label l_ped_kav;
        private System.Windows.Forms.DataGridView dgv_ped_kavejumi;
        private System.Windows.Forms.ToolStripMenuItem pēdējieKavējumiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nodarbībuApmeklējumaPārskatsToolStripMenuItem;
        private System.Windows.Forms.Label l__apm_parskats;
        private System.Windows.Forms.DataGridView dgv_parskats;
        private System.Windows.Forms.TabPage tb_ped_apmeklejumi;
        private System.Windows.Forms.Label l_ped_apm;
        private System.Windows.Forms.DataGridView dgv_ped_apmeklejumi;
        private System.Windows.Forms.ToolStripMenuItem pēdējieNodarbībuapmeklējumiToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb_filtret_kavejumus;
        private System.Windows.Forms.Label l_f_kav_teksts;
        private System.Windows.Forms.Button b_atiestatit_kavejumus;
        private System.Windows.Forms.TextBox tb_kavejumi_teksts;
        private System.Windows.Forms.GroupBox gb_filtret_apmeklejumus;
        private System.Windows.Forms.TextBox tb_apmeklejumi_teksts;
        private System.Windows.Forms.Button b_ateistatit_apmeklejumi;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(students));
            this.ms_izvelne = new System.Windows.Forms.MenuStrip();
            this.datneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izietToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pēdējieKavējumiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pēdējieNodarbībuapmeklējumiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodarbībuApmeklējumaPārskatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rīkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainītParoliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.palīdzībaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resursiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lLUNodarbībuSarakstsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sūtītAtsauksmiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.parToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ss_josla = new System.Windows.Forms.StatusStrip();
            this.sl_datums_laiks = new System.Windows.Forms.ToolStripStatusLabel();
            this.sl_lietotajs = new System.Windows.Forms.ToolStripStatusLabel();
            this.sl_statuss = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabc_cilnes = new System.Windows.Forms.TabControl();
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
            this.b_ateistatit_apmeklejumi = new System.Windows.Forms.Button();
            this.l_f_apm_teksts = new System.Windows.Forms.Label();
            this.dgv_ped_apmeklejumi = new System.Windows.Forms.DataGridView();
            this.l_ped_apm = new System.Windows.Forms.Label();
            this.tb_parskats = new System.Windows.Forms.TabPage();
            this.dgv_parskats = new System.Windows.Forms.DataGridView();
            this.l__apm_parskats = new System.Windows.Forms.Label();
            this.t_laiks = new System.Windows.Forms.Timer(this.components);
            this.ms_izvelne.SuspendLayout();
            this.ss_josla.SuspendLayout();
            this.tabc_cilnes.SuspendLayout();
            this.tb_ped_kavejumi.SuspendLayout();
            this.gb_filtret_kavejumus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_kavejumi)).BeginInit();
            this.tb_ped_apmeklejumi.SuspendLayout();
            this.gb_filtret_apmeklejumus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_apmeklejumi)).BeginInit();
            this.tb_parskats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_parskats)).BeginInit();
            this.SuspendLayout();
            // 
            // ms_izvelne
            // 
            this.ms_izvelne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datneToolStripMenuItem,
            this.skatsToolStripMenuItem,
            this.rīkiToolStripMenuItem,
            this.palīdzībaToolStripMenuItem});
            this.ms_izvelne.Location = new System.Drawing.Point(0, 0);
            this.ms_izvelne.Name = "ms_izvelne";
            this.ms_izvelne.Size = new System.Drawing.Size(784, 24);
            this.ms_izvelne.TabIndex = 0;
            this.ms_izvelne.Text = "Izvēlne";
            // 
            // datneToolStripMenuItem
            // 
            this.datneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izietToolStripMenuItem});
            this.datneToolStripMenuItem.Name = "datneToolStripMenuItem";
            this.datneToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.datneToolStripMenuItem.Text = "&Datne";
            // 
            // izietToolStripMenuItem
            // 
            this.izietToolStripMenuItem.Name = "izietToolStripMenuItem";
            this.izietToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.izietToolStripMenuItem.Text = "&Iziet";
            this.izietToolStripMenuItem.Click += new System.EventHandler(this.IzietToolStripMenuItemClick);
            // 
            // skatsToolStripMenuItem
            // 
            this.skatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pēdējieKavējumiToolStripMenuItem,
            this.pēdējieNodarbībuapmeklējumiToolStripMenuItem,
            this.nodarbībuApmeklējumaPārskatsToolStripMenuItem});
            this.skatsToolStripMenuItem.Name = "skatsToolStripMenuItem";
            this.skatsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.skatsToolStripMenuItem.Text = "S&kats";
            // 
            // pēdējieKavējumiToolStripMenuItem
            // 
            this.pēdējieKavējumiToolStripMenuItem.Name = "pēdējieKavējumiToolStripMenuItem";
            this.pēdējieKavējumiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.pēdējieKavējumiToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.pēdējieKavējumiToolStripMenuItem.Text = "Pēdējie nodarbību &kavējumi";
            this.pēdējieKavējumiToolStripMenuItem.Click += new System.EventHandler(this.PēdējieKavējumiToolStripMenuItemClick);
            // 
            // pēdējieNodarbībuapmeklējumiToolStripMenuItem
            // 
            this.pēdējieNodarbībuapmeklējumiToolStripMenuItem.Name = "pēdējieNodarbībuapmeklējumiToolStripMenuItem";
            this.pēdējieNodarbībuapmeklējumiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.pēdējieNodarbībuapmeklējumiToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.pēdējieNodarbībuapmeklējumiToolStripMenuItem.Text = "Pēdējie nodarbību &apmeklējumi";
            this.pēdējieNodarbībuapmeklējumiToolStripMenuItem.Click += new System.EventHandler(this.PēdējieNodarbībuapmeklējumiToolStripMenuItemClick);
            // 
            // nodarbībuApmeklējumaPārskatsToolStripMenuItem
            // 
            this.nodarbībuApmeklējumaPārskatsToolStripMenuItem.Name = "nodarbībuApmeklējumaPārskatsToolStripMenuItem";
            this.nodarbībuApmeklējumaPārskatsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.nodarbībuApmeklējumaPārskatsToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.nodarbībuApmeklējumaPārskatsToolStripMenuItem.Text = "&Nodarbību apmeklējuma pārskats";
            this.nodarbībuApmeklējumaPārskatsToolStripMenuItem.Click += new System.EventHandler(this.NodarbībuApmeklējumaPārskatsToolStripMenuItemClick);
            // 
            // rīkiToolStripMenuItem
            // 
            this.rīkiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainītParoliToolStripMenuItem});
            this.rīkiToolStripMenuItem.Name = "rīkiToolStripMenuItem";
            this.rīkiToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.rīkiToolStripMenuItem.Text = "&Rīki";
            // 
            // mainītParoliToolStripMenuItem
            // 
            this.mainītParoliToolStripMenuItem.Name = "mainītParoliToolStripMenuItem";
            this.mainītParoliToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.mainītParoliToolStripMenuItem.Text = "&Mainīt paroli...";
            this.mainītParoliToolStripMenuItem.Click += new System.EventHandler(this.MainītParoliToolStripMenuItemClick);
            // 
            // palīdzībaToolStripMenuItem
            // 
            this.palīdzībaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resursiToolStripMenuItem,
            this.toolStripSeparator1,
            this.parToolStripMenuItem});
            this.palīdzībaToolStripMenuItem.Name = "palīdzībaToolStripMenuItem";
            this.palīdzībaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.palīdzībaToolStripMenuItem.Text = "&Palīdzība";
            // 
            // resursiToolStripMenuItem
            // 
            this.resursiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lLUNodarbībuSarakstsToolStripMenuItem,
            this.sūtītAtsauksmiToolStripMenuItem});
            this.resursiToolStripMenuItem.Name = "resursiToolStripMenuItem";
            this.resursiToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.resursiToolStripMenuItem.Text = "&Resursi";
            // 
            // lLUNodarbībuSarakstsToolStripMenuItem
            // 
            this.lLUNodarbībuSarakstsToolStripMenuItem.Name = "lLUNodarbībuSarakstsToolStripMenuItem";
            this.lLUNodarbībuSarakstsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.lLUNodarbībuSarakstsToolStripMenuItem.Text = "&LLU nodarbību saraksts";
            this.lLUNodarbībuSarakstsToolStripMenuItem.Click += new System.EventHandler(this.LLUNodarbībuSarakstsToolStripMenuItemClick);
            // 
            // sūtītAtsauksmiToolStripMenuItem
            // 
            this.sūtītAtsauksmiToolStripMenuItem.Name = "sūtītAtsauksmiToolStripMenuItem";
            this.sūtītAtsauksmiToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sūtītAtsauksmiToolStripMenuItem.Text = "&Sūtīt atsauksmi";
            this.sūtītAtsauksmiToolStripMenuItem.Click += new System.EventHandler(this.SūtītAtsauksmiToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // parToolStripMenuItem
            // 
            this.parToolStripMenuItem.Name = "parToolStripMenuItem";
            this.parToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.parToolStripMenuItem.Text = "P&ar..";
            this.parToolStripMenuItem.Click += new System.EventHandler(this.ParToolStripMenuItemClick);
            // 
            // ss_josla
            // 
            this.ss_josla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sl_datums_laiks,
            this.sl_lietotajs,
            this.sl_statuss});
            this.ss_josla.Location = new System.Drawing.Point(0, 540);
            this.ss_josla.Name = "ss_josla";
            this.ss_josla.Size = new System.Drawing.Size(784, 22);
            this.ss_josla.TabIndex = 2;
            this.ss_josla.Text = "Statusa josla";
            // 
            // sl_datums_laiks
            // 
            this.sl_datums_laiks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.sl_datums_laiks.Name = "sl_datums_laiks";
            this.sl_datums_laiks.Size = new System.Drawing.Size(93, 17);
            this.sl_datums_laiks.Text = "Datums un laiks";
            // 
            // sl_lietotajs
            // 
            this.sl_lietotajs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.sl_lietotajs.Name = "sl_lietotajs";
            this.sl_lietotajs.Size = new System.Drawing.Size(57, 17);
            this.sl_lietotajs.Text = "Students";
            // 
            // sl_statuss
            // 
            this.sl_statuss.Name = "sl_statuss";
            this.sl_statuss.Size = new System.Drawing.Size(287, 17);
            this.sl_statuss.Text = "Studiju programma (programmas kods), kurss, grupa";
            // 
            // tabc_cilnes
            // 
            this.tabc_cilnes.Controls.Add(this.tb_ped_kavejumi);
            this.tabc_cilnes.Controls.Add(this.tb_ped_apmeklejumi);
            this.tabc_cilnes.Controls.Add(this.tb_parskats);
            this.tabc_cilnes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc_cilnes.Location = new System.Drawing.Point(0, 24);
            this.tabc_cilnes.Name = "tabc_cilnes";
            this.tabc_cilnes.SelectedIndex = 0;
            this.tabc_cilnes.Size = new System.Drawing.Size(784, 516);
            this.tabc_cilnes.TabIndex = 1;
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
            this.tb_ped_kavejumi.Size = new System.Drawing.Size(776, 490);
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
            this.gb_filtret_kavejumus.Size = new System.Drawing.Size(764, 46);
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
            this.tb_kavejumi_teksts.Size = new System.Drawing.Size(390, 20);
            this.tb_kavejumi_teksts.TabIndex = 1;
            this.tb_kavejumi_teksts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_kavejumi_teksts.TextChanged += new System.EventHandler(this.Tb_kavejumi_tekstsTextChanged);
            // 
            // b_atiestatit_kavejumus
            // 
            this.b_atiestatit_kavejumus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_atiestatit_kavejumus.Location = new System.Drawing.Point(638, 18);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_ped_kavejumi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ped_kavejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ped_kavejumi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ped_kavejumi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_ped_kavejumi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ped_kavejumi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ped_kavejumi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ped_kavejumi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ped_kavejumi.Location = new System.Drawing.Point(6, 73);
            this.dgv_ped_kavejumi.MultiSelect = false;
            this.dgv_ped_kavejumi.Name = "dgv_ped_kavejumi";
            this.dgv_ped_kavejumi.ReadOnly = true;
            this.dgv_ped_kavejumi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ped_kavejumi.Size = new System.Drawing.Size(764, 411);
            this.dgv_ped_kavejumi.TabIndex = 2;
            // 
            // l_ped_kav
            // 
            this.l_ped_kav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ped_kav.Location = new System.Drawing.Point(6, 55);
            this.l_ped_kav.Name = "l_ped_kav";
            this.l_ped_kav.Size = new System.Drawing.Size(764, 15);
            this.l_ped_kav.TabIndex = 1;
            this.l_ped_kav.Text = "Pēdējie 50 nodarbību kavējumi:";
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
            this.tb_ped_apmeklejumi.Size = new System.Drawing.Size(776, 490);
            this.tb_ped_apmeklejumi.TabIndex = 2;
            this.tb_ped_apmeklejumi.Text = "Pēdējie nodarbību apmeklējumi";
            // 
            // gb_filtret_apmeklejumus
            // 
            this.gb_filtret_apmeklejumus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_filtret_apmeklejumus.Controls.Add(this.tb_apmeklejumi_teksts);
            this.gb_filtret_apmeklejumus.Controls.Add(this.b_ateistatit_apmeklejumi);
            this.gb_filtret_apmeklejumus.Controls.Add(this.l_f_apm_teksts);
            this.gb_filtret_apmeklejumus.Location = new System.Drawing.Point(6, 6);
            this.gb_filtret_apmeklejumus.Name = "gb_filtret_apmeklejumus";
            this.gb_filtret_apmeklejumus.Size = new System.Drawing.Size(764, 46);
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
            this.tb_apmeklejumi_teksts.Size = new System.Drawing.Size(390, 20);
            this.tb_apmeklejumi_teksts.TabIndex = 1;
            this.tb_apmeklejumi_teksts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_apmeklejumi_teksts.TextChanged += new System.EventHandler(this.Tb_apmeklejumi_tekstsTextChanged);
            // 
            // b_ateistatit_apmeklejumi
            // 
            this.b_ateistatit_apmeklejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_ateistatit_apmeklejumi.Location = new System.Drawing.Point(638, 18);
            this.b_ateistatit_apmeklejumi.Name = "b_ateistatit_apmeklejumi";
            this.b_ateistatit_apmeklejumi.Size = new System.Drawing.Size(120, 21);
            this.b_ateistatit_apmeklejumi.TabIndex = 2;
            this.b_ateistatit_apmeklejumi.Text = "Atiestatīt &filtru";
            this.b_ateistatit_apmeklejumi.UseVisualStyleBackColor = true;
            this.b_ateistatit_apmeklejumi.Click += new System.EventHandler(this.B_ateistatit_apmeklejumiClick);
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_ped_apmeklejumi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ped_apmeklejumi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ped_apmeklejumi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ped_apmeklejumi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_ped_apmeklejumi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ped_apmeklejumi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ped_apmeklejumi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ped_apmeklejumi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ped_apmeklejumi.Location = new System.Drawing.Point(6, 73);
            this.dgv_ped_apmeklejumi.MultiSelect = false;
            this.dgv_ped_apmeklejumi.Name = "dgv_ped_apmeklejumi";
            this.dgv_ped_apmeklejumi.ReadOnly = true;
            this.dgv_ped_apmeklejumi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ped_apmeklejumi.Size = new System.Drawing.Size(764, 411);
            this.dgv_ped_apmeklejumi.TabIndex = 2;
            // 
            // l_ped_apm
            // 
            this.l_ped_apm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ped_apm.Location = new System.Drawing.Point(6, 55);
            this.l_ped_apm.Name = "l_ped_apm";
            this.l_ped_apm.Size = new System.Drawing.Size(764, 15);
            this.l_ped_apm.TabIndex = 1;
            this.l_ped_apm.Text = "Pēdējie 50 nodarbību apmeklējumi:";
            this.l_ped_apm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_parskats
            // 
            this.tb_parskats.BackColor = System.Drawing.SystemColors.Control;
            this.tb_parskats.Controls.Add(this.dgv_parskats);
            this.tb_parskats.Controls.Add(this.l__apm_parskats);
            this.tb_parskats.Location = new System.Drawing.Point(4, 22);
            this.tb_parskats.Name = "tb_parskats";
            this.tb_parskats.Padding = new System.Windows.Forms.Padding(3);
            this.tb_parskats.Size = new System.Drawing.Size(776, 490);
            this.tb_parskats.TabIndex = 1;
            this.tb_parskats.Text = "Nodarbību apmeklējuma pārskats";
            // 
            // dgv_parskats
            // 
            this.dgv_parskats.AllowUserToAddRows = false;
            this.dgv_parskats.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            this.dgv_parskats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_parskats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_parskats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_parskats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_parskats.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_parskats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_parskats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_parskats.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_parskats.Location = new System.Drawing.Point(6, 21);
            this.dgv_parskats.MultiSelect = false;
            this.dgv_parskats.Name = "dgv_parskats";
            this.dgv_parskats.ReadOnly = true;
            this.dgv_parskats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_parskats.Size = new System.Drawing.Size(764, 463);
            this.dgv_parskats.TabIndex = 1;
            // 
            // l__apm_parskats
            // 
            this.l__apm_parskats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l__apm_parskats.Location = new System.Drawing.Point(6, 3);
            this.l__apm_parskats.Name = "l__apm_parskats";
            this.l__apm_parskats.Size = new System.Drawing.Size(764, 15);
            this.l__apm_parskats.TabIndex = 0;
            this.l__apm_parskats.Text = "Studiju kursu nodarbību apmeklējuma pārskats:";
            this.l__apm_parskats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_laiks
            // 
            this.t_laiks.Enabled = true;
            this.t_laiks.Interval = 30000;
            this.t_laiks.Tick += new System.EventHandler(this.T_laiksTick);
            // 
            // students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabc_cilnes);
            this.Controls.Add(this.ss_josla);
            this.Controls.Add(this.ms_izvelne);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_izvelne;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Students] Nodarbību apmeklējuma uzskaites sistēma";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentsFormClosed);
            this.ms_izvelne.ResumeLayout(false);
            this.ms_izvelne.PerformLayout();
            this.ss_josla.ResumeLayout(false);
            this.ss_josla.PerformLayout();
            this.tabc_cilnes.ResumeLayout(false);
            this.tb_ped_kavejumi.ResumeLayout(false);
            this.gb_filtret_kavejumus.ResumeLayout(false);
            this.gb_filtret_kavejumus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_kavejumi)).EndInit();
            this.tb_ped_apmeklejumi.ResumeLayout(false);
            this.gb_filtret_apmeklejumus.ResumeLayout(false);
            this.gb_filtret_apmeklejumus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ped_apmeklejumi)).EndInit();
            this.tb_parskats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_parskats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
