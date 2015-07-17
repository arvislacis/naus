using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace naus
{
    public partial class macibspeku_ievade : Form
    {
        public string id_macsp, vards, uzvards, zin_grads, amats;
        
        public macibspeku_ievade(string id, string v, string u, string z, string a)
        {
            InitializeComponent();
            
            id_macsp = id;
            vards = v;
            uzvards = u;
            zin_grads = z;
            amats = a;
            
            if (id != "") {
                Text = "Labot mācībspēku";
                b_pievienot.Text = "&Labot mācībspēka datus";
                
                tb_idmacsp.Enabled = false;
                tb_idmacsp.Text = id;
                tb_vards.Text = vards;
                tb_uzvards.Text = uzvards;
                tb_zin_grads.Text = zin_grads;
                tb_amats.Text = amats;
            }
        }
        
        bool parbaudit_ievadlaukus()
        {
            bool nav_kludu = true;
            
            if (tb_idmacsp.Text == "") {
                ep_kluda.SetError(tb_idmacsp, db.obligats);
            }else if (!Regex.IsMatch(tb_idmacsp.Text, @"^[A-Za-z0-9\.]*$")) {
                ep_kluda.SetError(tb_idmacsp, "Mācībspēka lietotājvārds var saturēt tikai latīņu alfabēta burtus (A-z), ciparus (0-9) un punktu (.)");
            } else if (vadiba.ds.Tables["macibspeki"].Select("id_macsp = '" + tb_idmacsp.Text + "'").Length != 0 && id_macsp != tb_idmacsp.Text) {
                ep_kluda.SetError(tb_idmacsp, "Mācībspēks ar šādu lietotājvārdu jau eksistē");
            } else {
                ep_kluda.SetError(tb_idmacsp, "");
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
            
            if (tb_zin_grads.Text == "") {
                ep_kluda.SetError(tb_zin_grads, db.obligats);
            } else if (!db.latviesu_burti(tb_zin_grads.Text)) {
                ep_kluda.SetError(tb_zin_grads, db.lv_burti);
            } else {
                ep_kluda.SetError(tb_zin_grads, "");
            }
            
            if (tb_amats.Text == "") {
                ep_kluda.SetError(tb_amats, db.obligats);
            } else if (!db.latviesu_burti(tb_amats.Text)) {
                ep_kluda.SetError(tb_amats, db.lv_burti);
            } else {
                ep_kluda.SetError(tb_amats, "");
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
                id_macsp = tb_idmacsp.Text;
                vards = tb_vards.Text;
                uzvards = tb_uzvards.Text;
                zin_grads = tb_zin_grads.Text;
                amats = tb_amats.Text;
            
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
