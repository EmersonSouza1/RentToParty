using RentToParty.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{    
    /// <summary>
    /// Caracteristicas.
    /// </summary>

    public class CaracteristicaRequest
    {
        [Required(ErrorMessage = "A descrição da caracteristica é obrigatorio!")]
        /// <summary>
        /// Descrição da caracteristica.
        /// </summary>
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo da caracteristica é obrigatorio!")]
        /// <summary>
        /// Tipo da caracteristica: 0 - Não Definida, 1 - Usual, 2 - Visual.
        /// </summary>
        public CaracteristicaEnum Tipo { get; set; }
    }
}