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

        
        [Key]
        [Column("ID_USUARIO_INCLUSAO")]
        public Int64 IdUsuarioInclusao { get; set; }

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
        public DateTime Data_Nascimento { get; set; }


        [Key]
        [Column("ID_USUARIO_ALTERACAO")]
        public Int64 IdUsuarioAlteracao { get; set; }

        [Column("DT_ALTERACAO")]
        public DateTime Data_Alteracao { get; set; }

        [Column("DT_INCLUSAO")]
        public DateTime Data_Inclusao { get; set; }

    }
}
