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

//TODO:
//- pervadinti puse pavadinimu nes jie kvaili
//- padaryt sioki toki prisijungima
//- leisti papildyti/editinti db
//- tikrinti pasirinktu komponentu suderinamuma
//- kainas ideti

namespace college_practice2_pcpartpicker
{
    public partial class MainWindow : Window
    {
        //listas objektu pasirinktu daliu informacijos datagridui
        List<PasirinktosDalys> PasirinktosDalys = new List<PasirinktosDalys>();
        //db ir path
        Database DB = new Database(@"Data Source=C:\Users\rytuciss\source\repos\college_practice2_pcpartpicker\college_practice2_pcpartpicker\database\database.db");
        public MainWindow()
        {
            InitializeComponent();
            //setupas
            try
            {
                //is db imama info ir kuriami objektai
                DB.SukurtiObjektus();
                //sukurus db sukuriamas listas stringu, kuriame laikoma kategorijos lengvai prieigai
                for (int i = 0; i < DB.GetKategorijuList().Count; i++)
                {
                    //combobox sudedama egzistuojancios kategorijos vartotojui pasirinkti
                    PasirinktiKategorija.Items.Add(DB.GetKategorijuList()[i]);
                    //sukuriami objektai pasirinktu daliu ir duodamos kategorijos,
                    //kita informacija bus sudedama tik pridejus konkrecias dalis
                    PasirinktosDalys.Add(new PasirinktosDalys(DB.GetKategorijuList()[i]));
                    //atvaizduojama pasirinktos dalys datagride
                    PasirinktosDalysSarasas.Items.Add(PasirinktosDalys[i]);
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
            DaliuPasirinkimas.Items.Clear();
            //atsizvelgiama kokia kategorija pasirinkta kategorijos combobox ir supildo sarasa
            if (PasirinktiKategorija.SelectedItem.ToString() == "COOLER")
                for (int i = 0; i < DB.GetCoolerList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetCoolerList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "CPU")
                for (int i = 0; i < DB.GetCPUList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetCPUList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "GPU")
                for (int i = 0; i < DB.GetGPUList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetGPUList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "HDD")
                for (int i = 0; i < DB.GetHDDList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetHDDList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "KORPUSAS")
                for (int i = 0; i < DB.GetKorpusuList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetKorpusuList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "MOBO")
                for (int i = 0; i < DB.GetMOBOList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetMOBOList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "PSU")
                for (int i = 0; i < DB.GetPSUList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetPSUList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "RAM")
                for (int i = 0; i < DB.GetRAMList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetRAMList()[i]);
            else if (PasirinktiKategorija.SelectedItem.ToString() == "SSD")
                for (int i = 0; i < DB.GetSSDList().Count; i++)
                    DaliuPasirinkimas.Items.Add(DB.GetSSDList()[i]);
        }
        private void DuotiDaliPasirinktiems(object sender, RoutedEventArgs e)
        {
            //paspaudus prideti dali, isrenkama informacija buvusi toje eilute
            DataGridCellInfo GamintojoCell = DaliuPasirinkimas.SelectedCells[1];
            string Gamintojas = (GamintojoCell.Column.GetCellContent(GamintojoCell.Item) as TextBlock).Text;
            DataGridCellInfo ModelioCell = DaliuPasirinkimas.SelectedCells[2];
            string Modelis = (ModelioCell.Column.GetCellContent(ModelioCell.Item) as TextBlock).Text;
            DataGridCellInfo SpecifikacijosCell = DaliuPasirinkimas.SelectedCells[3];
            string Specifikacija = (SpecifikacijosCell.Column.GetCellContent(SpecifikacijosCell.Item) as TextBlock).Text;

            PasirinktosDalysSarasas.Items.Clear();

            //pasiziurima koke kategorija pasirinkta combobox, 
            //einama i lista pasirinktu daliu ir ieskoma sutampancios kategorijos, 
            //tada virsuje isrinkta informacija sudedama i atitinkama objekta
            for (int i = 0; i < PasirinktosDalys.Count; i++)
            {
                if (PasirinktosDalys[i].GetKategorija() == PasirinktiKategorija.Text)
                {
                    PasirinktosDalys[i].Gamintojas = Gamintojas;
                    PasirinktosDalys[i].Modelis = Modelis;
                    PasirinktosDalys[i].Specifikacija = Specifikacija;
                }
                PasirinktosDalysSarasas.Items.Add(PasirinktosDalys[i]);
            }
        }
        private void PasalintiPasirinktaDali(object sender, RoutedEventArgs e)
        {

        }






        public void SkaiciuotiGalia()
        {
            int ReikalingaGalia = 0;

            for (int i = 0; i < PasirinktosDalys.Count; i++)
                if (PasirinktosDalys[i].GetKategorija() == "CPU")
                    for (int j = 0; j < DB.GetCPUList().Count; j++)
                        if (DB.GetCPUList()[i].GetModelis() == PasirinktosDalys[i].Modelis)
                            ReikalingaGalia += DB.GetCPUList()[i].GetGaliosReikalavimai();
            
            GaliosReikalavimai.Content = ReikalingaGalia;
        }





        public void TikrintiSuderinamuma()
        {
            //cooler 1 tikrinimas su mobo 
            int i = PasirinktosDalys.FindIndex(a => a.GetKategorija() == "COOLER");
            int j = DB.GetCoolerList().FindIndex(a => a.GetModelis() == PasirinktosDalys[i].Modelis);
            //string UncutString = DB.GetCoolerList()[j].GetJungtiesTipas();
            //char[] temp = UncutString.ToCharArray();
            //for (int k = 0; )
            //cpu 2 tikrinimai su mobo ir ram
            //i = PasirinktosDalys.FindIndex(a => a.GetKategorija() == "CPU");
            //j = DB.GetCPUList().FindIndex(a => a.GetModelis() == PasirinktosDalys[i].Modelis);

        }
    }
}
