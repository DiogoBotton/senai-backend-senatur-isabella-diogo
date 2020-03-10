using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        //Define que será chave primária
        [Key]
        //Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Define nome da coluna e tipo de dados
        [Column(TypeName = "VARCHAR(255)")]

        //Define que é obrigatório
        [Required(ErrorMessage = "O email é obrigatório")]

        //Define o tipo de dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        //Define nome da coluna e tipo de dado
        [Column(TypeName = "VARCHAR(255)")]

        //Define que é obrigatório
        [Required(ErrorMessage = "Senha é obrigatória")]

        //Define o tipo de dados
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        //Coluna da chave estrangeira
        public int TiposUsuariosId { get; set; }

        //Define chave estrangeira
        [ForeignKey("Id")]
        public TiposUsuarios TiposUsuarios { get; set; }


    }
}
