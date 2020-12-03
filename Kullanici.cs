using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporcuKartOyunu
{
    class Kullanici : Oyuncu
    {
        public Kullanici()
        {
            this.oyuncuID = -1;
            this.oyuncuAdi = "Kullanıcı";
            Skor = 0;
            kartListesi = new List<Sporcu>();
        }

        public Kullanici(int oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID, oyuncuAdi, skor)
        {

            kartListesi = new List<Sporcu>();
        }
        public override Sporcu kartSec()
        {
            return null;
        }
        public List<Sporcu> kullanilmamisKartSec()
        {
            List<Sporcu> kullanilmamisListe = new List<Sporcu>();
            foreach (Sporcu sporcu in kartListesi)
            {
                if (!sporcu.kartKullanildiMi)
                {
                    kullanilmamisListe.Add(sporcu);
                }
            }
            return kullanilmamisListe;
        }
    }
}
