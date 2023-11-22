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
class Contatto
    {
        private int pk;
        private string nome;
        private string cognome;
        private string numero;
        private string indirizzo;
        private string mail;

        public int Pk { get => pk; set => pk = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Numero { get => numero; set => numero = value; }
        
        public string Mail { get => mail; set => mail = value; }
        public string Indirizzo { get => indirizzo; set => indirizzo = value; }
        

        public Contatto(string riga)
        {

            string[] campi = riga.Split(';');
            
            if (int.TryParse(campi[0], out int res) && campi.Length==5) {
                this.pk = res;
                this.Nome = campi[1];
                this.Cognome = campi[2];
                this.numero = campi[3];
                this.mail = campi[4];
            }
            else
                this.pk = 0;



        }

        public Contatto()
        {
        }
    }
```
All'interno della classe Contatto  Dichiariamo un campo privato "pk" di tipo intero che rappresenta la chiave primaria del contatto. Poi andiamo a dichiarare altri campi privati come:
"private string nome;, private string cognome;, private string numero; private string indirizzo;, private string mail;".
Successivamente andiamo a creare delle proprietà pubbliche con metodi di accesso (get e set) per accedere e modificare i campi privati. Ad esempio, public int Pk { get => pk; set => pk = value; } permette di accedere e modificare la chiave primaria (pk) del contatto.
Andiamo a creare il primo costruttore: "public Contatto(string riga)" che è il costruttore della classe che accetta una stringa (riga) come parametro. Questo metodo è utilizzato per inizializzare un oggetto Contatto a partire dai dati presenti nella stringa. La stringa viene suddivisa in campi utilizzando il delimitatore ';' e il metodo Split. Come ultimo passaggio creiamo il costruttore di default: "public Contatto()" che  è il secondo costruttore della classe, che non accetta alcun parametro. Questo costruttore viene utilizzato per creare un oggetto Contatto senza inizializzare i suoi attributi.
