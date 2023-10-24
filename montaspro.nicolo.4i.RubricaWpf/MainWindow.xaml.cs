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
            try
            {
                Contatto[] Contatti = new Contatto[100];
                for (int i = 0; i < Contatti.Length; i++)
                    Contatti[i] = new Contatto();

                int idx = 0;

                StreamReader fin = new StreamReader("Dati.csv");
                while (!fin.EndOfStream)
                {
                    string riga = fin.ReadLine();
                    Contatto c = new Contatto(riga);

                    Contatti[idx++] = c;
                }

                dgDati.ItemsSource = Contatti;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No no!!\n\n" + ex.Message);
            }

            /*
            try
            {
                Contatto c = new Contatto();
                c.Numero = 1;
                c.Nome = "Maurizio";
                c.Cognome = "Conti";
                c.EMail = "maurizio.conti@ittsrimini.edu.it";
                c.Telefono = "3337722";
                c.CAP = "47923";

                Contatti[0] = c;
       
                Contatto c1 = new Contatto { Numero = 2, Nome = "Riccardo", Cognome = "Bianchi" };
                Contatti[1] = c1;

                Contatto c2 = new Contatto (  2, "Antonio", "Vallone" );
                Contatti[2] = c2;
            }
            catch (Exception err)
            {
                MessageBox.Show("No no!!\n" + err.Message);
            }
            */


        }

    }
}
