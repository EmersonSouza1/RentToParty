using System.ComponentModel.DataAnnotations;

namespace RentToParty.Model
{
    /// <summary>
    /// Representação da tabela Pessoa no banco de dados.
    /// </summary>
    public class PessoaModel
    {
        /// <summary>
        /// Identificador na tabela.
        /// </summary>
        public int Id { get; set; }

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
