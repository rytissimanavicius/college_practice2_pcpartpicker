using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class PSU : Dalis
    {
        private int Galia { get; set; }
        private int Efektyvumas { get; set; }
        public PSU(string a, string b, string c, string d, float e, int f, int g)
            : base(a, b, c, d, e)
        {
            Galia = f;
            Efektyvumas = g;
        }
        public int GetGalia()
        {
            return Galia;
        }
        public int GetEfektyvumas()
        {
            return Efektyvumas;
        }
        public int GetTikraGalia()
        {
            return (Galia * Efektyvumas) / 100;
        }
    }
}
