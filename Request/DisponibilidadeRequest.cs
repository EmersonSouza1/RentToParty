using RentToParty.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;


namespace RentToParty.Request
{
    public class DisponibilidadeRequest
    {
        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel é obrigatorio!")]
        public int? IdImovel { get; set; }

        /// <summary>
        /// Dia da Semana: 1 - Domingo, 2 - Segunda-feira, 3- Terça-feira, 4 - Quarta-feira, 5 - Quinta-feria, 6 - Sexta-feira, 7 - Sábado. 
        /// </summary>
        [Required(ErrorMessage = "O dia da semana é obrigatorio!")]
        public DiaDaSemanaEnum DiaDaSemana { get; set; }

        /// <summary>
        /// Status: 0 - Não disponivel, 1 - Disponivel, 2 - Negociar.
        /// </summary>
        [Required(ErrorMessage = "O dia da semana é obrigatorio!")]
        public StatusDispoEnum Status { get; set; }

        /// <summary>
        /// Hora de Inicio.
        /// </summary>
        [Required(ErrorMessage = "A hora de abertura é obrigatorio!")]
        public DateTime HoraInicio { get; set; }

        /// <summary>
        /// Hora de Final.
        /// </summary>
        [Required(ErrorMessage = "A hora de fechamento é obrigatorio!")]
        public DateTime HoraFinal { get; set; }
    }
}