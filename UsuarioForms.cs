using SistemaCartorio.Entidades;
using SistemaCartorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaCartorio
{
    public partial class UsuarioForms : Form
    {
        private Cadastro _passarUsuario;
        private baseContext _baseContext = new baseContext();
        public UsuarioForms(Cadastro passarUsuario)
        {
            _passarUsuario = passarUsuario;
            InitializeComponent();
        }

        private void UsuarioForms_Load(object sender, EventArgs e)
        {
            textBox1.Text = _passarUsuario.NomeDevedor;
            textBox2.Text = _passarUsuario.DocumentoDevedor;
            textBox3.Text = _passarUsuario.NomeApresentante;
            textBox4.Text = _passarUsuario.DocumentoApresentante;
            textBox5.Text = _passarUsuario.NomeCredor;
            textBox6.Text = _passarUsuario.DocumentoCredor;
            textBox7.Text = _passarUsuario.NumeroTitulo;
            textBox8.Text = _passarUsuario.ValorTitulo;
            textBox9.Text = _passarUsuario.DataEmissao.ToString();
            textBox10.Text = _passarUsuario.EspecieTitulo;
            textBox11.Text = _passarUsuario.Protocolo;
            textBox12.Text = _passarUsuario.DataApresentacao.ToString();
            textBox13.Text = _passarUsuario.Valor;
            textBox14.Text = _passarUsuario.ProtocoloGerado.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult resposta = MessageBox.Show("Deseja editar os dados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                int id = _passarUsuario.Id;
                var editarDados = _baseContext.cadastro.Where(x => x.Id == id).FirstOrDefault();

                if (editarDados != null)
                {
                    editarDados.NomeDevedor = textBox1.Text;
                    editarDados.DocumentoDevedor = textBox2.Text;
                    editarDados.NomeApresentante = textBox3.Text;
                    editarDados.DocumentoApresentante = textBox4.Text;
                    editarDados.NomeCredor = textBox5.Text;
                    editarDados.DocumentoCredor = textBox6.Text;
                    editarDados.NumeroTitulo = textBox7.Text;
                    editarDados.ValorTitulo = textBox8.Text;
                    editarDados.DataEmissao = DateTime.Parse(textBox9.Text);
                    editarDados.EspecieTitulo = textBox10.Text;
                    editarDados.Protocolo = textBox11.Text;
                    editarDados.DataApresentacao = DateTime.Parse(textBox12.Text);
                    editarDados.Valor = textBox13.Text;
                    editarDados.ProtocoloGerado = int.Parse(textBox14.Text);

                    _baseContext.cadastro.Update(editarDados);
                    _baseContext.SaveChanges();

                    MessageBox.Show("Dados Editado Com sucesso.");
                    //CarregarArquivos carregar = new CarregarArquivos();
                    //carregar.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Operação Cancelada.");
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja excluir os dados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                int id = _passarUsuario.Id;
                var excluirDados = _baseContext.cadastro.Where(x => x.Id == id).FirstOrDefault();

                if (excluirDados != null)
                {
                    _baseContext.cadastro.Remove(excluirDados);
                    _baseContext.SaveChanges();

                    MessageBox.Show("Dados excluido com sucesso.");
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Operação Cancelada.");
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
