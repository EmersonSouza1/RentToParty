using RentToParty.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    public class DisponibilidadeModel
    {
        /// <summary>
        /// Tabela de Disponibilidade do imovel.
        /// </summary>
        [Table("Disponibilidade")]
        public class Excessao_DispoModel
        {
            /// <summary>
            /// Identificador da disponibilidade.
            /// </summary>
            public int IdDisponibilidade { get; set; }

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
            /// Dia da Semana: 0 - Domingo, 1 - Segunda-feira, 2- Terça-feira, 3 - Quarta-feira, 4 - Quinta-feria, 5 - Sexta-feira, 6 - Sábado. 
            /// </summary>
            public DiaDaSemanaEnum DiaDaSemana { get; set; }

            /// <summary>
            /// Status: 0 - Não disponivel, 1 - Disponivel, 2 - Negociar.
            /// </summary>
            public StatusDispoEnum Status { get; set; }

            /// <summary>
            /// Hora de Inicio.
            /// </summary>
            public DateTime HoraInicio { get; set; }

            /// <summary>
            /// Hora de Final.
            /// </summary>
            public DateTime HoraFinal { get; set; }

        }
    }
}