using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("Pacotes")]
    public class Pacotes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "Nome de pacote é obrigatório")]
        public string NomePacote { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATETIME")]
        [DataType(DataType.DateTime)]
        public DateTime DataIda { get; set; }

        [Column(TypeName = "DATETIME")]
        [DataType(DataType.DateTime)]
        public DateTime DataVolta { get; set; }

        [Column("Valor" , TypeName = "DECIMAL (18,2)")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Column(TypeName = "BIT")]
        public bool Ativo { get; set; }

        public int CidadeId { get; set; }

        [ForeignKey("Id")]
        public Cidades Cidades { get; set; }


        public void AlterarParaInativo()
        {
            Ativo = false;
        }

        public void AlterarInformacoes(string nomePacote, string descricao, DateTime dataIda, DateTime dataVolta, decimal valor, bool ativo, int cidadeId)
        {
            NomePacote = nomePacote;
            Descricao = descricao;
            DataIda = dataIda;
            DataVolta = dataVolta;
            Valor = valor;
            Ativo = ativo;
            CidadeId = cidadeId;
        }
    }
}
