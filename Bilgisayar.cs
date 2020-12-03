using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporcuKartOyunu
{
    class Bilgisayar : Oyuncu
    {
        public Bilgisayar()
        {
            this.oyuncuID = -1;
            this.oyuncuAdi = "Bilgisayar";
            Skor = 0;
            kartListesi = new List<Sporcu>();
        }

        public Bilgisayar(int oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID, oyuncuAdi, skor)
        {

            kartListesi = new List<Sporcu>();
        }
        public override Sporcu kartSec()
        {
            Random rnd = new Random();
            Sporcu secilenKart = kartListesi[rnd.Next(0, kartListesi.Count)];
            while (secilenKart.kartKullanildiMi)
            {
                secilenKart = kartListesi[rnd.Next(0, kartListesi.Count)];
            }
            return secilenKart;
        }
    }
}
