using System;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class autorizacija : Form
    {
        NpgsqlCommand aut_kom;
        
        int aut_skaits = 1;
        
        public autorizacija()
        {
            InitializeComponent();
            
            cb_grupa.SelectedIndex = 0;
            this.ActiveControl = tb_lietotajs;
        }
        
        void atvert_darba_formu()
        {
            Form darba_forma = null;
            Visible = false;
            
            switch (db.liet_grupa) {
                case "Mācībspēks":
                    darba_forma = new macibspeks();
                    break;
                case "Vadība":
                    darba_forma = new vadiba();
                    break;
                case "Students":
                    darba_forma = new students();
                    break;
            }
            
            if (darba_forma.ShowDialog() == DialogResult.OK) {
                Visible = true;
            } else {
                Application.Exit();
            }
        }
        
        void pieslegties()
        {
            string parole = "";
            db.liet_grupa = cb_grupa.Text;
            
            switch (db.liet_grupa) {
                case "Mācībspēks":
                    parole = db.SHA1Parole(tb_lietotajs.Text, tb_parole.Text);
                    
                    aut_kom = new NpgsqlCommand("SELECT id_macsp, vards, uzvards, zin_grads, amats, parole FROM macibspeki WHERE id_macsp = @lietotajs AND parole = @parole;", db.sav);
                    break;
                case "Vadība":
                    parole = db.SHA1Parole(tb_lietotajs.Text, tb_parole.Text);
                
                    aut_kom = new NpgsqlCommand("SELECT id_vadiba, vards, uzvards, parole FROM vadiba WHERE id_vadiba = @lietotajs AND parole = @parole;", db.sav);
                    break;
                case "Students":
                    tb_lietotajs.Text = tb_lietotajs.Text.ToUpper();
                    parole = db.SHA1Parole(tb_lietotajs.Text, tb_parole.Text);
                
                    aut_kom = new NpgsqlCommand("SELECT s.id_matr, s.vards, s.uzvards, p.nosaukums, s.id_prkods, s.kurss, s.grupa, s.parole FROM stud_prog p, studenti s WHERE p.id_prkods = s.id_prkods AND id_matr = @lietotajs AND parole = @parole;", db.sav);
                    break;
            }
            
            aut_kom.Parameters.AddWithValue("@lietotajs", tb_lietotajs.Text);
            aut_kom.Parameters.AddWithValue("@parole", parole);
            
            if (tb_lietotajs.Text != "" && tb_parole.Text != "") {
                db.sav.Open();
                NpgsqlDataReader lasitajs = aut_kom.ExecuteReader();
                
                if (lasitajs.HasRows) {
                    lasitajs.Read();
                    
                    switch (db.liet_grupa) {
                        case "Mācībspēks":
                            db.lietotajs = (string)lasitajs["id_macsp"];
                            db.vards = (string)lasitajs["vards"];
                            db.uzvards = (string)lasitajs["uzvards"];
                            db.zin_grads = (string)lasitajs["zin_grads"];
                            db.amats = (string)lasitajs["amats"];
                            db.parole = (string)lasitajs["parole"];
                            break;
                        case "Vadība":
                            db.lietotajs = (string)lasitajs["id_vadiba"];
                            db.vards = (string)lasitajs["vards"];
                            db.uzvards = (string)lasitajs["uzvards"];
                            db.parole = (string)lasitajs["parole"];
                            break;
                        case "Students":
                            db.lietotajs = (string)lasitajs["id_matr"];
                            db.vards = (string)lasitajs["vards"];
                            db.uzvards = (string)lasitajs["uzvards"];
                            db.pr_nosaukums = (string)lasitajs["nosaukums"];
                            db.pr_kods = (string)lasitajs["id_prkods"];
                            db.kurss = (int)lasitajs["kurss"];
                            db.grupa = Convert.ToDouble(lasitajs["grupa"]);
                            db.parole = (string)lasitajs["parole"];
                            break;
                    }
                    
                    db.sav.Close();
                    
                    NpgsqlCommand sist_zurn = new NpgsqlCommand("INSERT INTO sist_zurnals VALUES(DEFAULT, @lietotajs, @liet_grupa, NOW())", db.sav);
                    sist_zurn.Parameters.AddWithValue("@lietotajs", db.lietotajs);
                    sist_zurn.Parameters.AddWithValue("@liet_grupa", db.liet_grupa);
                    
                    db.sav.Open();
                    sist_zurn.ExecuteNonQuery();
                    db.sav.Close();
                    
                    aut_skaits = 1;
                    cb_grupa.SelectedIndex = 0;
                    tb_lietotajs.Text = "";
                    tb_parole.Text = "";
                    
                    if (db.SHA1Parole(db.lietotajs, db.lietotajs) != db.parole) {
                        atvert_darba_formu();
                    } else {
                        MessageBox.Show("Jūsu lietotāja kontam tiek izmantota sistēmas automātiski ģenerētā parole, tādēļ nepieciešams veikt pašreizējās paroles maiņu.", "Nepieciešams veikt pašreizējās paroles maiņu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        paroles_maina d_parole = new paroles_maina();
                        
                        if (d_parole.ShowDialog() == DialogResult.OK) {
                            atvert_darba_formu();
                        }
                    }
                } else {
                    MessageBox.Show("Neizdevās atrast lietotāju ar norādīto autorizēšanās informāciju!\n\nPārbaudiet vai esat ievadījis pareizu lietotājvārdu un/vai paroli, kā arī esat izvēlējies sev atbilstošo lietotāju grupu.", "Neizdevās autorizēties sistēmā", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (aut_skaits == 3) {
                        
                        NpgsqlCommand sist_zurn = new NpgsqlCommand("INSERT INTO sist_zurnals VALUES(DEFAULT, 'Nezināms lietotājs', @liet_grupa, NOW())", db.sav);
                        sist_zurn.Parameters.AddWithValue("@liet_grupa", cb_grupa.Text);
                        sist_zurn.ExecuteNonQuery();
                        
                        Application.Exit();
                    } else {
                        aut_skaits++;
                    }
                }
                
                db.sav.Close();
            } else {
                MessageBox.Show("Lietotājvārda un paroles ievadlaukiem jābūt obligāti aizpildītiem!", "Nederīgi autorizēšanās dati", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        void Cb_grupaSelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveControl = tb_lietotajs;
        }
        
        void Tb_paroleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                pieslegties();
            }
        }
        
        void B_pieslegtiesClick(object sender, EventArgs e)
        {
            pieslegties();
        }
        
        void B_izietClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
