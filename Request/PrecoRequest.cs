using RentToParty.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentToParty.Request
{    /// <summary>
    /// Tabela de Preço do imovel.
    /// </summary>
    public class PrecoRequest
    {
        /// <summary>
        /// Identificador da disponibilidade.
        /// </summary>
        [Required(ErrorMessage = "O Identificador é obrigatorio!")]
        [JsonPropertyName("Id")]
        public int IdPreco { get; set; }

        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel é obrigatorio!")]
        public int IdImovel { get; set; }

        /// <summary>
        /// Valor.
        /// </summary>
        [Required(ErrorMessage = "O valor da locação é obrigatorio!")]
        public Decimal Valor { get; set; }

        /// <summary>
        /// Data de Inicio do Valor.
        /// </summa
        [Required(ErrorMessage = "A data de inicio do preço é obrigatoria!")]
        public DateTime Dtainicio { get; set; }

        /// <summary>
        /// Data Final do Valor.
        /// </summa
        public DateTime DtaFim { get; set; }

        /// <summary>
        /// Status: 0 - Não disponivel, 1 - Disponivel, 2 - Negociar.
        /// </summary>
        [Required(ErrorMessage = "O status é obrigatorio!")]
        public StatusPrecoEnum Status { get; set; }

        /// <summary>
        /// Dia da Semana: 0 - None, 1 - Domingo, 2 - Segunda-feira, 3- Terça-feira, 4 - Quarta-feira, 5 - Quinta-feria, 6 - Sexta-feira, 7 - Sábado.  
        /// </summary>
        public DiaDaSemanaEnum DiaDaSemana { get; set; }

    }
}