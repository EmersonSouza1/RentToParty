using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    /// <summary>
    /// Tabela de Endereço.
    /// </summa
    [Table("Endereco")]
    public class EnderecoModel
    {
        /// <summary>
        /// Identificador do Endereço
        /// </summa
        [Key()]
        public int IdEndereco { get; set; }

        /// <summary>
        /// Cep do endereço.
        /// </summa
        public int Cep { get; set; }

        /// <summary>
        /// Logradouro.
        /// </summa
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do local.
        /// </summa
        public string Numero { get; set; }

        /// <summary>
        /// Informação complementar ao endereço.
        /// </summa
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro.
        /// </summa
        public string Bairro { get; set; }

        /// <summary>
        /// Cidade.
        /// </summa
        public string Cidade { get; set; }

    }
}