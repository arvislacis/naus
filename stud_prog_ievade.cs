using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace naus
{
    public partial class stud_prog_ievade : Form
    {
        public string id_prkods, nosaukums, id_prveids;
        
        public stud_prog_ievade(string id, string n, string v)
        {
            InitializeComponent();
            
            id_prkods = id;
            nosaukums = n;
            id_prveids = v;
            
            cb_prog_veids.DataSource = vadiba.ds.Tables["prog_veidi"];
            cb_prog_veids.DisplayMember = "veids";
            cb_prog_veids.ValueMember = "id_prveids";
            
            if (id != "") {
                Text = "Labot studiju programmu";
                b_pievienot.Text = "&Labot studiju programmas datus";
                
                tb_prkods.Text = id_prkods;
                tb_prog_nosauk.Text = nosaukums;
                cb_prog_veids.SelectedValue = id_prveids;
            }
        }
        
        bool parbaudit_ievadlaukus()
        {
            bool nav_kludu = true;
            
            if (tb_prkods.Text == "") {
                ep_kluda.SetError(tb_prkods, db.obligats);
            } else if (!Regex.IsMatch(tb_prkods.Text, @"^G\d{4}$")) {
                ep_kluda.SetError(tb_prkods, "Studiju programmas kodam jābūt formātā G9999, piemēram, G0904");
            } else if (vadiba.ds.Tables["stud_prog"].Select("id_prkods = '" + tb_prkods.Text + "'").Length != 0 && id_prkods != tb_prkods.Text) {
                ep_kluda.SetError(tb_prkods, "Studiju programma ar šādu kodu jau eksistē");
            } else {
                ep_kluda.SetError(tb_prkods, "");
            }
            
            if (tb_prog_nosauk.Text == "") {
                ep_kluda.SetError(tb_prog_nosauk, db.obligats);
            } else if (!db.latviesu_burti(tb_prog_nosauk.Text)) {
                ep_kluda.SetError(tb_prog_nosauk, db.lv_burti);
            } else {
                ep_kluda.SetError(tb_prog_nosauk, "");
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
                id_prkods = tb_prkods.Text;
                nosaukums = tb_prog_nosauk.Text;
                id_prveids = cb_prog_veids.SelectedValue.ToString();
            
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
