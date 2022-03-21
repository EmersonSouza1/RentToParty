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
        public string CPF_CNPJ { get; set; }

        /// <summary>
        /// Data de Nascimento.
        /// </summary>
        [Required(ErrorMessage = "A Data de Nascimento é obrigatorio!")]
        public DateTime DtaNascimento { get; set; }

        /// <summary>
        /// Email de Contato.
        /// </summary>
        [Required(ErrorMessage = "O Email é obrigatorio!")]
        public string Email { get; set; }

        /// <summary>
        /// Telefone de Contato.
        /// </summary>
        public long Telefone { get; set; }

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
