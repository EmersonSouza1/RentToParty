using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    /// <summary>
    /// Endereço.
    /// </summa
    public class EnderecoRequest
    {
        /// <summary>
        /// Cep do endereço, exp: 01001000.
        /// </summa
        [Required(ErrorMessage = "O Cep é obrigatorio!")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O Cep deve conter 8 digitos.")]
        public string Cep { get; set; }

        /// <summary>
        /// Número do local, para ausência de número, utilizar [S/N].
        /// </summa
        [Required(ErrorMessage = "O Endereço é obrigatorio!")]
        [StringLength(5 ,ErrorMessage = "O número deve conter até 5 caracteres.")]
        public string Numero { get; set; }

        /// <summary>
        /// Informação complementar ao endereço, exp: Bloco 01 Apartamento 102.
        /// </summa
        [StringLength(25, ErrorMessage = "O complemento deve conter até 25 caracteres.")]
        public string Complemento { get; set; }

    }
}