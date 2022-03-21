﻿using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    /// <summary>
    /// Endereço.
    /// </summa
    public class EnderecoRequest
    {
        /// <summary>
        /// Cep do endereço.
        /// </summa
        [Required(ErrorMessage = "O Cep é obrigatorio!")]
        public int Cep { get; set; }

        /// <summary>
        /// Número do local.
        /// </summa
        [Required(ErrorMessage = "O Endereço é obrigatorio!")]
        public string Numero { get; set; }

        /// <summary>
        /// Informação complementar ao endereço.
        /// </summa
        public string Complemento { get; set; }

    }
}