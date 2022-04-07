using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTeste.Models
{
    [Table(name: "CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("ID_CLIENTE")]
        public Int64 IdCliente { get; set;}

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("SOBRENOME")]
        public string Sobrenome { get; set; }

        [Column("DDD")]
        public string DDD { get; set; }

        [Column("TELEFONE")]
        public string Telefone { get; set; }

        [Column("CPF")]
        public string Cpf { get; set; }

        [Column("RG")]
        public string Rg { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("UsuarioInclusao")]
        [Column("ID_USUARIO_INCLUSAO")]
        public Int64 IdUsuarioInclusao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime DataInclusao { get; set; }

        [ForeignKey("UsuarioAlteracao")]
        [Column("ID_USUARIO_ALTERACAO")]
        public Int64 IdUsuarioAlteracao { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        internal virtual Usuario UsuarioInclusao { get; set; }

        internal virtual Usuario UsuarioAlteracao { get; set; }
    }
    public class ClienteParam 
    {
        public Int64 IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public Int64 IdUsuarioInclusao { get; set; }
        public Int64 IdUsuarioAlteracao { get; set; }
    }
}
