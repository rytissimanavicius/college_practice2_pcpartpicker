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
        protected string Specifikacija { get; set; }
        protected string Paveikslelis { get; set; }
        protected float Kaina { get; set; }
        public Dalis(string a, string b, string c, string d, float e)
        {
            Gamintojas = a;
            Modelis = b;
            Specifikacija = c;
            Paveikslelis = d;
            Kaina = e;
        }
        public string GetGamintojas()
        {
            return Gamintojas;
        }
        public string GetModelis()
        {
            return Modelis;
        }
        public string GetSpecifikacija()
        {
            return Specifikacija;
        }
        public string GetPaveikslelis()
        {
            return Paveikslelis;
        }
        public float GetKaina()
        {
            return Kaina;
        }
        public string GamintojasDaliuPasirinkimui
        {
            get { return GetGamintojas(); }
        }
        public string ModelisDaliuPasirinkimui
        {
            get { return GetModelis(); }
        }
        public string SpecifikacijaDaliuPasirinkimui
        {
            get { return GetSpecifikacija(); }
        }
        public string PaveikslelisDaliuPasirinkimui
        {
            get { return GetPaveikslelis(); }
        }
        public string KainaDaliuPasirinkimui
        {
            get { return GetKaina().ToString("#.00 €"); }
        }
    }
}
