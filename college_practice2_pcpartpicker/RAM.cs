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
        public RAM(string a, string b, string c, string d, float e, int f)
            : base(a, b, c, d, e)
        {
            RAMSpeed = f;
        }
        public int GetRAMSpeed()
        {
            return RAMSpeed;
        }
    }
}
