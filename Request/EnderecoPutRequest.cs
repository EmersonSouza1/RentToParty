using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    /// <summary>
    /// Endereço.
    /// </summa
    public class EnderecoPutRequest
    {
        /// <summary>
        /// Identificador do Endereço.
        /// </summa
        [Required(ErrorMessage = "O Identificador é obrigatorio!")]
        public int IdEndereco { get; set; }
        /// <summary>
        /// Cep do endereço.
        /// </summa
        
        public int Cep { get; set; }

        /// <summary>
        /// Número do local.
        /// </summa
        public string Numero { get; set; }

        /// <summary>
        /// Informação complementar ao endereço.
        /// </summa
        public string Complemento { get; set; }

    }
}