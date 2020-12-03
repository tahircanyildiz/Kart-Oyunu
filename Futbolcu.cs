using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporcuKartOyunu
{
    public class Futbolcu : Sporcu
    {
        public int penalti { get; set; }
        public int serbestAtis { get; set; }
        public int kaleciKarsiKarsiya { get; set; }
        public Futbolcu()
        {
            this.penalti = 0;
            this.serbestAtis = 0;
            this.kaleciKarsiKarsiya = 0;
            this.SporcuTakim = "Belirtilmemiş";
            this.SporcuIsim = "Belirtilmemiş";
            this.kartKullanildiMi = false;
        }

        public Futbolcu(string sporcuIsim, string sporcuTakim,int penalti, int serbestAtis, int kaleciKarsiKarsiya) : base(sporcuIsim, sporcuTakim)
        {
            this.penalti = penalti;
            this.serbestAtis = serbestAtis;
            this.kaleciKarsiKarsiya = kaleciKarsiKarsiya;
            this.kartKullanildiMi = false;
        }

        public override string sporcuPuaniGoster()
        {
            return string.Format("Penaltı: {0} Serbest Atış: {1} Kaleciyle Karşı Karşıya: {2}", penalti, serbestAtis, kaleciKarsiKarsiya);
        }
    }
}
