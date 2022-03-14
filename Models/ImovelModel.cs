using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    /// <summary>
    /// Tabela de Imovel.
    /// </summary>
    [Table("Imovel")]
    public class ImovelModel
    {
        /// <summary>
        /// Identificador do imovel.
        /// </summary>
        [Key()]
        public int IdIMovel { get; set; }

        /// <summary>
        /// Descri��o do Imovel.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Identificador do proprietario.
        /// </summary>
        [ForeignKey("Pessoa")]
        public int IdProprietario { get; set; }

        /// <summary>
        /// Proprietario.
        /// </summary>
        public virtual PessoaModel Proprietario { get; set; }

        /// <summary>
        /// Identificador do endere�o.
        /// </summary>
        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }

        /// <summary>
        /// Endere�o.
        /// </summary>
        public virtual EnderecoModel endereco { get; set; }


    }
}
