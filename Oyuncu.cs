using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporcuKartOyunu
{
    class Oyuncu
    {
        public int oyuncuID { get; set; }
        public string oyuncuAdi { get; set; }
        public int Skor { get; set; }
        public List<Sporcu> kartListesi { get; set; }
        public Oyuncu()
        {
            this.oyuncuID = -1;
            this.oyuncuAdi = "Belirtilmemiş";
            Skor = 0;
            kartListesi = new List<Sporcu>();
        }

        public Oyuncu(int oyuncuID, string oyuncuAdi, int skor)
        {
            this.oyuncuID = oyuncuID;
            this.oyuncuAdi = oyuncuAdi;
            Skor = skor;
        }
        public virtual Sporcu kartSec() { return null; }
        
    }
}
