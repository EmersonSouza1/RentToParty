using System.ComponentModel.DataAnnotations;

namespace RentToParty.Response
{
    /// <summary>
    /// Dados do Individuo.
    /// </summary>
    public class PessoaSimplesResponse
    {
        /// <summary>
        /// Nome completo do individuo.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Email de Contato.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone de Contato.
        /// </summary>
        public string Telefone { get; set; }

    }
}
