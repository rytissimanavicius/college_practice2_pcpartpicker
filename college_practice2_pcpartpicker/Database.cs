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
        //kategoriju listas greitai prieigai
        private List<string> KategorijuList = new List<string>();
        //daliu objektu listai su unikalia informacija
        private List<Cooler> CoolerList = new List<Cooler>();
        private List<CPU> CPUList = new List<CPU>();
        private List<GPU> GPUList = new List<GPU>();
        private List<HDD> HDDList = new List<HDD>();
        private List<Korpusas> KorpusasList = new List<Korpusas>();
        private List<MOBO> MOBOList = new List<MOBO>();
        private List<PSU> PSUList = new List<PSU>();
        private List<RAM> RAMList = new List<RAM>();
        private List<SSD> SSDList = new List<SSD>();
        //sudaromas prisijungimas su db, konstruktorius perduoda path
        private SQLiteConnection Conn { get; set; }
        public Database(string a)
        {
            Conn = new SQLiteConnection(a);
        }
        //kintamieji perduoti informacijai is GetDalisInfo() metodo
        string a = null, b = null, c = null, d = null;
        float e = 0.0f;
        //kreipiamasi i db informacijos apie dalis, su ja kuriami objektai
        public void SukurtiObjektus()
        {
            Conn.Open();
            //kategorijos 
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT pavadinimas FROM kategorija", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        KategorijuList.Add(Reader.GetString(0));
            //cooler
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,jungties_tipas FROM cooler", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        CoolerList.Add(new Cooler(a, b, c, d, e, Reader.GetString(1)));
                    }
            //cpu 
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,jungties_tipas,ram_speed_reikalavimai,galios_reikalavimai FROM cpu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        CPUList.Add(new CPU(a, b, c, d, e, Reader.GetString(1), Reader.GetInt32(2), Reader.GetInt32(3)));
                    }
            //gpu 
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,jungties_tipas,galios_reikalavimai FROM gpu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        GPUList.Add(new GPU(a, b, c, d, e, Reader.GetString(1), Reader.GetInt32(2)));
                    }            
            //hdd 
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,jungtis FROM hdd", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        HDDList.Add(new HDD(a, b, c, d, e, Reader.GetString(1)));
                    }                
            //korpusu
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,montavimo_tipas FROM korpusas", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        KorpusasList.Add(new Korpusas(a, b, c, d, e, Reader.GetString(1)));
                    }   
            //mobo 
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,korpuso_tipas,cpu_jungties_tipas,ram_speed_min,ram_speed_max,ram_jungciu_kiekis,gpu_jungties_tipas,sata_kiekis,mdot2_kiekis FROM mobo", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        MOBOList.Add(new MOBO(a, b, c, d, e, Reader.GetString(1), Reader.GetString(2), Reader.GetInt32(3), Reader.GetInt32(4), Reader.GetInt32(5), Reader.GetString(6), Reader.GetInt32(7), Reader.GetInt32(8)));
                    }   
            //psu 
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,galia,efektyvumas FROM psu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        PSUList.Add(new PSU(a, b, c, d, e, Reader.GetInt32(1), Reader.GetInt32(2)));
                    }  
            //ram
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,ram_speed FROM ram", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        RAMList.Add(new RAM(a, b, c, d, e, Reader.GetInt32(1)));
                    }   
            //ssd 
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT dalies_id,tipas FROM ssd", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                    {
                        GetDalisInfo(Reader.GetInt32(0));
                        SSDList.Add(new SSD(a, b, c, d, e, Reader.GetString(1)));
                    }
            Conn.Close();
        }
        //kuriant objekta kvieciamas sis metodas bei perduodamas id, pagal id randama
        //"dalis" lenteles tinkamas irasas ir paimama modelis, specifikacija ir pns.
        public void GetDalisInfo(int f)
        {
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT id,gamintojas,modelis,specifikacija,paveikslelis,kaina FROM dalis", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        if (Reader.GetInt32(0) == f)
                        {
                            a = Reader.GetString(1);
                            b = Reader.GetString(2);
                            c = Reader.GetString(3);
                            d = Reader.GetString(4);
                            e = Reader.GetFloat(5);
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
