using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class kursu_apmeklejumi : Form
    {
        DataTable apmeklejumiDT = new DataTable("apmeklejumi");
        
        NpgsqlDataAdapter apmeklejumiA = new NpgsqlDataAdapter();
        
        public string id_macsp;
        
        public kursu_apmeklejumi(string id, string v, string u)
        {
            InitializeComponent();
            
            id_macsp = id;
            Text = v + " " + u + " [" + id + "] - Mācībspēka pasniegto studiju kursu apmeklējuma datu pārskats";
            
            izveidot_lokalo_db();
            noformet_saraksta_logus();
        }
        
        void izveidot_lokalo_db()
        {
            apmeklejumiA = new NpgsqlDataAdapter("SELECT id_kkods, nosaukums, apmeklejumi, kavejumi, kopa, (procenti || '%') procenti FROM mac_k_apm WHERE id_macsp = '" + id_macsp + "' ORDER BY nosaukums;", db.sav);
            
            apmeklejumiA.Fill(apmeklejumiDT);
        }
        
        void noformet_saraksta_logus()
        {
            dgv_kursu_apmeklejumi.DataSource = apmeklejumiDT;
            dgv_kursu_apmeklejumi.Columns["id_kkods"].HeaderText = "Kursa kods";
            dgv_kursu_apmeklejumi.Columns["nosaukums"].HeaderText = "Kursa nosaukums";
            dgv_kursu_apmeklejumi.Columns["apmeklejumi"].HeaderText = "Apmeklētās nodarbības";
            dgv_kursu_apmeklejumi.Columns["kavejumi"].HeaderText = "Kavētās nodarbības";
            dgv_kursu_apmeklejumi.Columns["kopa"].HeaderText = "Kopējais nodarbību skaits";
            dgv_kursu_apmeklejumi.Columns["procenti"].HeaderText = "Apmeklējums procentos";
        }
        
        void Tb_apmeklejumi_tekstsTextChanged(object sender, EventArgs e)
        {
            if (tb_apmeklejumi_teksts.Text != "" && db.latviesu_burti(tb_apmeklejumi_teksts.Text)) {
                apmeklejumiDT.DefaultView.RowFilter = string.Format("id_kkods LIKE '%{0}%' OR nosaukums LIKE '%{0}%'", tb_apmeklejumi_teksts.Text);
            } else {
                apmeklejumiDT.DefaultView.RowFilter = "";
            }
        }
        
        void B_atiestatit_apmeklejumiClick(object sender, EventArgs e)
        {
            tb_apmeklejumi_teksts.Text = "";
        }
    }
}
