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
            //isvalome sarasa, kad galetu refreshint su atnaujinta informacija
            DaliuPasirinkimasSarasas.Items.Clear();
            //ziuri kuri kategorija pasirinkta, jai priklausancia informacija supildo i datagrida, refreshina
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
            //pasirinke dali, paspaude prideti, isrenkame informacija is pasirinktos dalies cellu
            DataGridCellInfo GamintojoCell = DaliuPasirinkimasSarasas.SelectedCells[1];
            string Gamintojas = (GamintojoCell.Column.GetCellContent(GamintojoCell.Item) as TextBlock).Text;
            DataGridCellInfo ModelioCell = DaliuPasirinkimasSarasas.SelectedCells[2];
            string Modelis = (ModelioCell.Column.GetCellContent(ModelioCell.Item) as TextBlock).Text;
            DataGridCellInfo SpecifikacijosCell = DaliuPasirinkimasSarasas.SelectedCells[3];
            string Specifikacija = (SpecifikacijosCell.Column.GetCellContent(SpecifikacijosCell.Item) as TextBlock).Text;
            DataGridCellInfo KainosCell = DaliuPasirinkimasSarasas.SelectedCells[4];
            string Kaina = (KainosCell.Column.GetCellContent(KainosCell.Item) as TextBlock).Text;
            //isvalome sarasa, kad galetu refreshint su atnaujinta informacija
            PasirinktosDalysSarasas.Items.Clear();
            //ieskome datagride eilutes kurioje kategorija sutampa su pasirinkta kategorija
            int i = PasirinktosDalysList.FindIndex(a => a.GetKategorija() == PasirinktiKategorija.Text);
            //tikriname ar kazkokia dalis jau buvo pasirinkta, if true, jos kaina ir galia kurie iejo i suma ir
            //galios reikalavimus pasalinama, kitu atveju ta eilute buvo tuscia, padarome, kad nuo siol naudojama
            if (PasirinktosDalysList[i].Naudojamas == true)
            {
                SkaiciuotiSuma(i, 0);
                SkaiciuotiGalia(i, 0);
            }
            else
                PasirinktosDalysList[i].Naudojamas = true;
            //informacija kuria isrinkome is vieno datagrido supildome i kita
            PasirinktosDalysList[i].Gamintojas = Gamintojas;
            PasirinktosDalysList[i].Modelis = Modelis;
            PasirinktosDalysList[i].Specifikacija = Specifikacija;
            //kaina string su euro zenklu, tai nukerpa ir pavercia i float, kad ateiti tikrint butu paprasciau
            string KainaTrim = Kaina.Substring(0, Kaina.Length - 2);
            PasirinktosDalysList[i].Kaina = float.Parse(KainaTrim);
            //baigus pildyti informacija apie pasirinkta dali, paimama jos kaina ir galia, pridedama 
            SkaiciuotiSuma(i, 1);
            SkaiciuotiGalia(i, 1);
            //refreshinamas datagrid su atnaujinta informacija
            for (int j = 0; j < PasirinktosDalysList.Count; j++)
                PasirinktosDalysSarasas.Items.Add(PasirinktosDalysList[j]);
        }
        private void PasalintiPasirinktaDali(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo KategorijosCell = PasirinktosDalysSarasas.SelectedCells[0];
            string Kategorija = (KategorijosCell.Column.GetCellContent(KategorijosCell.Item) as TextBlock).Text;

            PasirinktosDalysSarasas.Items.Clear();

            int i = PasirinktosDalysList.FindIndex(a => a.GetKategorija() == Kategorija);

            SkaiciuotiSuma(i, 0);
            SkaiciuotiGalia(i, 0);

            PasirinktosDalysList[i].Gamintojas = "";
            PasirinktosDalysList[i].Modelis = "";
            PasirinktosDalysList[i].Specifikacija = "";
            PasirinktosDalysList[i].Kaina = 0.0f;
            PasirinktosDalysList[i].Naudojamas = false;
            
            for (int j = 0; j < PasirinktosDalysList.Count; j++)
                PasirinktosDalysSarasas.Items.Add(PasirinktosDalysList[j]);
        }
        float Suma = 0.0f;
        public void SkaiciuotiSuma(int i, int j)
        {
            if (j == 0)
                Suma -= PasirinktosDalysList[i].Kaina;
            else
                Suma += PasirinktosDalysList[i].Kaina;

            DaliuSuma.Content = Math.Round(Suma, 2);
        }
        int Galia = 0;
        public void SkaiciuotiGalia(int i, int j)
        {
            int k = DB.GetCPUList().FindIndex(a => a.GetModelis() == PasirinktosDalysList[i].Modelis);
            if (k == -1)
            {
                k = DB.GetGPUList().FindIndex(a => a.GetModelis() == PasirinktosDalysList[i].Modelis);
                if (k != -1)
                {
                    if (j == 0)
                        Galia -= DB.GetGPUList()[k].GetGaliosReikalavimai();
                    else
                        Galia += DB.GetGPUList()[k].GetGaliosReikalavimai();
                }
            }
            else
                if (j == 0)
                    Galia -= DB.GetCPUList()[k].GetGaliosReikalavimai();
                else
                    Galia += DB.GetCPUList()[k].GetGaliosReikalavimai();

            GaliosReikalavimai.Content = Galia + 150;
        }





        public void TikrintiSuderinamuma()
        {
            //cooler

        }
    }
}
