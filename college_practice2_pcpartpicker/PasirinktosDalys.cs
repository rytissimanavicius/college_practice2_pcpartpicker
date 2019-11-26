using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college_practice2_pcpartpicker
{
    class PasirinktosDalys
    {
        private string Kategorija { get; set; }
        public string Gamintojas { get; set; }
        public string Modelis { get; set; }
        public string Specifikacija { get; set; }
        public PasirinktosDalys(string a)
        {
            Kategorija = a;
        }
        public string GetKategorija()
        {
            return Kategorija;
        }
        public string KategorijaPasirinktaiDaliai
        {
            get { return GetKategorija(); }
        }
        public string GamintojasPasirinktaiDaliai
        {
            get { return Gamintojas; }
        }
        public string ModelisPasirinktaiDaliai
        {
            get { return Modelis; }
        }
        public string AprasymasPasirinktaiDaliai
        {
            get { return Specifikacija; }
        }
    }
}
