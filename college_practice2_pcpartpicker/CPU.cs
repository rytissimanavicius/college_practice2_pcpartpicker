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
        private int GaliosReikalavimai { get; set; }
        public CPU(string a, string b, string c, string d, float e, string f, int g, int h) 
            : base(a, b, c, d, e)
        {
            JungtiesTipas = f;
            RAMSpeedReikalavimai = g;
            GaliosReikalavimai = h;
        }
        public string GetJungtiesTipas()
        {
            return JungtiesTipas;
        }
        public int GetRAMSpeedReikalavimai()
        {
            return RAMSpeedReikalavimai;
        }
        public int GetGaliosReikalavimai()
        {
            return GaliosReikalavimai;
        }
    }
}
