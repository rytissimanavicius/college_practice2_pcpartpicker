﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class Korpusas : Dalis
    {
        private string MontavimoTipas;
        public Korpusas(string a, string b, string c, string d, string e)
            : base(a, b, c, d)
        {
            MontavimoTipas = e;
        }
    }
}