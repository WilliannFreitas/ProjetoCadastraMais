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
        public string logIn { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime Data_Nascimento { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime Data_Inclusao { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime Data_Alteracao { get; set; }

    }
}
