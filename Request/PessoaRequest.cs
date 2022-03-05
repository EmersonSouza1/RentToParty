using System.ComponentModel.DataAnnotations;
namespace RentToParty.Request
{
    /// <summary>
    /// Dados do Individuo.
    /// </summary>
    public class PessoaRequest 
    {
        /// <summary>
        /// Nome completo do individuo.
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CPF/CNPJ do Individuo.
        /// </summary>
        [Required]
        public string CPF_CNPJ { get; set; }

        /// <summary>
        /// Email de Contato.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Telefone de Contato.
        /// </summary>
        public long Telefone { get; set; }

    }
}
