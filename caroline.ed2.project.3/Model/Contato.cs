using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caroline.ed2.project._3.Model
{
    class Contato
    {
        
        private string email;
        private string telefone;
        private string nome;

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public Contato(string email, string telefone, string nome)
        {
            this.email = email;
            this.telefone = telefone;
            this.nome = nome;
        }
        public Contato()
        {
            
        }
    }
}
