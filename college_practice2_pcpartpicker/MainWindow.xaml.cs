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
        public MainWindow()
        {
            Database DB = new Database(@"Data Source=C:\Users\rytuciss\source\repos\college_practice2_pcpartpicker\college_practice2_pcpartpicker\database\database.db");

            try
            {
                DB.CreateObjects();
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message);
                Environment.Exit(0);
            }

            InitializeComponent();

            for (int i = 0; i < DB.GetKategorijuKiekis(); i++)
            {
                PasirinktiKategorija.Items.Add(DB.GetKategorijuList()[i]);
            }
        }
    }
}
