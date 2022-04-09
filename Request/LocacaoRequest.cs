﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentToParty.Request
{
    /// <summary>
    /// Locação.
    /// </summary>
    public class LocacaoRequest 
    {
        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel é obrigatorio!")]
        public int IdImovel { get; set; }

        /// <summary>
        /// Identificador do locatario.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do locatario é obrigatorio!")]
        public int IdLocatario { get; set; }

        /// <summary>
        /// Data de Inicio da Locação.
        /// </summa
        [Required(ErrorMessage = "A Data Inicial da Locação é obrigatorio!")]
        public DateTime DtainicioLocacao { get; set; }

        /// <summary>
        /// Data Final da Locação.
        /// </summa
        [Required(ErrorMessage = "A Data Final da Locação é obrigatorio!")]
        public DateTime DtaFimLocacao { get; set; }

        /// <summary>
        /// Valor da locação.
        /// </summa
        [Required(ErrorMessage = "O Valor da Locacao deve ser informado!")]
        public Decimal Valor { get; set; }
    }

}