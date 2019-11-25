using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class RAM : Dalis
    {
        private int RAMSpeed { get; set; }
        private int RAMLatency { get; set; }
        private int GaliosReikalavimai { get; set; }
        public RAM(string a, string b, string c, string d, int e, int f, int g)
            : base(a, b, c, d)
        {
            RAMSpeed = e;
            RAMLatency = f;
            GaliosReikalavimai = g;
        }
    }
}
