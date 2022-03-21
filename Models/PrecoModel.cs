using RentToParty.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    public class PrecoModel
    {
        /// <summary>
        /// Tabela de Preço do imovel.
        /// </summary>
        [Table("Preco")]
        public class Excessao_DispoModel
        {
            /// <summary>
            /// Identificador da disponibilidade.
            /// </summary>
            [Key()]
            public int IdPreco { get; set; }

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
            /// Valor.
            /// </summary>
            public Decimal Valor { get; set; }

            /// <summary>
            /// Data de Inicio do Valor.
            /// </summa
            public DateTime Dtainicio { get; set; }

            /// <summary>
            /// Data Final do Valor.
            /// </summa
            public DateTime DtaFim { get; set; }

            /// <summary>
            /// Status: 0 - Não disponivel, 1 - Disponivel, 2 - Negociar.
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// Dia da Semana: 0 - None, 1 - Domingo, 2 - Segunda-feira, 3- Terça-feira, 4 - Quarta-feira, 5 - Quinta-feria, 6 - Sexta-feira, 7 - Sábado.  
            /// </summary>
            public DiaDaSemanaEnum DiaDaSemana { get; set; }

        }
    }
}