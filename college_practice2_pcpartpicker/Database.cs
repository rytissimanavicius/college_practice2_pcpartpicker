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
        //TODO:
        //- is db ciklu sumest

        private List<string> KategorijuList = new List<string>();

        private List<Cooler> CoolerList = new List<Cooler>();
        private List<CPU> CPUList = new List<CPU>();
        private List<GPU> GPUList = new List<GPU>();
        private List<HDD> HDDList = new List<HDD>();
        private List<Korpusas> KorpusasList = new List<Korpusas>();
        private List<MOBO> MOBOList = new List<MOBO>();
        private List<PSU> PSUList = new List<PSU>();
        private List<RAM> RAMList = new List<RAM>();
        private List<SSD> SSDList = new List<SSD>();
        private SQLiteConnection Conn { get; set; }
        public Database(string a)
        {
            Conn = new SQLiteConnection(a);
        }
        public void CreateObjects()
        {
            Conn.Open();

            //
            //cooler objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,jungties_tipas FROM cooler", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        CoolerList.Add(new Cooler(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
                        FillKategorijos("Procesorių aušintuvai");
                    }
                }
            }

            //
            //cpu objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,jungties_tipas,ram_speed_reikalavimai,ram_latency_reikalavimai,galios_reikalavimai FROM cpu", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        CPUList.Add(new CPU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetInt32(5), Reader.GetInt32(6), Reader.GetInt32(7)));
                        FillKategorijos("Procesoriai (CPU)");
                    }
                }
            }

            //
            //gpu objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,jungties_tipas,galios_reikalavimai FROM gpu", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        GPUList.Add(new GPU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetInt32(5)));
                        FillKategorijos("Vaizdo plokštės (GPU)");
                    }
                }
            }

            //
            //hdd objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis FROM hdd", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        HDDList.Add(new HDD(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3)));
                        FillKategorijos("HDD diskai");
                    }
                }
            }

            //
            //korpusu objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,montavimo_tipas FROM korpusas", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        KorpusasList.Add(new Korpusas(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
                        FillKategorijos("Korpusai");
                    }
                }
            }

            //
            //mobo objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,korpuso_tipas,cpu_jungties_tipas,ram_speed_reikalavimai,ram_latency_reikalavimai,ram_jungciu_kiekis,gpu_jungties_tipas,sata_kiekis,mdot2_kiekis,galios_reikalavimai FROM mobo", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        MOBOList.Add(new MOBO(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5), Reader.GetInt32(7), Reader.GetInt32(8), Reader.GetInt32(9), Reader.GetString(10), Reader.GetInt32(11), Reader.GetInt32(12), Reader.GetInt32(13)));
                        FillKategorijos("Pagrindinės plokštės (MOBO)");
                    }
                }
            }

            //
            //psu objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,galia,efektyvumas FROM psu", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        PSUList.Add(new PSU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetInt32(4), Reader.GetInt32(5)));
                        FillKategorijos("Maitinimo blokai (PSU)");
                    }
                }
            }

            //
            //ram objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,ram_speed,ram_latency,galios_reikalavimai FROM ram", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        RAMList.Add(new RAM(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetInt32(4), Reader.GetInt32(5), Reader.GetInt32(6)));
                        FillKategorijos("Operatyvoji atmintis (RAM)");
                    }
                }
            }

            //
            //ssd objektu inicializavimas
            //
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,tipas FROM ssd", Conn))
            {
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        SSDList.Add(new SSD(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
                        FillKategorijos("SSD diskai");
                    }
                }
            }

            Conn.Close();
        }

        public void FillKategorijos(string a)
        {
            if (a != null) KategorijuList.Add(a);
        }

        public int GetKategorijuKiekis()
        {
            return KategorijuList.Count;
        }

        public List<string> GetKategorijuList()
        {
            return KategorijuList;
        }
    }
}
