using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FossAnalizAktarma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=" + Properties.Settings.Default.DbIp + "; Database=" + Properties.Settings.Default.DbIsmi + ";" +
            "uid=" + Properties.Settings.Default.DbKullaniciAdi + ";pwd=" + Properties.Settings.Default.DbSifre + ";");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string tasinacakDosya = "";
        string DosyaIsmi = "";
        bool tamamenKapat = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                formAyarlari();
                //timer1.Start();

            }
            catch (Exception ex)
            {
                Bildirim(ex.Message, 0);
            }
        }

        private void formAyarlari()
        {
            txtKaynakKlasor.Text = Properties.Settings.Default.kaynakKlasor;
            txtHedefKlasor.Text = Properties.Settings.Default.hedefKlasor;
            txtDbIpAdresi.Text = Properties.Settings.Default.DbIp;
            txtDbIsmi.Text = Properties.Settings.Default.DbIsmi;
            txtKullaniciAdi.Text = Properties.Settings.Default.DbKullaniciAdi;
            txtSifre.Text = Properties.Settings.Default.DbSifre;
        }

        private void btnKaynakAc_Click(object sender, EventArgs e)
        {
            fbdKlasor.ShowNewFolderButton = true;
            DialogResult basilan = fbdKlasor.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                txtKaynakKlasor.Text = fbdKlasor.SelectedPath;
                Properties.Settings.Default.kaynakKlasor = txtKaynakKlasor.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void btnHedefAc_Click(object sender, EventArgs e)
        {

            fbdKlasor.ShowNewFolderButton = true;
            DialogResult basilan = fbdKlasor.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                txtHedefKlasor.Text = fbdKlasor.SelectedPath;
                Properties.Settings.Default.hedefKlasor = txtHedefKlasor.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bool txtKontrol = true;
            foreach (Control item in tabNavigationPage2.Controls)
            {
                if ((item is TextBox) & (item.Text == "")) { item.Focus(); txtKontrol = false; }
            }
            if (txtKontrol)
            {
                try
                {
                    SqlConnection baglantiTest = new SqlConnection("Data Source=" + txtDbIpAdresi.Text + "; Database=" + txtDbIsmi.Text + ";" +
                        "uid=" + txtKullaniciAdi.Text + ";pwd=" + txtSifre.Text + ";");
                    baglantiTest.Open();
                    if (baglantiTest.State == ConnectionState.Open)
                    {
                        baglantiTest.Close();
                        Bildirim("Veritabanı Bağlantısı Başarılı", 0);
                        Properties.Settings.Default.kaynakKlasor = txtKaynakKlasor.Text;
                        Properties.Settings.Default.hedefKlasor = txtHedefKlasor.Text;
                        Properties.Settings.Default.DbIp = txtDbIpAdresi.Text;
                        Properties.Settings.Default.DbIsmi = txtDbIsmi.Text;
                        Properties.Settings.Default.DbKullaniciAdi = txtKullaniciAdi.Text;
                        Properties.Settings.Default.DbSifre = txtSifre.Text;
                        Properties.Settings.Default.Save();
                        klasorDizinleriniOlustur();
                        xmlOku();
                        timer1.Start();
                        //csvOku();
                        this.Hide();

                    }
                }
                catch (Exception ex)
                {
                    Bildirim("Veritabanı Bağlantı Hatası\n"+ex.Message, 1);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun !!!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void csvOku()
        {
            try
            {
                DirectoryInfo dizin = new DirectoryInfo(Properties.Settings.Default.kaynakKlasor);
                FileInfo[] fileName = dizin.GetFiles();
                dt = new DataTable();
                foreach (FileInfo fi in fileName)
                {
                    if (fi.Extension == ".csv")
                    {
                        string[] satirlar = File.ReadAllLines(fi.FullName);
                        if (satirlar.Length > 0)
                        {
                            string ilkSatir = satirlar[0];
                            string[] basliklar = ilkSatir.Split(';');
                            foreach (string item in basliklar)
                            {
                                dt.Columns.Add(new DataColumn(item));
                            }
                            for (int i = 0; i < satirlar.Length; i++)
                            {
                                string[] veriler = satirlar[i].Split(';');
                                DataRow dr = dt.NewRow();
                                int columnIndex = 0;
                                foreach (var veri in basliklar)
                                {
                                    dr[veri] = veriler[columnIndex++];
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        FileStream fs;
        private void xmlOku()
        {
            try
            {

                DirectoryInfo dizin = new DirectoryInfo(Properties.Settings.Default.kaynakKlasor);
                FileInfo[] fileName = dizin.GetFiles();
                foreach (FileInfo fi in fileName)
                {
                    if (fi.Extension == ".xml")
                    {
                        tasinacakDosya = "";
                        DosyaIsmi = "";
                        ds = new DataSet();
                        fs = new FileStream(fi.FullName, FileMode.Open);
                        ds.ReadXml(fs);
                        tasinacakDosya = fi.FullName;
                        DosyaIsmi = fi.Name;
                        fs.Close();
                        //if (ds.Tables[2].Rows.Count > 0 & ds.Tables[2].Rows[2][0].ToString()== "Barley I - Arpa") { dosyaTasi(); }
                        if (ds.Tables[2].Rows.Count > 0) { dosyaTasi(); }
                    }
                }
            }
            catch (Exception ex)
            {
                fs.Close();
                Bildirim(ex.Message, 1);
            }
        }

        private void sqlEkle()
        {
            if (ds.Tables[2].Rows[2][0].ToString() == "Barley I - Arpa")
            {
                string sorgu = "insert into fossTable(AnalysisDate,AnalysisTime, ProductName,SampleNumber, Protein, Moisture,Tw,Tarih,Bilgisayar) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9)";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@1", Convert.ToDateTime(ds.Tables[2].Rows[0][0].ToString()));//AnalysisDate
                cmd.Parameters.AddWithValue("@2", Convert.ToDateTime(ds.Tables[2].Rows[1][0].ToString()));//AnalysisTime
                cmd.Parameters.AddWithValue("@3", ds.Tables[2].Rows[2][0].ToString());//ProductName
                cmd.Parameters.AddWithValue("@4", ds.Tables[2].Rows[4][0].ToString());//SampleNumber
                cmd.Parameters.AddWithValue("@5", ds.Tables[2].Rows[5][0].ToString().Split(' ')[0]);//Protein
                cmd.Parameters.AddWithValue("@6", ds.Tables[2].Rows[6][0].ToString().Split(' ')[0]);//Moisture
                cmd.Parameters.AddWithValue("@7", ds.Tables[2].Rows[7][0].ToString().Split(' ')[0]);//Tw
                cmd.Parameters.AddWithValue("@8", DateTime.Now);//Tarih
                cmd.Parameters.AddWithValue("@9", System.Net.Dns.GetHostName());//Bilgisayar
                cmd.ExecuteNonQuery();
                //dosyaTasi();
            }
            else if (ds.Tables[2].Rows[2][0].ToString() == "Wheat II - Bugday")
            {
                string sorgu = "insert into fossTable(AnalysisDate,AnalysisTime, ProductName,SampleNumber, Protein, Moisture,Tw,Tarih,Bilgisayar,Gluten,Zeleny) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@1", Convert.ToDateTime(ds.Tables[2].Rows[0][0].ToString()));//AnalysisDate
                cmd.Parameters.AddWithValue("@2", Convert.ToDateTime(ds.Tables[2].Rows[1][0].ToString()));//AnalysisTime
                cmd.Parameters.AddWithValue("@3", ds.Tables[2].Rows[2][0].ToString());//ProductName
                cmd.Parameters.AddWithValue("@4", ds.Tables[2].Rows[4][0].ToString());//SampleNumber
                cmd.Parameters.AddWithValue("@5", ds.Tables[2].Rows[5][0].ToString().Split(' ')[0]);//Protein
                cmd.Parameters.AddWithValue("@6", ds.Tables[2].Rows[6][0].ToString().Split(' ')[0]);//Moisture
                cmd.Parameters.AddWithValue("@7", ds.Tables[2].Rows[10][0].ToString().Split(' ')[0]);//Tw
                cmd.Parameters.AddWithValue("@8", DateTime.Now);//Tarih
                cmd.Parameters.AddWithValue("@9", System.Net.Dns.GetHostName());//Bilgisayar
                cmd.Parameters.AddWithValue("@10", ds.Tables[2].Rows[8][0].ToString().Split(' ')[0]);//Gluten
                cmd.Parameters.AddWithValue("@11", ds.Tables[2].Rows[9][0].ToString().Split(' ')[0]);//Zeleny
                cmd.ExecuteNonQuery();
                //dosyaTasi();
            }
            else if (ds.Tables[2].Rows[2][0].ToString() == "Corn - Misir")
            {
                string sorgu = "insert into fossTable(AnalysisDate,AnalysisTime, ProductName,SampleNumber, Protein, Moisture,Tw,Tarih,Bilgisayar) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9)";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@1", Convert.ToDateTime(ds.Tables[2].Rows[0][0].ToString()));//AnalysisDate
                cmd.Parameters.AddWithValue("@2", Convert.ToDateTime(ds.Tables[2].Rows[1][0].ToString()));//AnalysisTime
                cmd.Parameters.AddWithValue("@3", ds.Tables[2].Rows[2][0].ToString());//ProductName
                cmd.Parameters.AddWithValue("@4", ds.Tables[2].Rows[4][0].ToString());//SampleNumber
                cmd.Parameters.AddWithValue("@5", ds.Tables[2].Rows[5][0].ToString().Split(' ')[0]);//Protein
                cmd.Parameters.AddWithValue("@6", ds.Tables[2].Rows[6][0].ToString().Split(' ')[0]);//Moisture
                cmd.Parameters.AddWithValue("@7", ds.Tables[2].Rows[9][0].ToString().Split(' ')[0]);//Tw
                cmd.Parameters.AddWithValue("@8", DateTime.Now);//Tarih
                cmd.Parameters.AddWithValue("@9", System.Net.Dns.GetHostName());//Bilgisayar               
                cmd.ExecuteNonQuery();
            }
            else if (ds.Tables[2].Rows[2][0].ToString() == "Durum Bugday")
            {
                string sorgu = "insert into fossTable(AnalysisDate,AnalysisTime, ProductName,SampleNumber, Protein, Moisture,Tw,Tarih,Bilgisayar) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9)";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@1", Convert.ToDateTime(ds.Tables[2].Rows[0][0].ToString()));//AnalysisDate
                cmd.Parameters.AddWithValue("@2", Convert.ToDateTime(ds.Tables[2].Rows[1][0].ToString()));//AnalysisTime
                cmd.Parameters.AddWithValue("@3", ds.Tables[2].Rows[2][0].ToString());//ProductName
                cmd.Parameters.AddWithValue("@4", ds.Tables[2].Rows[4][0].ToString());//SampleNumber
                cmd.Parameters.AddWithValue("@5", ds.Tables[2].Rows[5][0].ToString().Split(' ')[0]);//Protein
                cmd.Parameters.AddWithValue("@6", ds.Tables[2].Rows[6][0].ToString().Split(' ')[0]);//Moisture
                cmd.Parameters.AddWithValue("@7", ds.Tables[2].Rows[9][0].ToString().Split(' ')[0]);//Tw
                cmd.Parameters.AddWithValue("@8", DateTime.Now);//Tarih
                cmd.Parameters.AddWithValue("@9", System.Net.Dns.GetHostName());//Bilgisayar
                cmd.ExecuteNonQuery();
                //dosyaTasi();
            }
            else if (ds.Tables[2].Rows[2][0].ToString() == "Triticale II")
            {
                string sorgu = "insert into fossTable(AnalysisDate,AnalysisTime, ProductName,SampleNumber, Protein, Moisture,Tw,Tarih,Bilgisayar) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9)";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@1", Convert.ToDateTime(ds.Tables[2].Rows[0][0].ToString()));//AnalysisDate
                cmd.Parameters.AddWithValue("@2", Convert.ToDateTime(ds.Tables[2].Rows[1][0].ToString()));//AnalysisTime
                cmd.Parameters.AddWithValue("@3", ds.Tables[2].Rows[2][0].ToString());//ProductName
                cmd.Parameters.AddWithValue("@4", ds.Tables[2].Rows[4][0].ToString());//SampleNumber
                cmd.Parameters.AddWithValue("@5", ds.Tables[2].Rows[5][0].ToString().Split(' ')[0]);//Protein
                cmd.Parameters.AddWithValue("@6", ds.Tables[2].Rows[6][0].ToString().Split(' ')[0]);//Moisture
                cmd.Parameters.AddWithValue("@7", ds.Tables[2].Rows[7][0].ToString().Split(' ')[0]);//Tw
                cmd.Parameters.AddWithValue("@8", DateTime.Now);//Tarih
                cmd.Parameters.AddWithValue("@9", System.Net.Dns.GetHostName());//Bilgisayar
                cmd.ExecuteNonQuery();
                //dosyaTasi();
            }

        }

        private void dosyaTasi()
        {
            try
            {
                File.Move(tasinacakDosya, Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\" + DosyaIsmi);
                File.Delete(tasinacakDosya);
                if (ds.Tables[2].Rows.Count > 0) { sqlEkle(); }
                Bildirim(tasinacakDosya + "\nAktarıldı !!!", 0);
            }
            catch (Exception ex)
            {
                Bildirim(tasinacakDosya + "\n"+ex.Message, 1);
            }
        }

        private void klasorDizinleriniOlustur()
        {
            if (Directory.Exists(Properties.Settings.Default.hedefKlasor))
            {
                if (Directory.Exists(Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year))
                {
                    if (Directory.Exists(Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month))
                    {
                        if (!(Directory.Exists(Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day)))
                        {
                            Directory.CreateDirectory(Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day);
                    }
                }
                else
                {
                    Directory.CreateDirectory(Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day);
                }
            }
            else
            {
                Directory.CreateDirectory(Properties.Settings.Default.hedefKlasor + "\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized) Bildirim("Program Arka Planda Çalışıyor", 0);
            ntBildirim.MouseDoubleClick += new MouseEventHandler(ntBildirim_MouseDoubleClick);
        }

        private void ntBildirim_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
           // ntBildirim.Visible = false;
        }

        private void Bildirim(string msg, int durum)
        {
            if (durum == 0) { ntBildirim.ShowBalloonTip(2000, "Aktarım", msg, ToolTipIcon.Info); }
            if (durum == 1) { ntBildirim.ShowBalloonTip(2000, "Aktarım", msg, ToolTipIcon.Error); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tamamenKapat)
            {
                e.Cancel = false;
            }
            else
            {
                btnKaydet_Click(sender, e);
                e.Cancel = true;
                ntBildirim.Visible = true;
                Bildirim("Program Arka Planda Çalışıyor", 0);
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            klasorDizinleriniOlustur();
            xmlOku();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            tamamenKapat = true;
            Application.Exit();
           
        }
    }
}
