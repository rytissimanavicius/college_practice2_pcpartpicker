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
        public SSD(string a, string b, string c, string d, float e, string f)
            : base(a, b, c, d, e)
        {
            Tipas = f;
        }
        public string GetTipas()
        {
            return Tipas;
        }
    }
}
