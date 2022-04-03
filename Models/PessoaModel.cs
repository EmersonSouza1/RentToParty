using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    /// <summary>
    /// Representação da tabela Pessoa no banco de dados.
    /// </summary>
    [Table("Pessoa")]
    public class PessoaModel
    {
        /// <summary>
        /// Identificador da pessoa na tabela.
        /// </summary>
        [Key()]
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
        /// Data de Nascimento.
        /// </summary>
        public DateTime DtaNascimento { get; set; }

        /// <summary>
        /// Email de Contato.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone de Contato.
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Identificador do endereco.
        /// </summary>
        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }

        /// <summary>
        /// Endereço da pessoa.
        /// </summary>
        public virtual EnderecoModel Endereco { get; set; }

    }
}
