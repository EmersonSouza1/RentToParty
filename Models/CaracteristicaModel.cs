using RentToParty.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    /// <summary>
    /// Tabela de Caracteristicas.
    /// </summary>
    [Table("Caracteristica")]
    public class CaracteristicaModel
    {
        /// <summary>
        /// Identificador da caracteristica.
        /// </summary>
        [Key()]
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