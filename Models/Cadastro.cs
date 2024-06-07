using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCartorio.Models
{
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }
        public string? NomeDevedor { get; set; }
        public string? DocumentoDevedor { get; set; }
        public string? NomeApresentante { get; set; }
        public string? DocumentoApresentante { get; set; }
        public string? NomeCredor { get; set; }
        public string? DocumentoCredor { get; set; }
        public string? NumeroTitulo { get; set; }
        public string? ValorTitulo { get; set; }
        public DateTime DataEmissao { get; set; }
        public string? EspecieTitulo { get; set; }
        public string? Protocolo { get; set; }
        public DateTime DataApresentacao { get; set; }
        public string? Valor { get; set; }
        public int ProtocoloGerado { get; set; }
    }
}
