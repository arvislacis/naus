using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;
using Novacode;

namespace naus
{
    public partial class macibspeks : Form
    {
        DataSet ds = new DataSet();
        
        DataTable aktivaDT = new DataTable("aktiva");
        DataTable apmeklejumiDT = new DataTable("apmeklejumi");
        DataTable stud_kursiDT = new DataTable("stud_kursi");
        DataTable nod_veidiDT = new DataTable("nod_veidi");
        DataTable nodarbibasDT = new DataTable("nodarbibas");
        DataTable nod_grupasDT = new DataTable("nod_grupas");
        DataTable stud_progDT = new DataTable("stud_prog");
        DataTable kursu_apmDT = new DataTable("kursu_apm");
        
        NpgsqlDataAdapter aktivaA = new NpgsqlDataAdapter("SELECT ad.id_apm, an.id_nod, ad.id_matr, (ad.vards || ' ' || ad.uzvards) st_v_uzv, ad.id_prkods, ad.kurss, ad.grupa, ad.datums, ad.ieradies, ad.labots FROM akt_nodarbibas an, apm_dati ad WHERE an.id_macsp = '" + db.lietotajs + "' AND an.id_nod = ad.id_nod ORDER BY ad.datums, ad.id_prkods, ad.kurss, ad.grupa, ad.uzvards;", db.sav);
        NpgsqlDataAdapter apmeklejumiA = new NpgsqlDataAdapter("SELECT ad.id_apm, n.id_nod, n.id_kkods, n.id_nveids, ad.id_matr, (ad.vards || ' ' || ad.uzvards) st_v_uzv, ad.id_prkods, ad.kurss, ad.grupa, n.ned_diena, ad.datums, n.laiks, ad.ieradies, ad.labots FROM apm_dati ad, nodarbibas n WHERE ad.id_nod = n.id_nod AND n.id_macsp = '" + db.lietotajs + "' ORDER BY ad.datums, n.laiks, ad.id_prkods, ad.kurss, ad.grupa, ad.uzvards;", db.sav);
        NpgsqlDataAdapter stud_kursiA = new NpgsqlDataAdapter("SELECT id_kkods, nosaukums, kr_punkti, (nosaukums || ' (' || id_kkods || ')') nosauk_kods FROM stud_kursi ORDER BY nosaukums;", db.sav);
        NpgsqlDataAdapter nod_veidiA = new NpgsqlDataAdapter("SELECT id_nveids, veids FROM nod_veidi;", db.sav);
        NpgsqlDataAdapter nodarbibasA = new NpgsqlDataAdapter("SELECT id_nod, id_kkods, id_nveids, dat_no, dat_lidz, ned_diena, laiks FROM nodarbibas WHERE id_macsp = '" + db.lietotajs + "' ORDER BY dat_no, ned_diena, laiks;", db.sav);
        NpgsqlDataAdapter nod_grupasA = new NpgsqlDataAdapter("SELECT g.id_grupa, g.id_nod, g.id_prkods, g.kurss, g.grupa FROM nod_grupas g, nodarbibas n WHERE g.id_nod = n.id_nod AND id_macsp = '" + db.lietotajs + "' ORDER BY kurss, grupa;", db.sav);
        NpgsqlDataAdapter stud_progA = new NpgsqlDataAdapter("SELECT id_prkods, nosaukums, id_prveids, (nosaukums || ' (' || id_prkods || ')') nos_kods FROM stud_prog;", db.sav);
        NpgsqlDataAdapter kursu_apmA = new NpgsqlDataAdapter("SELECT id_kkods, nosaukums, apmeklejumi, kavejumi, kopa, (procenti || '%') procenti FROM mac_k_apm WHERE id_macsp = '" + db.lietotajs + "' ORDER BY nosaukums;", db.sav);
        
        int akt_nod_id = -1;
        bool sagl_kluda;
        string sodiena;
        
        public macibspeks()
        {
            InitializeComponent();
            
            sl_lietotajs.Text = db.vards + " " + db.uzvards;
            sl_statuss.Text = db.zin_grads + ", " + db.amats;
            sl_datums_laiks.Text = db.datuma_virkne(DateTime.Now, true);
            
            izveidot_lokalo_db();
            iegut_aktivo_nodarbibu();
            noformet_saraksta_logus();
        }
        
        void aktivas_nodarbibas_skats()
        {
            aktivaA.Fill(aktivaDT);
            ds.Tables.Add(aktivaDT);
            
            aktivaDT.PrimaryKey = new DataColumn[] {aktivaDT.Columns["id_apm"]};
            
            ds.Relations.Add("nodarbibas-aktiva", nodarbibasDT.Columns["id_nod"], aktivaDT.Columns["id_nod"], true);
            
            dgv_aktiva.DataSource = aktivaDT;
            dgv_aktiva.Columns["id_apm"].HeaderText = "ID";
            dgv_aktiva.Columns["id_nod"].HeaderText = "Nodarbības ID";
            dgv_aktiva.Columns["id_matr"].HeaderText = "Matrikulas numurs";
            dgv_aktiva.Columns["id_matr"].ReadOnly = true;
            dgv_aktiva.Columns["st_v_uzv"].HeaderText = "Studējošais";
            dgv_aktiva.Columns["st_v_uzv"].ReadOnly = true;
            dgv_aktiva.Columns["id_prkods"].HeaderText = "Studiju programma";
            DataGridViewComboBoxColumn cb_stud_prog = new DataGridViewComboBoxColumn();
            cb_stud_prog.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_stud_prog.DataSource = stud_progDT;
            cb_stud_prog.Name = "id_prkods";
            cb_stud_prog.DataPropertyName = cb_stud_prog.ValueMember = "id_prkods";
            cb_stud_prog.DisplayMember = "nos_kods";
            cb_stud_prog.ReadOnly = true;
            cb_stud_prog.HeaderText = "Studiju programma";
            dgv_aktiva.Columns.Remove(dgv_aktiva.Columns["id_prkods"]);
            dgv_aktiva.Columns.Insert(3, cb_stud_prog);
            dgv_aktiva.Columns["kurss"].HeaderText = "Kurss";
            dgv_aktiva.Columns["kurss"].ReadOnly = true;
            dgv_aktiva.Columns["grupa"].HeaderText = "Grupa";
            dgv_aktiva.Columns["grupa"].ReadOnly = true;
            dgv_aktiva.Columns["datums"].HeaderText = "Nodarbības datums";
            dgv_aktiva.Columns["datums"].ReadOnly = true;
            dgv_aktiva.Columns["ieradies"].HeaderText = "Ieradies";
            dgv_aktiva.Columns["labots"].HeaderText = "Reģistrēšanas datums";
            dgv_aktiva.Columns["labots"].ReadOnly = true;
            dgv_aktiva.Columns["id_apm"].Visible = false;
            dgv_aktiva.Columns["id_nod"].Visible = false;
            
            aktivas_nodarbibas_filtri();
        }
        
        void iegut_aktivo_nodarbibu()
        {
            NpgsqlCommand akt_nod = new NpgsqlCommand("SELECT n.id_nod, sk.nosaukums, n.id_kkods, sk.kr_punkti, nv.veids, n.laiks, n.dat_no, n.dat_lidz, NOW() sodiena FROM akt_nodarbibas n, stud_kursi sk, nod_veidi nv WHERE n.id_kkods = sk.id_kkods AND n.id_nveids = nv.id_nveids AND n.id_macsp = '"+ db.lietotajs +"';", db.sav);
            
            db.sav.Open();
            
            NpgsqlDataReader lasitajs = akt_nod.ExecuteReader();
            
            if (lasitajs.HasRows) {
                lasitajs.Read();
                
                akt_nod_id = (int)lasitajs["id_nod"];
                
                l_stud_kursa_nosauk.Text = lasitajs["nosaukums"] + " (" + lasitajs["id_kkods"] + ")";
                l_kp_vert.Text = lasitajs["kr_punkti"].ToString();
                l_nod_veida_nosauk.Text = (string)lasitajs["veids"];
                l_laiks_vert.Text = lasitajs["laiks"] + ":30 - " + ((int)lasitajs["laiks"] + 1) + ":15";
                l_dat_no_vert.Text = lasitajs["dat_no"].ToString().Substring(0, 11);
                l_dat_lidz_vert.Text = lasitajs["dat_lidz"].ToString().Substring(0, 11);
                sodiena = lasitajs["sodiena"].ToString().Substring(0, 11);
                
                lasitajs.Close();
                
                aktivas_nodarbibas_skats();
            } else {
                akt_nod_id = -1;
                tabc_cilnes.TabPages.Remove(tb_aktiva);
                aktīvāsNodarbībasApmeklējumiToolStripMenuItem.Visible = false;
            }
            
            db.sav.Close();
        }
        
        void izveidot_lokalo_db()
        {
            apmeklejumiA.Fill(apmeklejumiDT);
            stud_kursiA.Fill(stud_kursiDT);
            nod_veidiA.Fill(nod_veidiDT);
            nodarbibasA.Fill(nodarbibasDT);
            nod_grupasA.Fill(nod_grupasDT);
            stud_progA.Fill(stud_progDT);
            kursu_apmA.Fill(kursu_apmDT);
            
            ds.Tables.Add(apmeklejumiDT);
            ds.Tables.Add(stud_kursiDT);
            ds.Tables.Add(nod_veidiDT);
            ds.Tables.Add(nodarbibasDT);
            ds.Tables.Add(nod_grupasDT);
            ds.Tables.Add(stud_progDT);
            ds.Tables.Add(kursu_apmDT);
            
            apmeklejumiDT.PrimaryKey = new DataColumn[] {apmeklejumiDT.Columns["id_apm"]};
            stud_kursiDT.PrimaryKey = new DataColumn[] {stud_kursiDT.Columns["id_kkods"]};
            nod_veidiDT.PrimaryKey = new DataColumn[] {nod_veidiDT.Columns["id_nveids"]};
            nodarbibasDT.PrimaryKey = new DataColumn[] {nodarbibasDT.Columns["id_nod"]};
            nod_grupasDT.PrimaryKey = new DataColumn[] {nod_grupasDT.Columns["id_grupa"]};
            stud_progDT.PrimaryKey = new DataColumn[] {stud_progDT.Columns["id_prkods"]};
            
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
            
            ds.Relations.Add("nodarbibas-nod_grupas", nodarbibasDT.Columns["id_nod"], nod_grupasDT.Columns["id_nod"], true);
            ds.Relations.Add("nodarbibas-apmeklejumi", nodarbibasDT.Columns["id_nod"], apmeklejumiDT.Columns["id_nod"], true);
        }
        
        void noformet_saraksta_logus()
        {
            dgv_apmeklejumi.DataSource = apmeklejumiDT;
            dgv_apmeklejumi.Columns["id_apm"].HeaderText = "ID";
            dgv_apmeklejumi.Columns["id_nod"].HeaderText = "Nodarbības ID";
            dgv_apmeklejumi.Columns["id_kkods"].HeaderText = "Studiju kurss";
            DataGridViewComboBoxColumn cb_stud_kurss = new DataGridViewComboBoxColumn();
            cb_stud_kurss.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_stud_kurss.DataSource = stud_kursiDT;
            cb_stud_kurss.Name = "id_kkods";
            cb_stud_kurss.DataPropertyName = cb_stud_kurss.ValueMember = "id_kkods";
            cb_stud_kurss.DisplayMember = "nosaukums";
            cb_stud_kurss.HeaderText = "Studiju kurss";
            cb_stud_kurss.ReadOnly = true;
            dgv_apmeklejumi.Columns.Remove(dgv_apmeklejumi.Columns["id_kkods"]);
            dgv_apmeklejumi.Columns.Insert(2, cb_stud_kurss);
            dgv_apmeklejumi.Columns["id_kkods"].DisplayIndex = 0;
            dgv_apmeklejumi.Columns["id_nveids"].HeaderText = "Nodarbības veids";
            DataGridViewComboBoxColumn cb_nod_veids1 = new DataGridViewComboBoxColumn();
            cb_nod_veids1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_nod_veids1.DataSource = nod_veidiDT;
            cb_nod_veids1.Name = "id_nveids";
            cb_nod_veids1.DataPropertyName = cb_nod_veids1.ValueMember = "id_nveids";
            cb_nod_veids1.DisplayMember = "veids";
            cb_nod_veids1.HeaderText = "Nodarbības veids";
            cb_nod_veids1.ReadOnly = true;
            dgv_apmeklejumi.Columns.Remove(dgv_apmeklejumi.Columns["id_nveids"]);
            dgv_apmeklejumi.Columns.Insert(2, cb_nod_veids1);
            dgv_apmeklejumi.Columns["id_nveids"].DisplayIndex = 1;
            dgv_apmeklejumi.Columns["id_matr"].HeaderText = "Matrikulas numurs";
            dgv_apmeklejumi.Columns["id_matr"].ReadOnly = true;
            dgv_apmeklejumi.Columns["id_matr"].DisplayIndex = 2;
            dgv_apmeklejumi.Columns["st_v_uzv"].HeaderText = "Studējošais";
            dgv_apmeklejumi.Columns["st_v_uzv"].ReadOnly = true;
            dgv_apmeklejumi.Columns["st_v_uzv"].DisplayIndex = 3;
            dgv_apmeklejumi.Columns["id_prkods"].HeaderText = "Studiju programma";
            DataGridViewComboBoxColumn cb_stud_prog = new DataGridViewComboBoxColumn();
            cb_stud_prog.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_stud_prog.DataSource = stud_progDT;
            cb_stud_prog.Name = "id_prkods";
            cb_stud_prog.DataPropertyName = cb_stud_prog.ValueMember = "id_prkods";
            cb_stud_prog.DisplayMember = "nos_kods";
            cb_stud_prog.HeaderText = "Studiju programma";
            cb_stud_prog.ReadOnly = true;
            dgv_apmeklejumi.Columns.Remove(dgv_apmeklejumi.Columns["id_prkods"]);
            dgv_apmeklejumi.Columns.Insert(5, cb_stud_prog);
            dgv_apmeklejumi.Columns["kurss"].HeaderText = "Kurss";
            dgv_apmeklejumi.Columns["kurss"].ReadOnly = true;
            dgv_apmeklejumi.Columns["grupa"].HeaderText = "Grupa";
            dgv_apmeklejumi.Columns["grupa"].ReadOnly = true;
            dgv_apmeklejumi.Columns["datums"].HeaderText = "Nodarbības datums";
            dgv_apmeklejumi.Columns["datums"].ReadOnly = true;
            dgv_apmeklejumi.Columns["ned_diena"].HeaderText = "Nedēļas diena";
            DataGridViewComboBoxColumn cb_ned_diena = new DataGridViewComboBoxColumn();
            cb_ned_diena.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_ned_diena.DataSource = db.n_dienasDT;
            cb_ned_diena.Name = "ned_diena";
            cb_ned_diena.DataPropertyName = cb_ned_diena.ValueMember = "ned_diena";
            cb_ned_diena.DisplayMember = "nosaukums";
            cb_ned_diena.HeaderText = "Nedēļas diena";
            cb_ned_diena.ReadOnly = true;
            dgv_apmeklejumi.Columns.Remove(dgv_apmeklejumi.Columns["ned_diena"]);
            dgv_apmeklejumi.Columns.Insert(9, cb_ned_diena);
            dgv_apmeklejumi.Columns["laiks"].HeaderText = "Laiks";
            DataGridViewComboBoxColumn cb_laiks = new DataGridViewComboBoxColumn();
            cb_laiks.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_laiks.DataSource = db.laikiDT;
            cb_laiks.Name = "laiks";
            cb_laiks.DataPropertyName = cb_laiks.ValueMember = "laiks";
            cb_laiks.DisplayMember = "virkne";
            cb_laiks.HeaderText = "Laiks";
            cb_laiks.ReadOnly = true;
            dgv_apmeklejumi.Columns.Remove(dgv_apmeklejumi.Columns["laiks"]);
            dgv_apmeklejumi.Columns.Insert(10, cb_laiks);
            dgv_apmeklejumi.Columns["ieradies"].HeaderText = "Ieradies";
            dgv_apmeklejumi.Columns["labots"].HeaderText = "Reģistrēšanas datums";
            dgv_apmeklejumi.Columns["labots"].ReadOnly = true;
            dgv_apmeklejumi.Columns["id_apm"].Visible = false;
            dgv_apmeklejumi.Columns["id_nod"].Visible = false;
            
            dgv_nodarbibas.DataSource = nodarbibasDT;
            dgv_nodarbibas.Columns["id_nod"].HeaderText = "ID";
            dgv_nodarbibas.Columns["id_kkods"].HeaderText = "Studiju kurss";
            DataGridViewComboBoxColumn cb_stud_kurss2 = new DataGridViewComboBoxColumn();
            cb_stud_kurss2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_stud_kurss2.DataSource = stud_kursiDT;
            cb_stud_kurss2.Name = "id_kkods";
            cb_stud_kurss2.DataPropertyName = cb_stud_kurss2.ValueMember = "id_kkods";
            cb_stud_kurss2.DisplayMember = "nosaukums";
            cb_stud_kurss2.HeaderText = "Studiju kurss";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["id_kkods"]);
            dgv_nodarbibas.Columns.Insert(1, cb_stud_kurss2);
            dgv_nodarbibas.Columns["id_nveids"].HeaderText = "Nosarbības veids";
            DataGridViewComboBoxColumn cb_nod_veids2 = new DataGridViewComboBoxColumn();
            cb_nod_veids2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_nod_veids2.DataSource = nod_veidiDT;
            cb_nod_veids2.Name = "id_nveids";
            cb_nod_veids2.DataPropertyName = cb_nod_veids2.ValueMember = "id_nveids";
            cb_nod_veids2.DisplayMember = "veids";
            cb_nod_veids2.HeaderText = "Nodarbības veids";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["id_nveids"]);
            dgv_nodarbibas.Columns.Insert(2, cb_nod_veids2);
            dgv_nodarbibas.Columns["dat_no"].HeaderText = "Datums no";
            dgv_nodarbibas.Columns["dat_lidz"].HeaderText = "Datums līdz";
            dgv_nodarbibas.Columns["ned_diena"].HeaderText = "Nedēļas diena";
            DataGridViewComboBoxColumn cb_ned_diena2 = new DataGridViewComboBoxColumn();
            cb_ned_diena2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_ned_diena2.DataSource = db.n_dienasDT;
            cb_ned_diena2.Name = "ned_diena";
            cb_ned_diena2.DataPropertyName = cb_ned_diena2.ValueMember = "ned_diena";
            cb_ned_diena2.DisplayMember = "nosaukums";
            cb_ned_diena2.HeaderText = "Nedēļas diena";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["ned_diena"]);
            dgv_nodarbibas.Columns.Insert(5, cb_ned_diena2);
            dgv_nodarbibas.Columns["laiks"].HeaderText = "Laiks";
            DataGridViewComboBoxColumn cb_laiks2 = new DataGridViewComboBoxColumn();
            cb_laiks2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cb_laiks2.DataSource = db.laikiDT;
            cb_laiks2.Name = "laiks";
            cb_laiks2.DataPropertyName = cb_laiks2.ValueMember = "laiks";
            cb_laiks2.DisplayMember = "virkne";
            cb_laiks2.HeaderText = "Laiks";
            dgv_nodarbibas.Columns.Remove(dgv_nodarbibas.Columns["laiks"]);
            dgv_nodarbibas.Columns.Insert(6, cb_laiks2);
            dgv_nodarbibas.Columns["id_nod"].Visible = false;
            
            dgv_nod_grupas.DataSource = nod_grupasDT;
            dgv_nod_grupas.DataSource = nodarbibasDT;
            dgv_nod_grupas.DataMember = "nodarbibas-nod_grupas";
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
            
            dgv_kursu_apmeklejumi.DataSource = kursu_apmDT;
            dgv_kursu_apmeklejumi.Columns["id_kkods"].HeaderText = "Kursa kods";
            dgv_kursu_apmeklejumi.Columns["nosaukums"].HeaderText = "Kursa nosaukums";
            dgv_kursu_apmeklejumi.Columns["apmeklejumi"].HeaderText = "Apmeklētās nodarbības";
            dgv_kursu_apmeklejumi.Columns["kavejumi"].HeaderText = "Kavētās nodarbības";
            dgv_kursu_apmeklejumi.Columns["kopa"].HeaderText = "Kopējais nodarbību skaits";
            dgv_kursu_apmeklejumi.Columns["procenti"].HeaderText = "Apmeklējums procentos";
            
            visu_nodarbibu_filtri();
            planoto_nodarbibu_filtri();
        }
        
        // Aktīvās nodarbības apmeklējumu cilne un ar to saistītās funkcijas
        
        void B_aktiva_iezimetClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rinda in dgv_aktiva.SelectedRows) {
                rinda.Cells["ieradies"].Value = true;
                rinda.Cells["labots"].Value = DateTime.Now;
                rinda.DataGridView.EndEdit();
            }
            
            dgv_aktiva.Select();
        }
        
        void B_aktiva_nonemtClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rinda in dgv_aktiva.SelectedRows) {
                rinda.Cells["ieradies"].Value = false;
                rinda.Cells["labots"].Value = DateTime.Now;
                rinda.DataGridView.EndEdit();
            }
            
            dgv_aktiva.Select();
        }
        
        void B_aktiva_neregistretClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rinda in dgv_aktiva.SelectedRows) {
                rinda.Cells["ieradies"].Value = false;
                rinda.Cells["labots"].Value = DBNull.Value;
                rinda.DataGridView.EndEdit();
            }
            
            dgv_aktiva.Select();
        }
        
        void aktivas_nodarbibas_filtri()
        {
            for (int i = 0; i < aktivaDT.Rows.Count; i++) {
                string datums = aktivaDT.Rows[i]["datums"].ToString().Substring(0, 11);
                
                if (!cb_ak_datums.Items.Contains(datums)) {
                    cb_ak_datums.Items.Add(datums);
                }
            }
            
            cb_ak_datums.Items.Add("Visi");
            
            if (cb_ak_datums.Items.Contains(sodiena)) {
                cb_ak_datums.SelectedItem = sodiena;
            } else {
                cb_ak_datums.SelectedItem = "Visi";
            }
            
            for (int i = 0; i < stud_progDT.Rows.Count; i++) {
                if (aktivaDT.Select("id_prkods = '" + stud_progDT.Rows[i]["id_prkods"] + "'").Length > 0) {
                    cb_ak_stud_prog.Items.Add(stud_progDT.Rows[i]["id_prkods"].ToString());
                }
            }

            cb_ak_stud_prog.Items.Add("Visas");
            cb_ak_stud_prog.SelectedItem = "Visas";
            
            for (int i = 0; i < db.kursiDT.Rows.Count; i++) {
                if (aktivaDT.Select("kurss = '" + db.kursiDT.Rows[i]["kurss"] + "'").Length > 0) {
                    cb_ak_kurss.Items.Add(db.kursiDT.Rows[i]["kurss"].ToString());
                }
            }
            
            cb_ak_kurss.Items.Add("Visi");
            cb_ak_kurss.SelectedItem = "Visi";
            
            for (int i = 0; i < db.grupasDT.Rows.Count; i++) {
                if (aktivaDT.Select("grupa = '" + db.grupasDT.Rows[i]["grupa"] + "'").Length > 0) {
                    cb_ak_grupa.Items.Add(db.grupasDT.Rows[i]["grupa"].ToString());
                }
            }
            
            cb_ak_grupa.Items.Add("Visas");
            cb_ak_grupa.SelectedItem = "Visas";
        }
        
        void filtret_aktivo_nodarbibu()
        {
            string filtrs = "1 = 1";
            
            if (!(cb_ak_datums.Text == "Visi" || string.IsNullOrEmpty(cb_ak_datums.Text))) {
                filtrs += " AND datums = '" + cb_ak_datums.Text + "'";
            }
            
            if (!(cb_ak_stud_prog.Text == "Visas" || string.IsNullOrEmpty(cb_ak_stud_prog.Text))) {
                filtrs += " AND id_prkods = '" + cb_ak_stud_prog.Text + "'";
            }
            
            if (!(cb_ak_kurss.Text == "Visi" || string.IsNullOrEmpty(cb_ak_kurss.Text))) {
                filtrs += " AND kurss = '" + cb_ak_kurss.Text + "'";
            }
            
            if (!(cb_ak_grupa.Text == "Visas" || string.IsNullOrEmpty(cb_ak_grupa.Text))) {
                filtrs += " AND grupa = '" + cb_ak_grupa.Text + "'";
            }
            
            if (tb_ak_teksts.Text != "" && db.latviesu_burti_cipari(tb_ak_teksts.Text)) {
                filtrs += string.Format(" AND (id_matr LIKE '%{0}%' OR st_v_uzv LIKE '%{0}%')", tb_ak_teksts.Text);
            }
            
            aktivaDT.DefaultView.RowFilter = filtrs;
            
            dgv_aktiva.Columns["id_apm"].Visible = false;
            dgv_aktiva.Columns["id_nod"].Visible = false;
        }
        
        void Cb_datumsSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_aktivo_nodarbibu();
        }
        
        void Cb_ak_stud_progSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_aktivo_nodarbibu();
        }
        
        void Cb_ak_kurssSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_aktivo_nodarbibu();
        }
        
        void Cb_ak_grupaSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_aktivo_nodarbibu();
        }
        
        void Tb_ak_tekstsTextChanged(object sender, EventArgs e)
        {
            filtret_aktivo_nodarbibu();
        }
        
        void B_atiestatit_aktivoClick(object sender, EventArgs e)
        {
            tb_ak_teksts.Text = "";
            cb_ak_grupa.SelectedItem = "Visas";
            cb_ak_kurss.SelectedItem = "Visi";
            cb_ak_stud_prog.SelectedItem = "Visas";
            
            if (cb_ak_datums.Items.Contains(sodiena)) {
                cb_ak_datums.SelectedItem = sodiena;
            } else {
                cb_ak_datums.SelectedItem = "Visi";
            }
        }
        
        void Dgv_aktivaCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_aktiva["ieradies", 0].ColumnIndex == e.ColumnIndex) {
                if (dgv_aktiva["ieradies", e.RowIndex].Value.ToString() == "False") {
                    dgv_aktiva["ieradies", e.RowIndex].Value = true;
                } else {
                    dgv_aktiva["ieradies", e.RowIndex].Value = false;
                }
                
                dgv_aktiva["labots", e.RowIndex].Value = DateTime.Now;
            }
        }
        
        void Dgv_aktivaCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                if (dgv_aktiva["ieradies", e.RowIndex].Value.ToString() == "False") {
                    dgv_aktiva["ieradies", e.RowIndex].Value = true;
                } else {
                    dgv_aktiva["ieradies", e.RowIndex].Value = false;
                }
            
                dgv_aktiva["labots", e.RowIndex].Value = DateTime.Now;
            }
        }
        
        void B_atcelt_aktivoClick(object sender, EventArgs e)
        {
            if (db.msgbox_atcelt_izmainas() == DialogResult.Yes) {
                try {
                    aktivaDT.RejectChanges();
                } catch (Exception) {
                    db.msgbox_nevar_atcelt();
                }
            }
        }
        
        void B_saglabat_aktivoClick(object sender, EventArgs e)
        {
            NpgsqlCommand atj_kom = new NpgsqlCommand("UPDATE apmeklejumi SET ieradies = @ieradies, labots = @labots WHERE id_apm = @id;", db.sav);
            atj_kom.Parameters.Add("@ieradies", NpgsqlTypes.NpgsqlDbType.Boolean, 5, "ieradies");
            atj_kom.Parameters.Add("@labots", NpgsqlTypes.NpgsqlDbType.Timestamp, 15, "labots");
            atj_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_apm");
            
            aktivaA.UpdateCommand = atj_kom;
            
            try {
                aktivaA.Update(aktivaDT);
                sagl_kluda = false;
            } catch (Exception) {
                sagl_kluda = true;
                db.msgbox_saglabasanas_kluda();
            }
            
            if (!sagl_kluda) {
                aktivaDT.AcceptChanges();
                db.msgbox_izmainas_saglabatas();
            }
        }
        
        // Visu nodarbību apmeklējumu cilne un ar to saistītās funkcijas
        
        void B_apmekl_iezimetClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rinda in dgv_apmeklejumi.SelectedRows) {
                rinda.Cells["ieradies"].Value = true;
                rinda.Cells["labots"].Value = DateTime.Now;
                rinda.DataGridView.EndEdit();
            }
            
            dgv_apmeklejumi.Select();
        }
        
        void B_apmekl_nonemtClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rinda in dgv_apmeklejumi.SelectedRows) {
                rinda.Cells["ieradies"].Value = false;
                rinda.Cells["labots"].Value = DateTime.Now;
                rinda.DataGridView.EndEdit();
            }
            
            dgv_apmeklejumi.Select();
        }
        
        void B_apmekl_neregistretClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rinda in dgv_apmeklejumi.SelectedRows) {
                rinda.Cells["ieradies"].Value = false;
                rinda.Cells["labots"].Value = DBNull.Value;
                rinda.DataGridView.EndEdit();
            }
            
            dgv_apmeklejumi.Select();
        }
        
        void visu_nodarbibu_filtri()
        {
            Dictionary<string, string> d_stud_kurss = new Dictionary<string, string>();
            Dictionary<string, string> d_nod_veids = new Dictionary<string, string>();
            Dictionary<string, string> d_laiks = new Dictionary<string, string>();
            
            for (int i = 0; i < stud_kursiDT.Rows.Count; i++) {
                if (apmeklejumiDT.Select("id_kkods = '" + stud_kursiDT.Rows[i]["id_kkods"] + "'").Length > 0) {
                    d_stud_kurss.Add(stud_kursiDT.Rows[i]["id_kkods"].ToString(), stud_kursiDT.Rows[i]["nosaukums"].ToString());
                }
            }
            
            d_stud_kurss.Add("Visi", "Visi");
            
            cb_nod_stud_kurss.DataSource = new BindingSource(d_stud_kurss, null);
            cb_nod_stud_kurss.DisplayMember = "Value";
            cb_nod_stud_kurss.ValueMember = "Key";
            cb_nod_stud_kurss.SelectedValue = "Visi";
            
            for (int i = 0; i < nod_veidiDT.Rows.Count; i++) {
                if (apmeklejumiDT.Select("id_nveids = '" + nod_veidiDT.Rows[i]["id_nveids"] + "'").Length > 0) {
                    d_nod_veids.Add(nod_veidiDT.Rows[i]["id_nveids"].ToString(), nod_veidiDT.Rows[i]["veids"].ToString());
                }
            }
            
            d_nod_veids.Add("Visi", "Visi");
            
            cb_nod_veids.DataSource = new BindingSource(d_nod_veids, null);
            cb_nod_veids.DisplayMember = "Value";
            cb_nod_veids.ValueMember = "Key";
            cb_nod_veids.SelectedValue = "Visi";
            
            for (int i = 0; i < stud_progDT.Rows.Count; i++) {
                if (apmeklejumiDT.Select("id_prkods = '" + stud_progDT.Rows[i]["id_prkods"] + "'").Length > 0) {
                    cb_nod_stud_prog.Items.Add(stud_progDT.Rows[i]["id_prkods"].ToString());
                }
            }

            cb_nod_stud_prog.Items.Add("Visas");
            cb_nod_stud_prog.SelectedItem = "Visas";
            
            for (int i = 0; i < db.kursiDT.Rows.Count; i++) {
                if (apmeklejumiDT.Select("kurss = '" + db.kursiDT.Rows[i]["kurss"] + "'").Length > 0) {
                    cb_nod_kurss.Items.Add(db.kursiDT.Rows[i]["kurss"].ToString());
                }
            }
            
            cb_nod_kurss.Items.Add("Visi");
            cb_nod_kurss.SelectedItem = "Visi";
            
            for (int i = 0; i < db.grupasDT.Rows.Count; i++) {
                if (apmeklejumiDT.Select("grupa = '" + db.grupasDT.Rows[i]["grupa"] + "'").Length > 0) {
                    cb_nod_grupa.Items.Add(db.grupasDT.Rows[i]["grupa"].ToString());
                }
            }
            
            cb_nod_grupa.Items.Add("Visas");
            cb_nod_grupa.SelectedItem = "Visas";
            
            for (int i = 0; i < apmeklejumiDT.Rows.Count; i++) {
                string datums = apmeklejumiDT.Rows[i]["datums"].ToString().Substring(0, 11);
                
                if (!cb_nod_datums.Items.Contains(datums)) {
                    cb_nod_datums.Items.Add(datums);
                }
            }
            
            cb_nod_datums.Items.Add("Visi");
            
            if (sodiena == null) {
                sodiena = DateTime.Now.ToString().Substring(0, 11);
            }
            
            if (cb_nod_datums.Items.Contains(sodiena)) {
                cb_nod_datums.SelectedItem = sodiena;
            } else {
                cb_nod_datums.SelectedItem = "Visi";
            }
            
            for (int i = 0; i < db.laikiDT.Rows.Count; i++) {
                if (apmeklejumiDT.Select("laiks = '" + db.laikiDT.Rows[i]["laiks"] + "'").Length > 0) {
                    d_laiks.Add(db.laikiDT.Rows[i]["laiks"].ToString(), db.laikiDT.Rows[i]["virkne"].ToString());
                }
            }
            
            d_laiks.Add("Visi", "Visi");
            
            cb_nod_laiks.DataSource = new BindingSource(d_laiks, null);
            cb_nod_laiks.DisplayMember = "Value";
            cb_nod_laiks.ValueMember = "Key";
            cb_nod_laiks.SelectedValue = "Visi";
        }
        
        void filtret_visas_nodarbibas()
        {
            string filtrs = "1 = 1";
            
            if (!(cb_nod_stud_kurss.Text == "Visi" || string.IsNullOrEmpty(cb_nod_stud_kurss.Text))) {
                filtrs += " AND id_kkods = '" + cb_nod_stud_kurss.SelectedValue + "'";
            }
            
            if (!(cb_nod_veids.Text == "Visi" || string.IsNullOrEmpty(cb_nod_veids.Text))) {
                filtrs += " AND id_nveids = '" + cb_nod_veids.SelectedValue + "'";
            }
            
            if (!(cb_nod_stud_prog.Text == "Visas" || string.IsNullOrEmpty(cb_nod_stud_prog.Text))) {
                filtrs += " AND id_prkods = '" + cb_nod_stud_prog.Text + "'";
            }
            
            if (tb_nod_teksts.Text != "" && db.latviesu_burti_cipari(tb_nod_teksts.Text)) {
                filtrs += string.Format(" AND (id_matr LIKE '%{0}%' OR st_v_uzv LIKE '%{0}%')", tb_nod_teksts.Text);
            }
            
            if (!(cb_nod_kurss.Text == "Visi" || string.IsNullOrEmpty(cb_nod_kurss.Text))) {
                filtrs += " AND kurss = '" + cb_nod_kurss.Text + "'";
            }
            
            if (!(cb_nod_grupa.Text == "Visas" || string.IsNullOrEmpty(cb_nod_grupa.Text))) {
                filtrs += " AND grupa = '" + cb_nod_grupa.Text + "'";
            }
            
            if (!(cb_nod_datums.Text == "Visi" || string.IsNullOrEmpty(cb_nod_datums.Text))) {
                filtrs += " AND datums = '" + cb_nod_datums.Text + "'";
            }
            
            if (!(cb_nod_laiks.Text == "Visi" || string.IsNullOrEmpty(cb_nod_laiks.Text))) {
                filtrs += " AND laiks = '" + cb_nod_laiks.SelectedValue + "'";
            }
            
            apmeklejumiDT.DefaultView.RowFilter = filtrs;
            
            dgv_apmeklejumi.Columns["id_apm"].Visible = false;
            dgv_apmeklejumi.Columns["id_nod"].Visible = false;
        }
        
        void Cb_nod_stud_kurssSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void Cb_nod_veidsSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void Cb_nod_stud_progSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void Tb_nod_tekstsTextChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void Cb_nod_kurssSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void Cb_nod_grupaSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void Cb_nod_datumsSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void Cb_nod_laiksSelectedIndexChanged(object sender, EventArgs e)
        {
            filtret_visas_nodarbibas();
        }
        
        void B_atiestatit_nodarbibasClick(object sender, EventArgs e)
        {
            cb_nod_laiks.SelectedValue = "Visi";
            
            if (cb_nod_datums.Items.Contains(sodiena)) {
                cb_nod_datums.SelectedItem = sodiena;
            } else {
                cb_nod_datums.SelectedItem = "Visi";
            }
            
            cb_nod_grupa.SelectedItem = "Visas";
            cb_nod_kurss.SelectedItem = "Visi";
            tb_nod_teksts.Text = "";
            cb_nod_stud_prog.SelectedItem = "Visas";
            cb_nod_veids.SelectedValue = "Visi";
            cb_nod_stud_kurss.SelectedValue = "Visi";
        }
        
        void Dgv_apmeklejumiCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_apmeklejumi["ieradies", 0].ColumnIndex == e.ColumnIndex) {
                if (dgv_apmeklejumi["ieradies", e.RowIndex].Value.ToString() == "False") {
                    dgv_apmeklejumi["ieradies", e.RowIndex].Value = true;
                } else {
                    dgv_apmeklejumi["ieradies", e.RowIndex].Value = false;
                }
                
                dgv_apmeklejumi["labots", e.RowIndex].Value = DateTime.Now;
            }
        }
        
        void Dgv_apmeklejumiCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                if (dgv_apmeklejumi["ieradies", e.RowIndex].Value.ToString() == "False") {
                    dgv_apmeklejumi["ieradies", e.RowIndex].Value = true;
                } else {
                    dgv_apmeklejumi["ieradies", e.RowIndex].Value = false;
                }
            
                dgv_apmeklejumi["labots", e.RowIndex].Value = DateTime.Now;
            }
        }
        
        void B_atcelt_apmeklClick(object sender, EventArgs e)
        {
            if (db.msgbox_atcelt_izmainas() == DialogResult.Yes) {
                try {
                    apmeklejumiDT.RejectChanges();
                } catch (Exception) {
                    db.msgbox_nevar_atcelt();
                }
            }
        }
        
        void B_saglabat_apmeklClick(object sender, EventArgs e)
        {
            NpgsqlCommand atj_kom = new NpgsqlCommand("UPDATE apmeklejumi SET ieradies = @ieradies, labots = @labots WHERE id_apm = @id;", db.sav);
            atj_kom.Parameters.Add("@ieradies", NpgsqlTypes.NpgsqlDbType.Boolean, 5, "ieradies");
            atj_kom.Parameters.Add("@labots", NpgsqlTypes.NpgsqlDbType.Timestamp, 15, "labots");
            atj_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_apm");
            
            apmeklejumiA.UpdateCommand = atj_kom;
            
            try {
                apmeklejumiA.Update(apmeklejumiDT);
                sagl_kluda = false;
            } catch (Exception) {
                sagl_kluda = true;
                db.msgbox_saglabasanas_kluda();
            }
            
            if (!sagl_kluda) {
                apmeklejumiDT.AcceptChanges();
                db.msgbox_izmainas_saglabatas();
            }
        }
        
        // Nodarbību plānošanas cilne un ar to saistītās funkcijas
        
        void B_nod_grupas_pievienotClick(object sender, EventArgs e)
        {
            int nod_idx;
            
            nod_idx = dgv_nodarbibas.SelectedRows[0].Index;
            
            string stud_kurss = dgv_nodarbibas["id_kkods", nod_idx].FormattedValue.ToString();
            string nod_veids = dgv_nodarbibas["id_nveids", nod_idx].FormattedValue.ToString();
            string dat_no = dgv_nodarbibas["dat_no", nod_idx].Value.ToString();
            string dat_lidz = dgv_nodarbibas["dat_lidz", nod_idx].Value.ToString();
            string ned_diena = dgv_nodarbibas["ned_diena", nod_idx].FormattedValue.ToString();
            string laiks = dgv_nodarbibas["laiks", nod_idx].FormattedValue.ToString();
            string ned_diena2 = dgv_nodarbibas["ned_diena", nod_idx].Value.ToString();
            string laiks2 = dgv_nodarbibas["laiks", nod_idx].Value.ToString();
            
            nod_grupu_ievade d_grupas = new nod_grupu_ievade(sl_lietotajs.Text, stud_kurss, nod_veids, dat_no, dat_lidz, ned_diena, laiks, ned_diena2, laiks2);
            
            if (d_grupas.ShowDialog() == DialogResult.OK) {
                DataRow nod_grupa = nod_grupasDT.NewRow();
                
                nod_grupa["id_nod"] = dgv_nodarbibas["id_nod", nod_idx].Value;
                nod_grupa["id_prkods"] = d_grupas.id_prkods;
                nod_grupa["kurss"] = d_grupas.kurss;
                nod_grupa["grupa"] = d_grupas.grupa;
                
                nod_grupasDT.Rows.Add(nod_grupa);
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
        
        void B_nod_pievienotClick(object sender, EventArgs e)
        {
            nodarbibu_ievade d_nodarbiba = new nodarbibu_ievade("", db.lietotajs, "", "", "", "", "", "", true);
            
            if (d_nodarbiba.ShowDialog() == DialogResult.OK) {
                DataRow nodarbiba = nodarbibasDT.NewRow();
                
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
        
        void planoto_nodarbibu_filtri()
        {
            Dictionary<string, string> d_stud_kurss = new Dictionary<string, string>();
            Dictionary<string, string> d_nod_veids = new Dictionary<string, string>();
            Dictionary<string, string> d_ned_diena = new Dictionary<string, string>();
            Dictionary<string, string> d_laiks = new Dictionary<string, string>();
            
            for (int i = 0; i < stud_kursiDT.Rows.Count; i++) {
                if (nodarbibasDT.Select("id_kkods = '" + stud_kursiDT.Rows[i]["id_kkods"] + "'").Length > 0) {
                    d_stud_kurss.Add(stud_kursiDT.Rows[i]["id_kkods"].ToString(), stud_kursiDT.Rows[i]["nosaukums"].ToString());
                }
            }
            
            d_stud_kurss.Add("Visi", "Visi");
            
            cb_plan_stud_kurss.DataSource = new BindingSource(d_stud_kurss, null);
            cb_plan_stud_kurss.DisplayMember = "Value";
            cb_plan_stud_kurss.ValueMember = "Key";
            cb_plan_stud_kurss.SelectedValue = "Visi";
            
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
            
            if (!(cb_plan_stud_kurss.Text == "Visi" || string.IsNullOrEmpty(cb_plan_stud_kurss.Text))) {
                filtrs += " AND id_kkods = '" + cb_plan_stud_kurss.SelectedValue + "'";
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
            
            nodarbibasDT.DefaultView.RowFilter = filtrs;
            
            dgv_nodarbibas.Columns["id_nod"].Visible = false;
            dgv_nod_grupas.Columns["id_nod"].Visible = false;
            dgv_nod_grupas.Columns["id_grupa"].Visible = false;
        }
        
        void Cb_plan_stud_kurssSelectedIndexChanged(object sender, EventArgs e)
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
            cb_plan_laiks.SelectedValue = "Visi";
            cb_plan_ned_diena.SelectedValue = "Visas";
            cb_plan_veids.SelectedValue = "Visi";
            cb_plan_stud_kurss.SelectedValue = "Visi";
        }
        
        void Dgv_nodarbibasCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                nodarbibu_ievade d_nodarbiba = new nodarbibu_ievade(dgv_nodarbibas["id_nod", e.RowIndex].Value.ToString(), db.lietotajs, dgv_nodarbibas["id_kkods", e.RowIndex].Value.ToString(), dgv_nodarbibas["id_nveids", e.RowIndex].Value.ToString(), dgv_nodarbibas["dat_no", e.RowIndex].Value.ToString(), dgv_nodarbibas["dat_lidz", e.RowIndex].Value.ToString(), dgv_nodarbibas["ned_diena", e.RowIndex].Value.ToString(), dgv_nodarbibas["laiks", e.RowIndex].Value.ToString(), true);
            
                if (d_nodarbiba.ShowDialog() == DialogResult.OK) {
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
                    int nod_idx;
                    
                    nod_idx = dgv_nodarbibas.SelectedRows[0].Index;
                    
                    string stud_kurss = dgv_nodarbibas["id_kkods", nod_idx].FormattedValue.ToString();
                    string nod_veids = dgv_nodarbibas["id_nveids", nod_idx].FormattedValue.ToString();
                    string dat_no = dgv_nodarbibas["dat_no", nod_idx].Value.ToString();
                    string dat_lidz = dgv_nodarbibas["dat_lidz", nod_idx].Value.ToString();
                    string ned_diena = dgv_nodarbibas["ned_diena", nod_idx].FormattedValue.ToString();
                    string laiks = dgv_nodarbibas["laiks", nod_idx].FormattedValue.ToString();
                    string ned_diena2 = dgv_nodarbibas["ned_diena", nod_idx].Value.ToString();
                    string laiks2 = dgv_nodarbibas["laiks", nod_idx].Value.ToString();
                
                    nod_grupu_ievade d_grupas = new nod_grupu_ievade(sl_lietotajs.Text, stud_kurss, nod_veids, dat_no, dat_lidz, ned_diena, laiks, ned_diena2, laiks2);
            
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
                nodarbibasDT.RejectChanges();
                nod_grupasDT.RejectChanges();
            }
        }
        
        void B_saglabat_nodarbibasClick(object sender, EventArgs e)
        {
            NpgsqlCommand iev_kom = new NpgsqlCommand("INSERT INTO nodarbibas VALUES(@id, @id_kkods, @id_macsp, @id_nveids, @dat_no, @dat_lidz, @ned_diena, @laiks);", db.sav);
            iev_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            iev_kom.Parameters.Add("@id_kkods", NpgsqlTypes.NpgsqlDbType.Char, 8, "id_kkods");
            iev_kom.Parameters.AddWithValue("@id_macsp", db.lietotajs);
            iev_kom.Parameters.Add("@id_nveids", NpgsqlTypes.NpgsqlDbType.Integer, 3, "id_nveids");
            iev_kom.Parameters.Add("@dat_no", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_no");
            iev_kom.Parameters.Add("@dat_lidz", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_lidz");
            iev_kom.Parameters.Add("@ned_diena", NpgsqlTypes.NpgsqlDbType.Integer, 1, "ned_diena");
            iev_kom.Parameters.Add("@laiks", NpgsqlTypes.NpgsqlDbType.Integer, 2, "laiks");
            NpgsqlCommand atj_kom = new NpgsqlCommand("UPDATE nodarbibas SET id_kkods = @id_kkods, id_macsp = @id_macsp, id_nveids = @id_nveids, dat_no = @dat_no, dat_lidz = @dat_lidz, ned_diena = @ned_diena, laiks = @laiks WHERE id_nod = @id;", db.sav);
            atj_kom.Parameters.Add("@id_kkods", NpgsqlTypes.NpgsqlDbType.Char, 8, "id_kkods");
            atj_kom.Parameters.AddWithValue("@id_macsp", db.lietotajs);
            atj_kom.Parameters.Add("@id_nveids", NpgsqlTypes.NpgsqlDbType.Integer, 3, "id_nveids");
            atj_kom.Parameters.Add("@dat_no", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_no");
            atj_kom.Parameters.Add("@dat_lidz", NpgsqlTypes.NpgsqlDbType.Date, 11, "dat_lidz");
            atj_kom.Parameters.Add("@ned_diena", NpgsqlTypes.NpgsqlDbType.Integer, 1, "ned_diena");
            atj_kom.Parameters.Add("@laiks", NpgsqlTypes.NpgsqlDbType.Integer, 2, "laiks");
            atj_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            NpgsqlCommand dz_kom = new NpgsqlCommand("DELETE FROM nodarbibas WHERE id_nod = @id AND id_macsp = @id_macsp;", db.sav);
            dz_kom.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            dz_kom.Parameters.AddWithValue("@id_macsp", db.lietotajs);
            
            NpgsqlCommand iev_kom2 = new NpgsqlCommand("INSERT INTO nod_grupas VALUES(@id, @id_nod, @id_prkods, @kurss, @grupa);", db.sav);
            iev_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_grupa");
            iev_kom2.Parameters.Add("@id_nod", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            iev_kom2.Parameters.Add("@id_prkods", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            iev_kom2.Parameters.Add("@kurss", NpgsqlTypes.NpgsqlDbType.Integer, 1, "kurss");
            iev_kom2.Parameters.Add("@grupa", NpgsqlTypes.NpgsqlDbType.Numeric, 3, "grupa");
            NpgsqlCommand atj_kom2 = new NpgsqlCommand("UPDATE nod_grupas SET id_nod = @id_nod, id_prkods = @id_prkods, kurss = @kurss, grupa = @grupa WHERE id_grupa = @id;", db.sav);
            atj_kom2.Parameters.Add("@id_nod", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_nod");
            atj_kom2.Parameters.Add("@id_prkods", NpgsqlTypes.NpgsqlDbType.Char, 5, "id_prkods");
            atj_kom2.Parameters.Add("@kurss", NpgsqlTypes.NpgsqlDbType.Integer, 1, "kurss");
            atj_kom2.Parameters.Add("@grupa", NpgsqlTypes.NpgsqlDbType.Numeric, 3, "grupa");
            atj_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_grupa");
            NpgsqlCommand dz_kom2 = new NpgsqlCommand("DELETE FROM nod_grupas WHERE id_grupa = @id;", db.sav);
            dz_kom2.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer, 9, "id_grupa");
            
            nodarbibasA.InsertCommand = iev_kom;
            nodarbibasA.UpdateCommand = atj_kom;
            nodarbibasA.DeleteCommand = dz_kom;
            nod_grupasA.InsertCommand = iev_kom2;
            nod_grupasA.UpdateCommand = atj_kom2;
            nod_grupasA.DeleteCommand = dz_kom2;
            
            try {
                nodarbibasA.Update(nodarbibasDT);
                nod_grupasA.Update(nod_grupasDT);
                sagl_kluda = false;
            } catch (Exception) {
                sagl_kluda = true;
                db.msgbox_saglabasanas_kluda();
            }
            
            if (!sagl_kluda) {
                nodarbibasDT.AcceptChanges();
                nod_grupasDT.AcceptChanges();
                db.msgbox_izmainas_saglabatas();
            }
        }
        
        // Pārskatu, izdruku cilne un ar to saistītās funkcijas
        
        void nav_datu() {
            string nav_datu = "Nav atlasīti dati";
            
            l_i_stud_kurss_nosauk.Text = nav_datu;
            l_i_nod_veida_nosauk.Text = nav_datu;
            l_i_ned_diena_vert.Text = nav_datu;
            l_i_laiks_vert.Text = nav_datu;
            l_i_dat_no_vert.Text = nav_datu;
            l_i_dat_lidz_vert.Text = nav_datu;
            l_i_stud_prog_nosauk.Text = nav_datu;
            l_i_kurss_vert.Text = nav_datu;
            l_i_grupa_vert.Text = nav_datu;
            
            b_sagatavot_izdruku.Enabled = false;
            b_generet_parskatu.Enabled = false;
        }
        
        void Dgv_nodarbibasSelectionChanged(object sender, EventArgs e)
        {
            if (dgv_nodarbibas.SelectedRows.Count > 0 && dgv_nodarbibas.Columns["id_nod"] != null) {
                int indekss = dgv_nodarbibas.SelectedRows[0].Index;
                
                if (dgv_nodarbibas["id_kkods", indekss].Value.ToString() != "") {
                    l_i_stud_kurss_nosauk.Text = dgv_nodarbibas["id_kkods", indekss].FormattedValue + " (" + dgv_nodarbibas["id_kkods", indekss].Value + ")";
                    l_i_nod_veida_nosauk.Text = dgv_nodarbibas["id_nveids", indekss].FormattedValue.ToString();
                    l_i_ned_diena_vert.Text = dgv_nodarbibas["ned_diena", indekss].FormattedValue.ToString();
                    l_i_laiks_vert.Text = dgv_nodarbibas["laiks", indekss].FormattedValue.ToString();
                    l_i_dat_no_vert.Text = dgv_nodarbibas["dat_no", indekss].Value.ToString().Substring(0, 11);
                    l_i_dat_lidz_vert.Text = dgv_nodarbibas["dat_lidz", indekss].Value.ToString().Substring(0, 11);
                } else {
                    nav_datu();
                }
            } else {
                nav_datu();
            }
        }
        
        void Dgv_nod_grupasSelectionChanged(object sender, EventArgs e)
        {
            if (dgv_nod_grupas.SelectedRows.Count > 0 && dgv_nod_grupas.Columns["id_grupa"] != null) {
                int indekss = dgv_nod_grupas.SelectedRows[0].Index;
                
                if (dgv_nod_grupas["id_prkods", indekss].Value.ToString() != "") {
                    l_i_stud_prog_nosauk.Text = dgv_nod_grupas["id_prkods", indekss].FormattedValue.ToString();
                    l_i_kurss_vert.Text = dgv_nod_grupas["kurss", indekss].Value.ToString();
                    l_i_grupa_vert.Text = dgv_nod_grupas["grupa", indekss].Value.ToString();
                    
                    b_sagatavot_izdruku.Enabled = true;
                    b_generet_parskatu.Enabled = true;
                } else {
                    nav_datu();
                }
            } else {
                nav_datu();
            }
        }
        
        void B_sagatavot_izdrukuClick(object sender, EventArgs e)
        {
            SaveFileDialog d_izdruka = new SaveFileDialog();
            d_izdruka.Title = "Saglabāt nodarbības apmeklējuma lapu...";
            d_izdruka.DefaultExt = "docx";
            d_izdruka.Filter = "MS Word dokuments (*.docx)|*.docx";
            d_izdruka.FileName = "apmeklejumu_lapa-" + String.Format("{0:yyyy-MM-dd}", DateTime.Now);
            
            if (d_izdruka.ShowDialog() == DialogResult.OK) {
                NpgsqlCommand studejosie = new NpgsqlCommand("SELECT s.id_matr, s.vards, s.uzvards FROM studenti s, nodarbibas n, nod_grupas g WHERE n.id_nod = g.id_nod AND s.kurss = g.kurss AND s.grupa = g.grupa AND n.id_nod = @id_nod AND s.id_prkods = @id_prkods AND s.kurss = @kurss AND s.grupa = @grupa ORDER BY s.uzvards;", db.sav);
                studejosie.Parameters.AddWithValue("@id_nod", dgv_nodarbibas["id_nod", dgv_nodarbibas.SelectedRows[0].Index].Value.ToString());
                studejosie.Parameters.AddWithValue("@id_prkods", dgv_nod_grupas["id_prkods", dgv_nod_grupas.SelectedRows[0].Index].Value.ToString());
                studejosie.Parameters.AddWithValue("@kurss", l_i_kurss_vert.Text);
                studejosie.Parameters.AddWithValue("@grupa", l_i_grupa_vert.Text);
                
                NpgsqlCommand datumi = new NpgsqlCommand("SELECT DISTINCT a.datums FROM apmeklejumi a WHERE a.id_nod = @id_nod ORDER BY a.datums;", db.sav);
                datumi.Parameters.AddWithValue("@id_nod", dgv_nodarbibas["id_nod", dgv_nodarbibas.SelectedRows[0].Index].Value.ToString());
                
                DataTable studejosieDT = new DataTable("studejosie");
                NpgsqlDataAdapter studejosieA = new NpgsqlDataAdapter();
                studejosieA.SelectCommand = studejosie;
                studejosieA.Fill(studejosieDT);
                
                DataTable datumiDT = new DataTable("datumi");
                NpgsqlDataAdapter datumiA = new NpgsqlDataAdapter();
                datumiA.SelectCommand = datumi;
                datumiA.Fill(datumiDT);
                
                using (DocX izdruka = DocX.Create(d_izdruka.FileName)) {
                    izdruka.PageLayout.Orientation = Novacode.Orientation.Landscape;
                    
                    izdruka.AddHeaders();
                    Header galvene = izdruka.Headers.odd;
                    Paragraph g1 = galvene.InsertParagraph();
                    g1.Alignment = Alignment.center;
                    g1.Append("Nodarbību apmeklējuma uzskaites sistēma (NAUS) - ").Append("Nodarbību apmeklējuma lapa").Bold();
                    
                    Paragraph virsraksts = izdruka.InsertParagraph();
                    virsraksts.Alignment = Alignment.center;
                    virsraksts.FontSize(14);
                    virsraksts.Append(l_i_stud_kurss_nosauk.Text).Bold().FontSize(14);
                    
                    Paragraph info = izdruka.InsertParagraph();
                    info.AppendLine().Append("Mācībspēks: ").Append(sl_lietotajs.Text).Bold()
                        .AppendLine().Append("Nodarbības veids: ").Append(l_i_nod_veida_nosauk.Text).Bold()
                        .Append("       Norises laiks: ").Append(l_i_ned_diena_vert.Text + ", plkst. " + l_i_laiks_vert.Text).Bold()
                        .AppendLine().AppendLine()
                        .Append(l_i_stud_prog_nosauk.Text + " " + l_i_kurss_vert.Text + ". kurss " + l_i_grupa_vert.Text + ". grupa").Bold().Italic()
                        .AppendLine();
                    
                    int rindas = studejosieDT.Rows.Count;
                    int kolonnas = datumiDT.Rows.Count;
                    
                    if (kolonnas > 9) {
                        kolonnas = 9;
                    }
                    
                    Table tabula = izdruka.AddTable(1 + rindas, 4 + kolonnas);
                    tabula.AutoFit = AutoFit.Contents;
                    
                    tabula.Rows[0].Cells[0].Paragraphs[0].InsertText("Nr.");
                    tabula.Rows[0].Cells[1].Paragraphs[0].InsertText("Matrikulas nr.");
                    tabula.Rows[0].Cells[2].Paragraphs[0].InsertText("Vārds");
                    tabula.Rows[0].Cells[3].Paragraphs[0].InsertText("Uzvārds");
                    
                    for (int i = 0; i < kolonnas; i++) {
                        tabula.Rows[0].Cells[4 + i].Paragraphs[0].InsertText(DateTime.Parse(datumiDT.Rows[i]["datums"].ToString()).ToString("dd.MM."));
                    }
                    
                    for (int i = 0; i < kolonnas; i++) {
                        tabula.Rows[1 + i].Cells[0].Paragraphs[0].InsertText((i + 1) + ".");
                        tabula.Rows[1 + i].Cells[1].Paragraphs[0].InsertText(studejosieDT.Rows[i]["id_matr"].ToString());
                        tabula.Rows[1 + i].Cells[2].Paragraphs[0].InsertText(studejosieDT.Rows[i]["vards"].ToString());
                        tabula.Rows[1 + i].Cells[3].Paragraphs[0].InsertText(studejosieDT.Rows[i]["uzvards"].ToString());
                        
                        for (int j = 0; j < 8; j++) {
                            tabula.Rows[1 + i].Cells[4 + j].Paragraphs[0].InsertText("");
                        }
                    }
                    
                    izdruka.InsertTable(tabula);
                    
                    izdruka.AddFooters();
                    Footer kajene = izdruka.Footers.odd;
                    Paragraph k1 = kajene.InsertParagraph();
                    k1.Append("Izdrukas sagatavošanas datums: " + db.datuma_virkne(DateTime.Now, false));
                    
                    izdruka.Save();
                }
                
                MessageBox.Show("Nodarbību apmeklējuma lapas izdruka veiksmīgi saglabāta datnē " + d_izdruka.FileName, "Izdruka sagatavota", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        void B_generet_parskatuClick(object sender, EventArgs e)
        {
            if (dgv_nodarbibas.SelectedRows.Count > 0 && dgv_nod_grupas.SelectedRows.Count > 0) {
                int indekss = dgv_nodarbibas.SelectedRows[0].Index;
                int indekss2 = dgv_nod_grupas.SelectedRows[0].Index;
                
                studentu_gr_apmeklejumi d_apmeklejumi = new studentu_gr_apmeklejumi(dgv_nodarbibas["id_nod", indekss].Value.ToString(), dgv_nod_grupas["id_prkods", indekss2].Value.ToString(), l_i_stud_prog_nosauk.Text, dgv_nod_grupas["kurss", indekss2].Value.ToString(), dgv_nod_grupas["grupa", indekss2].Value.ToString());
                d_apmeklejumi.Show();
            }
        }
        
        void MacibspeksFormClosing(object sender, FormClosingEventArgs e)
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
        
        void MacibspeksFormClosed(object sender, FormClosedEventArgs e)
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
        
        
        void AktīvāsNodarbībasApmeklējumiToolStripMenuItemClick(object sender, EventArgs e)
        {
            tabc_cilnes.SelectedIndex = 0;
        }
        
        void VisuNodarbībuApmeklējumiToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (aktīvāsNodarbībasApmeklējumiToolStripMenuItem.Visible) {
                tabc_cilnes.SelectedIndex = 1;
            } else {
                tabc_cilnes.SelectedIndex = 0;
            }
        }
        
        void NodarbībuPlānošanaToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (aktīvāsNodarbībasApmeklējumiToolStripMenuItem.Visible) {
                tabc_cilnes.SelectedIndex = 2;
            } else {
                tabc_cilnes.SelectedIndex = 1;
            }
        }
        
        void PārskatiUnIzdrukasToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (aktīvāsNodarbībasApmeklējumiToolStripMenuItem.Visible) {
                tabc_cilnes.SelectedIndex = 3;
            } else {
                tabc_cilnes.SelectedIndex = 2;
            }
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
