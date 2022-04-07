using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    public class CaracteristicaPutRequest
    {
        [Required]
        public int Tipo { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}