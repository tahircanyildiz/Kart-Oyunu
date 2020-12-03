using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporcuKartOyunu
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        Kullanici oyuncu;
        Bilgisayar bilgisayar;
        private void Test_Load(object sender, EventArgs e)
        {
            bilgisayar = new Bilgisayar();
            oyuncu = new Kullanici();
            Baslat();
            index = 0;
            secilenKart = oyuncu.kullanilmamisKartSec()[index];
            OyuncuPanelGuncelle();
        }
        void Baslat()
        {
            List<Sporcu> kartlar = new List<Sporcu>();
            kartlar.Add(new Futbolcu("Radamel Falcao", "Galatasaray", 92, 86, 91));
            kartlar.Add(new Futbolcu("Tahir Can Yıldız", "Kocaeli Üni", 100, 100, 100));
            kartlar.Add(new Futbolcu("Emre Kılınç", "Galatasaray", 80, 80, 80));
            kartlar.Add(new Futbolcu("Nwakaeme", "Trabzonspor", 85, 90, 90));
            kartlar.Add(new Futbolcu("Ozan Tufan", "Fenerbahçe", 50, 55, 50));
            kartlar.Add(new Futbolcu("Messi", "Barcelona", 99, 99, 96));
            kartlar.Add(new Futbolcu("C.Ronaldo", "Juventus", 96, 96, 99));
            kartlar.Add(new Futbolcu("Aboubakar", "Beşiktaş", 86, 91, 92));
            kartlar.Add(new Basketbolcu("Melih Mahmutoğlu", "Fenerbahçe", 81, 91, 91));
            kartlar.Add(new Basketbolcu("Bobby Dixon", "Fenerbahçe", 76, 99, 86));
            kartlar.Add(new Basketbolcu("Kobe Bryant", "LA.Lakers", 101, 101, 101));
            kartlar.Add(new Basketbolcu("Stephen Curry", "Golden State", 99, 99, 99));
            kartlar.Add(new Basketbolcu("Bill Russel", "Boston", 97, 96, 97));
            kartlar.Add(new Basketbolcu("LeBron James", "Los Angles", 98, 98, 98));
            kartlar.Add(new Basketbolcu("Kevin Durant", "Brooklyn", 96, 97, 100));
            kartlar.Add(new Basketbolcu("Cedi Osman", "Cleveland", 94, 92, 92));
            kartlar = kartlariKaristir(kartlar);
            KartlariDagit(kartlar);
            buttonOyna.Enabled = true;
            OyuncuPanelGuncelle();
        }
        bool oyunBittiMi()
        {
            for (int i = 0; i < oyuncu.kartListesi.Count; i++)
            {
                if (!oyuncu.kartListesi[i].kartKullanildiMi)
                {
                    return false;
                }
            }
            return true;
        }
        void KartlariDagit(List<Sporcu> kartlar)
        {
            int sira = 0;
            foreach (Sporcu sporcu in kartlar)
            {
                if (sporcu is Futbolcu)
                {
                    if (sira % 2 == 0)
                    {
                        oyuncu.kartListesi.Add(sporcu);
                    }
                    else
                    {
                        bilgisayar.kartListesi.Add(sporcu);
                    }
                    sira++;
                }
            }
            foreach (Sporcu sporcu in kartlar)
            {
                if (sporcu is Basketbolcu)
                {
                    if (sira % 2 == 0)
                    {
                        oyuncu.kartListesi.Add(sporcu);
                    }
                    else
                    {
                        bilgisayar.kartListesi.Add(sporcu);
                    }
                    sira++;
                }
            }
            
        }
        private bool tumKartlarEklendimi(bool[] eklendimi)
        {
            for (int i = 0; i < eklendimi.Length; i++)
            {
                if (!eklendimi[i])
                {
                    return false;
                }
            }
            return true;
        }
        List<Sporcu> kartlariKaristir(List<Sporcu> kartlar)
        {
            List<Sporcu> yeniListe = new List<Sporcu>();
            Random rnd = new Random();
            int sayi;
            bool[] eklendimi = new bool[kartlar.Count];
            for (int i = 0; i < eklendimi.Length; i++)
                eklendimi[i] = false;
            while (!tumKartlarEklendimi(eklendimi))
            {
                sayi = rnd.Next(0, kartlar.Count);
                if (!eklendimi[sayi])
                {
                    yeniListe.Add(kartlar[sayi]);
                    eklendimi[sayi] = true;
                }
            }
         
            return yeniListe;
        }

        Sporcu secilenKart;
        int index;
        void OyuncuPanelGuncelle()
        {
            if (secilenKart != null)
            {
                if (secilenKart is Basketbolcu)                   
                    pictureBox4.Image = Properties.Resources.basketball;             
                else
                    pictureBox4.Image = Properties.Resources.football;
                
                labelOyuncuKartSayisi.Text = (8 - ((bilgisayar.Skor + oyuncu.Skor)/10)).ToString();
                labelOyuncuSkor.Text = oyuncu.Skor.ToString();
                labelBilgisayarPuan.Text = bilgisayar.Skor.ToString();
                labelBilgisayarKartSayisi.Text = (8 - ((bilgisayar.Skor + oyuncu.Skor)/10)).ToString();
            }
        }

        public int intKarsilastir(int s1, int s2)
        {
            if (s1 > s2)
            {
                return 1;
            }
            else if (s2 > s1) return -1;
            else return 0;
        }

        public int Karsilastir(Sporcu kart1, Sporcu kart2)
        {
            int rastgele = new Random().Next(0, 3);
            if (kart1 is Futbolcu)
            {
                
                if (rastgele == 0)
                {
                    labelSecilenOzellik.Text = "Seçilen Pozisyon: Penaltı";
                    if ((intKarsilastir(((Futbolcu)kart1).penalti, ((Futbolcu)kart2).penalti)) == 0)
                    {
                        return 0;
                    }
                    else if ((intKarsilastir(((Futbolcu)kart1).penalti, ((Futbolcu)kart2).penalti)) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (rastgele == 1)
                {
                    labelSecilenOzellik.Text = "Seçilen Pozisyon: Serbest Vuruş";
                    if ((intKarsilastir(((Futbolcu)kart1).serbestAtis, ((Futbolcu)kart2).serbestAtis)) == 0)
                    {
                        return 0;
                    }
                    else if ((intKarsilastir(((Futbolcu)kart1).serbestAtis, ((Futbolcu)kart2).serbestAtis)) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    labelSecilenOzellik.Text = "Seçilen Pozisyon: Kaleciyle Karşı Karşıya";
                    if ((intKarsilastir(((Futbolcu)kart1).kaleciKarsiKarsiya, ((Futbolcu)kart2).kaleciKarsiKarsiya)) == 0)
                    {
                        return 0;
                    }
                    else if ((intKarsilastir(((Futbolcu)kart1).kaleciKarsiKarsiya, ((Futbolcu)kart2).kaleciKarsiKarsiya)) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                
                if (rastgele == 0)
                {
                    labelSecilenOzellik.Text = "Seçilen Pozisyon: İkilik";
                    if ((intKarsilastir(((Basketbolcu)kart1).ikilik, ((Basketbolcu)kart2).ikilik)) == 0)
                    {
                        return 0;
                    }
                    else if ((intKarsilastir(((Basketbolcu)kart1).ikilik, ((Basketbolcu)kart2).ikilik)) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else if (rastgele == 1)
                {
                    labelSecilenOzellik.Text = "Seçilen Pozisyon: Üçlük";
                    if ((intKarsilastir(((Basketbolcu)kart1).ucluk, ((Basketbolcu)kart2).ucluk)) == 0)
                    {
                        return 0;
                    }
                    else if ((intKarsilastir(((Basketbolcu)kart1).ucluk, ((Basketbolcu)kart2).ucluk)) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    labelSecilenOzellik.Text = "Seçilen Pozisyon: Serbest Atış";
                    if ((intKarsilastir(((Basketbolcu)kart1).serbestAtis, ((Basketbolcu)kart2).serbestAtis)) == 0)
                    {
                        return 0;
                    }
                    else if ((intKarsilastir(((Basketbolcu)kart1).serbestAtis, ((Basketbolcu)kart2).serbestAtis)) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        public void YerGuncelle(Sporcu kart1, Sporcu kart2)
        {
            labelOsporcuAdi.Text = kart1.SporcuIsim;
            labelBSporcuAdi.Text = kart2.SporcuIsim;
            labelOsporcuTakim.Text = kart1.SporcuTakim;
            labelBSporcuTakim.Text = kart2.SporcuTakim;
            if (kart1.SporcuIsim == "Melih Mahmutoğlu") pictureBox3.Image = Properties.Resources.mahmutoğlu;
           else if (kart1.SporcuIsim == "Radamel Falcao") pictureBox3.Image = Properties.Resources.falcao;
           else if (kart1.SporcuIsim == "Emre Kılınç") pictureBox3.Image = Properties.Resources.kılınç;
            else if (kart1.SporcuIsim == "Nwakaeme") pictureBox3.Image = Properties.Resources.nwakaeme;
            else if (kart1.SporcuIsim == "Ozan Tufan") pictureBox3.Image = Properties.Resources.tufan;
            else if (kart1.SporcuIsim == "Messi") pictureBox3.Image = Properties.Resources.messi;
            else if (kart1.SporcuIsim == "C.Ronaldo") pictureBox3.Image = Properties.Resources.ronaldo;
            else if (kart1.SporcuIsim == "Aboubakar") pictureBox3.Image = Properties.Resources.aboubakar;
            else if (kart1.SporcuIsim == "Bobby Dixon") pictureBox3.Image = Properties.Resources.dixon;
            else if (kart1.SporcuIsim == "Kobe Bryant") pictureBox3.Image = Properties.Resources.kobe;
            else if (kart1.SporcuIsim == "Stephen Curry") pictureBox3.Image = Properties.Resources.stephen;
            else if (kart1.SporcuIsim == "Bill Russel") pictureBox3.Image = Properties.Resources.russel;
            else if (kart1.SporcuIsim == "LeBron James") pictureBox3.Image = Properties.Resources.lebron;
            else if (kart1.SporcuIsim == "Kevin Durant") pictureBox3.Image = Properties.Resources.kevindurant;
            else if (kart1.SporcuIsim == "Cedi Osman") pictureBox3.Image = Properties.Resources.cedi;
            else if (kart1.SporcuIsim == "Tahir Can Yıldız") pictureBox3.Image = Properties.Resources.tahircan;
            if (kart2.SporcuIsim == "Melih Mahmutoğlu") pictureBox1.Image = Properties.Resources.mahmutoğlu;
            else if (kart2.SporcuIsim == "Radamel Falcao") pictureBox1.Image = Properties.Resources.falcao;
            else if (kart2.SporcuIsim == "Emre Kılınç") pictureBox1.Image = Properties.Resources.kılınç;
            else if (kart2.SporcuIsim == "Nwakaeme") pictureBox1.Image = Properties.Resources.nwakaeme;
            else if (kart2.SporcuIsim == "Ozan Tufan") pictureBox1.Image = Properties.Resources.tufan;
            else if (kart2.SporcuIsim == "Messi") pictureBox1.Image = Properties.Resources.messi;
            else if (kart2.SporcuIsim == "C.Ronaldo") pictureBox1.Image = Properties.Resources.ronaldo;
            else if (kart2.SporcuIsim == "Aboubakar") pictureBox1.Image = Properties.Resources.aboubakar;
            else if (kart2.SporcuIsim == "Bobby Dixon") pictureBox1.Image = Properties.Resources.dixon;
            else if (kart2.SporcuIsim == "Kobe Bryant") pictureBox1.Image = Properties.Resources.kobe;
            else if (kart2.SporcuIsim == "Stephen Curry") pictureBox1.Image = Properties.Resources.stephen;
            else if (kart2.SporcuIsim == "Bill Russel") pictureBox1.Image = Properties.Resources.russel;
            else if (kart2.SporcuIsim == "LeBron James") pictureBox1.Image = Properties.Resources.lebron;
            else if (kart2.SporcuIsim == "Kevin Durant") pictureBox1.Image = Properties.Resources.kevindurant;
            else if (kart2.SporcuIsim == "Cedi Osman") pictureBox1.Image = Properties.Resources.cedi;
            else if (kart2.SporcuIsim == "Tahir Can Yıldız") pictureBox1.Image = Properties.Resources.tahircan;















            if (kart1 is Futbolcu)
            {
                
                labelOOzellik1.Text = "Penaltı";
                labelOOzellik2.Text = "Serbest Atış";
                labelOOzellik3.Text = "Kaleci Karşı Karşıya";
                labelBOzellik1.Text = "Penaltı";
                labelBOzellik2.Text = "Serbest Atış";
                labelBOzellik3.Text = "Kaleci Karşı Karşıya";
                labelOSporcuOzellik1.Text = ((Futbolcu)kart1).penalti.ToString();
                labelOSporcuOzellik2.Text = ((Futbolcu)kart1).serbestAtis.ToString();
                labelOSporcuOzellik3.Text = ((Futbolcu)kart1).kaleciKarsiKarsiya.ToString();

                labelBSporcuOzellik1.Text = ((Futbolcu)kart2).penalti.ToString();
                labelBSporcuOzellik2.Text = ((Futbolcu)kart2).serbestAtis.ToString();
                labelBSporcuOzellik3.Text = ((Futbolcu)kart2).kaleciKarsiKarsiya.ToString();
            }
            else
            {
               
                labelOOzellik1.Text = "İkilik";
                labelOOzellik2.Text = "Üçlük";
                labelOOzellik3.Text = "Serbest Atış";
                labelBOzellik1.Text = "İkilik";
                labelBOzellik2.Text = "Üçlük";
                labelBOzellik3.Text = "Serbest Atış";
                labelOSporcuOzellik1.Text = ((Basketbolcu)kart1).ikilik.ToString();
                labelOSporcuOzellik2.Text = ((Basketbolcu)kart1).ucluk.ToString();
                labelOSporcuOzellik3.Text = ((Basketbolcu)kart1).serbestAtis.ToString();


                labelBSporcuOzellik1.Text = ((Basketbolcu)kart2).ikilik.ToString();
                labelBSporcuOzellik2.Text = ((Basketbolcu)kart2).ucluk.ToString();
                labelBSporcuOzellik3.Text = ((Basketbolcu)kart2).serbestAtis.ToString();
            }
        }
        private void buttonOyna_Click(object sender, EventArgs e)
        {
            Sporcu bilgisayarHamle;
            if (secilenKart==null)
                secilenKart = oyuncu.kullanilmamisKartSec()[index];
            OyuncuPanelGuncelle();
            if (secilenKart is Futbolcu)
            {
                do
                {
                    bilgisayarHamle = bilgisayar.kartSec();
                } while ((!(bilgisayarHamle is Futbolcu)));
            }
            else
            {
                do
                {
                    bilgisayarHamle = bilgisayar.kartSec();
                } while ((!(bilgisayarHamle is Basketbolcu)));
            }
            YerGuncelle(secilenKart, bilgisayarHamle);
            int sonuc = Karsilastir(secilenKart, bilgisayarHamle);
            if (sonuc == 0)//Eşitlik
            {
                kazananLabel.Text = "Kimse kazanamdı!";
            }
            else if (sonuc == 1)//Oyuncu kazandı
            {
                kazananLabel.Text = "Oyuncu kazandı!";
                oyuncu.Skor+=10;
                oyuncu.kartListesi[oyuncu.kartListesi.IndexOf(secilenKart)].kartKullanildiMi = true;
                bilgisayar.kartListesi[bilgisayar.kartListesi.IndexOf(bilgisayarHamle)].kartKullanildiMi = true;
            }
            else//Bilgisayar kazandı
            {
                kazananLabel.Text = "Bilgisayar kazandı!";
                bilgisayar.Skor+=10;
                oyuncu.kartListesi[oyuncu.kartListesi.IndexOf(secilenKart)].kartKullanildiMi = true;
                bilgisayar.kartListesi[bilgisayar.kartListesi.IndexOf(bilgisayarHamle)].kartKullanildiMi = true;
            }
            if (!oyunBittiMi())
            {
                index = oyuncu.kullanilmamisKartSec().Count;
                if (index%2==0)
                {
                    secilenKart = oyuncu.kullanilmamisKartSec()[0];
                    pictureBox2.Image = Properties.Resources.football;
                }
                else
                {
                    secilenKart = oyuncu.kullanilmamisKartSec()[index - 1];
                    pictureBox2.Image = Properties.Resources.basketball;
                }
                OyuncuPanelGuncelle();
            }
            else
            {
                OyuncuPanelGuncelle();
                string mesaj = "Oyun Bitti!  ";
                if (oyuncu.Skor > bilgisayar.Skor)
                {
                    mesaj += "KAZANDIN !!!!!";
                }
                else if (oyuncu.Skor == bilgisayar.Skor)
                    mesaj += "BERABERE !!!";
                else mesaj += "KAYBETTİN :((";
                MessageBox.Show(mesaj);
                Application.Exit();
            }

        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelSporcuAdi_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void kazananLabel_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void labelOOzellik1_Click(object sender, EventArgs e)
        {

        }

        private void labelOSporcuOzellik2_Click(object sender, EventArgs e)
        {

        }

        private void labelOSporcuOzellik3_Click(object sender, EventArgs e)
        {

        }

        private void labelBSporcuOzellik1_Click(object sender, EventArgs e)
        {

        }

        private void labelOyuncuKartSayisi_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void labelOsporcuAdi_Click(object sender, EventArgs e)
        {

        }

        private void labelSporcuTuru_Click(object sender, EventArgs e)
        {

        }

        private void labelBSporcuOzellik2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void labelBSporcuAdi_Click(object sender, EventArgs e)
        {

        }
    }
}
