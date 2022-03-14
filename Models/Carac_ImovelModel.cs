using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    /// <summary>
    /// Tabela de caracteristicas de um imovel.
    /// </summary>
    [Table("Carac_Imovel")]
    public class Carac_ImovelModel
    {
        /// <summary>
        /// Identificador da caracteristica no imovel.
        /// </summary>
        [Key()]
        public int IdCaracImovel { get; set; }

        /// <summary>
        /// Identificador da Caracteristica.
        /// </summary>
        [ForeignKey("Caracteristica")]
        public int IdCaracteristica { get; set; }

        /// <summary>
        /// Caracteristica.
        /// </summary>
        public virtual CaracteristicaModel Caracteristica { get; set; }

        /// <summary>
        /// Identificador do imovel.
        /// </summary>
        [ForeignKey("Imovel")]
        public int IdImovel { get; set; }

        /// <summary>
        /// Imovel.
        /// </summary>
        public virtual ImovelModel Imovel { get; set; }

        /// <summary>
        /// Quantidade da caracteristica.
        /// </summary>
        public int Quantidade { get; set; }
    }
}