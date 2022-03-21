using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    /// <summary>
    /// Tabela de Datas de Exssão das disponibilidade do imovel.
    /// </summary>
    [Table("Endereco")]
    public class Excessao_DispoModel
    {
        /// <summary>
        /// Identificador da excessao.
        /// </summary>
        [Key()]
        public int IdExcessao { get; set; }

        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [ForeignKey("Imovel")]
        public int IdImovel { get; set; }

        /// <summary>
        /// Data de Excessao.
        /// </summary>
        public DateTime DataExcessao { get; set; }

        /// <summary>
        /// Situação da Excessão.
        /// </summary>
        public string Situacao { get; set; }

        /// <summary>
        /// Obsservação da Excessao.
        /// </summary>
        public string Obsservacao { get; set; }
    }
}