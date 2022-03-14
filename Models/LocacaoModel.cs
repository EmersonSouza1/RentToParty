using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    /// <summary>
    /// Tabela de Loca��o
    /// </summary>
    [Table("Locacao")]
    public class LocacaoModel
    {
        /// <summary>
        /// Identificador da loca��o.
        /// </summary>
        [Key()]
        public int IdLocacao { get; set; }

        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [ForeignKey("Imovel")]
        public int IdImovel { get; set; }

        /// <summary>
        /// Imovel.
        /// </summary>
        public virtual ImovelModel Imovel { get; set; }

        /// <summary>
        /// Identificador do locatario.
        /// </summary>
        [ForeignKey("Pessoa")]
        public int IdLocatario { get; set; }

        /// <summary>
        /// Locatario.
        /// </summa
        public virtual PessoaModel Locatario { get; set; }

        /// <summary>
        /// Data de Inicio da Loca��o.
        /// </summa
        public DateTime DtainicioLocacao  { get; set; }

        /// <summary>
        /// Data Final da Loca��o.
        /// </summa
        public DateTime DtaFimLocacao { get; set; }

    }
}
