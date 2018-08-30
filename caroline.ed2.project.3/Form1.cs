using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caroline.ed2.project._3
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();                
        public Form1()
        {            
            InitializeComponent();            
            clearAll();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {            
            try
            {
                string email = txtEmail.Text;
                string nome = txtNome.Text;
                string telefone = txtTelefone.Text;
                if(txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("O campo email não pode ficar em branco!");
                }
                else if(controller.Retorna(txtEmail.Text.Trim()) != null)
                {
                    MessageBox.Show("\""+txtEmail.Text.Trim()+"\" já está cadastrado");
                }
                else
                {
                    controller.Adicionar(new Model.Contato(email, telefone, nome));
                    MessageBox.Show("Contato adicionado com sucesso");
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR \n"+error.Message);
            }
            clearAll();
            load();            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {           
            try
            {
                if (txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("O campo email não pode ficar em branco!");
                }
                else
                {
                    string email = txtEmail.Text;
                    string nome = txtNome.Text;
                    string telefone = txtTelefone.Text;
                    controller.Alterar(email, new Model.Contato(email, telefone, nome));
                    MessageBox.Show("Contato alterado com sucesso");
                }               
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR \n" + error.Message);
            }
            clearAll();
            load();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {                       
            try
            {
                string email = txtEmail.Text;
                Model.Contato c = controller.Retorna(email);
                gbVisualiza.Text = c.Email;
                gbVisualiza.Visible = true;
                lblVRNome.Text = c.Nome;
                lblVRTelefone.Text = c.Telefone;
                lblVNome.Text = "Nome";
                lblVTelefone.Text = "Telefone";
            }
            catch (Exception error)
            {
                clearAll();
                MessageBox.Show("ERROR \n" + error.Message);
            }            
            load();
        }       

        private void btnRemover_Click(object sender, EventArgs e)
        {            
            try
            {
                string email = txtEmail.Text;
                if (txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("É necessário informar um email para que seja removido o contato");
                }   
                else
                {
                    if(controller.Retorna(email)==null)
                    {
                        MessageBox.Show("O email informado não existe");
                    }
                    else
                    {
                        controller.Remover(email);
                        MessageBox.Show("Contato removido com sucesso");
                    }  
                }                
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            clearAll();
            load(); 
        }
        private void clearAll()
        {
            txtEmail.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            gbVisualiza.Text = "";
            gbVisualiza.Visible = false;
            lblVNome.Text = "";
            lblVTelefone.Text = "";
            lblVRNome.Text = "";
            lblVRTelefone.Text = "";
        }
        private void load()
        {
            if (controller.Contatos != null)
            {
                dgContatos.DataSource = null;
                dgContatos.DataSource = controller.Contatos;                
            }
        }
    }
}
