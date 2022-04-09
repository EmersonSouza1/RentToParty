using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("Id")]
        public int IdEndereco { get; set; }

        /// Cep do endereço, exp: 01001000.
        /// </summa
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O Cep deve conter 8 digitos.")]
        public string Cep { get; set; }

        /// <summary>
        /// Número do local, para ausência de número, utilizar [S/N].
        /// </summa
        [StringLength(5, ErrorMessage = "O número deve conter até 5 caracteres.")]
        public string Numero { get; set; }

        /// <summary>
        /// Informação complementar ao endereço, exp: Bloco 01 Apartamento 102.
        /// </summa
        [StringLength(25, ErrorMessage = "O complemento deve conter até 25 caracteres.")]
        public string Complemento { get; set; }

    }
}