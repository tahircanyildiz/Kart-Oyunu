using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporcuKartOyunu
{
    public class Sporcu
    {
        public string SporcuIsim { get; set; }
        public string SporcuTakim { get; set; }
        public bool kartKullanildiMi { get; set; }
        //Iki sınıfta da tanımlanan bir özellik olacağı için bu sınıfta tanımlanması daha uygun görünüyordu.
        public Sporcu(string sporcuIsim, string sporcuTakim)
        {
            this.SporcuIsim = sporcuIsim;
            this.SporcuTakim = sporcuTakim;
        }
        public Sporcu() { }
        public virtual string sporcuPuaniGoster() { return null; }
    }
}
