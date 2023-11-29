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
using System.IO;

namespace montaspro.nicolo._4i.RubricaWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Contatto[] Contatti = new Contatto[100];
            try  
            {
                for (int i = 0; i < Contatti.Length; i++)
                {
                    Contatti[i] = new Contatto();
                }
                StreamReader fin = new StreamReader("Dati.csv");
                int idx = 0;
                while (!fin.EndOfStream)
                {
                    string? riga = fin.ReadLine();
                    Contatti[idx] = new Contatto(riga);
                    idx++;
                }
                dgDati.ItemsSource = Contatti;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }

        private void dgDati_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto c = e.Row.Item as Contatto;
            if (c != null)
            {
                if (c.Pk == 0)
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;
                }
                else if (c.Numero.StartsWith("3"))
        {
            e.Row.Background = Brushes.Yellow;
        }
            }
        }

    }
}
