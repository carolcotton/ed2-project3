using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using caroline.ed2.project._3.Model;

namespace caroline.ed2.project._3
{
    class Controller
    {
        private List<Contato> contatos;

        public List<Contato> Contatos
        {
            get { return contatos; }
        }
        public Controller()
        {            
           contatos = new List<Contato>();
        }

        public void Adicionar(Contato c)
        {
            contatos.Add(c);
        }

        public void Remover (string email)
        {            
            foreach (var c in contatos)
            {
                if (c.Email.Equals(email))
                {                    
                    contatos.Remove(c);
                    break;
                }
            }                
        }

        public Contato Retorna(string email)
        {
            foreach(var c in contatos)
            {
                if(c.Email.Equals(email))
                {
                    return c;
                }
            }
            return null;
        }

        public void Alterar(string email, Contato newContato)
        {
            int i = 0;
            foreach (var c in contatos)
            {
                if (c.Email.Equals(email))
                {
                    contatos.Remove(c);
                    contatos.Insert(i, newContato);
                    break;
                }
                i++;
            }
        }
    }
}
