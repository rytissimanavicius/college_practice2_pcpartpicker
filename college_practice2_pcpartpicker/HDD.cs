using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class HDD : Dalis
    {
        private string Jungtis;
        public HDD(string a, string b, string c, string d, string e)
            : base(a, b, c, d)
        {
            Jungtis = e;
        }
        public string GetJungtis()
        {
            return Jungtis;
        }
    }
}
