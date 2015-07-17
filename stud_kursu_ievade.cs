using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace naus
{
    public partial class stud_kursu_ievade : Form
    {
        public string id_kkods, nosaukums, kp;
        
        public stud_kursu_ievade(string id, string n, string k)
        {
            InitializeComponent();
            
            id_kkods = id;
            nosaukums = n;
            kp = k;
            
            if (id != "") {
                Text = "Labot studiju kursu";
                b_pievienot.Text = "&Labot studiju kursa datus";
                
                tb_kkods.Text = id_kkods;
                tb_k_nosauk.Text = nosaukums;
                nud_kp.Value = Convert.ToDecimal(kp);
            }
        }
        
        bool parbaudit_ievadlaukus()
        {
            bool nav_kludu = true;
            
            if (tb_kkods.Text == "") {
                ep_kluda.SetError(tb_kkods, db.obligats);
            } else if (!Regex.IsMatch(tb_kkods.Text, @"^[A-Za-z]{4,5}\d*$")) {
                ep_kluda.SetError(tb_kkods, "Studiju kursa kodam jābūt formātā AaaA9999 vai AaaAA999, piemēram, InfT2035 vai InfTP016");
            } else if (vadiba.ds.Tables["stud_kursi"].Select("id_kkods = '" + tb_kkods.Text + "'").Length != 0 && id_kkods != tb_kkods.Text) {
                ep_kluda.SetError(tb_kkods, "Studiju kurss ar šādu kodu jau eksistē");
            } else {
                ep_kluda.SetError(tb_kkods, "");
            }
            
            if (tb_k_nosauk.Text == "") {
                ep_kluda.SetError(tb_k_nosauk, db.obligats);
            } else if (!db.latviesu_burti(tb_k_nosauk.Text)) {
                ep_kluda.SetError(tb_k_nosauk, db.lv_burti);
            } else if (vadiba.ds.Tables["stud_kursi"].Select("nosaukums = '" + tb_k_nosauk.Text + "'").Length != 0 && nosaukums != tb_k_nosauk.Text) {
                ep_kluda.SetError(tb_k_nosauk, "Studiju kurss ar šādu nosaukumu jau eksistē");
            } else {
                ep_kluda.SetError(tb_k_nosauk, "");
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
                id_kkods = tb_kkods.Text;
                nosaukums = tb_k_nosauk.Text;
                kp = nud_kp.Value.ToString();
            
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
