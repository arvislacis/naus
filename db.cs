using System;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Npgsql;

namespace naus
{
    public static class db
    {
        public static NpgsqlConnection sav = new NpgsqlConnection("server=localhost;port=5432;database=naus;uid=arvis;pwd=lacis;protocol=3;ssl=true;sslmode=require;");

        public static string[] MENESI = {"decembris", "janvāris", "februāris", "marts", "aprīlis", "maijs", "jūnijs", "jūlijs", "augusts", "septembris", "oktobris", "novembris"};
        public static string[] NED_DIENAS = {"Svētdiena", "Pirmdiena", "Otrdiena", "Trešdiena", "Ceturtdiena", "Piektdiena", "Sestdiena"};

        public static string liet_grupa, lietotajs, vards, uzvards, zin_grads, amats, pr_nosaukums, pr_kods, parole;
        public static int kurss;
        public static double grupa;

        public static DataTable grupasDT = iegut_grupas();
        public static DataTable kursiDT = iegut_kursus();
        public static DataTable laikiDT = iegut_laikus();
        public static DataTable n_dienasDT = iegut_nedelas_dienas();

        public static DataTable macibspekiDT = iegut_macibspekus();
        public static DataTable nod_veidiDT = iegut_nod_veidus();
        public static DataTable stud_kursiDT = iegut_studiju_kursus();
        public static DataTable stud_progDT = iegut_studiju_programmas();

        public static datu_ielade ielades_forma = new datu_ielade();

        public static string lv_burti = "Laukam jāsatur tikai latviešu alfabēta burtus";
        public static string obligats = "Ievadlaukam jābūt obligāti aizpildītam";

        public static string datuma_virkne(DateTime datums, bool laiks)
        {
            string virkne = NED_DIENAS[(int)datums.DayOfWeek] + ", " + datums.Year + ". gada " + datums.Day + ". " + MENESI[datums.Month];

            if (laiks) {
                int stundas = datums.Hour;
                int minutes = datums.Minute;

                virkne += ", plkst. ";

                if (stundas < 10) {
                    virkne += "0" + stundas;
                } else {
                    virkne += stundas;
                }

                virkne += ":";

                if (datums.Minute < 10) {
                    virkne += "0" + minutes;
                } else {
                    virkne += minutes;
                }
            }

            return virkne;
        }

        public static DataTable iegut_grupas()
        {
            DataTable grupas = new DataTable("grupas");
            grupas.Columns.Add("grupa", typeof(float));

            grupas.Rows.Add(1);
            grupas.Rows.Add(1.1);
            grupas.Rows.Add(1.2);
            grupas.Rows.Add(2);
            grupas.Rows.Add(2.1);
            grupas.Rows.Add(2.2);

            return grupas;
        }

        public static DataTable iegut_macibspekus()
        {
            NpgsqlDataAdapter macibspekiA = new NpgsqlDataAdapter("SELECT id_macsp, (vards || ' ' || uzvards) m_v_uzv FROM macibspeki ORDER BY uzvards;", sav);
            DataTable macibspeki = new DataTable("macibspeki");

            macibspekiA.Fill(macibspeki);

            return macibspeki;
        }

        public static DataTable iegut_kursus()
        {
            DataTable kursi = new DataTable("kursi");
            kursi.Columns.Add("kurss", typeof(int));

            kursi.Rows.Add(1);
            kursi.Rows.Add(2);
            kursi.Rows.Add(3);
            kursi.Rows.Add(4);

            return kursi;
        }

        public static DataTable iegut_laikus()
        {
            DataTable laiki = new DataTable("laiki");
            laiki.Columns.Add("laiks", typeof(int));
            laiki.Columns.Add("virkne", typeof(string));

            laiki.Rows.Add(8, "8:30 - 9:15");
            laiki.Rows.Add(9, "9:30 - 10:15");
            laiki.Rows.Add(10, "10:30 - 11:15");
            laiki.Rows.Add(11, "11:30 - 12:15");
            laiki.Rows.Add(12, "12:30 - 13:15");
            laiki.Rows.Add(13, "13:30 - 14:15");
            laiki.Rows.Add(14, "14:30 - 15:15");
            laiki.Rows.Add(15, "15:30 - 16:15");
            laiki.Rows.Add(16, "16:30 - 17:15");
            laiki.Rows.Add(17, "17:30 - 18:15");
            laiki.Rows.Add(18, "18:30 - 19:15");
            laiki.Rows.Add(19, "19:30 - 20:15");
            laiki.Rows.Add(20, "20:30 - 21:15");

            return laiki;
        }

        public static DataTable iegut_nedelas_dienas()
        {
            DataTable ned_dienas = new DataTable("ned_dienas");
            ned_dienas.Columns.Add("ned_diena", typeof(int));
            ned_dienas.Columns.Add("nosaukums", typeof(string));

            ned_dienas.Rows.Add(1, "Pirmdiena");
            ned_dienas.Rows.Add(2, "Otrdiena");
            ned_dienas.Rows.Add(3, "Trešdiena");
            ned_dienas.Rows.Add(4, "Ceturtdiena");
            ned_dienas.Rows.Add(5, "Piektdiena");
            ned_dienas.Rows.Add(6, "Sestdiena");

            return ned_dienas;
        }

        public static DataTable iegut_nod_veidus()
        {
            DataTable nod_veidi = new DataTable("nod_veidi");
            NpgsqlDataAdapter nod_veidiA = new NpgsqlDataAdapter("SELECT id_nveids, veids FROM nod_veidi;", sav);

            nod_veidiA.Fill(nod_veidi);

            return nod_veidi;
        }

        public static DataTable iegut_studiju_kursus()
        {
            NpgsqlDataAdapter stud_kursiA = new NpgsqlDataAdapter("SELECT id_kkods, nosaukums FROM stud_kursi ORDER BY nosaukums;", sav);
            DataTable stud_kursi = new DataTable("stud_kursi");

            stud_kursiA.Fill(stud_kursi);

            return stud_kursi;
        }

        public static DataTable iegut_studiju_programmas()
        {
            NpgsqlDataAdapter stud_progA = new NpgsqlDataAdapter("SELECT id_prkods, (nosaukums || ' (' || id_prkods || ')') nosauk_kods FROM stud_prog;", sav);
            DataTable stud_prog = new DataTable("stud_prog");

            stud_progA.Fill(stud_prog);

            return stud_prog;
        }

        public static bool latviesu_burti(string virkne)
        {
            if (Regex.IsMatch(virkne, @"^[A-ZĀČĒĢĪĶĻŅŠŪŽa-zāčēģīķļņšūž\s]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static bool latviesu_burti_cipari(string virkne)
        {
            if (Regex.IsMatch(virkne, @"^[A-ZĀČĒĢĪĶĻŅŠŪŽa-zāčēģīķļņšūž0-9\s\.\-]*$")) {
                return true;
            } else {
                return false;
            }
        }

        public static DialogResult msgbox_atcelt_izmainas()
        {
            return MessageBox.Show("Vai tiešām vēlaties atcelt esošajā lietojuma sadaļā veiktās izmaiņas?", "Vai atcelt izmaiņas?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult msgbox_dzesanas_apstiprinajums()
        {
            return MessageBox.Show("Vai tiešām vēlaties dzēst izvēlēto ierakstu un visu ar to saistīto informāciju?", "Vai dzēst ierakstu?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult msgbox_iziet()
        {
            return MessageBox.Show("NAUS datu bāzē nesaglabātās izmaiņas tiks atceltas.\n\nVai tiešām vēlaties pārtraukt darbu ar aktīvo sesiju?", "Vai iziet?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void msgbox_nav_dzesamo()
        {
            MessageBox.Show("Saraksta logā nav izvēlēts neviens dzēšamais ieraksts!", "Nav dzēšamo datu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void msgbox_nav_labojamo()
        {
            MessageBox.Show("Saraksta logā nav izvēlēts neviens labojamais ieraksts!", "Nav labojamo datu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void msgbox_nevar_atcelt()
        {
            MessageBox.Show("Neizdevās atcelt veiktās izmaiņas, jo vairs neeksistē saistītie dati no citās datu bāzes tabulās!", "Izmaiņu atcelšana neizdevās", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void msgbox_par()
        {
            MessageBox.Show("Nodarbību apmeklējuma uzskaites sistēma (NAUS) v1.0.0\n\nLietojumprogramma LLU ITF studējošo nodarbību apmeklējuma un kavējuma datu administrēšanai, reģistrēšanai un pārskatu, kopsavilkumu veidošanai.\n\nLatvijas Lauksaimniecības universitāte\nInformācijas tehnoloģiju fakultāte\n3. kurss Programmēšana\n\nKursa darbs studiju priekšmetā Lietojumu programmēšana datubāzēm\n\n© 2015 Arvis Lācis", "Par Nodarbību apmeklējuma uzskaites sistēmu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void msgbox_izmainas_saglabatas()
        {
            MessageBox.Show("Veiktās izmaiņas veiksmīgi saglabātas NAUS datu bāzē.", "Izmaiņas saglabātas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void msgbox_saglabasanas_kluda()
        {
            MessageBox.Show("Veikto izmaiņu saglabāšanas procesā radās neparedzēta kļūda!\n\nPārskatiet veiktās izmaiņas un ievadīto datu pareizību; mēģiniet atkārtot datu saglabāšanu vēlāk, veicot atkārtotu pieslēgšanos sistēmai.", "Kļūda izmaiņu saglabāšanas procesā", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void nodarbibu_saraksts()
        {
            Process.Start("http://lais.llu.lv/luis/LS2015p.html");
        }

        public static void sutit_atsauksmi()
        {
            try {
                Process.Start("mailto:arvis.lacis@gmail.com?subject=" + Application.ProductName.ToString() + " " + Application.ProductVersion.ToString());
            } catch (Exception) {
                MessageBox.Show("Lai NAUS lietojumprogrammas izstrādātājam nosūtītu atsauksmi, datorā jābūt instalētam un konfigurētam e-pasta klientam.", "Netika atrasts e-pasta klients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static string SHA1Parole(string lietotajvards, string parole)
        {
            SHA1 sha1 = SHA1.Create();
            StringBuilder sha1parole = new StringBuilder();

            string virkne = lietotajvards + "&NAUS&" + parole;
            byte[] baiti = Encoding.UTF8.GetBytes(virkne);
            byte[] hashBaiti = sha1.ComputeHash(baiti);

            foreach (byte b in hashBaiti) {
                string hex = b.ToString("x2");
                sha1parole.Append(hex);
            }

            return sha1parole.ToString();
        }
    }
}
