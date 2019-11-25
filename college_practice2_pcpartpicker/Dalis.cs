using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    abstract class Dalis
    {
        protected string Gamintojas { get; set; }
        protected string Modelis { get; set; }
        protected string Aprasymas { get; set; }
        protected string Paveikslelis { get; set; }
        //protected static double PVM = 0.21;
        public Dalis(string a, string b, string c, string d)
        {
            Gamintojas = a;
            Modelis = b;
            Aprasymas = d;
            Paveikslelis = d;
        }
        public string GetGamintojas()
        {
            return Gamintojas;
        }
    }
}
