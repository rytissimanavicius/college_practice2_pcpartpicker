using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class Korpusas : Dalis
    {
        private string MontavimoTipas;
        public Korpusas(string a, string b, string c, string d, float e, string f)
            : base(a, b, c, d, e)
        {
            MontavimoTipas = f;
        }
        public string GetMontavimoTipas()
        {
            return MontavimoTipas;
        }
    }
}