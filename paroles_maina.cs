using System;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class paroles_maina : Form
    {
        NpgsqlCommand mainas_kom;
        
        public paroles_maina()
        {
            InitializeComponent();
            
            this.ActiveControl = tb_pasreizeja;
        }
        
        void mainit_paroli()
        {
            switch (db.liet_grupa) {
                case "Mācībspēks":
                    mainas_kom = new NpgsqlCommand("UPDATE macibspeki SET parole = @parole WHERE id_macsp = @lietotajs;", db.sav);
                    break;
                case "Vadība":
                    mainas_kom = new NpgsqlCommand("UPDATE vadiba SET parole = @parole WHERE id_vadiba = @lietotajs;", db.sav);
                    break;
                case "Students":
                    mainas_kom = new NpgsqlCommand("UPDATE studenti SET parole = @parole WHERE id_matr = @lietotajs;", db.sav);
                    break;
            }
            
            mainas_kom.Parameters.AddWithValue("@lietotajs", db.lietotajs);
            mainas_kom.Parameters.AddWithValue("@parole", db.SHA1Parole(db.lietotajs, tb_jauna.Text));
            
            db.sav.Open();
            int ieraksti = mainas_kom.ExecuteNonQuery();
            db.sav.Close();
            
            if (ieraksti != -1) {
                MessageBox.Show("Lietotāja parole veiksmīgi nomainīta!", "Parole nomainīta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DialogResult = DialogResult.OK;
                Close();
            } else {
                MessageBox.Show("Paroles maiņas procesā radās neparedzēta kļūda!\nMēģiniet atkārtot paroles maiņu vēlāk.", "Kļūda paroles maiņas procesā", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        bool parbaudit_ievadlaukus()
        {
            bool nav_kludu = true;
            
            if (tb_pasreizeja.Text == "") {
                ep_kluda.SetError(tb_pasreizeja, db.obligats);
            } else if (db.SHA1Parole(db.lietotajs, tb_pasreizeja.Text) != db.parole) {
                ep_kluda.SetError(tb_pasreizeja, "Ievadītā parole nesakrīt ar pašreizējo paroli");
            } else {
                ep_kluda.SetError(tb_pasreizeja, "");
            }
            
            if (tb_jauna.Text == "") {
                ep_kluda.SetError(tb_jauna, db.obligats);
            } else if (tb_jauna.Text == tb_pasreizeja.Text) {
                ep_kluda.SetError(tb_jauna, "Jaunā parole sakrīt ar pašreizējo paroli");
            } else if (tb_jauna.Text != tb_atkartoti.Text) {
                ep_kluda.SetError(tb_jauna, "Jaunā un atkārtoti ievadītā parole nesakrīt");
            } else if (tb_jauna.Text.Length < 5) {
                ep_kluda.SetError(tb_jauna, "Parolei jābūt vismaz 5 simbolus garai");
            } else {
                ep_kluda.SetError(tb_jauna, "");
            }
            
            if (tb_atkartoti.Text == "") {
                ep_kluda.SetError(tb_atkartoti, db.obligats);
            } else if (tb_jauna.Text != tb_atkartoti.Text) {
                ep_kluda.SetError(tb_atkartoti, "Jaunā un atkārtoti ievadītā parole nesakrīt");
            } else if (tb_atkartoti.Text.Length < 5) {
                ep_kluda.SetError(tb_atkartoti, "Parolei jābūt vismaz 5 simbolus garai");
            } else {
                ep_kluda.SetError(tb_atkartoti, "");
            }
            
            foreach (Control el in Controls) {
                if (ep_kluda.GetError(el) != "") {
                    nav_kludu = false;
                    break;
                }
            }
            
            return nav_kludu;
        }
        
        void Tb_atkartotiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (parbaudit_ievadlaukus()) {
                    mainit_paroli();
                }
            }
        }
        
        void B_atceltClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        void B_mainitClick(object sender, EventArgs e)
        {            
            if (parbaudit_ievadlaukus()) {
                mainit_paroli();
            }
        }
    }
}
