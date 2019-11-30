using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

using System.Windows;

namespace college_practice2_pcpartpicker
{
    class Database
    {
        //kategoriju listas kai prireiks spausdint interfeise
        private List<string> KategorijuList = new List<string>();
        //kiekviena kompiuterio dalis kaip objektas
        private List<Cooler> CoolerList = new List<Cooler>();
        private List<CPU> CPUList = new List<CPU>();
        private List<GPU> GPUList = new List<GPU>();
        private List<HDD> HDDList = new List<HDD>();
        private List<Korpusas> KorpusasList = new List<Korpusas>();
        private List<MOBO> MOBOList = new List<MOBO>();
        private List<PSU> PSUList = new List<PSU>();
        private List<RAM> RAMList = new List<RAM>();
        private List<SSD> SSDList = new List<SSD>();
        //programa paima is db informacija ir pagal ja sukure objektus
        private SQLiteConnection Conn { get; set; }
        public Database(string a)
        {
            Conn = new SQLiteConnection(a);
        }
        //reikalingi surenkant dalies info
        string a = null, b = null, c = null, d = null;
        public void CreateObjects()
        {
            Conn.Open();
            //kategorijos objektu kurimas
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT pavadinimas FROM kategorija", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        KategorijuList.Add(Reader.GetString(0));
            //cooler objektu kurimas
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,jungties_tipas FROM cooler", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        CoolerList.Add(new Cooler(a, b, c, d, Reader.GetString(1)));
                    }
            //cpu objektu kurimai
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,jungties_tipas,ram_speed_reikalavimai,galios_reikalavimai FROM cpu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        CPUList.Add(new CPU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetInt32(5), Reader.GetInt32(6)));
            //gpu objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,jungties_tipas,galios_reikalavimai FROM gpu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        GPUList.Add(new GPU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetInt32(5)));
            //hdd objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,jungtis FROM hdd", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        HDDList.Add(new HDD(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
            //korpusu objektu kurimas
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,montavimo_tipas FROM korpusas", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        KorpusasList.Add(new Korpusas(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
            //mobo objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,korpuso_tipas,cpu_jungties_tipas,ram_speed_min,ram_speed_max,ram_jungciu_kiekis,gpu_jungties_tipas,sata_kiekis,mdot2_kiekis FROM mobo", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        MOBOList.Add(new MOBO(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5), Reader.GetInt32(6), Reader.GetInt32(7), Reader.GetInt32(8), Reader.GetString(9), Reader.GetInt32(10), Reader.GetInt32(11)));
            //psu objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,galia,efektyvumas FROM psu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        PSUList.Add(new PSU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetInt32(4), Reader.GetInt32(5)));
            //ram objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,ram_speed FROM ram", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        RAMList.Add(new RAM(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetInt32(4)));
            //ssd objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,specifikacija,paveikslelis,tipas FROM ssd", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        SSDList.Add(new SSD(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
            Conn.Close();
        }
        public void GetDalisInfo(int e)
        {
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT id,gamintojas,modelis,specifikacija,paveikslelis FROM dalis", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        if (Reader.GetInt32(0) == e)
                        {
                            a = Reader.GetString(1);
                            b = Reader.GetString(2);
                            c = Reader.GetString(3);
                            d = Reader.GetString(4);
                        }
        }
        public List<string> GetKategorijuList()
        {
            return KategorijuList;
        }
        public List<Cooler> GetCoolerList()
        {
            return CoolerList;
        }
        public List<CPU> GetCPUList()
        {
            return CPUList;
        }
        public List<GPU> GetGPUList()
        {
            return GPUList;
        }
        public List<HDD> GetHDDList()
        {
            return HDDList;
        }
        public List<Korpusas> GetKorpusuList()
        {
            return KorpusasList;
        }
        public List<MOBO> GetMOBOList()
        {
            return MOBOList;
        }
        public List<PSU> GetPSUList()
        {
            return PSUList;
        }
        public List<RAM> GetRAMList()
        {
            return RAMList;
        }
        public List<SSD> GetSSDList()
        {
            return SSDList;
        }
    }
}
