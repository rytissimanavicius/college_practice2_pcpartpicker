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
        public Cooler(string a, string b, string c, string d, float e, string f)
            : base(a, b, c, d, e)
        {
            JungtiesTipas = f;
        }
        public string GetJungtiesTipas()
        {
            return JungtiesTipas;
        }
    }
}
