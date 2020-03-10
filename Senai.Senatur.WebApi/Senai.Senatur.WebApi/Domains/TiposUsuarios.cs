using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        //Define que será chave primária
        [Key]

        //Define auto inclemento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        // Define nome da coluna e tipo de dado
        [Column(TypeName = "VARCHAR(255)")]

        //Define que é obrigatório
        [Required(ErrorMessage = "O tipo usuário é obrigatório")]
        public string Titulo { get; set; }

    }
}
