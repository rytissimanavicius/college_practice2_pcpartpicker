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
        public Dalis(string a, string b, string c, string d)
        {
            Gamintojas = a;
            Modelis = b;
            Aprasymas = c;
            Paveikslelis = d;
        }
        public string GetGamintojas()
        {
            return Gamintojas;
        }
        public string GetModelis()
        {
            return Modelis;
        }
        public string GetAprasymas()
        {
            return Aprasymas;
        }
        public string GetPaveikslelis()
        {
            return Paveikslelis;
        }
        public string GamintojasDaliuPasirinkimui
        {
            get { return GetGamintojas(); }
        }
        public string ModelisDaliuPasirinkimui
        {
            get { return GetModelis(); }
        }
        public string AprasymasDaliuPasirinkimui
        {
            get { return GetAprasymas(); }
        }
        public string PaveikslelisDaliuPasirinkimui
        {
            get { return GetPaveikslelis(); }
        }
    }
}
