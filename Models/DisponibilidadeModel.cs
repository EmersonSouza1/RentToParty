using RentToParty.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentToParty.Model
{
    public class DisponibilidadeModel
    {
        /// <summary>
        /// Identificador da disponibilidade.
        /// </summary>
        [Key()]
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
        /// Dia da Semana: 1 - Domingo, 2 - Segunda-feira, 3- Terça-feira, 4 - Quarta-feira, 5 - Quinta-feria, 6 - Sexta-feira, 7 - Sábado. 
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