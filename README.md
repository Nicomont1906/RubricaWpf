# RubricaWpf
```
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
            }

```
Nel codice MainWindow.cs andiamo a creare il metodo "InitializeComponent() nel quale andiamo a creare un vettore di 100 elementi. 
Successivamente con l'operazione tray andiamo a gestire eventuali eccezzioni e poi con un ciclio for andiamo a popolare il vettore. Andiamo ad aprire un file "Dati.csv" per visualizzzare quello che c'è sccritto e inzializziamo un contatore "idx" a 0 per l'indice del vettore. Nel blocco while scorriamo il file fino alla fine e ogni riga fine considerata come una stringa che viene memorizzata nel vettore. Con l'operazione di catch andiamo a visualizzare a schermo le eventuali eccezzioni. "Contatto c = e.Row.Item as Contatto;" ottiene l'oggetto Contatto associato alla riga corrente e se l'oggetto Contatto è diverso da null e ha la chiave primaria (Pk) uguale a 0, imposta lo sfondo e il testo della riga per evidenziarla.
```
public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Contatto c = new Contatto();
            c.Numero = 1;
            c.Nome = "Nicolò";
            c.Cognome = "Montaspro";

            Contatto[] Contatti = new Contatto[100];
            Contatti[0] = c;

            Contatti[1].Nome = "Riccardo";
            Contatti[1].Cognome = "Bianchi";
        }
    }
}
```

Successivamente siamo passati nel codice MainWindow.xaml.cs per testare la nostra classe "Contatto" creandone un'istanza. Aggiungiamo una breackpoint in una riga di codice qualsiasi, basta che ci sia qualcosa di scritto. Verifichiamo le variabili locali e vredmo il suo conteuto pubblico ma anche quello privato. In successione allochiamo spazio per cento elementi in un vettore chiamato "Contatti" all'interno della classe "Contatto",sistemiamo il breackpoint e rilanciamo il programma. Ricontrollando le variabili "Contatti" è grande 100 elementi ma solo il primo ha un valore corretto, tutti gli altri sono null. Aggiungiamo altre due breackpoint e rilanciamo il programma, all'interno delle variabili vedremo in rosso i campi e le relative property modificati.
