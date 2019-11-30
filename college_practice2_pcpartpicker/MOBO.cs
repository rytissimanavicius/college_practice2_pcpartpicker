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
        private int RAMSpeedMin { get; set; }
        private int RAMSpeedMax { get; set; }
        private int RAMJungciuKiekis { get; set; }
        private string GPUJungtiesTipas { get; set; }
        private int SataKiekis { get; set; }
        private int Mdot2Kiekis { get; set; }
        public MOBO(string a, string b, string c, string d, float e, string f, string g, int h, int i, int j, string k, int l, int m)
            : base(a, b, c, d, e)
        {
            KorpusoTipas = f;
            CPUJungtiesTipas = g;
            RAMSpeedMin = h;
            RAMSpeedMax = i;
            RAMJungciuKiekis = j;
            GPUJungtiesTipas = k;
            SataKiekis = l;
            Mdot2Kiekis = m;
        }
        public string GetKorpusoTipas()
        {
            return KorpusoTipas;
        }
        public string GetCPUJungtiesTipas()
        {
            return CPUJungtiesTipas;
        }
        public int GetRAMSpeedMin()
        {
            return RAMSpeedMin;
        }
        public int GetRAMSpeedMax()
        {
            return RAMSpeedMax;
        }
        public int GetRAMJungciuKiekis()
        {
            return RAMJungciuKiekis;
        }
        public string GetGPUJungtiesTipas()
        {
            return GPUJungtiesTipas;
        }
        public int GetSataKiekis()
        {
            return SataKiekis;
        }
        public int GetMdot2Kiekis()
        {
            return Mdot2Kiekis;
        }
    }
}
