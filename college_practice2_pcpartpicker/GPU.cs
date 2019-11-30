using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class GPU : Dalis
    {
        private string JungtiesTipas { get; set; }
        private int GaliosReikalavimai { get; set; }
        public GPU(string a, string b, string c, string d, float e, string f, int g)
            : base(a, b, c, d, e)
        {
            JungtiesTipas = f;
            GaliosReikalavimai = g;
        }
        public string GetJungtiesTipas()
        {
            return JungtiesTipas;
        }
        public int GetGaliosReikalavimai()
        {
            return GaliosReikalavimai;
        }
    }
}
