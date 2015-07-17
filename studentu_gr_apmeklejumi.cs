using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class studentu_gr_apmeklejumi : Form
    {
        DataTable apmeklejumiDT = new DataTable("apmeklejumi");
        
        NpgsqlDataAdapter apmeklejumiA = new NpgsqlDataAdapter();
        
        public string id_nod, id_prkods, nosaukums, kurss, grupa;
        
        public studentu_gr_apmeklejumi(string id, string pr, string n, string k, string g)
        {
            InitializeComponent();
            
            id_nod = id;
            id_prkods = pr;
            nosaukums = n;
            kurss = k;
            grupa = g;
            Text = "[" + n + "] - " + k + ". kurss " + g + ". grupa - Studiju kursa nodarbības apmeklējuma datu pārskats";
            
            izveidot_lokalo_db();
            noformet_saraksta_logus();
        }
        
        void izveidot_lokalo_db()
        {
            apmeklejumiA = new NpgsqlDataAdapter("SELECT id_matr, (vards || ' ' || uzvards) st_v_uzv, nosaukums, kurss, grupa, apmeklejumi, kavejumi, kopa, (procenti || '%') procenti FROM studiju_kursa_apm WHERE id_nod = '" + id_nod + "' AND id_prkods = '" + id_prkods + "' AND kurss = '" + kurss + "' AND grupa = '" + grupa + "' ORDER BY uzvards;", db.sav);
            
            apmeklejumiA.Fill(apmeklejumiDT);
        }
        
        void noformet_saraksta_logus()
        {
            dgv_gr_apmeklejumi.DataSource = apmeklejumiDT;
            dgv_gr_apmeklejumi.Columns["id_matr"].HeaderText = "Matrikulas numurs";
            dgv_gr_apmeklejumi.Columns["st_v_uzv"].HeaderText = "Studējošais";
            dgv_gr_apmeklejumi.Columns["nosaukums"].HeaderText = "Studiju programma";
            dgv_gr_apmeklejumi.Columns["kurss"].HeaderText = "Kurss";
            dgv_gr_apmeklejumi.Columns["grupa"].HeaderText = "Grupa";
            dgv_gr_apmeklejumi.Columns["apmeklejumi"].HeaderText = "Apmeklētās nodarbības";
            dgv_gr_apmeklejumi.Columns["kavejumi"].HeaderText = "Kavētās nodarbības";
            dgv_gr_apmeklejumi.Columns["kopa"].HeaderText = "Kopējais nodarbību skaits";
            dgv_gr_apmeklejumi.Columns["procenti"].HeaderText = "Apmeklējums procentos";
        }
        
        void Tb_apmeklejumi_tekstsTextChanged(object sender, EventArgs e)
        {
            if (tb_apmeklejumi_teksts.Text != "" && db.latviesu_burti(tb_apmeklejumi_teksts.Text)) {
                apmeklejumiDT.DefaultView.RowFilter = string.Format("id_matr LIKE '%{0}%' OR st_v_uzv LIKE '%{0}%' OR nosaukums LIKE '%{0}%'", tb_apmeklejumi_teksts.Text);
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
