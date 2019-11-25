using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class CPU : Dalis
    {
        private string JungtiesTipas { get; set; }
        private int RAMSpeedReikalavimai { get; set; }
        private int RAMLatencyReikalavimai { get; set; }
        private int GaliosReikalavimai { get; set; }
        public CPU(string a, string b, string c, string d, string e, int f, int g, int h) 
            : base(a, b, c, d)
        {
            JungtiesTipas = e;
            RAMSpeedReikalavimai = f;
            RAMLatencyReikalavimai = g;
            GaliosReikalavimai = h;
        }
    }
}
