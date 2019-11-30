using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace college_practice2_pcpartpicker
{
    public partial class MainWindow : Window
    {
        //sitam liste laikoma informacija kuri bus atvaizduoja pasirinktu daliu datagride
        List<PasirinktosDalys> PasirinktosDalysList = new List<PasirinktosDalys>();
        //kurti db, path per konstruktoriu
        Database DB = new Database(@"Data Source=C:\Users\rytuciss\source\repos\college_practice2_pcpartpicker\college_practice2_pcpartpicker\database\database.db");
        public MainWindow()
        {
            InitializeComponent();
            //inicializavimas
            try
            {
                //is db imama informacija ir kuriami objektai
                DB.SukurtiObjektus();
                //sukurus db sukuriamas listas stringu, kuriame laikoma kategorijos lengvai prieigai
                for (int i = 0; i < DB.GetKategorijuList().Count; i++)
                {
                    //combobox sudedama egzistuojancios kategorijos vartotojui pasirinkti
                    PasirinktiKategorija.Items.Add(DB.GetKategorijuList()[i]);
                    //sukuriami objektai pasirinktu daliu ir duodamos kategorijos,
                    //kita informacija bus sudedama tik pridejus konkrecias dalis
                    PasirinktosDalysList.Add(new PasirinktosDalys(DB.GetKategorijuList()[i]));
                    //atvaizduojama pasirinktos dalys datagride
                    PasirinktosDalysSarasas.Items.Add(PasirinktosDalysList[i]);
                }
                //kad nebutu tuscias combobox paleidus programa, pasirenka pirma kategorija
                PasirinktiKategorija.SelectedItem = DB.GetKategorijuList()[0];
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message);
                Environment.Exit(0);
            }
        }
        private void PasirinktiKategorijaComboBox(object sender, SelectionChangedEventArgs e)
        {
            DaliuPasirinkimasSarasas.Items.Clear();
            //atsizvelgiama kokia kategorija pasirinkta kategorijos combobox ir supildo sarasa
            if (PasirinktiKategorija.SelectedItem.ToString() == "COOLER")
                for (int i = 0; i < DB.GetCoolerList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetCoolerList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "CPU")
                for (int i = 0; i < DB.GetCPUList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetCPUList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "GPU")
                for (int i = 0; i < DB.GetGPUList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetGPUList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "HDD")
                for (int i = 0; i < DB.GetHDDList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetHDDList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "KORPUSAS")
                for (int i = 0; i < DB.GetKorpusuList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetKorpusuList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "MOBO")
                for (int i = 0; i < DB.GetMOBOList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetMOBOList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "PSU")
                for (int i = 0; i < DB.GetPSUList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetPSUList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "RAM")
                for (int i = 0; i < DB.GetRAMList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetRAMList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "SSD")
                for (int i = 0; i < DB.GetSSDList().Count; i++)
                    DaliuPasirinkimasSarasas.Items.Add(DB.GetSSDList()[i]);
        }
        private void DuotiDaliPasirinktiems(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo GamintojoCell = DaliuPasirinkimasSarasas.SelectedCells[1];
            string Gamintojas = (GamintojoCell.Column.GetCellContent(GamintojoCell.Item) as TextBlock).Text;
            DataGridCellInfo ModelioCell = DaliuPasirinkimasSarasas.SelectedCells[2];
            string Modelis = (ModelioCell.Column.GetCellContent(ModelioCell.Item) as TextBlock).Text;
            DataGridCellInfo SpecifikacijosCell = DaliuPasirinkimasSarasas.SelectedCells[3];
            string Specifikacija = (SpecifikacijosCell.Column.GetCellContent(SpecifikacijosCell.Item) as TextBlock).Text;

            PasirinktosDalysSarasas.Items.Clear();

            for (int i = 0; i < PasirinktosDalysList.Count; i++)
            {
                if (PasirinktosDalysList[i].GetKategorija() == PasirinktiKategorija.Text)
                {
                    PasirinktosDalysList[i].Gamintojas = Gamintojas;
                    PasirinktosDalysList[i].Modelis = Modelis;
                    PasirinktosDalysList[i].Specifikacija = Specifikacija;
                }
                PasirinktosDalysSarasas.Items.Add(PasirinktosDalysList[i]);
            }
        }
        private void PasalintiPasirinktaDali(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo ModelioCell = PasirinktosDalysSarasas.SelectedCells[2];
            string Modelis = (ModelioCell.Column.GetCellContent(ModelioCell.Item) as TextBlock).Text;

            PasirinktosDalysSarasas.Items.Clear();

            for (int i = 0; i < PasirinktosDalysList.Count; i++)
            {
                if (PasirinktosDalysList[i].Modelis == Modelis)
                {
                    PasirinktosDalysList[i].Gamintojas = null;
                    PasirinktosDalysList[i].Modelis = null;
                    PasirinktosDalysList[i].Specifikacija = null;
                }
                PasirinktosDalysSarasas.Items.Add(PasirinktosDalysList[i]);
            }
        }
        public void SkaiciuotiGalia()
        {
            int ReikalingaGalia = 0;

            for (int i = 0; i < PasirinktosDalysList.Count; i++)
                if (PasirinktosDalysList[i].GetKategorija() == "CPU")
                    for (int j = 0; j < DB.GetCPUList().Count; j++)
                        if (DB.GetCPUList()[i].GetModelis() == PasirinktosDalysList[i].Modelis)
                            ReikalingaGalia += DB.GetCPUList()[i].GetGaliosReikalavimai();
            
            GaliosReikalavimai.Content = ReikalingaGalia;
        }





        public void TikrintiSuderinamuma()
        {
            //cooler 1 tikrinimas su mobo 
            int i = PasirinktosDalysList.FindIndex(a => a.GetKategorija() == "COOLER");
            int j = DB.GetCoolerList().FindIndex(a => a.GetModelis() == PasirinktosDalysList[i].Modelis);
            //string UncutString = DB.GetCoolerList()[j].GetJungtiesTipas();
            //char[] temp = UncutString.ToCharArray();
            //for (int k = 0; )
            //cpu 2 tikrinimai su mobo ir ram
            //i = PasirinktosDalys.FindIndex(a => a.GetKategorija() == "CPU");
            //j = DB.GetCPUList().FindIndex(a => a.GetModelis() == PasirinktosDalys[i].Modelis);

        }
    }
}
