namespace FossAnalizAktarma
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.fbdKlasor = new System.Windows.Forms.FolderBrowserDialog();
            this.ntBildirim = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnHedefAc = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaynakAc = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtDbIsmi = new System.Windows.Forms.TextBox();
            this.txtDbIpAdresi = new System.Windows.Forms.TextBox();
            this.txtHedefKlasor = new System.Windows.Forms.TextBox();
            this.txtKaynakKlasor = new System.Windows.Forms.TextBox();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // ntBildirim
            // 
            this.ntBildirim.Icon = ((System.Drawing.Icon)(resources.GetObject("ntBildirim.Icon")));
            this.ntBildirim.Text = "Analiz Aktarım Programı";
            this.ntBildirim.Visible = true;
            this.ntBildirim.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntBildirim_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Ayarlar";
            this.tabNavigationPage2.Controls.Add(this.btnCikis);
            this.tabNavigationPage2.Controls.Add(this.btnKaydet);
            this.tabNavigationPage2.Controls.Add(this.btnHedefAc);
            this.tabNavigationPage2.Controls.Add(this.btnKaynakAc);
            this.tabNavigationPage2.Controls.Add(this.label7);
            this.tabNavigationPage2.Controls.Add(this.label6);
            this.tabNavigationPage2.Controls.Add(this.label5);
            this.tabNavigationPage2.Controls.Add(this.label4);
            this.tabNavigationPage2.Controls.Add(this.label3);
            this.tabNavigationPage2.Controls.Add(this.label1);
            this.tabNavigationPage2.Controls.Add(this.txtSifre);
            this.tabNavigationPage2.Controls.Add(this.txtKullaniciAdi);
            this.tabNavigationPage2.Controls.Add(this.txtDbIsmi);
            this.tabNavigationPage2.Controls.Add(this.txtDbIpAdresi);
            this.tabNavigationPage2.Controls.Add(this.txtHedefKlasor);
            this.tabNavigationPage2.Controls.Add(this.txtKaynakKlasor);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(346, 149);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(297, 115);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(44, 23);
            this.btnCikis.TabIndex = 1;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(297, 89);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(44, 20);
            this.btnKaydet.TabIndex = 15;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnHedefAc
            // 
            this.btnHedefAc.Location = new System.Drawing.Point(297, 38);
            this.btnHedefAc.Name = "btnHedefAc";
            this.btnHedefAc.Size = new System.Drawing.Size(44, 20);
            this.btnHedefAc.TabIndex = 14;
            this.btnHedefAc.Text = "Aç";
            this.btnHedefAc.Click += new System.EventHandler(this.btnHedefAc_Click);
            // 
            // btnKaynakAc
            // 
            this.btnKaynakAc.Location = new System.Drawing.Point(297, 17);
            this.btnKaynakAc.Name = "btnKaynakAc";
            this.btnKaynakAc.Size = new System.Drawing.Size(44, 20);
            this.btnKaynakAc.TabIndex = 13;
            this.btnKaynakAc.Text = "Aç";
            this.btnKaynakAc.Click += new System.EventHandler(this.btnKaynakAc_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Hedef Klasör";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "DB Ip Adresi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "DB İsmi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Şifre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kaynak Klasör";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(108, 117);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(185, 20);
            this.txtSifre.TabIndex = 6;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(108, 97);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(185, 20);
            this.txtKullaniciAdi.TabIndex = 5;
            // 
            // txtDbIsmi
            // 
            this.txtDbIsmi.Location = new System.Drawing.Point(108, 77);
            this.txtDbIsmi.Name = "txtDbIsmi";
            this.txtDbIsmi.Size = new System.Drawing.Size(185, 20);
            this.txtDbIsmi.TabIndex = 4;
            // 
            // txtDbIpAdresi
            // 
            this.txtDbIpAdresi.Location = new System.Drawing.Point(108, 57);
            this.txtDbIpAdresi.Name = "txtDbIpAdresi";
            this.txtDbIpAdresi.Size = new System.Drawing.Size(185, 20);
            this.txtDbIpAdresi.TabIndex = 3;
            // 
            // txtHedefKlasor
            // 
            this.txtHedefKlasor.Location = new System.Drawing.Point(108, 37);
            this.txtHedefKlasor.Name = "txtHedefKlasor";
            this.txtHedefKlasor.ReadOnly = true;
            this.txtHedefKlasor.Size = new System.Drawing.Size(185, 20);
            this.txtHedefKlasor.TabIndex = 2;
            // 
            // txtKaynakKlasor
            // 
            this.txtKaynakKlasor.Location = new System.Drawing.Point(108, 17);
            this.txtKaynakKlasor.Name = "txtKaynakKlasor";
            this.txtKaynakKlasor.ReadOnly = true;
            this.txtKaynakKlasor.Size = new System.Drawing.Size(185, 20);
            this.txtKaynakKlasor.TabIndex = 1;
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage2});
            this.tabPane1.RegularSize = new System.Drawing.Size(364, 194);
            this.tabPane1.SelectedPage = this.tabNavigationPage2;
            this.tabPane1.Size = new System.Drawing.Size(364, 194);
            this.tabPane1.TabIndex = 0;
            this.tabPane1.Text = "f";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 194);
            this.Controls.Add(this.tabPane1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabNavigationPage2.ResumeLayout(false);
            this.tabNavigationPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.FolderBrowserDialog fbdKlasor;
        private System.Windows.Forms.NotifyIcon ntBildirim;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnHedefAc;
        private DevExpress.XtraEditors.SimpleButton btnKaynakAc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtDbIsmi;
        private System.Windows.Forms.TextBox txtDbIpAdresi;
        private System.Windows.Forms.TextBox txtHedefKlasor;
        private System.Windows.Forms.TextBox txtKaynakKlasor;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
    }
}

