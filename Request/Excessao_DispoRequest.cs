using RentToParty.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentToParty.Request
{
    /// <summary>
    /// Tabela de Datas de Exssão das disponibilidade do imovel.
    /// </summary>
    public class Excessao_DispoRequest
    {
        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel é obrigatorio!")]
        public int IdImovel { get; set; }

        /// <summary>
        /// Data de Excessao.
        /// </summary>
        [Required(ErrorMessage = "A data de excessão é obrigatoria!")]
        public DateTime DataExcessao { get; set; }

        /// <summary>
        /// Situação da Excessão.
        /// </summary>
        [Required(ErrorMessage = "A situação é obrigatoria!")]
        public SituacaoExcEnum Situacao { get; set; }

        /// <summary>
        /// Obsservação da Excessao.
        /// </summary>
        public string Obsservacao { get; set; }
    }
}