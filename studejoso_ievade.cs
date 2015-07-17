using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace naus
{
    public partial class studejoso_ievade : Form
    {
        public string id_matr, vards, uzvards, id_prkods, kurss, grupa;
        
        public studejoso_ievade(string id, string v, string u, string s, string k, string g)
        {
            InitializeComponent();
            
            id_matr = id;
            vards = v;
            uzvards = u;
            id_prkods = s;
            kurss = k;
            grupa = g;
            
            cb_stud_prog.DataSource = vadiba.ds.Tables["stud_prog"];
            cb_stud_prog.DisplayMember = "nosauk_kods";
            cb_stud_prog.ValueMember = "id_prkods";
            
            cb_kurss.DataSource = db.kursiDT;
            cb_kurss.DisplayMember = "kurss";
            cb_kurss.ValueMember = "kurss";
            
            cb_grupa.DataSource = db.grupasDT;
            cb_grupa.DisplayMember = "grupa";
            cb_grupa.ValueMember = "grupa";
            
            if (id != "") {
                Text = "Labot studējošo";
                b_pievienot.Text = "&Labot studējošā datus";
                
                tb_matr_nr.Enabled = false;
                tb_matr_nr.Text = id_matr;
                tb_vards.Text = vards;
                tb_uzvards.Text = uzvards;
                cb_stud_prog.Enabled = false;
                cb_stud_prog.SelectedValue = id_prkods;
                cb_kurss.Enabled = false;
                cb_kurss.SelectedValue = kurss;
                cb_grupa.Enabled = false;
                cb_grupa.SelectedValue = grupa;
            } else if (id_prkods != "") {
                cb_stud_prog.Enabled = false;
                cb_stud_prog.SelectedValue = id_prkods;
            }
        }
        
        bool parbaudit_ievadlaukus()
        {
            bool nav_kludu = true;
            
            if (tb_matr_nr.Text == "") {
                ep_kluda.SetError(tb_matr_nr, db.obligats);
            } else if (!Regex.IsMatch(tb_matr_nr.Text, @"^[A-Za-z]{2}\d{5}$")) {
                ep_kluda.SetError(tb_matr_nr, "Matrikulas numuram jābūt formātā AA99999, piemēram, IT12023");
            } else if (vadiba.ds.Tables["studenti"].Select("id_matr = '" + tb_matr_nr.Text + "'").Length != 0 && id_matr != tb_matr_nr.Text) {
                ep_kluda.SetError(tb_matr_nr, "Studējošais ar šādu matrikulas numuru jau eksistē");
            } else {
                ep_kluda.SetError(tb_matr_nr, "");
            }
            
            if (tb_vards.Text == "") {
                ep_kluda.SetError(tb_vards, db.obligats);
            } else if (!db.latviesu_burti(tb_vards.Text)) {
                ep_kluda.SetError(tb_vards, db.lv_burti);
            } else {
                ep_kluda.SetError(tb_vards, "");
            }
            
            if (tb_uzvards.Text == "") {
                ep_kluda.SetError(tb_uzvards, db.obligats);
            } else if (!db.latviesu_burti(tb_uzvards.Text)) {
                ep_kluda.SetError(tb_uzvards, db.lv_burti);
            } else {
                ep_kluda.SetError(tb_uzvards, "");
            }
            
            foreach (Control el in Controls) {
                if (ep_kluda.GetError(el) != "") {
                    nav_kludu = false;
                    break;
                }
            }
            
            return nav_kludu;
        }
        
        void B_pievienotClick(object sender, EventArgs e)
        {
            if (parbaudit_ievadlaukus()) {
                id_matr = tb_matr_nr.Text.ToUpper();
                vards = tb_vards.Text;
                uzvards = tb_uzvards.Text;
                id_prkods = cb_stud_prog.SelectedValue.ToString();
                kurss = cb_kurss.SelectedValue.ToString();
                grupa = cb_grupa.SelectedValue.ToString();
            
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
