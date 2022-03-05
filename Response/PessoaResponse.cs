using System.ComponentModel.DataAnnotations;

namespace RentToParty.Response
{
    /// <summary>
    /// Dados do Individuo.
    /// </summary>
    public class PessoaResponse
    {
        /// <summary>
        /// Nome completo do individuo.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF/CNPJ do Individuo.
        /// </summary>
        public string CPF_CNPJ { get; set; }

        /// <summary>
        /// Email de Contato.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone de Contato.
        /// </summary>
        public long Telefone { get; set; }
    }
}
