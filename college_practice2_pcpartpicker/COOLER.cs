using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class Cooler : Dalis
    {
        private string JungtiesTipas { get; set; }
        public Cooler(string a, string b, string c, string d, string e)
            : base(a, b, c, d)
        {
            JungtiesTipas = e;
        }
    }
}
