﻿using System;
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
        public float Kaina { get; set; }
        public string Suderinamumas { get; set; }
        public bool Naudojamas { get; set; }
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
        public string SpecifikacijaPasirinktaiDaliai
        {
            get { return Specifikacija; }
        }
        public string KainaPasirinktaiDaliai
        {
            get { return Kaina.ToString("#.00 €"); }
        }
        public string SuderinamumasPasirinktaiDaliai
        {
            get { return Suderinamumas; }
        }
    }
}
