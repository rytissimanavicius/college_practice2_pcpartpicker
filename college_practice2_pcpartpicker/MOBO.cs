using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class MOBO : Dalis
    {
        private string KorpusoTipas { get; set; }
        private string CPUJungtiesTipas { get; set; }
        private int RAMSpeedReikalavimai { get; set; }
        private int RAMLatencyReikalavimai { get; set; }
        private int RAMJungciuKiekis { get; set; }
        private string GPUJungtiesTipas { get; set; }
        private int SataKiekis { get; set; }
        private int Mdot2Kiekis { get; set; }
        private int GaliosReikalavimai { get; set; }
        public MOBO(string a, string b, string c, string d, string e, string f, int g, int h, int i, string j, int k, int l, int m)
            : base(a, b, c, d)
        {
            KorpusoTipas = e;
            CPUJungtiesTipas = f;
            RAMSpeedReikalavimai = g;
            RAMLatencyReikalavimai = h;
            RAMJungciuKiekis = i;
            GPUJungtiesTipas = j;
            SataKiekis = k;
            Mdot2Kiekis = l;
            GaliosReikalavimai = m;
        }
    }
}
