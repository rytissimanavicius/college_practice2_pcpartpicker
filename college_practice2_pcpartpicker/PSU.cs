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
        public PSU(string a, string b, string c, string d, int e, int f)
            : base(a, b, c, d)
        {
            Galia = e;
            Efektyvumas = f;
        }
    }
}
