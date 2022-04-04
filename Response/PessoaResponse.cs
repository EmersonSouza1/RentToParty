using System.ComponentModel.DataAnnotations;

namespace RentToParty.Response
{
    /// <summary>
    /// Dados do Individuo.
    /// </summary>
    public class PessoaResponse
    {
        /// <summary>
        /// Identificador da pessoa na tabela.
        /// </summary>
        public int IdPessoa { get; set; }
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
        public string Telefone { get; set; }

        /// <summary>
        /// Endereço da pessoa.
        /// </summary>
        public EnderecoResponse Endereco { get; set; }
    }
}
