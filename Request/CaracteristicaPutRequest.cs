using RentToParty.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentToParty.Request
{
    /// <summary>
    /// Caracteristicas.
    /// </summary>
    public class CaracteristicaPutRequest
    {
        /// <summary>
        /// Identificador da caracteristica.
        /// </summary>
        [Required(ErrorMessage = "O Identificador da caracteristica é obrigatorio!")]
        [JsonPropertyName("Id")]
        public int? IdCaracteristica { get; set; }

        /// <summary>
        /// Descrição da caracteristica.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Tipo da caracteristica: 0 - Não Definida, 1 - Qualitativa, 2 - Quantitativa.
        /// </summary>
        public CaracteristicaEnum Tipo { get; set; }
    }
}