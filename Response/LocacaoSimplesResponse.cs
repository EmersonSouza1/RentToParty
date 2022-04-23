using RentToParty.Response;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    /// <summary>
    /// Locação.
    /// </summary>
    public class LocacaoSimplesResponse
    {
        /// <summary>
        /// Identificador da Locação.
        /// </summary>
        public int IdLocacao { get; set; }

        /// <summary>
        /// Identificador do imovel.
        /// </summary>
        public ImovelSimplesResponse Imovel { get; set; }

        /// <summary>
        /// Identificador da Locação.
        /// </summary>
        public PessoaResponse Locatario { get; set; }

        /// <summary>
        /// Data de Inicio da Locação.
        /// </summa
        public DateTime DtainicioLocacao { get; set; }

        /// <summary>
        /// Data Final da Locação.
        /// </summa
        public DateTime DtaFimLocacao { get; set; }

        /// <summary>
        /// Valor da locação.
        /// </summa
        public Decimal Valor { get; set; }
    }

}