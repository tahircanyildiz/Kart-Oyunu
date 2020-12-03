using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporcuKartOyunu
{
    public class Basketbolcu :Sporcu
    {
        public int ikilik { get; set; }
        public int ucluk{ get; set; }
        public int serbestAtis{ get; set; }
        public Basketbolcu()
        {
            this.ikilik = 0;
            this.serbestAtis = 0;
            this.ucluk = 0;
            this.SporcuTakim = "Belirtilmemiş";
            this.SporcuIsim = "Belirtilmemiş";
            this.kartKullanildiMi = false;
        }

        public Basketbolcu(string sporcuIsim, string sporcuTakim, int ikilik, int serbestAtis, int ucluk) : base(sporcuIsim, sporcuTakim)
        {
            this.ikilik = ikilik;
            this.serbestAtis = serbestAtis;
            this.ucluk = ucluk;
            this.kartKullanildiMi = false;
        }

        public override string sporcuPuaniGoster()
        {
            return string.Format("İkilik: {0} Üçlük: {1} Serbest Atış: {2}", ikilik, ucluk, serbestAtis);
        }
    }
}
