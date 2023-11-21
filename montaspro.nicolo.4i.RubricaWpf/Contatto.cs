using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace montaspro.nicolo._4i.RubricaWpf
{
    internal class Contatto
    {
      
        private string nome;
        private string cognome;
        private string email;
        private int numero;
        private string cellulare;

        

        public Contatto(string row)
        {
            string[] fields = row.Split(';');
            if (fields.Length >= 5)
            {
                numero = 0;
                int.TryParse(fields[0], out numero);
                nome = fields[1];
                cognome = fields[2];
                cellulare = fields[3];
                email = fields[4];
            }
        }
        public Contatto() { }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Cellulare { get => cellulare; set => cellulare = value; }
        public int Numero { get => numero; set => numero = value; }
    }
}
