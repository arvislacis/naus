using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class students : Form
    {
        DataTable kavejumiDT = new DataTable("kavejumi");
        DataTable apmeklejumiDT = new DataTable("apmeklejumi");
        DataTable parskatsDT = new DataTable("parskats");
        
        NpgsqlDataAdapter kavejumiA = new NpgsqlDataAdapter("SELECT nosaukums, veids, m_v_uzv, datums, ned_diena, laiks FROM kavetas_nod WHERE id_matr = '" + db.lietotajs + "' ORDER BY datums DESC, laiks DESC LIMIT 50;", db.sav);
        NpgsqlDataAdapter apmeklejumiA = new NpgsqlDataAdapter("SELECT nosaukums, veids, m_v_uzv, datums, ned_diena, laiks FROM apmekletas_nod WHERE id_matr = '" + db.lietotajs + "' ORDER BY datums DESC, laiks DESC LIMIT 50;", db.sav);
        NpgsqlDataAdapter parskatsA = new NpgsqlDataAdapter("SELECT k.nosaukums, ska.apmeklejumi, ska.kavejumi, ska.kopa, (ska.procenti || '%') procenti FROM st_k_apm ska, stud_kursi k WHERE ska.id_kkods = k.id_kkods AND id_matr = '" + db.lietotajs + "' ORDER BY ska.procenti;", db.sav);
        
        public students()
        {
            InitializeComponent();
            
            sl_lietotajs.Text = db.vards + " " + db.uzvards;
            sl_statuss.Text = db.pr_nosaukums + " (" + db.pr_kods + ") " + db.kurss + ". kurss " + db.grupa + ". grupa";
            sl_datums_laiks.Text = db.datuma_virkne(DateTime.Now, true);
            
            izveidot_lokalo_db();
            noformet_saraksta_logus();
        }
        
        void izveidot_lokalo_db()
        {
            kavejumiA.Fill(kavejumiDT);
            apmeklejumiA.Fill(apmeklejumiDT);
            parskatsA.Fill(parskatsDT);
        }
        
        void noformet_saraksta_logus()
        {
            dgv_ped_kavejumi.DataSource = kavejumiDT;
            dgv_ped_kavejumi.Columns["nosaukums"].HeaderText = "Studiju kurss";
            dgv_ped_kavejumi.Columns["veids"].HeaderText = "Nodarbības veids";
            dgv_ped_kavejumi.Columns["m_v_uzv"].HeaderText = "Mācībspēks";
            dgv_ped_kavejumi.Columns["datums"].HeaderText = "Kavējuma datums";
            dgv_ped_kavejumi.Columns["ned_diena"].HeaderText = "Nedēļas diena";
            DataGridViewComboBoxColumn cb_ned_diena = new DataGridViewComboBoxColumn();
            cb_ned_diena.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_ned_diena.DataSource = db.n_dienasDT;
            cb_ned_diena.Name = "ned_diena";
            cb_ned_diena.DataPropertyName = cb_ned_diena.ValueMember = "ned_diena";
            cb_ned_diena.DisplayMember = "nosaukums";
            cb_ned_diena.HeaderText = "Nedēļas diena";
            dgv_ped_kavejumi.Columns.Remove(dgv_ped_kavejumi.Columns["ned_diena"]);
            dgv_ped_kavejumi.Columns.Insert(4, cb_ned_diena);
            dgv_ped_kavejumi.Columns["laiks"].HeaderText = "Laiks";
            DataGridViewComboBoxColumn cb_laiks = new DataGridViewComboBoxColumn();
            cb_laiks.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_laiks.DataSource = db.laikiDT;
            cb_laiks.Name = "laiks";
            cb_laiks.DataPropertyName = cb_laiks.ValueMember = "laiks";
            cb_laiks.DisplayMember = "virkne";
            cb_laiks.HeaderText = "Laiks";
            dgv_ped_kavejumi.Columns.Remove(dgv_ped_kavejumi.Columns["laiks"]);
            dgv_ped_kavejumi.Columns.Insert(5, cb_laiks);
            
            dgv_ped_apmeklejumi.DataSource = apmeklejumiDT;
            dgv_ped_apmeklejumi.Columns["nosaukums"].HeaderText = "Studiju kurss";
            dgv_ped_apmeklejumi.Columns["veids"].HeaderText = "Nodarbības veids";
            dgv_ped_apmeklejumi.Columns["m_v_uzv"].HeaderText = "Mācībspēks";
            dgv_ped_apmeklejumi.Columns["datums"].HeaderText = "Apmeklējuma datums";
            dgv_ped_apmeklejumi.Columns["ned_diena"].HeaderText = "Nedēļas diena";
            DataGridViewComboBoxColumn cb_ned_diena2 = new DataGridViewComboBoxColumn();
            cb_ned_diena2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_ned_diena2.DataSource = db.n_dienasDT;
            cb_ned_diena2.Name = "ned_diena";
            cb_ned_diena2.DataPropertyName = cb_ned_diena2.ValueMember = "ned_diena";
            cb_ned_diena2.DisplayMember = "nosaukums";
            cb_ned_diena2.HeaderText = "Nedēļas diena";
            dgv_ped_apmeklejumi.Columns.Remove(dgv_ped_apmeklejumi.Columns["ned_diena"]);
            dgv_ped_apmeklejumi.Columns.Insert(4, cb_ned_diena2);
            dgv_ped_apmeklejumi.Columns["laiks"].HeaderText = "Laiks";
            DataGridViewComboBoxColumn cb_laiks2 = new DataGridViewComboBoxColumn();
            cb_laiks2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_laiks2.DataSource = db.laikiDT;
            cb_laiks2.Name = "laiks";
            cb_laiks2.DataPropertyName = cb_laiks2.ValueMember = "laiks";
            cb_laiks2.DisplayMember = "virkne";
            cb_laiks2.HeaderText = "Laiks";
            dgv_ped_apmeklejumi.Columns.Remove(dgv_ped_apmeklejumi.Columns["laiks"]);
            dgv_ped_apmeklejumi.Columns.Insert(5, cb_laiks2);
            
            dgv_parskats.DataSource = parskatsDT;
            dgv_parskats.Columns["nosaukums"].HeaderText = "Studiju kurss";
            dgv_parskats.Columns["apmeklejumi"].HeaderText = "Apmeklētās nodarbības";
            dgv_parskats.Columns["kavejumi"].HeaderText = "Kavētās nodarbības";
            dgv_parskats.Columns["kopa"].HeaderText = "Kopējais nodarbību skaits";
            dgv_parskats.Columns["procenti"].HeaderText = "Apmeklējums procentos";
        }
        
        void Tb_kavejumi_tekstsTextChanged(object sender, EventArgs e)
        {
            if (tb_kavejumi_teksts.Text != "" && db.latviesu_burti(tb_kavejumi_teksts.Text)) {
                kavejumiDT.DefaultView.RowFilter = string.Format("nosaukums LIKE '%{0}%' OR veids LIKE '%{0}%' OR m_v_uzv LIKE '%{0}%'", tb_kavejumi_teksts.Text);
            } else {
                kavejumiDT.DefaultView.RowFilter = "";
            }
        }
        void B_atiestatit_kavejumusClick(object sender, EventArgs e)
        {
            tb_kavejumi_teksts.Text = "";
        }
        
        void Tb_apmeklejumi_tekstsTextChanged(object sender, EventArgs e)
        {
            if (tb_apmeklejumi_teksts.Text != "" && db.latviesu_burti(tb_apmeklejumi_teksts.Text)) {
                apmeklejumiDT.DefaultView.RowFilter = string.Format("nosaukums LIKE '%{0}%' OR veids LIKE '%{0}%' OR m_v_uzv LIKE '%{0}%'", tb_apmeklejumi_teksts.Text);
            } else {
                apmeklejumiDT.DefaultView.RowFilter = "";
            }
        }
        
        void B_ateistatit_apmeklejumiClick(object sender, EventArgs e)
        {
            tb_apmeklejumi_teksts.Text = "";
        }
        
        void StudentsFormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        void T_laiksTick(object sender, EventArgs e)
        {
            sl_datums_laiks.Text = db.datuma_virkne(DateTime.Now, true);
        }
        
        void IzietToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }
        
        void PēdējieKavējumiToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 0;
        }
        
        void PēdējieNodarbībuapmeklējumiToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 1;
        }
        
        void NodarbībuApmeklējumaPārskatsToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 2;
        }
        
        void MainītParoliToolStripMenuItemClick(object sender, EventArgs e)
        {
            paroles_maina d_parole = new paroles_maina();
            d_parole.ShowDialog();
        }
        
        void LLUNodarbībuSarakstsToolStripMenuItemClick(object sender, EventArgs e)
        {
            db.nodarbibu_saraksts();
        }
        
        void SūtītAtsauksmiToolStripMenuItemClick(object sender, EventArgs e)
        {
            db.sutit_atsauksmi();
        }
        
        void ParToolStripMenuItemClick(object sender, EventArgs e)
        {
            db.msgbox_par();
        }
    }
}
