using System;
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
        [Required(ErrorMessage = "O Nome é obrigatorio")]
        public string Nome { get; set; }

        /// <summary>
        /// CPF/CNPJ do Individuo.
        /// </summary>
        [Required(ErrorMessage = "O CPF/CNPJ é obrigatorio")]
        [StringLength( 14, ErrorMessage = "O tamanho do CPF_CNPJ deve ser entre 11 e 14 digitos", MinimumLength = 11)]
        [RegularExpression(@"^\d{11,14}$", ErrorMessage = "O CPF_CNPJ deve deve conter apenas números.")]
        public string CPF_CNPJ { get; set; }

        /// <summary>
        /// Data de Nascimento.
        /// </summary>
        [Required(ErrorMessage = "A Data de Nascimento é obrigatorio!")]
        public DateTime? DtaNascimento { get; set; }

        /// <summary>
        /// Email de Contato.
        /// </summary>
        [Required(ErrorMessage = "O Email é obrigatorio!")]
        [EmailAddress(ErrorMessage = "O Email informado não é valido!")]
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
