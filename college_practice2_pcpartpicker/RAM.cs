using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class RAM : Dalis
    {
        private int RAMSpeed { get; set; }
        public RAM(string a, string b, string c, string d, int e)
            : base(a, b, c, d)
        {
            RAMSpeed = e;
        }
        public int GetRAMSpeed()
        {
            return RAMSpeed;
        }
    }
}
