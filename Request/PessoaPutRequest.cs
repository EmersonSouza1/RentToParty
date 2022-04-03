using System.ComponentModel.DataAnnotations;
namespace RentToParty.Request
{
    /// <summary>
    /// Dados do Individuo.
    /// </summary>
    public class PessoaPutRequest 
    {
        /// <summary>
        /// Nome completo do individuo.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF/CNPJ do Individuo.
        /// </summary>
        [Required(ErrorMessage = "O CPF/CNPJ é obrigatorio")]
        public string CPF_CNPJ { get; set; }

        /// <summary>
        /// Email de Contato.
        /// </summary>
        [EmailAddress(ErrorMessage = "O Email não é valido!")]
        public string Email { get; set; }

        /// <summary>
        /// Telefone de Contato.
        /// </summary>
        [RegularExpression(@"^(\d{3})\d{5}-\d{4}$", ErrorMessage = "O telefone deve deve seguir o seguinte padrão (DDD)98888-7777")]
        public string Telefone { get; set; }

        /// <summary>
        /// Identificador do endereco.
        /// </summary>
        public int IdEndereco { get; set; }

        /// <summary>
        /// Endereço da pessoa.
        /// </summary>
        public EnderecoRequest Endereco { get; set; }

    }
}
