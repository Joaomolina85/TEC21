using SistemaCartorio.Entidades;
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
using System.Xml;
using System.Xml.Linq;
using SistemaCartorio.Models;
using System.Data.SqlTypes;

namespace SistemaCartorio
{
    public partial class Inicial : Form
    {
        private baseContext _baseContext = new baseContext();
        public Inicial()
        {
            InitializeComponent();
        }

        private void Inicial_Load(object sender, EventArgs e)
        {
            //botao de salvar inativo.
            button2.Enabled = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Selecione um Arquivo XML";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Lendo o arquivo.
                    string filePath = openFileDialog.FileName;
                    XDocument xDoc = XDocument.Load(filePath);

                    var Guardarimportacoes = new List<Models.Importacao>();
                    // variavel para armazenar informações que recebo do arquivo xml.

                    var tituloNodes = xDoc.Descendants("Titulo");
                    foreach (var titulo in tituloNodes)
                    {
                        var LerImportacao = new Models.Importacao
                        {
                            Protocolo = titulo.Element("Protocolo")?.Value,
                            NomeDevedor = titulo.Element("NomeDevedor")?.Value,
                            DocumentoDevedor = titulo.Element("DocumentoDevedor")?.Value,
                            NomeApresentante = titulo.Element("NomeApresentante")?.Value,
                            DocumentoApresentante = titulo.Element("DocumentoApresentante")?.Value,
                            NomeCredor = titulo.Element("NomeCredor")?.Value,
                            DocumentoCredor = titulo.Element("DocumentoCredor")?.Value,
                            NumeroTitulo = titulo.Element("NumeroTitulo")?.Value,
                            ValorTitulo = titulo.Element("ValorTitulo")?.Value,
                            DataEmissao = DateTime.Parse(titulo.Element("DataEmissao")?.Value),
                            EspecieTitulo = titulo.Element("EspecieTitulo")?.Value,
                        };
                        Guardarimportacoes.Add(LerImportacao);
                    }

                    //apresentar no gridView
                    dataGridView1.DataSource = Guardarimportacoes;

                    //fazer botao aparecer.
                    button2.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao ler o arquivo XML: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //função para salvar todas informações, data da geração, protocolo gerado.
        private async void button2_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja salvar os dados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                // recebendo meus valores do datagrid view.
                var dados = dataGridView1.DataSource as List<Models.Importacao>;

                for (int i = 0; i < dados.Count; i++)
                {
                    //numero de protocolo gerado para cada salvar.
                    Random numAleatorio = new Random();
                    int procotocolo = numAleatorio.Next(1000000, 9999999);

                    //gerar valor de 10% baseado no valor recebido.
                    SqlMoney valorPorcentagemConvertido = SqlMoney.Parse(dados[i].ValorTitulo);
                    SqlMoney valorPorcetagem = valorPorcentagemConvertido * 0.10m;

                    //valores para armazenar no banco de dados,
                    var salvarDados = new Cadastro
                    {
                        NomeDevedor = dados[i].NomeDevedor,
                        DocumentoDevedor = dados[i].DocumentoDevedor,
                        NomeApresentante = dados[i].NomeApresentante,
                        DocumentoApresentante = dados[i].DocumentoApresentante,
                        NomeCredor = dados[i].NomeCredor,
                        DocumentoCredor = dados[i].DocumentoCredor,
                        NumeroTitulo = dados[i].NumeroTitulo,
                        ValorTitulo = dados[i].ValorTitulo,
                        DataEmissao = dados[i].DataEmissao,
                        EspecieTitulo = dados[i].EspecieTitulo,
                        Protocolo = dados[i].Protocolo,
                        DataApresentacao = DateTime.Today,
                        Valor = valorPorcetagem.ToString(),
                        ProtocoloGerado = procotocolo
                    };
                    _baseContext.cadastro.Add(salvarDados);
                }
                _baseContext.SaveChanges();
                dataGridView1.DataSource = "";
                MessageBox.Show("Dados salvo com sucesso");
            }
            else
            {
                MessageBox.Show("Operação Cancelada");
                dataGridView1.DataSource = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CarregarArquivos arquivos_load = new CarregarArquivos();
            arquivos_load.Show();
            this.Hide();
        }
    }
}
