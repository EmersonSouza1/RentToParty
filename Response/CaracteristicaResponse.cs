﻿
using RentToParty.Model.Enums;
using System.Text.Json.Serialization;

namespace RentToParty.Response
{
    public class CaracteristicaResponse
    {
        /// <summary>
        /// Identificador da caracteristica.
        /// </summary>
        [JsonPropertyName("Id")]
        public int IdCaracteristica { get; set; }

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