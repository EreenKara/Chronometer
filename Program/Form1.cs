using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kronometre2
{
    class Hesapla
    {
        public long saniye = 0;
        public long dakika = 0;
        public long saat = 0;
        public string kronometre = "";

        public void SaniyetoDakika(ref long saniye)
        {
            if (saniye == 60)
            {
                saniye = 0;
                dakika++;
            }

            if (dakika == 60)
            {
                dakika = 0;
                saat++;
            }
            kronometre = saat.ToString() + ":" + dakika.ToString() + ":" + saniye.ToString();
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button btn_baslat = new Button();
        Button btn_durdur = new Button();
        Button btn_kaydet = new Button();
        Button btn_sil = new Button();
        Button btn_sifirla = new Button();
        Button btn_araVer = new Button();
        Button btn_araDurdur = new Button();
        Button btn_araKaydet = new Button();
        Button btn_araSil = new Button();

        Timer time_timer = new Timer();
        Timer time_timer2 = new Timer();

        ListBox lbox_veriler = new ListBox();

        ListBox lbox_veriler2 = new ListBox();
        MaskedTextBox mtxt_zaman = new MaskedTextBox();
        Label lbl_zaman = new Label();
        Label lbl_zaman2 = new Label();
        Label lbl1 = new Label();
        Label lbl2 = new Label();

        Hesapla Calisma = new Hesapla();
        Hesapla Ara = new Hesapla();


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(600, 390);

            this.Text = "Kronometre";
            mtxt_zaman.Mask = "00000";
            btn_baslat.Text = "Başlat";
            btn_durdur.Text = "Durdur";
            btn_kaydet.Text = "Kaydet";
            btn_sifirla.Text = "Sıfırla";
            btn_sil.Text = "Sil";

            btn_araDurdur.Text = "Arayı Durdur";
            btn_araKaydet.Text = "Arayı Kaydet";
            btn_araSil.Text = "Kaydı Sil";
            btn_araVer.Text = "Arayı Başlat";


            mtxt_zaman.Text = "";
            time_timer.Interval = 1000;
            time_timer2.Interval = 1000;
            time_timer.Enabled = true;
            time_timer2.Enabled = true;
            mtxt_zaman.Size = new Size(150, 20);
            lbl_zaman.Size = new Size(150, 30);
            lbl_zaman2.Size = new Size(150, 30);
            lbl1.Size = new Size(150, 30);
            lbl2.Size = new Size(150, 30);
            lbl_zaman.Text = "0:0:0";
            lbl_zaman2.Text = "0:0:0";
            lbl1.Text = "Çalışma Süresi";
            lbl2.Text = "Ara Verme Süresi";



            lbox_veriler.Size = new Size(560, 150);
            lbox_veriler.Size = new Size(275, 150);
            lbox_veriler2.Size = new Size(285, 150);
            mtxt_zaman.TextAlign = HorizontalAlignment.Center;
            Font eski = mtxt_zaman.Font;
            mtxt_zaman.Font = new Font(eski.FontFamily, 20, FontStyle.Bold);
            lbl_zaman.Font = new Font(eski.FontFamily, 20, FontStyle.Bold);
            lbl_zaman2.Font = new Font(eski.FontFamily, 20, FontStyle.Bold);
            lbl1.Font = new Font(eski.FontFamily, 12, FontStyle.Bold);
            lbl2.Font = new Font(eski.FontFamily, 12, FontStyle.Bold);
            mtxt_zaman.Location = new Point(30, 30);
            mtxt_zaman.ReadOnly = true;
            lbl_zaman.Location = new Point(50, 70);
            lbl_zaman2.Location = new Point(440, 70);
            lbl1.Location = new Point(30, 30);
            lbl2.Location = new Point(410, 30);


            btn_durdur.Enabled = false;
            btn_baslat.Location = new Point(200, 10);
            btn_durdur.Location = new Point(200, 50);
            btn_kaydet.Location = new Point(200, 90);
            btn_sil.Location = new Point(200, 130);
            btn_sifirla.Location = new Point(250, 170);

            btn_araVer.Location = new Point(300, 10);
            btn_araDurdur.Location = new Point(300, 50);
            btn_araKaydet.Location = new Point(300, 90);
            btn_araSil.Location = new Point(300, 130);


            lbox_veriler.Location = new Point(10, 200);
            lbox_veriler2.Location = new Point(290, 200);
            lbox_veriler.MultiColumn = true;
            lbox_veriler2.MultiColumn = true;
            lbox_veriler.Font = new Font(eski.FontFamily, 12, FontStyle.Bold);
            lbox_veriler2.Font = new Font(eski.FontFamily, 12, FontStyle.Bold);

            this.Controls.Add(btn_baslat);
            this.Controls.Add(btn_durdur);
            this.Controls.Add(btn_kaydet);
            this.Controls.Add(btn_sil);
            this.Controls.Add(btn_sifirla);
            //this.Controls.Add(mtxt_zaman);

            this.Controls.Add(btn_araVer);
            this.Controls.Add(btn_araKaydet);
            this.Controls.Add(btn_araDurdur);
            this.Controls.Add(btn_araSil);

            this.Controls.Add(lbl_zaman);
            this.Controls.Add(lbl_zaman2);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbox_veriler);
            this.Controls.Add(lbox_veriler2);

            time_timer.Tick += kronotmetre_Tick;
            time_timer2.Tick += kronotmetre2_Tick;
            btn_kaydet.Click += btn_Kaydet;
            btn_baslat.Click += btn_Baslat;
            btn_durdur.Click += btn_Durdur;
            btn_sil.Click += btn_Sil;
            btn_sifirla.Click += btn_Sifirla;

            btn_araVer.Click += btn_AraVer;
            btn_araDurdur.Click += btn_AraDurdur;
            btn_araKaydet.Click += btn_AraKaydet;
            btn_araSil.Click += btn_AraSil;


        }

        private void kronotmetre_Tick(object sender, EventArgs e)
        {
            if (btn_baslat.Enabled == false)
            {
                Calisma.saniye++;
            }
            Calisma.SaniyetoDakika(ref Calisma.saniye);
            lbl_zaman.Text = Calisma.kronometre;
        }
        private void kronotmetre2_Tick(object sender, EventArgs e)
        {
            if (btn_araVer.Enabled == false)
            {
                Ara.saniye++;
            }
            Ara.SaniyetoDakika(ref Ara.saniye);
            lbl_zaman2.Text = Ara.kronometre;
        }

        private void btn_Baslat(object sender, EventArgs e)
        {
            btn_baslat.Enabled = false;
            btn_durdur.Enabled = true;
        }

        private void btn_Durdur(object sender, EventArgs e)
        {
            btn_durdur.Enabled = false;
            btn_baslat.Enabled = true;
        }


        private void btn_Kaydet(object sender, EventArgs e)
        {
            lbox_veriler.Items.Add(lbl_zaman.Text);
        }

        private void btn_Sil(object sender, EventArgs e)
        {
            lbox_veriler.Items.Remove(lbox_veriler.SelectedItem);
        }

        private void btn_Sifirla(object sender, EventArgs e)
        {
            lbl_zaman.Text = "0:0:0";
            Calisma.saniye = 0;
            Calisma.dakika = 0;
            Calisma.saat = 0;
            lbox_veriler.Items.Clear();
        }
        private void btn_AraVer(object sender, EventArgs e)
        {
            btn_araVer.Enabled = false;
            btn_araDurdur.Enabled = true;
        }

        private void btn_AraDurdur(object sender, EventArgs e)
        {
            btn_araDurdur.Enabled = false;
            btn_araVer.Enabled = true;
        }

        private void btn_AraKaydet(object sender, EventArgs e)
        {
            lbox_veriler2.Items.Add(lbl_zaman2.Text);
        }

        private void btn_AraSil(object sender, EventArgs e)
        {
            lbox_veriler2.Items.Remove(lbox_veriler2.SelectedItem);
        }

    }
}
