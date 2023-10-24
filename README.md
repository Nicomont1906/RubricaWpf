# RubricaWpf

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace montaspro.nicolo._4i
{
    internal class Contatto
    {
        private int numero;
        private string nome;
        private string cognome;

        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public int Numero { get => numero; set => numero = value; }
    }
}

```
In questo codice come prima cosa è stata creata una classe c# rinominata "Contatto" alla quale sono stati aggiunti poi tre attributi privati: (int numero,string nome, string cognome) che in successione sono stati incapsulati utilizzando le "Property".
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
