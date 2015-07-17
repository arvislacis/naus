using System;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class nodarbibu_ievade : Form
    {
        public string id_nod, id_macsp, id_kkods, nveids, dat_no, dat_lidz, ned_diena, laiks;
        
        public nodarbibu_ievade(string nid, string id, string k, string n, string no, string lidz, string nd, string l, bool m)
        {
            InitializeComponent();
            
            id_nod = nid;
            id_macsp = id;
            id_kkods = k;
            nveids = n;
            dat_no = no;
            dat_lidz = lidz;
            ned_diena = nd;
            laiks = l;
            
            if (m) {
                cb_idkkods.DataSource = db.iegut_studiju_kursus();
            } else {
                cb_idkkods.DataSource = vadiba.ds.Tables["stud_kursi"];
            }
            
            cb_idkkods.DisplayMember = "nosaukums";
            cb_idkkods.ValueMember = "id_kkods";
            
            cb_idmacsp.DataSource = db.iegut_macibspekus();
            cb_idmacsp.DisplayMember = "m_v_uzv";
            cb_idmacsp.ValueMember = "id_macsp";
            
            cb_nod_veids.DataSource = db.iegut_nod_veidus();
            cb_nod_veids.DisplayMember = "veids";
            cb_nod_veids.ValueMember = "id_nveids";
            
            dtp_dat_no.Value = DateTime.Today.AddDays(-(float)DateTime.Today.DayOfWeek + 1);
            dtp_dat_lidz.Value = DateTime.Today.AddDays(-(float)DateTime.Today.DayOfWeek + 7);
            
            cb_ned_diena.DataSource = db.n_dienasDT;
            cb_ned_diena.DisplayMember = "nosaukums";
            cb_ned_diena.ValueMember = "ned_diena";
            
            if (DateTime.Today.DayOfWeek > 0) {
                cb_ned_diena.SelectedValue = DateTime.Now.DayOfWeek;
            }
            
            cb_laiks.DataSource = db.laikiDT;
            cb_laiks.DisplayMember = "virkne";
            cb_laiks.ValueMember = "laiks";
            
            if (DateTime.Now.Hour > 7 && DateTime.Now.Hour < 21) {
                cb_laiks.SelectedValue = DateTime.Now.Hour;
            }
            
            if (id_macsp != "" && id_kkods != "") {
                Text = "Labot nodarbību";
                b_pievienot.Text = "&Labot nodarbības datus";
                
                if (m) {
                    cb_idmacsp.Enabled = false;
                }
                
                cb_idmacsp.SelectedValue = id_macsp;
               
                cb_idkkods.Enabled = false;
                cb_idkkods.SelectedValue = id_kkods;
                cb_nod_veids.SelectedValue = nveids;
                dtp_dat_no.Value = DateTime.Parse(dat_no);
                dtp_dat_lidz.Value = DateTime.Parse(dat_lidz);
                
                cb_ned_diena.Enabled = false;
                cb_ned_diena.SelectedValue = ned_diena;
                cb_laiks.SelectedValue = laiks;
            } else if (id_kkods != "") {
                cb_idkkods.Enabled = false;
                cb_idkkods.SelectedValue = id_kkods;
            } else if (m) {
                cb_idmacsp.Enabled = false;
                cb_idmacsp.SelectedValue = id_macsp;
            }
        }
        
        bool parbaudit_ievadlaukus()
        {
            bool nav_kludu = true;
            
            dtp_dat_no.Value = dtp_dat_no.Value.AddDays(-(float)dtp_dat_no.Value.DayOfWeek + 1);
            
            if (dtp_dat_lidz.Value.DayOfWeek != 0) {
                dtp_dat_lidz.Value = dtp_dat_lidz.Value.AddDays(-(float)dtp_dat_lidz.Value.DayOfWeek + 7);
            }
            
            if (dtp_dat_no.Value > dtp_dat_lidz.Value) {
                ep_kluda.SetError(dtp_dat_no, "Sākuma datums nevar būt lielāks par beigu datumu");
                ep_kluda.SetError(dtp_dat_lidz, "Beigu datums nevar būt mazāks par sākuma datumu");
            } else {
                ep_kluda.SetError(dtp_dat_no, "");
                ep_kluda.SetError(dtp_dat_lidz, "");
            }
            
            foreach (Control el in Controls) {
                if (ep_kluda.GetError(el) != "") {
                    nav_kludu = false;
                    break;
                }
            }
            
            NpgsqlCommand parbaude = new NpgsqlCommand("SELECT n.id_nod FROM nodarbibas n, macibspeki m WHERE n.id_macsp = m.id_macsp AND m.id_macsp = @id_macsp AND n.ned_diena = @ned_diena AND n.laiks = @laiks AND (n.dat_no, n.dat_lidz) OVERLAPS (DATE @dat_no, DATE @dat_lidz);", db.sav);
            parbaude.Parameters.AddWithValue("@id_macsp", cb_idmacsp.SelectedValue.ToString());
            parbaude.Parameters.AddWithValue("@ned_diena", cb_ned_diena.SelectedValue.ToString());
            parbaude.Parameters.AddWithValue("@laiks", cb_laiks.SelectedValue.ToString());
            parbaude.Parameters.AddWithValue("@dat_no", dtp_dat_no.Value.ToString());
            parbaude.Parameters.AddWithValue("@dat_lidz", dtp_dat_lidz.Value.ToString());
            
            db.sav.Open();
            
            NpgsqlDataReader lasitajs = parbaude.ExecuteReader();
            
            if (lasitajs.HasRows) {
                lasitajs.Read();
                
                if (lasitajs["id_nod"].ToString() != id_nod) {
                    MessageBox.Show("Izvēlētajā laikā mācībspēkam jau ir ieplānota nodarbība!", "Ieplānota nodarbība", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nav_kludu = false;
                }
                
                db.sav.Close();
            }
            
            db.sav.Close();
            
            return nav_kludu;
        }
        
        void B_pievienotClick(object sender, EventArgs e)
        {
            if (parbaudit_ievadlaukus()) {
                id_macsp = cb_idmacsp.SelectedValue.ToString();
                id_kkods = cb_idkkods.SelectedValue.ToString();
                nveids = cb_nod_veids.SelectedValue.ToString();
                dat_no = dtp_dat_no.Value.ToString();
                dat_lidz = dtp_dat_lidz.Value.ToString();
                ned_diena = cb_ned_diena.SelectedValue.ToString();
                laiks = cb_laiks.SelectedValue.ToString();
                
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
