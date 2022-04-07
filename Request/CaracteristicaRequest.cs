﻿using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    public class CaracteristicaRequest
    {
        [Required]
        public int Tipo { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}