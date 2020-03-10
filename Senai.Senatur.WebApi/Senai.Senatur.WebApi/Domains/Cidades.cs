using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("Cidades")]
    public class Cidades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR (255)")]
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Titulo { get; set; }
    }
}
