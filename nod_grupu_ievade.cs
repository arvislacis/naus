using System;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class nod_grupu_ievade : Form
    {
        public string id_prkods, kurss, grupa, ned_diena, laiks, dat_no, dat_lidz;
        
        public nod_grupu_ievade(string m, string s, string n, string no, string lidz, string nd, string l, string nd2, string l2)
        {
            InitializeComponent();

            dat_no = no;
            dat_lidz = lidz;
            
            l_macsp_nosauk.Text = m;
            l_stud_kurss_nosauk.Text = s;
            l_nod_veida_nosauk.Text = n;
            l_dat_no_vert.Text = DateTime.Parse(no).ToLongDateString();
            l_dat_lidz_vert.Text = DateTime.Parse(lidz).ToLongDateString();
            l_ned_diena_vert.Text = nd;
            l_laiks_vert.Text = l;
            ned_diena = nd2;
            laiks = l2;
            
            cb_stud_prog.DataSource = db.iegut_studiju_programmas();
            cb_stud_prog.DisplayMember = "nosauk_kods";
            cb_stud_prog.ValueMember = "id_prkods";
            
            cb_kurss.DataSource = db.kursiDT;
            cb_kurss.DisplayMember = "kurss";
            cb_kurss.ValueMember = "kurss";
            
            cb_grupa.DataSource = db.grupasDT;
            cb_grupa.DisplayMember = "grupa";
            cb_grupa.ValueMember = "grupa";
        }
        
        bool parbaudit_ievadlaukus()
        {
            bool nav_kludu = true;
            
            NpgsqlCommand parbaude = new NpgsqlCommand("SELECT s.id_matr FROM studenti s, stud_prog p WHERE p.id_prkods = @prkods AND s.id_prkods = p.id_prkods AND kurss = @kurss AND grupa = @grupa;", db.sav);
            parbaude.Parameters.AddWithValue("@prkods", cb_stud_prog.SelectedValue.ToString());
            parbaude.Parameters.AddWithValue("@kurss", cb_kurss.SelectedValue.ToString());
            parbaude.Parameters.AddWithValue("@grupa", cb_grupa.SelectedValue.ToString());
            
            NpgsqlCommand parbaude2 = new NpgsqlCommand("SELECT g.id_grupa FROM nodarbibas n, nod_grupas g WHERE n.id_nod = g.id_nod AND g.id_prkods = @prkods AND g.kurss = @kurss AND grupa = @grupa AND n.ned_diena = @ned_diena AND n.laiks = @laiks AND (n.dat_no, n.dat_lidz) OVERLAPS (DATE @dat_no, DATE @dat_lidz);", db.sav);
            parbaude2.Parameters.AddWithValue("@prkods", cb_stud_prog.SelectedValue.ToString());
            parbaude2.Parameters.AddWithValue("@kurss", cb_kurss.SelectedValue.ToString());
            parbaude2.Parameters.AddWithValue("@grupa", cb_grupa.SelectedValue.ToString());
            parbaude2.Parameters.AddWithValue("@ned_diena", ned_diena);
            parbaude2.Parameters.AddWithValue("@laiks", laiks);
            parbaude2.Parameters.AddWithValue("@dat_no", dat_no);
            parbaude2.Parameters.AddWithValue("@dat_lidz", dat_lidz);
            
            db.sav.Open();
            
            NpgsqlDataReader lasitajs = parbaude.ExecuteReader();
            
            if (!lasitajs.HasRows) {
                MessageBox.Show("Neizdevās atrast studējošo datus pēc norādītās studiju programmas, kursa un grupas!\n\nPārbaudiet vai esat izvēlējies atbilstošo studiju programmu, studējošu kursu un grupu.", "Nav studējošo datu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.sav.Close();
                return false;
            }
            
            db.sav.Close();
            db.sav.Open();
            
            NpgsqlDataReader lasitajs2 = parbaude2.ExecuteReader();
            
            if (lasitajs2.HasRows) {
                MessageBox.Show("Izvēlētajā laikā studējošo grupai jau ir ieplānota nodarbība!", "Ieplānota nodarbība", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.sav.Close();
                return false;
            }
            
            db.sav.Close();
            
            return nav_kludu;
        }
        
        void B_pievienotClick(object sender, EventArgs e)
        {
            if (parbaudit_ievadlaukus()) {
                id_prkods = cb_stud_prog.SelectedValue.ToString();
                kurss = cb_kurss.SelectedValue.ToString();
                grupa = cb_grupa.SelectedValue.ToString();
            
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
