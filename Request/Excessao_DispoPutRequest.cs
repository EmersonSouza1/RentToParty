using RentToParty.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentToParty.Request
{
    public class Excessao_DispoPutRequest
    {
        /// <summary>
        /// Identificador da excessao.
        /// </summary>
        [Required(ErrorMessage = "O Identificador é obrigatorio!")]
        [JsonPropertyName("Id")]
        public int IdExcessao { get; set; }

        /// <summary>
        /// Identificador do Imovel.
        /// </summary>

        public int IdImovel { get; set; }

        /// <summary>
        /// Data de Excessao.
        /// </summary>
        public DateTime DataExcessao { get; set; }

        /// <summary>
        /// Situação da Excessão.
        /// </summary>
        public SituacaoExcEnum Situacao { get; set; }

        /// <summary>
        /// Obsservação da Excessao.
        /// </summary>
        public string Obsservacao { get; set; }
    }
}