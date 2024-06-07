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
    public partial class CarregarArquivos : Form
    {
        baseContext _baseContext = new baseContext();
        public CarregarArquivos()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void CarregarArquivos_Load(object sender, EventArgs e)
        {
            var dados = _baseContext.cadastro.ToList();
            dataGridView1.DataSource = dados;

            //ocultando coluna Id, e deixando apenas para readonly,
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Id = this.dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            string NomeDevedor = this.dataGridView1.CurrentRow.Cells["NomeDevedor"].Value.ToString();
            string DocumentoDevedor = this.dataGridView1.CurrentRow.Cells["DocumentoDevedor"].Value.ToString();
            string NomeApresentante = this.dataGridView1.CurrentRow.Cells["NomeApresentante"].Value.ToString();
            string DocumentoApresentante = this.dataGridView1.CurrentRow.Cells["DocumentoApresentante"].Value.ToString();
            string NomeCredor = this.dataGridView1.CurrentRow.Cells["NomeCredor"].Value.ToString();
            string DocumentoCredor = this.dataGridView1.CurrentRow.Cells["DocumentoCredor"].Value.ToString();
            string NumeroTitulo = this.dataGridView1.CurrentRow.Cells["NumeroTitulo"].Value.ToString();
            string ValorTitulo = this.dataGridView1.CurrentRow.Cells["ValorTitulo"].Value.ToString();
            string DataEmissao = this.dataGridView1.CurrentRow.Cells["DataEmissao"].Value.ToString();
            string EspecieTitulo = this.dataGridView1.CurrentRow.Cells["EspecieTitulo"].Value.ToString();
            string Protocolo = this.dataGridView1.CurrentRow.Cells["Protocolo"].Value.ToString();
            string DataApresentacao = this.dataGridView1.CurrentRow.Cells["DataApresentacao"].Value.ToString();
            string Valor = this.dataGridView1.CurrentRow.Cells["Valor"].Value.ToString();
            string ProtocoloGerado = this.dataGridView1.CurrentRow.Cells["ProtocoloGerado"].Value.ToString();

            var passarUsuario = new Cadastro
            {
                Id = int.Parse(Id),
                NomeDevedor = NomeDevedor,
                DocumentoDevedor = DocumentoDevedor,
                NomeApresentante = NomeApresentante,
                DocumentoApresentante = DocumentoApresentante,
                NomeCredor = NomeCredor,
                DocumentoCredor = DocumentoCredor,
                NumeroTitulo = NumeroTitulo,
                ValorTitulo = ValorTitulo,
                DataEmissao = DateTime.Parse(DataEmissao),
                EspecieTitulo = EspecieTitulo,
                Protocolo = Protocolo,
                DataApresentacao = DateTime.Today,
                Valor = Valor,
                ProtocoloGerado = int.Parse(ProtocoloGerado)
            };

            UsuarioForms usuarioForms = new UsuarioForms(passarUsuario);
            usuarioForms.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

