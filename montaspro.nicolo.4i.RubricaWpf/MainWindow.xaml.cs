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
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             int idx = 0;
            Contatto[] Contatti = new Contatto[100];
            try
                {
                    StreamReader buffer = new StreamReader("Dati.csv");

                for (int i = 0; i < Contatti.Length; i++)
                    if (Contatti[i] == null)
                        Contatti[i] = new Contatto();
                idx = 0;
                buffer.ReadLine();
                while (!buffer.EndOfStream)
                {
                    string row = buffer.ReadLine();
                    Contatto contatto = new Contatto(row);
                    Contatti[idx++] = contatto;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgArray.ItemsSource = Contatti;
        }
        private void dgArray_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto? c = e.Row.Item as Contatto;
            if (c != null)
                if (c.Numero == 0) 
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;
                }
            

        }

    }
}
