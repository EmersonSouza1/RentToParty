using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentToParty.Request
{
    public class Carac_ImovelPutRequest
    {
        /// <summary>
        /// Identificador da caracteristica no imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador é obrigatorio!")]
        [JsonPropertyName("Id")]
        public int IdCaracImovel { get; set; }

        /// <summary>
        /// Identificador da Caracteristica.
        /// </summary>
        public int IdCaracteristica { get; set; }

        /// <summary>
        /// Identificador do imovel.
        /// </summary>
        public int IdImovel { get; set; }

        /// <summary>
        /// Quantidade da caracteristica.
        /// </summary>
        public int Quantidade { get; set; }
    }
}