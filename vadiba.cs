using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public partial class vadiba : Form
    {
        public static DataSet ds = new DataSet();
        
        DataTable prog_veidiDT = new DataTable("prog_veidi");
        DataTable stud_progDT = new DataTable("stud_prog");
        DataTable studentiDT = new DataTable("studenti");
        DataTable macibspekiDT = new DataTable("macibspeki");
        DataTable stud_kursiDT = new DataTable("stud_kursi");
        DataTable nod_veidiDT = new DataTable("nod_veidi");
        DataTable nodarbibasDT = new DataTable("nodarbibas");
        DataTable nod_grupasDT = new DataTable("nod_grupas");
        DataTable aktivas_nodDT = new DataTable("aktivas_nod");
        DataTable pedejas_autDT = new DataTable("pedejas_aut");
        DataTable visi_studDT = new DataTable("visi_studejosie");
        DataTable visi_macspDT = new DataTable("visi_macibspeki");
        
        NpgsqlDataAdapter prog_veidiA = new NpgsqlDataAdapter("SELECT id_prveids, veids FROM prog_veidi;", db.sav);
        NpgsqlDataAdapter stud_progA = new NpgsqlDataAdapter("SELECT id_prkods, nosaukums, id_prveids, (nosaukums || ' (' || id_prkods || ')') nosauk_kods FROM stud_prog;", db.sav);
        NpgsqlDataAdapter studentiA = new NpgsqlDataAdapter("SELECT id_matr, vards, uzvards, id_prkods, kurss, grupa, parole, (CASE WHEN parbaudit_paroli(id_matr, id_matr, parole) = 1 THEN true ELSE false END) main_parole FROM studenti ORDER BY kurss, grupa, uzvards;", db.sav);
        NpgsqlDataAdapter macibspekiA = new NpgsqlDataAdapter("SELECT id_macsp, vards, uzvards, zin_grads, amats, parole, (vards || ' ' || uzvards) m_v_uzv, (CASE WHEN parbaudit_paroli(id_macsp, id_macsp, parole) = 1 THEN true ELSE false END) main_parole FROM macibspeki ORDER BY uzvards;", db.sav);
        NpgsqlDataAdapter stud_kursiA = new NpgsqlDataAdapter("SELECT id_kkods, nosaukums, kr_punkti FROM stud_kursi ORDER BY nosaukums;", db.sav);
        NpgsqlDataAdapter nod_veidiA = new NpgsqlDataAdapter("SELECT id_nveids, veids FROM nod_veidi;", db.sav);
        NpgsqlDataAdapter nodarbibasA = new NpgsqlDataAdapter("SELECT id_nod, id_kkods, id_macsp, id_nveids, dat_no, dat_lidz, ned_diena, laiks FROM nodarbibas ORDER BY dat_no, ned_diena, laiks;", db.sav);
        NpgsqlDataAdapter nod_grupasA = new NpgsqlDataAdapter("SELECT id_grupa, id_nod, id_prkods, kurss, grupa FROM nod_grupas ORDER BY kurss, grupa;", db.sav);
        NpgsqlDataAdapter aktivas_nodA = new NpgsqlDataAdapter("SELECT k.nosaukums, (m.vards || ' ' || m.uzvards) m_v_uzv, n.veids, a.dat_no, a.dat_lidz, a.laiks FROM akt_nodarbibas a, stud_kursi k, macibspeki m, nod_veidi n WHERE a.id_kkods = k.id_kkods AND a.id_macsp = m.id_macsp AND a.id_nveids = n.id_nveids;", db.sav);
        NpgsqlDataAdapter pedejas_autA = new NpgsqlDataAdapter("SELECT sz.lietotajs, sz.liet_grupa, sz.datums, (TO_CHAR(NOW() - sz.datums, 'DD \" d \" HH24 \" h \" MI \" min \" SS \" s \"')) pirms, SUM(ask.skaits) aut_skaits FROM sist_zurnals sz, (SELECT lietotajs, COUNT(lietotajs) skaits FROM sist_zurnals GROUP BY lietotajs) ask WHERE sz.lietotajs = ask.lietotajs GROUP BY sz.lietotajs, sz.liet_grupa, sz.datums, pirms ORDER BY sz.datums DESC LIMIT 100;", db.sav);
        NpgsqlDataAdapter visi_studA = new NpgsqlDataAdapter("SELECT id_matr, vards, uzvards, nosaukums, kurss, grupa, apmeklejumi, kavejumi, kopa, (procenti || '%') procenti FROM stud_kop_apm ORDER BY nosaukums, kurss, grupa, uzvards;", db.sav);
        NpgsqlDataAdapter visi_macspA = new NpgsqlDataAdapter("SELECT vards, uzvards, apmeklejumi, kavejumi, kopa, (procenti || '%') procenti FROM mac_kop_apm ORDER BY uzvards;", db.sav);
        
        bool sagl_kluda;
        
        public vadiba()
        {
            InitializeComponent();
            
            sl_lietotajs.Text = db.vards + " " + db.uzvards;
            sl_datums_laiks.Text = db.datuma_virkne(DateTime.Now, true);
            
            izveidot_lokalo_db();
            noformet_saraksta_logus();
        }
        
        void izveidot_lokalo_db()
        {
            prog_veidiA.Fill(prog_veidiDT);
            stud_progA.Fill(stud_progDT);
            studentiA.Fill(studentiDT);
            macibspekiA.Fill(macibspekiDT);
            stud_kursiA.Fill(stud_kursiDT);
            nod_veidiA.Fill(nod_veidiDT);
            nodarbibasA.Fill(nodarbibasDT);
            nod_grupasA.Fill(nod_grupasDT);
            aktivas_nodA.Fill(aktivas_nodDT);
            pedejas_autA.Fill(pedejas_autDT);
            visi_studA.Fill(visi_studDT);
            visi_macspA.Fill(visi_macspDT);
            
            ds.Tables.Add(prog_veidiDT);
            ds.Tables.Add(stud_progDT);
            ds.Tables.Add(studentiDT);
            ds.Tables.Add(macibspekiDT);
            ds.Tables.Add(stud_kursiDT);
            ds.Tables.Add(nod_veidiDT);
            ds.Tables.Add(nodarbibasDT);
            ds.Tables.Add(nod_grupasDT);
            ds.Tables.Add(aktivas_nodDT);
            ds.Tables.Add(pedejas_autDT);
            ds.Tables.Add(visi_studDT);
            ds.Tables.Add(visi_macspDT);
            
            prog_veidiDT.PrimaryKey = new DataColumn[] {prog_veidiDT.Columns["id_prveids"]};
            stud_progDT.PrimaryKey = new DataColumn[] {stud_progDT.Columns["id_prkods"]};
            studentiDT.PrimaryKey = new DataColumn[] {studentiDT.Columns["id_matr"]};
            macibspekiDT.PrimaryKey = new DataColumn[] {macibspekiDT.Columns["id_macsp"]};
            stud_kursiDT.PrimaryKey = new DataColumn[] {stud_kursiDT.Columns["id_kkods"]};
            nod_veidiDT.PrimaryKey = new DataColumn[] {nod_veidiDT.Columns["id_nveids"]};
            nodarbibasDT.PrimaryKey = new DataColumn[] {nodarbibasDT.Columns["id_nod"]};
            nod_grupasDT.PrimaryKey = new DataColumn[] {nod_grupasDT.Columns["id_grupa"]};
            
            nodarbibasDT.Columns["id_nod"].AutoIncrement = true;
            nod_grupasDT.Columns["id_grupa"].AutoIncrement = true;
            
            nodarbibasDT.Columns["id_nod"].AutoIncrementStep = 1;
            nod_grupasDT.Columns["id_grupa"].AutoIncrementStep = 1;
            
            db.sav.Open();
            
            NpgsqlCommand id_nod = new NpgsqlCommand("SELECT nextval('nodarbibas_id_nod_seq');", db.sav);
            NpgsqlCommand id_grupa = new NpgsqlCommand("SELECT nextval('nod_grupas_id_grupa_seq');", db.sav);
            
            nodarbibasDT.Columns["id_nod"].AutoIncrementSeed = (long)id_nod.ExecuteScalar();
            nod_grupasDT.Columns["id_grupa"].AutoIncrementSeed = (long)id_grupa.ExecuteScalar();
            
            db.sav.Close();
            
            ds.Relations.Add("stud_prog-studenti", stud_progDT.Columns["id_prkods"], studentiDT.Columns["id_prkods"], true);
            ds.Relations.Add("stud_kursi-nodarbibas", stud_kursiDT.Columns["id_kkods"], nodarbibasDT.Columns["id_kkods"], true);
            ds.Relations.Add("nodarbibas-nod_grupas", nodarbibasDT.Columns["id_nod"], nod_grupasDT.Columns["id_nod"], true);
            ds.Relations.Add("stud_prog-nod_grupas", stud_progDT.Columns["id_prkods"], nod_grupasDT.Columns["id_prkods"], true);
            ds.Relations.Add("macibspeki-nodarbibas", macibspekiDT.Columns["id_macsp"], nodarbibasDT.Columns["id_macsp"], true);
        }
        
        void noformet_saraksta_logus()
        {
            dgv_aktivas_nod.DataSource = aktivas_nodDT;
            dgv_aktivas_nod.Columns["nosaukums"].HeaderText = "Studiju kurss";
            dgv_aktivas_nod.Columns["m_v_uzv"].HeaderText = "Mācībspēks";
            dgv_aktivas_nod.Columns["veids"].HeaderText = "Nodarbības veids";
            dgv_aktivas_nod.Columns["dat_no"].HeaderText = "Datums no";
            dgv_aktivas_nod.Columns["dat_lidz"].HeaderText = "Datums līdz";
            dgv_aktivas_nod.Columns["laiks"].HeaderText = "Laiks";
            DataGridViewComboBoxColumn cb_laiks = new DataGridViewComboBoxColumn();
            cb_laiks.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_laiks.DataSource = db.laikiDT;
            cb_laiks.Name = "laiks";
            cb_laiks.DataPropertyName = cb_laiks.ValueMember = "laiks";
            cb_laiks.DisplayMember = "virkne";
            cb_laiks.HeaderText = "Laiks";
            dgv_aktivas_nod.Columns.Remove(dgv_aktivas_nod.Columns["laiks"]);
            dgv_aktivas_nod.Columns.Insert(5, cb_laiks);
            
            dgv_ped_autorizacijas.DataSource = pedejas_autDT;
            dgv_ped_autorizacijas.Columns["lietotajs"].HeaderText = "Lietotājvārds";
            dgv_ped_autorizacijas.Columns["liet_grupa"].HeaderText = "Lietotāja grupa";
            dgv_ped_autorizacijas.Columns["datums"].HeaderText = "Autorizācijas datums un laiks";
            dgv_ped_autorizacijas.Columns["pirms"].HeaderText = "Laiks kopš autorizācijas";
            dgv_ped_autorizacijas.Columns["aut_skaits"].HeaderText = "Kopējais autorizāciju skaits";
            
            dgv_stud_kursi.DataSource = stud_kursiDT;
            dgv_stud_kursi.Columns["id_kkods"].HeaderText = "Kursa kods";
            dgv_stud_kursi.Columns["nosaukums"].HeaderText = "Kursa nosaukums";
            dgv_stud_kursi.Columns["kr_punkti"].HeaderText = "Kredītpunkti";
            
            dgv_nodarbibas.DataSource = nodarbibasDT;
            dgv_nodarbibas.DataSource = stud_kursiDT;
            dgv_nodarbibas.DataMember = "stud_kursi-nodarbibas";
            sagatavot_plan_nodarbibu_skatu();
            
            dgv_nod_grupas.DataSource = nod_grupasDT;
            dgv_nod_grupas.Columns["id_grupa"].HeaderText = "ID";
            dgv_nod_grupas.Columns["id_nod"].HeaderText = "Nodarbība";
            dgv_nod_grupas.Columns["id_prkods"].HeaderText = "Studiju programma";
            DataGridViewComboBoxColumn cb_stud_prog2 = new DataGridViewComboBoxColumn();
            cb_stud_prog2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_stud_prog2.DataSource = stud_progDT;
            cb_stud_prog2.Name = "id_prkods";
            cb_stud_prog2.DataPropertyName = cb_stud_prog2.ValueMember = "id_prkods";
            cb_stud_prog2.DisplayMember = "nosaukums";
            cb_stud_prog2.HeaderText = "Studiju programma";
            dgv_nod_grupas.Columns.Remove(dgv_nod_grupas.Columns["id_prkods"]);
            dgv_nod_grupas.Columns.Insert(2, cb_stud_prog2);
            dgv_nod_grupas.Columns["kurss"].HeaderText = "Kurss";
            dgv_nod_grupas.Columns["grupa"].HeaderText = "Grupa";
            dgv_nod_grupas.Columns["id_nod"].Visible = false;
            dgv_nod_grupas.Columns["id_grupa"].Visible = false;
            
            dgv_stud_prog.DataSource = stud_progDT;
            dgv_stud_prog.Columns["id_prkods"].HeaderText = "Programmas kods";
            dgv_stud_prog.Columns["nosaukums"].HeaderText = "Programmas nosaukums";
            dgv_stud_prog.Columns["nosauk_kods"].HeaderText = "Nosaukums (kods)";
            DataGridViewComboBoxColumn cb_prog_veids = new DataGridViewComboBoxColumn();
            cb_prog_veids.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_prog_veids.DataSource = prog_veidiDT;
            cb_prog_veids.Name = "id_prveids";
            cb_prog_veids.DataPropertyName = cb_prog_veids.ValueMember = "id_prveids";
            cb_prog_veids.DisplayMember = "veids";
            cb_prog_veids.HeaderText = "Programmas veids";
            dgv_stud_prog.Columns.Remove(dgv_stud_prog.Columns["id_prveids"]);
            dgv_stud_prog.Columns.Add(cb_prog_veids);
            dgv_stud_prog.Columns["nosauk_kods"].Visible = false;
            
            dgv_studenti.DataSource = studentiDT;
            dgv_studenti.DataSource = stud_progDT;
            dgv_studenti.DataMember = "stud_prog-studenti";
            sagatavot_studejoso_skatu();
            
            dgv_macibspeki.DataSource = macibspekiDT;
            dgv_macibspeki.Columns["id_macsp"].HeaderText = "Lietotājvārds";
            dgv_macibspeki.Columns["vards"].HeaderText = "Vārds";
            dgv_macibspeki.Columns["uzvards"].HeaderText = "Uzvārds";
            dgv_macibspeki.Columns["zin_grads"].HeaderText = "Zinātniskais grāds";
            dgv_macibspeki.Columns["amats"].HeaderText = "Amats";
            dgv_macibspeki.Columns["parole"].HeaderText = "Parole";
            dgv_macibspeki.Columns["m_v_uzv"].HeaderText = "Mācībspēks";
            dgv_macibspeki.Columns["main_parole"].HeaderText = "Nomainīta parole";
            dgv_macibspeki.Columns["main_parole"].ReadOnly = true;
            dgv_macibspeki.Columns["parole"].Visible = false;
            dgv_macibspeki.Columns["m_v_uzv"].Visible = false;
            
            dgv_visu_stud_apm.DataSource = visi_studDT;
            dgv_visu_stud_apm.Columns["id_matr"].HeaderText = "Matrikulas nr.";
            dgv_visu_stud_apm.Columns["vards"].HeaderText = "Vārds";
            dgv_visu_stud_apm.Columns["uzvards"].HeaderText = "Uzvārds";
            dgv_visu_stud_apm.Columns["nosaukums"].HeaderText = "Studiju programma";
            dgv_visu_stud_apm.Columns["kurss"].HeaderText = "Kurss";
            dgv_visu_stud_apm.Columns["grupa"].HeaderText = "Grupa";
            dgv_visu_stud_apm.Columns["apmeklejumi"].HeaderText = "Apmeklētās nodarbības";
            dgv_visu_stud_apm.Columns["kavejumi"].HeaderText = "Kavētās nodarbības";
            dgv_visu_stud_apm.Columns["kopa"].HeaderText = "Kopējais nodarbību skaits";
            dgv_visu_stud_apm.Columns["procenti"].HeaderText = "Apmeklējums procentos";
            
            dgv_visu_macsp_apm.DataSource = visi_macspDT;
            dgv_visu_macsp_apm.Columns["vards"].HeaderText = "Vārds";
            dgv_visu_macsp_apm.Columns["uzvards"].HeaderText = "Uzvārds";
            dgv_visu_macsp_apm.Columns["apmeklejumi"].HeaderText = "Apmeklētās nodarbības";
            dgv_visu_macsp_apm.Columns["kavejumi"].HeaderText = "Kavētās nodarbības";
            dgv_visu_macsp_apm.Columns["kopa"].HeaderText = "Kopējais nodarbību skaits";
            dgv_visu_macsp_apm.Columns["procenti"].HeaderText = "Apmeklējums procentos";
            
            planoto_nodarbibu_filtri();
            studejoso_filtri();
        }
        
        // Nodarbību plānošanas cilne un ar to saistītās funkcijas
        
        void B_stud_kursi_pievienotClick(object sender, EventArgs e)
        {
            stud_kursu_ievade d_stud_kurss = new stud_kursu_ievade("", "", "");
            
            if (d_stud_kurss.ShowDialog() == DialogResult.OK) {
                DataRow stud_kurss = stud_kursiDT.NewRow();
             
                stud_kurss["id_kkods"] = d_stud_kurss.id_kkods;
                stud_kurss["nosaukums"] = d_stud_kurss.nosaukums;
                stud_kurss["kr_punkti"] = d_stud_kurss.kp;
                
                stud_kursiDT.Rows.Add(stud_kurss);
            }
        }
        
        void B_stud_kursi_labotClick(object sender, EventArgs e)
        {
            if (dgv_stud_kursi.SelectedRows.Count > 0) {
                int indekss = dgv_stud_kursi.SelectedRows[0].Index;
                
                Dgv_stud_kursiCellDoubleClick(dgv_stud_kursi, new DataGridViewCellEventArgs(0, indekss));
            } else {
                db.msgbox_nav_labojamo();
            }
        }
        void B_stud_kursi_dzestClick(object sender, EventArgs e)
        {
            if (dgv_stud_kursi.SelectedRows.Count > 0) {
                int indekss = dgv_stud_kursi.SelectedRows[0].Index;
                
                if (db.msgbox_dzesanas_apstiprinajums() == DialogResult.Yes) {
                    dgv_stud_kursi.Rows.RemoveAt(indekss);
                }
            } else {
                db.msgbox_nav_dzesamo();
            }
        }
        
        void B_nod_pievienotClick(object sender, EventArgs e)
        {
            string stud_kurss = "";
            
            if (dgv_stud_kursi.SelectedRows.Count > 0) {
                stud_kurss = dgv_stud_kursi["id_kkods", dgv_stud_kursi.SelectedRows[0].Index].Value.ToString();
            }
            
            nodarbibu_ievade d_nodarbiba = new nodarbibu_ievade("", "", stud_kurss, "", "", "", "", "", false);
            
            if (d_nodarbiba.ShowDialog() == DialogResult.OK) {
                DataRow nodarbiba = nodarbibasDT.NewRow();
                
                nodarbiba["id_macsp"] = d_nodarbiba.id_macsp;
                nodarbiba["id_kkods"] = d_nodarbiba.id_kkods;
                nodarbiba["id_nveids"] = d_nodarbiba.nveids;
                nodarbiba["dat_no"] = d_nodarbiba.dat_no;
                nodarbiba["dat_lidz"] = d_nodarbiba.dat_lidz;
                nodarbiba["ned_diena"] = d_nodarbiba.ned_diena;
                nodarbiba["laiks"] = d_nodarbiba.laiks;
                
                nodarbibasDT.Rows.Add(nodarbiba);
            }
        }
        
        void B_nod_labotClick(object sender, EventArgs e)
        {
            if (dgv_nodarbibas.SelectedRows.Count > 0) {
                int indekss = dgv_nodarbibas.SelectedRows[0].Index;
                
                Dgv_nodarbibasCellDoubleClick(dgv_nodarbibas, new DataGridViewCellEventArgs(0, indekss));
            } else {
                db.msgbox_nav_labojamo();
            }
        }
        
        void B_nod_dzestClick(object sender, EventArgs e)
        {
            if (dgv_nodarbibas.SelectedRows.Count > 0) {
                int indekss = dgv_nodarbibas.SelectedRows[0].Index;
                
                if (db.msgbox_dzesanas_apstiprinajums() == DialogResult.Yes) {
                    dgv_nodarbibas.Rows.RemoveAt(indekss);
                }
            } else {
                db.msgbox_nav_dzesamo();
            }
        }
        
        void B_nod_grupas_pievienotClick(object sender, EventArgs e)
        {
            if (dgv_nodarbibas.SelectedRows.Count > 0) {
                int stk_idx;
                string stud_kurss;
            
                if (dgv_stud_kursi.SelectedRows.Count > 0) {
                    stk_idx = dgv_stud_kursi.SelectedRows[0].Index;
                    stud_kurss = dgv_stud_kursi["nosaukums", stk_idx].Value.ToString();
                } else {
                    stk_idx = dgv_nodarbibas.SelectedRows[0].Index;
                    stud_kurss = dgv_nodarbibas["id_kkods", stk_idx].FormattedValue.ToString();
                }
            
                int nod_idx = dgv_nodarbibas.SelectedRows[0].Index;
                
                string macsp = dgv_nodarbibas["id_macsp", nod_idx].FormattedValue.ToString();
                string nod_veids = dgv_nodarbibas["id_nveids", nod_idx].FormattedValue.ToString();
                string dat_no = dgv_nodarbibas["dat_no", nod_idx].Value.ToString();
                string dat_lidz = dgv_nodarbibas["dat_lidz", nod_idx].Value.ToString();
                string ned_diena = dgv_nodarbibas["ned_diena", nod_idx].FormattedValue.ToString();
                string laiks = dgv_nodarbibas["laiks", nod_idx].FormattedValue.ToString();
                string ned_diena2 = dgv_nodarbibas["ned_diena", nod_idx].Value.ToString();
                string laiks2 = dgv_nodarbibas["laiks", nod_idx].Value.ToString();
            
                nod_grupu_ievade d_grupas = new nod_grupu_ievade(macsp, stud_kurss, nod_veids, dat_no, dat_lidz, ned_diena, laiks, ned_diena2, laiks2);
            
                if (d_grupas.ShowDialog() == DialogResult.OK) {
                    DataRow nod_grupa = nod_grupasDT.NewRow();
                
                    nod_grupa["id_nod"] = dgv_nodarbibas["id_nod", nod_idx].Value;
                    nod_grupa["id_prkods"] = d_grupas.id_prkods;
                    nod_grupa["kurss"] = d_grupas.kurss;
                    nod_grupa["grupa"] = d_grupas.grupa;
                
                    nod_grupasDT.Rows.Add(nod_grupa);
                }
            } else {
                MessageBox.Show("Pirms studējošo grupas pievienošanas, nepieciešams izveidot jaunu nodarbību!", "Nav izvēlēta nodarbība", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        void B_nod_grupas_dzestClick(object sender, EventArgs e)
        {
            if (dgv_nod_grupas.SelectedRows.Count > 0) {
                int indekss = dgv_nod_grupas.SelectedRows[0].Index;
                
                if (db.msgbox_dzesanas_apstiprinajums() == DialogResult.Yes) {
                    dgv_nod_grupas.Rows.RemoveAt(indekss);
                }
            } else {
                db.msgbox_nav_dzesamo();
            }
        }
        
        void sagatavot_plan_nodarbibu_skatu()
        {
            dgv_nodarbibas.Columns["id_nod"].HeaderText = "ID";
            dgv_nodarbibas.Columns["id_kkods"].HeaderText = "Studiju kurss";
            dgv_nodarbibas.Columns["id_macsp"].HeaderText = "Mācībspēks";
            DataGridViewComboBoxColumn cb_macsp = new DataGridViewComboBoxColumn();
            cb_macsp.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_macsp.DataSource = macibspekiDT;
            cb_macsp.Name = "id_macsp";
            cb_macsp.DataPropertyName = cb_macsp.ValueMember = "id_macsp";
            cb_macsp.DisplayMember = "m_v_uzv";
            cb_macsp.HeaderText = "Mācībspēks";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["id_macsp"]);
            dgv_nodarbibas.Columns.Insert(2, cb_macsp);
            dgv_nodarbibas.Columns["id_nveids"].HeaderText = "Nodarbības veids";
            DataGridViewComboBoxColumn cb_nveids = new DataGridViewComboBoxColumn();
            cb_nveids.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_nveids.DataSource = nod_veidiDT;
            cb_nveids.Name = "id_nveids";
            cb_nveids.DataPropertyName = cb_nveids.ValueMember = "id_nveids";
            cb_nveids.DisplayMember = "veids";
            cb_nveids.HeaderText = "Nodarbības veids";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["id_nveids"]);
            dgv_nodarbibas.Columns.Insert(3, cb_nveids);
            dgv_nodarbibas.Columns["dat_no"].HeaderText = "Datums no";
            dgv_nodarbibas.Columns["dat_lidz"].HeaderText = "Datums līdz";
            dgv_nodarbibas.Columns["ned_diena"].HeaderText = "Nedēļas diena";
            DataGridViewComboBoxColumn cb_ned_diena = new DataGridViewComboBoxColumn();
            cb_ned_diena.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_ned_diena.DataSource = db.n_dienasDT;
            cb_ned_diena.Name = "ned_diena";
            cb_ned_diena.DataPropertyName = cb_ned_diena.ValueMember = "ned_diena";
            cb_ned_diena.DisplayMember = "nosaukums";
            cb_ned_diena.HeaderText = "Nedēļas diena";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["ned_diena"]);
            dgv_nodarbibas.Columns.Insert(6, cb_ned_diena);
            dgv_nodarbibas.Columns["laiks"].HeaderText = "Laiks";
            DataGridViewComboBoxColumn cb_laiks = new DataGridViewComboBoxColumn();
            cb_laiks.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_laiks.DataSource = db.laikiDT;
            cb_laiks.Name = "laiks";
            cb_laiks.DataPropertyName = cb_laiks.ValueMember = "laiks";
            cb_laiks.DisplayMember = "virkne";
            cb_laiks.HeaderText = "Laiks";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["laiks"]);
            dgv_nodarbibas.Columns.Insert(7, cb_laiks);
            
            if (dgv_nodarbibas.DataSource == nodarbibasDT) {
                DataGridViewComboBoxColumn cb_stud_kurss = new DataGridViewComboBoxColumn();
                cb_stud_kurss.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                cb_stud_kurss.DataSource = stud_kursiDT;
                cb_stud_kurss.Name = "id_kkods";
                cb_stud_kurss.DataPropertyName = cb_stud_kurss.ValueMember = "id_kkods";
                cb_stud_kurss.DisplayMember = "nosaukums";
                cb_stud_kurss.HeaderText = "Studiju kurss";
                dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["id_kkods"]);
                dgv_nodarbibas.Columns.Insert(0, cb_stud_kurss);
            } else {
                dgv_nodarbibas.Columns["id_kkods"].Visible = false;
            }
            
            dgv_nodarbibas.Columns["id_nod"].Visible = false;
        }
        
        void planoto_nodarbibu_filtri()
        {
            Dictionary<string, string> d_macibspeks = new Dictionary<string, string>();
            Dictionary<string, string> d_nod_veids = new Dictionary<string, string>();
            Dictionary<string, string> d_ned_diena = new Dictionary<string, string>();
            Dictionary<string, string> d_laiks = new Dictionary<string, string>();
            
            for (int i = 0; i < macibspekiDT.Rows.Count; i++) {
                if (nodarbibasDT.Select("id_macsp = '" + macibspekiDT.Rows[i]["id_macsp"] + "'").Length > 0) {
                    d_macibspeks.Add(macibspekiDT.Rows[i]["id_macsp"].ToString(), macibspekiDT.Rows[i]["m_v_uzv"].ToString());
                }
            }
            
            d_macibspeks.Add("Visi", "Visi");
            
            cb_plan_macibspeks.DataSource = new BindingSource(d_macibspeks, null);
            cb_plan_macibspeks.DisplayMember = "Value";
            cb_plan_macibspeks.ValueMember = "Key";
            cb_plan_macibspeks.SelectedValue = "Visi";
            
            for (int i = 0; i < nod_veidiDT.Rows.Count; i++) {
                if (nodarbibasDT.Select("id_nveids = '" + nod_veidiDT.Rows[i]["id_nveids"] + "'").Length > 0) {
                    d_nod_veids.Add(nod_veidiDT.Rows[i]["id_nveids"].ToString(), nod_veidiDT.Rows[i]["veids"].ToString());
                }
            }
            
            d_nod_veids.Add("Visi", "Visi");
            
            cb_plan_veids.DataSource = new BindingSource(d_nod_veids, null);
            cb_plan_veids.DisplayMember = "Value";
            cb_plan_veids.ValueMember = "Key";
            cb_plan_veids.SelectedValue = "Visi";
            
            for (int i = 0; i < db.n_dienasDT.Rows.Count; i++) {
                if (nodarbibasDT.Select("ned_diena = '" + db.n_dienasDT.Rows[i]["ned_diena"] + "'").Length > 0) {
                    d_ned_diena.Add(db.n_dienasDT.Rows[i]["ned_diena"].ToString(), db.n_dienasDT.Rows[i]["nosaukums"].ToString());
                }
            }
            
            d_ned_diena.Add("Visas", "Visas");
            
            cb_plan_ned_diena.DataSource = new BindingSource(d_ned_diena, null);
            cb_plan_ned_diena.DisplayMember = "Value";
            cb_plan_ned_diena.ValueMember = "Key";
            cb_plan_ned_diena.SelectedValue = "Visas";
            
            for (int i = 0; i < db.laikiDT.Rows.Count; i++) {
                if (nodarbibasDT.Select("laiks = '" + db.laikiDT.Rows[i]["laiks"] + "'").Length > 0) {
                    d_laiks.Add(db.laikiDT.Rows[i]["laiks"].ToString(), db.laikiDT.Rows[i]["virkne"].ToString());
                }
            }
            
            d_laiks.Add("Visi", "Visi");
            
            cb_plan_laiks.DataSource = new BindingSource(d_laiks, null);
            cb_plan_laiks.DisplayMember = "Value";
            cb_plan_laiks.ValueMember = "Key";
            cb_plan_laiks.SelectedValue = "Visi";
        }
        
        void filtret_planotas_nodarbibas()
        {
            string filtrs = "1 = 1";
            
            if (!(cb_plan_macibspeks.Text == "Visi" || string.IsNullOrEmpty(cb_plan_macibspeks.Text))) {
                filtrs += " AND id_macsp = '" + cb_plan_macibspeks.SelectedValue + "'";
            }
            
            if (!(cb_plan_veids.Text == "Visi" || string.IsNullOrEmpty(cb_plan_veids.Text))) {
                filtrs += " AND id_nveids = '" + cb_plan_veids.SelectedValue + "'";
            }
            
            if (!(cb_plan_ned_diena.Text == "Visas" || string.IsNullOrEmpty(cb_plan_ned_diena.Text))) {
                filtrs += " AND ned_diena = '" + cb_plan_ned_diena.SelectedValue + "'";
            }
            
            if (!(cb_plan_laiks.Text == "Visi" || string.IsNullOrEmpty(cb_plan_laiks.Text))) {
                filtrs += " AND laiks = '" + cb_plan_laiks.SelectedValue + "'";
            }
            
            dgv_nodarbibas.DataSource = null;
            
            if (filtrs == "1 = 1") {
                dgv_nodarbibas.DataSource = stud_kursiDT;
                dgv_nodarbibas.DataMember = "stud_kursi-nodarbibas";
            } else {
                dgv_stud_kursi.ClearSelection();
                dgv_nodarbibas.DataSource = nodarbibasDT;
                nodarbibasDT.DefaultView.RowFilter = filtrs;
            }
            
            sagatavot_plan_nodarbibu_skatu();
        }
        
        void Dgv_stud_kursiClick(object sender, EventArgs e)
        {
            b_atiestatit_planosana.PerformClick();
        }
        
        void Cb_plan_macibspeksSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_planotas_nodarbibas();
        }
        
        void Cb_plan_veidsSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_planotas_nodarbibas();
        }
        
        void Cb_plan_ned_dienaSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_planotas_nodarbibas();
        }
        
        void Cb_plan_laiksSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_planotas_nodarbibas();
        }
        
        void B_atiestatit_planosanaClick(object sender, EventArgs e)
        {
            if (dgv_stud_kursi.SelectedRows.Count == 0 && dgv_stud_kursi.Rows[0] != null) {
                dgv_stud_kursi.Rows[0].Selected = true;
            }
            
            cb_plan_laiks.SelectedValue = "Visi";
            cb_plan_ned_diena.SelectedValue = "Visas";
            cb_plan_veids.SelectedValue = "Visi";
            cb_plan_macibspeks.SelectedValue = "Visi";
        }
        
        void Dgv_nodarbibasSelectionChanged(object sender, EventArgs e)
        {
            if (dgv_nodarbibas.SelectedRows.Count > 0 && dgv_nodarbibas.Columns["id_nod"] != null) {
                int indekss = dgv_nodarbibas.SelectedRows[0].Index;
            
                nod_grupasDT.DefaultView.RowFilter = "id_nod = '" + dgv_nodarbibas["id_nod", indekss].Value + "'";
                nod_grupasDT.Columns["id_nod"].DefaultValue = dgv_nodarbibas["id_nod", indekss].Value;
            } else {
                nod_grupasDT.DefaultView.RowFilter = "0 = 1";
            }
        }
        
        void Dgv_stud_kursiCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                stud_kursu_ievade d_stud_kurss = new stud_kursu_ievade(dgv_stud_kursi["id_kkods", e.RowIndex].Value.ToString(), dgv_stud_kursi["nosaukums", e.RowIndex].Value.ToString(), dgv_stud_kursi["kr_punkti", e.RowIndex].Value.ToString());
            
                if (d_stud_kurss.ShowDialog() == DialogResult.OK) {
                    dgv_stud_kursi["id_kkods", e.RowIndex].Value = d_stud_kurss.id_kkods;
                    dgv_stud_kursi["nosaukums", e.RowIndex].Value = d_stud_kurss.nosaukums;
                    dgv_stud_kursi["kr_punkti", e.RowIndex].Value = d_stud_kurss.kp;
                }
            }
        }
        
        void Dgv_nodarbibasCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                nodarbibu_ievade d_nodarbiba = new nodarbibu_ievade(dgv_nodarbibas["id_nod", e.RowIndex].Value.ToString(), dgv_nodarbibas["id_macsp", e.RowIndex].Value.ToString(), dgv_nodarbibas["id_kkods", e.RowIndex].Value.ToString(), dgv_nodarbibas["id_nveids", e.RowIndex].Value.ToString(), dgv_nodarbibas["dat_no", e.RowIndex].Value.ToString(), dgv_nodarbibas["dat_lidz", e.RowIndex].Value.ToString(), dgv_nodarbibas["ned_diena", e.RowIndex].Value.ToString(), dgv_nodarbibas["laiks", e.RowIndex].Value.ToString(), false);
            
                if (d_nodarbiba.ShowDialog() == DialogResult.OK) {
                    dgv_nodarbibas["id_macsp", e.RowIndex].Value = d_nodarbiba.id_macsp;
                    dgv_nodarbibas["id_kkods", e.RowIndex].Value = d_nodarbiba.id_kkods;
                    dgv_nodarbibas["id_nveids", e.RowIndex].Value = d_nodarbiba.nveids;
                    dgv_nodarbibas["dat_no", e.RowIndex].Value = d_nodarbiba.dat_no;
                    dgv_nodarbibas["dat_lidz", e.RowIndex].Value = d_nodarbiba.dat_lidz;
                    dgv_nodarbibas["ned_diena", e.RowIndex].Value = d_nodarbiba.ned_diena;
                    dgv_nodarbibas["laiks", e.RowIndex].Value = d_nodarbiba.laiks;
                }
            }
        }
        
        void Dgv_nod_grupasCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                if (dgv_nod_grupas["id_prkods", e.RowIndex].Value.ToString() == "") {
                    int stk_idx;
                    string stud_kurss;
                
                    if (dgv_stud_kursi.SelectedRows.Count > 0) {
                        stk_idx = dgv_stud_kursi.SelectedRows[0].Index;
                        stud_kurss = dgv_stud_kursi["nosaukums", stk_idx].Value.ToString();
                    } else {
                        stk_idx = dgv_nodarbibas.SelectedRows[0].Index;
                        stud_kurss = dgv_nodarbibas["id_kkods", stk_idx].FormattedValue.ToString();
                    }
                    
                    int nod_idx = dgv_nodarbibas.SelectedRows[0].Index;
                    
                    string macsp = dgv_nodarbibas["id_macsp", nod_idx].FormattedValue.ToString();
                    string nod_veids = dgv_nodarbibas["id_nveids", nod_idx].FormattedValue.ToString();
                    string dat_no = dgv_nodarbibas["dat_no", nod_idx].Value.ToString();
                    string dat_lidz = dgv_nodarbibas["dat_lidz", nod_idx].Value.ToString();
                    string ned_diena = dgv_nodarbibas["ned_diena", nod_idx].FormattedValue.ToString();
                    string laiks = dgv_nodarbibas["laiks", nod_idx].FormattedValue.ToString();
                    string ned_diena2 = dgv_nodarbibas["ned_diena", nod_idx].Value.ToString();
                    string laiks2 = dgv_nodarbibas["laiks", nod_idx].Value.ToString();
                
                    nod_grupu_ievade d_grupas = new nod_grupu_ievade(macsp, stud_kurss, nod_veids, dat_no, dat_lidz, ned_diena, laiks, ned_diena2, laiks2);
            
                    if (d_grupas.ShowDialog() == DialogResult.OK) {
                        dgv_nod_grupas["id_prkods", e.RowIndex].Value = d_grupas.id_prkods;
                        dgv_nod_grupas["kurss", e.RowIndex].Value = d_grupas.kurss;
                        dgv_nod_grupas["grupa", e.RowIndex].Value = d_grupas.grupa;
                    }
                }
            }
        }
        
        void B_atcelt_nodarbibasClick(object sender, EventArgs e)
        {
            if (db.msgbox_atcelt_izmainas() == DialogResult.Yes) {
                try {
                    stud_kursiDT.RejectChanges();
                    nodarbibasDT.RejectChanges();
                    nod_grupasDT.RejectChanges();
                } catch (Exception) {
                    db.msgbox_nevar_atcelt();
                }
            }
        }
        
        void B_saglabat_nodarbibasClick(object sender, EventArgs e)
        {
            NpgsqlCommand iev_kom = new NpgsqlCommand("INSERT INTO stud_kursi VALUES(@id, @nosaukums, @kr_punkti);", db.sav);
            iev_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 8, "id_kkods");
            iev_kom.Parameters.Add("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "nosaukums");
            iev_kom.Parameters.Add("@kr_punkti", NpgsqlTypes.NpgsqlDbType.Numeric, 5, "kr_punkti");
            NpgsqlCommand atj_kom = new NpgsqlCommand("UPDATE stud_kursi SET nosaukums = @nosaukums, kr_punkti = @kr_punkti WHERE id_kkods = @id;", db.sav);
            atj_kom.Parameters.Add("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "nosaukums");
            atj_kom.Parameters.Add("@kr_punkti", NpgsqlTypes.NpgsqlDbType.Numeric, 5, "kr_punkti");
            atj_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 8, "id_kkods");
            NpgsqlCommand dz_kom = new NpgsqlCommand("DELETE FROM stud_kursi WHERE id_kkods = @id;", db.sav);
            dz_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 8, "id_kkods");
            
            NpgsqlCommand iev_kom2 = new NpgsqlCommand("INSERT INTO nodarbibas VALUES(@id, @id_kkods, @id_macsp, @id_nveids, @dat_no, @dat_lidz, @ned_diena, @laiks);", db.sav);
            iev_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            iev_kom2.Parameters.Add("@id_kkods", NpgsqlTypes.NpgsqlDbType.Char, 8, "id_kkods");
            iev_kom2.Parameters.Add("@id_macsp", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "id_macsp");
            iev_kom2.Parameters.Add("@id_nveids", NpgsqlTypes.NpgsqlDbType.Integer, 3, "id_nveids");
            iev_kom2.Parameters.Add("@dat_no", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_no");
            iev_kom2.Parameters.Add("@dat_lidz", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_lidz");
            iev_kom2.Parameters.Add("@ned_diena", NpgsqlTypes.NpgsqlDbType.Integer, 1, "ned_diena");
            iev_kom2.Parameters.Add("@laiks", NpgsqlTypes.NpgsqlDbType.Integer, 2, "laiks");
            NpgsqlCommand atj_kom2 = new NpgsqlCommand("UPDATE nodarbibas SET id_kkods = @id_kkods, id_macsp = @id_macsp, id_nveids = @id_nveids, dat_no = @dat_no, dat_lidz = @dat_lidz, ned_diena = @ned_diena, laiks = @laiks WHERE id_nod = @id;", db.sav);
            atj_kom2.Parameters.Add("@id_kkods", NpgsqlTypes.NpgsqlDbType.Char, 8, "id_kkods");
            atj_kom2.Parameters.Add("@id_macsp", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "id_macsp");
            atj_kom2.Parameters.Add("@id_nveids", NpgsqlTypes.NpgsqlDbType.Integer, 3, "id_nveids");
            atj_kom2.Parameters.Add("@dat_no", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_no");
            atj_kom2.Parameters.Add("@dat_lidz", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_lidz");
            atj_kom2.Parameters.Add("@ned_diena", NpgsqlTypes.NpgsqlDbType.Integer, 1, "ned_diena");
            atj_kom2.Parameters.Add("@laiks", NpgsqlTypes.NpgsqlDbType.Integer, 2, "laiks");
            atj_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            NpgsqlCommand dz_kom2 = new NpgsqlCommand("DELETE FROM nodarbibas WHERE id_nod = @id;", db.sav);
            dz_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            
            NpgsqlCommand iev_kom3 = new NpgsqlCommand("INSERT INTO nod_grupas VALUES(@id, @id_nod, @id_prkods, @kurss, @grupa);", db.sav);
            iev_kom3.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_grupa");
            iev_kom3.Parameters.Add("@id_nod", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            iev_kom3.Parameters.Add("@id_prkods", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            iev_kom3.Parameters.Add("@kurss", NpgsqlTypes.NpgsqlDbType.Integer, 1, "kurss");
            iev_kom3.Parameters.Add("@grupa", NpgsqlTypes.NpgsqlDbType.Numeric, 3, "grupa");
            NpgsqlCommand atj_kom3 = new NpgsqlCommand("UPDATE nod_grupas SET id_nod = @id_nod, id_prkods = @id_prkods, kurss = @kurss, grupa = @grupa WHERE id_grupa = @id;", db.sav);
            atj_kom3.Parameters.Add("@id_nod", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            atj_kom3.Parameters.Add("@id_prkods", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            atj_kom3.Parameters.Add("@kurss", NpgsqlTypes.NpgsqlDbType.Integer, 1, "kurss");
            atj_kom3.Parameters.Add("@grupa", NpgsqlTypes.NpgsqlDbType.Numeric, 3, "grupa");
            atj_kom3.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_grupa");
            NpgsqlCommand dz_kom3 = new NpgsqlCommand("DELETE FROM nod_grupas WHERE id_grupa = @id;", db.sav);
            dz_kom3.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_grupa");
            
            stud_kursiA.InsertCommand = iev_kom;
            stud_kursiA.UpdateCommand = atj_kom;
            stud_kursiA.DeleteCommand = dz_kom;
            nodarbibasA.InsertCommand = iev_kom2;
            nodarbibasA.UpdateCommand = atj_kom2;
            nodarbibasA.DeleteCommand = dz_kom2;
            nod_grupasA.InsertCommand = iev_kom3;
            nod_grupasA.UpdateCommand = atj_kom3;
            nod_grupasA.DeleteCommand = dz_kom3;
            
            try {
                stud_kursiA.Update(stud_kursiDT);
                nodarbibasA.Update(nodarbibasDT);
                nod_grupasA.Update(nod_grupasDT);
                sagl_kluda = false;
            } catch (Exception) {
                sagl_kluda = true;
                db.msgbox_saglabasanas_kluda();
            }
            
            if (!sagl_kluda) {
                stud_kursiDT.AcceptChanges();
                nodarbibasDT.AcceptChanges();
                nod_grupasDT.AcceptChanges();
                db.msgbox_izmainas_saglabatas();
            }
        }
        
        // Studējošo cilne un ar to saistītās funkcijas
        
        void B_stud_prog_pievienotClick(object sender, EventArgs e)
        {
            stud_prog_ievade d_stud_programma = new stud_prog_ievade("", "", "");
            
            if (d_stud_programma.ShowDialog() == DialogResult.OK) {
                DataRow stud_prog = stud_progDT.NewRow();
                
                stud_prog["id_prkods"] = d_stud_programma.id_prkods;
                stud_prog["nosaukums"] = d_stud_programma.nosaukums;
                stud_prog["id_prveids"] = d_stud_programma.id_prveids;
                stud_prog["nosauk_kods"] = d_stud_programma.nosaukums + " (" + d_stud_programma.id_prkods + ")";
                
                stud_progDT.Rows.Add(stud_prog);
            }
        }
        
        void B_stud_prog_labotClick(object sender, EventArgs e)
        {
            if (dgv_stud_prog.SelectedRows.Count > 0) {
                int indekss = dgv_stud_prog.SelectedRows[0].Index;
                
                Dgv_stud_progCellDoubleClick(dgv_stud_prog, new DataGridViewCellEventArgs(0, indekss));
            } else {
                db.msgbox_nav_labojamo();
            }
        }
        
        void B_stud_prog_dzestClick(object sender, EventArgs e)
        {
            if (dgv_stud_prog.SelectedRows.Count > 0) {
                int indekss = dgv_stud_prog.SelectedRows[0].Index;
                
                if (db.msgbox_dzesanas_apstiprinajums() == DialogResult.Yes) {
                    dgv_stud_prog.Rows.RemoveAt(indekss);
                }
            } else {
                db.msgbox_nav_dzesamo();
            }
        }
        
        void B_studenti_pievienotClick(object sender, EventArgs e)
        {
            string stud_prog = "";
            
            if (dgv_stud_prog.SelectedRows.Count > 0) {
                stud_prog = dgv_stud_prog["id_prkods", dgv_stud_prog.SelectedRows[0].Index].Value.ToString();
            }
            
            studejoso_ievade d_studejosais = new studejoso_ievade("", "", "", stud_prog, "", "");
            
            if (d_studejosais.ShowDialog() == DialogResult.OK) {
                DataRow students = studentiDT.NewRow();
                
                students["id_matr"] = d_studejosais.id_matr;
                students["vards"] = d_studejosais.vards;
                students["uzvards"] = d_studejosais.uzvards;
                students["id_prkods"] = d_studejosais.id_prkods;
                students["kurss"] = d_studejosais.kurss;
                students["grupa"] = d_studejosais.grupa;
                
                studentiDT.Rows.Add(students);
            }
        }
        
        void B_studenti_labotClick(object sender, EventArgs e)
        {
            if (dgv_studenti.SelectedRows.Count > 0) {
                int indekss = dgv_studenti.SelectedRows[0].Index;
                
                Dgv_studentiCellDoubleClick(dgv_studenti, new DataGridViewCellEventArgs(0, indekss));
            } else {
                db.msgbox_nav_labojamo();
            }
        }
        
        void B_studenti_apmeklClick(object sender, EventArgs e)
        {
            if (dgv_studenti.SelectedRows.Count > 0) {
                int indekss = dgv_studenti.SelectedRows[0].Index;
                
                studenta_apmeklejumi d_apmeklejumi = new studenta_apmeklejumi(dgv_studenti["id_matr", indekss].Value.ToString(), dgv_studenti["vards", indekss].Value.ToString(), dgv_studenti["uzvards", indekss].Value.ToString());
                d_apmeklejumi.Show();
            }
        }
        
        void B_studenti_paroleClick(object sender, EventArgs e)
        {
            if (dgv_studenti.SelectedRows.Count > 0) {
                int indekss = dgv_studenti.SelectedRows[0].Index;
                
                string matrikula = dgv_studenti["id_matr", indekss].Value.ToString();
                string vards = dgv_studenti["vards", indekss].Value.ToString();
                string uzvards = dgv_studenti["uzvards", indekss].Value.ToString();
                
                DataRow[] students = studentiDT.Select("id_matr = '" + matrikula + "'");
                
                if (MessageBox.Show("Vai studējošajam atiestatīt autorizēšanās paroli?\n\nMatrikulas numurs: " + matrikula + "\nVārds: " + vards + "\nUzvārds: " + uzvards, "Vai atiestatīt paroli?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    students[0]["parole"] = db.SHA1Parole(matrikula, matrikula);
                    students[0]["main_parole"] = false;
                }
            } else {
                db.msgbox_nav_labojamo();
            }
        }
        
        void B_studenti_dzestClick(object sender, EventArgs e)
        {
            if (dgv_studenti.SelectedRows.Count > 0) {
                int indekss = dgv_studenti.SelectedRows[0].Index;
                
                if (db.msgbox_dzesanas_apstiprinajums() == DialogResult.Yes) {
                    dgv_studenti.Rows.RemoveAt(indekss);
                }
            } else {
                db.msgbox_nav_dzesamo();
            }
        }
        
        void sagatavot_studejoso_skatu()
        {
            dgv_studenti.Columns["id_matr"].HeaderText = "Matrikulas numurs";
            dgv_studenti.Columns["vards"].HeaderText = "Vārds";
            dgv_studenti.Columns["uzvards"].HeaderText = "Uzvārds";
            dgv_studenti.Columns["id_prkods"].HeaderText = "Studiju programma";
            dgv_studenti.Columns["kurss"].HeaderText = "Kurss";
            DataGridViewComboBoxColumn cb_kurss = new DataGridViewComboBoxColumn();
            cb_kurss.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_kurss.DataSource = db.kursiDT;
            cb_kurss.Name = "kurss";
            cb_kurss.DataPropertyName = cb_kurss.ValueMember = cb_kurss.DisplayMember = "kurss";
            cb_kurss.HeaderText = "Kurss";
            dgv_studenti.Columns.Remove(dgv_studenti.Columns["kurss"]);
            dgv_studenti.Columns.Insert(4, cb_kurss);
            dgv_studenti.Columns["grupa"].HeaderText = "Grupa";
            dgv_studenti.Columns["parole"].HeaderText = "Šifrētā parole";
            dgv_studenti.Columns["main_parole"].HeaderText = "Nomainīta parole";
            dgv_studenti.Columns["main_parole"].ReadOnly = true;
            
            if (dgv_studenti.DataSource == studentiDT) {
                DataGridViewComboBoxColumn cb_stud_prog = new DataGridViewComboBoxColumn();
                cb_stud_prog.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                cb_stud_prog.DataSource = stud_progDT;
                cb_stud_prog.Name = "id_prkods";
                cb_stud_prog.DataPropertyName = cb_stud_prog.ValueMember = "id_prkods";
                cb_stud_prog.DisplayMember = "nosaukums";
                cb_stud_prog.HeaderText = "Studiju programma";
                dgv_studenti.Columns.Remove(dgv_studenti.Columns["id_prkods"]);
                dgv_studenti.Columns.Insert(0, cb_stud_prog);
            } else {
                dgv_studenti.Columns["id_prkods"].Visible = false;
            }
            
            dgv_studenti.Columns["parole"].Visible = false;
        }
        
        void studejoso_filtri()
        {
            for (int i = 0; i < db.kursiDT.Rows.Count; i++) {
                if (studentiDT.Select("kurss = '" + db.kursiDT.Rows[i]["kurss"] + "'").Length > 0) {
                    cb_st_kurss.Items.Add(db.kursiDT.Rows[i]["kurss"].ToString());
                }
            }
            
            cb_st_kurss.Items.Add("Visi");
            cb_st_kurss.SelectedItem = "Visi";
            
            for (int i = 0; i < db.grupasDT.Rows.Count; i++) {
                if (studentiDT.Select("grupa = '" + db.grupasDT.Rows[i]["grupa"] + "'").Length > 0) {
                    cb_st_grupa.Items.Add(db.grupasDT.Rows[i]["grupa"].ToString());
                }
            }
            
            cb_st_grupa.Items.Add("Visas");
            cb_st_grupa.SelectedItem = "Visas";
        }
        
        void filtret_studejosos()
        {
            string filtrs = "1 = 1";
            
            if (!(cb_st_kurss.Text == "Visi" || string.IsNullOrEmpty(cb_st_kurss.Text))) {
                filtrs += " AND kurss = '" + cb_st_kurss.Text + "'";
            }
            
            if (!(cb_st_grupa.Text == "Visas" || string.IsNullOrEmpty(cb_st_grupa.Text))) {
                filtrs += " AND grupa = '" + cb_st_grupa.Text + "'";
            }
            
            if (tb_st_teksts.Text != "" && db.latviesu_burti_cipari(tb_st_teksts.Text)) {
                filtrs += string.Format("AND (id_matr LIKE '%{0}%' OR vards LIKE '%{0}%' OR uzvards LIKE '%{0}%')", tb_st_teksts.Text);
            }
            
            dgv_studenti.DataSource = null;
            
            if (filtrs == "1 = 1") {
                dgv_studenti.DataSource = stud_progDT;
                dgv_studenti.DataMember = "stud_prog-studenti";
            } else {
                dgv_stud_prog.ClearSelection();
                dgv_studenti.DataSource = studentiDT;
                studentiDT.DefaultView.RowFilter = filtrs;
            }
            
            sagatavot_studejoso_skatu();
        }
        
        void Dgv_stud_progClick(object sender, EventArgs e)
        {
            b_atiestatit_studejosos.PerformClick();
        }
        
        void Cb_st_kurssSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_studejosos();
        }
        
        void Cb_st_grupaSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_studejosos();
        }
        
        void Tb_st_tekstsTextChanged(object sender, EventArgs e)
        {
            filtret_studejosos();
        }
        
        void B_atiestatit_studejososClick(object sender, EventArgs e)
        {            
            if (dgv_stud_prog.SelectedRows.Count == 0 && dgv_stud_prog.Rows[0] != null) {
                dgv_stud_prog.Rows[0].Selected = true;
            }
            
            cb_st_kurss.Text = "Visi";
            cb_st_grupa.Text = "Visas";
            tb_st_teksts.Text = "";
        }
        
        void Dgv_stud_progCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                stud_prog_ievade d_stud_programma = new stud_prog_ievade(dgv_stud_prog["id_prkods", e.RowIndex].Value.ToString(), dgv_stud_prog["nosaukums", e.RowIndex].Value.ToString(), dgv_stud_prog["id_prveids", e.RowIndex].Value.ToString());
            
                if (d_stud_programma.ShowDialog() == DialogResult.OK) {
                    dgv_stud_prog["id_prkods", e.RowIndex].Value = d_stud_programma.id_prkods;
                    dgv_stud_prog["nosaukums", e.RowIndex].Value = d_stud_programma.nosaukums;
                    dgv_stud_prog["id_prveids", e.RowIndex].Value = d_stud_programma.id_prveids;
                }
            }
        }
        
        void Dgv_studentiCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                studejoso_ievade d_studejosais = new studejoso_ievade(dgv_studenti["id_matr", e.RowIndex].Value.ToString(), dgv_studenti["vards", e.RowIndex].Value.ToString(), dgv_studenti["uzvards", e.RowIndex].Value.ToString(), dgv_studenti["id_prkods", e.RowIndex].Value.ToString(), dgv_studenti["kurss", e.RowIndex].Value.ToString(), dgv_studenti["grupa", e.RowIndex].Value.ToString());
            
                if (d_studejosais.ShowDialog() == DialogResult.OK) {
                    dgv_studenti["id_matr", e.RowIndex].Value = d_studejosais.id_matr;
                    dgv_studenti["vards", e.RowIndex].Value = d_studejosais.vards;
                    dgv_studenti["uzvards", e.RowIndex].Value = d_studejosais.uzvards;
                    dgv_studenti["id_prkods", e.RowIndex].Value = d_studejosais.id_prkods;
                    dgv_studenti["kurss", e.RowIndex].Value = d_studejosais.kurss;
                    dgv_studenti["grupa", e.RowIndex].Value = d_studejosais.grupa;
                }
            }
        }
        
        void B_atcelt_studejosieClick(object sender, EventArgs e)
        {
            if (db.msgbox_atcelt_izmainas() == DialogResult.Yes) {
                try {
                    stud_progDT.RejectChanges();
                    studentiDT.RejectChanges();
                } catch (Exception) {
                    db.msgbox_nevar_atcelt();
                }
            }
        }
        
        void B_importetClick(object sender, EventArgs e)
        {
            OpenFileDialog d_imports = new OpenFileDialog();
            d_imports.Title = "Izvēlēties studējošo importa datni...";
            d_imports.Filter = "Teksta dokuments (*.csv, *.txt)|*.csv;*.txt";
            
            if (d_imports.ShowDialog() == DialogResult.OK) {
                int skaits = 0;
                int veiksmigie = 0;
                
                StreamReader lasitajs = new StreamReader(d_imports.FileName);
                
                while (!lasitajs.EndOfStream) {
                    skaits++;
                    
                    string[] lauki = lasitajs.ReadLine().Split(',', ';', '|');
                    
                    if (lauki[0] == "" || !Regex.IsMatch(lauki[0], @"^[A-Za-z]{2}\d{5}$") || vadiba.ds.Tables["studenti"].Select("id_matr = '" + lauki[0] + "'").Length != 0){
                        continue;
                    }
                    
                    if (lauki[1] == "" || !db.latviesu_burti(lauki[1])) {
                        continue;
                    }
                    
                    if (lauki[2] == "" || !db.latviesu_burti(lauki[2])) {
                        continue;
                    }
                    
                    if (lauki[3] == "" || !Regex.IsMatch(lauki[3], @"^G\d{4}$") || vadiba.ds.Tables["stud_prog"].Select("id_prkods = '" + lauki[3] + "'").Length == 0) {
                        continue;
                    }
                    
                    if (lauki[4] == "" || !Regex.IsMatch(lauki[4], @"^[1-4]$")) {
                        continue;
                    }
                    
                    if (lauki[5] == "" || !Regex.IsMatch(lauki[5], @"^[1-2](\.[0-2])?$")) {
                        continue;
                    }
                    
                    DataRow students = studentiDT.NewRow();
                    
                    students["id_matr"] = lauki[0];
                    students["vards"] = lauki[1];
                    students["uzvards"] = lauki[2];
                    students["id_prkods"] = lauki[3];
                    students["kurss"] = lauki[4];
                    students["grupa"] = lauki[5];
                    
                    studentiDT.Rows.Add(students);
                    
                    veiksmigie++;
                }
                
                lasitajs.Close();
                
                MessageBox.Show("Importējamā datne: " + d_imports.FileName + "\n\nVeiksmīgi importētie ieraksti: " + veiksmigie + "\nNeveiksmīgi importētie ieraksti: " + (skaits - veiksmigie), "Imports pabeigts", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        void B_saglabat_studejosieClick(object sender, EventArgs e)
        {
            NpgsqlCommand iev_kom = new NpgsqlCommand("INSERT INTO stud_prog VALUES(@id, @nosaukums, @id_prveids);", db.sav);
            iev_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            iev_kom.Parameters.Add("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "nosaukums");
            iev_kom.Parameters.Add("@id_prveids", NpgsqlTypes.NpgsqlDbType.Integer, 3, "id_prveids");
            NpgsqlCommand atj_kom = new NpgsqlCommand("UPDATE stud_prog SET nosaukums = @nosaukums, id_prveids = @id_prveids WHERE id_prkods = @id;", db.sav);
            atj_kom.Parameters.Add("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "nosaukums");
            atj_kom.Parameters.Add("@id_prveids", NpgsqlTypes.NpgsqlDbType.Integer, 3, "id_prveids");
            atj_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            NpgsqlCommand dz_kom = new NpgsqlCommand("DELETE FROM stud_prog WHERE id_prkods = @id;", db.sav);
            dz_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            
            NpgsqlCommand iev_kom2 = new NpgsqlCommand("INSERT INTO studenti VALUES(@id, @vards, @uzvards, @id_prkods, @kurss, @grupa, @parole);", db.sav);
            iev_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 7, "id_matr");
            iev_kom2.Parameters.Add("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "vards");
            iev_kom2.Parameters.Add("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "uzvards");
            iev_kom2.Parameters.Add("@id_prkods", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            iev_kom2.Parameters.Add("@kurss", NpgsqlTypes.NpgsqlDbType.Integer, 1, "kurss");
            iev_kom2.Parameters.Add("@grupa", NpgsqlTypes.NpgsqlDbType.Numeric, 3, "grupa");
            iev_kom2.Parameters.Add("@parole", NpgsqlTypes.NpgsqlDbType.Char, 40, "parole");
            NpgsqlCommand atj_kom2 = new NpgsqlCommand("UPDATE studenti SET vards = @vards, uzvards = @uzvards, id_prkods = @id_prkods, kurss = @kurss, grupa = @grupa, parole = @parole WHERE id_matr = @id;", db.sav);
            atj_kom2.Parameters.Add("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "vards");
            atj_kom2.Parameters.Add("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "uzvards");
            atj_kom2.Parameters.Add("@id_prkods", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            atj_kom2.Parameters.Add("@kurss", NpgsqlTypes.NpgsqlDbType.Integer, 1, "kurss");
            atj_kom2.Parameters.Add("@grupa", NpgsqlTypes.NpgsqlDbType.Numeric, 3, "grupa");
            atj_kom2.Parameters.Add("@parole", NpgsqlTypes.NpgsqlDbType.Char, 40, "parole");
            atj_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 7, "id_matr");
            NpgsqlCommand dz_kom2 = new NpgsqlCommand("DELETE FROM studenti WHERE id_matr = @id;", db.sav);
            dz_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Char, 7, "id_matr");
            
            stud_progA.InsertCommand = iev_kom;
            stud_progA.UpdateCommand = atj_kom;
            stud_progA.DeleteCommand = dz_kom;
            studentiA.InsertCommand = iev_kom2;
            studentiA.UpdateCommand = atj_kom2;
            studentiA.DeleteCommand = dz_kom2;
            
            try {
                stud_progA.Update(stud_progDT);
                studentiA.Update(studentiDT);
                sagl_kluda = false;
            } catch (Exception) {
                sagl_kluda = true;
                db.msgbox_saglabasanas_kluda();
            }
            
            if (!sagl_kluda) {
                stud_progDT.AcceptChanges();
                studentiDT.AcceptChanges();
                db.msgbox_izmainas_saglabatas();
            }
        }
        
        // Mācībspēku cilne un ar to saistītās funkcijas
        
        void B_macibspeki_pievienotClick(object sender, EventArgs e)
        {
            macibspeku_ievade d_macibspeks = new macibspeku_ievade("", "", "", "", "");
            
            if (d_macibspeks.ShowDialog() == DialogResult.OK) {
                DataRow macibspeks = macibspekiDT.NewRow();
                
                macibspeks["id_macsp"] = d_macibspeks.id_macsp;
                macibspeks["vards"] = d_macibspeks.vards;
                macibspeks["uzvards"] = d_macibspeks.uzvards;
                macibspeks["zin_grads"] = d_macibspeks.zin_grads;
                macibspeks["amats"] = d_macibspeks.amats;
                macibspeks["m_v_uzv"] = d_macibspeks.vards + " " + d_macibspeks.uzvards;
                
                macibspekiDT.Rows.Add(macibspeks);
            }
        }
        
        void B_macibspeki_labotClick(object sender, EventArgs e)
        {
            if (dgv_macibspeki.SelectedRows.Count > 0) {
                int indekss = dgv_macibspeki.SelectedRows[0].Index;
                
                Dgv_macibspekiCellDoubleClick(dgv_macibspeki, new DataGridViewCellEventArgs(0, indekss));
            } else {
                db.msgbox_nav_labojamo();
            }
        }
        
        void B_kursu_apmClick(object sender, EventArgs e)
        {
            if (dgv_macibspeki.SelectedRows.Count > 0) {
                int indekss = dgv_macibspeki.SelectedRows[0].Index;
                
                kursu_apmeklejumi d_apmeklejumi = new kursu_apmeklejumi(dgv_macibspeki["id_macsp", indekss].Value.ToString(), dgv_macibspeki["vards", indekss].Value.ToString(), dgv_macibspeki["uzvards", indekss].Value.ToString());
                d_apmeklejumi.Show();
            }
        }
        
        void B_macibspeki_paroleClick(object sender, EventArgs e)
        {
            if (dgv_macibspeki.SelectedRows.Count > 0) {
                int indekss = dgv_macibspeki.SelectedRows[0].Index;
                
                string lietotajs = dgv_macibspeki["id_macsp", indekss].Value.ToString();
                string vards = dgv_macibspeki["vards", indekss].Value.ToString();
                string uzvards = dgv_macibspeki["uzvards", indekss].Value.ToString();
                
                DataRow[] macibspeks = macibspekiDT.Select("id_macsp = '" + lietotajs + "'");
                
                if (MessageBox.Show("Vai mācībspēkam atiestatīt autorizēšanās paroli?\n\nLietotājvārds: " + lietotajs + "\nVārds: " + vards + "\nUzvārds: " + uzvards, "Vai atiestatīt paroli?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    macibspeks[0]["parole"] = db.SHA1Parole(lietotajs, lietotajs);
                    macibspeks[0]["main_parole"] = false;
                }
            } else {
                db.msgbox_nav_labojamo();
            }
        }
        
        void B_macibspeki_dzestClick(object sender, EventArgs e)
        {
            if (dgv_macibspeki.SelectedRows.Count > 0) {
                int indekss = dgv_macibspeki.SelectedRows[0].Index;
                
                if (db.msgbox_dzesanas_apstiprinajums() == DialogResult.Yes) {
                    dgv_macibspeki.Rows.RemoveAt(indekss);
                }
            } else {
                db.msgbox_nav_dzesamo();
            }
        }
        
        void filtret_macibspekus()
        {
            string filtrs = "1 = 1";
            
            if (tb_macsp_teksts.Text != "" && db.latviesu_burti_cipari(tb_macsp_teksts.Text)) {
                filtrs += string.Format("AND (id_macsp LIKE '%{0}%' OR vards LIKE '%{0}%' OR uzvards LIKE '%{0}%' OR zin_grads LIKE '%{0}%' OR amats LIKE '%{0}%')", tb_macsp_teksts.Text);
            }
            
            macibspekiDT.DefaultView.RowFilter = filtrs;
        }
        
        void Tb_macsp_tekstsTextChanged(object sender, EventArgs e)
        {
            filtret_macibspekus();
        }
        
        void B_atiestatit_macibspekusClick(object sender, EventArgs e)
        {
            tb_macsp_teksts.Text = "";
        }
        
        void Dgv_macibspekiCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                macibspeku_ievade d_macibspeks = new macibspeku_ievade(dgv_macibspeki["id_macsp", e.RowIndex].Value.ToString(), dgv_macibspeki["vards", e.RowIndex].Value.ToString(), dgv_macibspeki["uzvards", e.RowIndex].Value.ToString(), dgv_macibspeki["zin_grads", e.RowIndex].Value.ToString(), dgv_macibspeki["amats", e.RowIndex].Value.ToString());
            
                if (d_macibspeks.ShowDialog() == DialogResult.OK) {
                    dgv_macibspeki["id_macsp", e.RowIndex].Value = d_macibspeks.id_macsp;
                    dgv_macibspeki["vards", e.RowIndex].Value = d_macibspeks.vards;
                    dgv_macibspeki["uzvards", e.RowIndex].Value = d_macibspeks.uzvards;
                    dgv_macibspeki["zin_grads", e.RowIndex].Value = d_macibspeks.zin_grads;
                    dgv_macibspeki["amats", e.RowIndex].Value = d_macibspeks.amats;
                }
            }
        }
        
        void B_atcelt_macibspekiClick(object sender, EventArgs e)
        {
            if (db.msgbox_atcelt_izmainas() == DialogResult.Yes) {
                macibspekiDT.RejectChanges();
            }
        }
        
        void B_saglabat_macibspekiClick(object sender, EventArgs e)
        {
            NpgsqlCommand iev_kom = new NpgsqlCommand("INSERT INTO macibspeki VALUES(@id, @vards, @uzvards, @zin_grads, @amats, @parole);", db.sav);
            iev_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "id_macsp");
            iev_kom.Parameters.Add("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "vards");
            iev_kom.Parameters.Add("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "uzvards");
            iev_kom.Parameters.Add("@zin_grads", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "zin_grads");
            iev_kom.Parameters.Add("@amats", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "amats");
            iev_kom.Parameters.Add("@parole", NpgsqlTypes.NpgsqlDbType.Char, 40, "parole");
            NpgsqlCommand atj_kom = new NpgsqlCommand("UPDATE macibspeki SET vards = @vards, uzvards = @uzvards, zin_grads = @zin_grads, amats = @amats, parole = @parole WHERE id_macsp = @id;", db.sav);
            atj_kom.Parameters.Add("@vards", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "vards");
            atj_kom.Parameters.Add("@uzvards", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "uzvards");
            atj_kom.Parameters.Add("@zin_grads", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "zin_grads");
            atj_kom.Parameters.Add("@amats", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "amats");
            atj_kom.Parameters.Add("@parole", NpgsqlTypes.NpgsqlDbType.Char, 40, "parole");
            atj_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "id_macsp");
            NpgsqlCommand dz_kom = new NpgsqlCommand("DELETE FROM macibspeki WHERE id_macsp = @id;", db.sav);
            dz_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Varchar, 20, "id_macsp");
            
            macibspekiA.InsertCommand = iev_kom;
            macibspekiA.UpdateCommand = atj_kom;
            macibspekiA.DeleteCommand = dz_kom;
            
            try {
                macibspekiA.Update(macibspekiDT);
                sagl_kluda = false;
            } catch (Exception) {
                sagl_kluda = true;
                db.msgbox_saglabasanas_kluda();
            }
            
            if (!sagl_kluda) {
                macibspekiDT.AcceptChanges();
                db.msgbox_izmainas_saglabatas();
            }
        }
        
        void Tb_visi_studejosieTextChanged(object sender, EventArgs e)
        {
            if (tb_visi_studejosie.Text != "" && db.latviesu_burti(tb_visi_studejosie.Text)) {
                visi_studDT.DefaultView.RowFilter = string.Format("id_matr LIKE '%{0}%' OR vards LIKE '%{0}%' OR uzvards LIKE '%{0}%' OR nosaukums LIKE '%{0}%'", tb_visi_studejosie.Text);
            } else {
                visi_studDT.DefaultView.RowFilter = "";
            }
        }
        
        void B_atiestatit_studentusClick(object sender, EventArgs e)
        {
            tb_visi_studejosie.Text = "";
        }
        
        void Tb_visi_macibspekiTextChanged(object sender, EventArgs e)
        {
            if (tb_visi_macibspeki.Text != "" && db.latviesu_burti(tb_visi_macibspeki.Text)) {
                visi_macspDT.DefaultView.RowFilter = string.Format("vards LIKE '%{0}%' OR uzvards LIKE '%{0}%'", tb_visi_macibspeki.Text);
            } else {
                visi_macspDT.DefaultView.RowFilter = "";
            }
        }
        
        void B_atiestatit_visus_macspClick(object sender, EventArgs e)
        {
            tb_visi_macibspeki.Text = "";
        }
        
        void VadibaFormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds.HasChanges()) {
                if (db.msgbox_iziet() == DialogResult.No) {
                    e.Cancel = true;
                } else {
                    ds = new DataSet();
                }
            } else {
                ds = new DataSet();
            }
        }
        
        void VadibaFormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        
        void T_laiksTick(object sender, EventArgs e)
        {
            sl_datums_laiks.Text = db.datuma_virkne(DateTime.Now, true);
        }
        
        void IzietToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }
        
        void InformācijaToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 0;
        }
        
        void NodarbībuPlānošanaToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 1;
        }
        
        void StudējošieToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 2;
        }
        
        void MācībspēkiToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 3;
        }
        
        void PārskatiUnIzdrukasToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 4;
        }
        
        void MainītParoliToolStripMenuItemClick(object sender, EventArgs e)
        {
            paroles_maina d_parole = new paroles_maina();
            d_parole.ShowDialog();
        }
        
        void LLUNodarbībuSarakstsToolStripMenuItemClick(object sender, EventArgs e)
        {
            db.nodarbibu_saraksts();
        }
        
        void SūtītAtsauksmiToolStripMenuItemClick(object sender, EventArgs e)
        {
            db.sutit_atsauksmi();
        }
        
        void ParToolStripMenuItemClick(object sender, EventArgs e)
        {
            db.msgbox_par();
        }
    }
}
