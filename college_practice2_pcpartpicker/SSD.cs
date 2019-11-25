using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class SSD : Dalis
    {
        private string Tipas { get; set; }
        public SSD(string a, string b, string c, string d, string e)
            : base(a, b, c, d)
        {
            Tipas = e;
        }
    }
}
