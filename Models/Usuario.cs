using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTeste.Models
{
    [Table(name:"USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public Int64 IdUsuario { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("SOBRENOME")]
        public string Sobrenome { get; set; }

        [Column("LOGIN")]
        public string Login { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime DataInclusao { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime? DataAlteracao { get; set; }
    }

    public class UsuarioParam
    {
        public Int64 IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
