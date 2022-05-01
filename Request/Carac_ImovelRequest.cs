using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentToParty.Request
{
    public class Carac_ImovelRequest
    {
        /// <summary>
        /// Identificador da Caracteristica.
        /// </summary>
        [Required(ErrorMessage = "O Identificador da caracteristica é obrigatorio!")]
        public int IdCaracteristica { get; set; }

        /// <summary>
        /// Identificador do imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel é obrigatorio!")]
        public int IdImovel { get; set; }

        /// <summary>
        /// Quantidade da caracteristica.
        /// </summary>
        public int Quantidade { get; set; }
    }
}