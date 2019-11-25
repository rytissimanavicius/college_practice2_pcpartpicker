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
        public GPU(string a, string b, string c, string d, string e, int f)
            : base(a, b, c, d)
        {
            JungtiesTipas = e;
            GaliosReikalavimai = f;
        }
    }
}
