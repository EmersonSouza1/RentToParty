using RentToParty.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{

    public class ImovelRequest
    {
        public int Id { get; set; }
        [Required]
        public PessoaRequest Proprietario { get; set; }
        [Required]
        public EnderecoRequest Endereco { get; set; }
        [Required]
        public List<CaracteristicaRequest> Caracteristicas { get; set; } = new List<CaracteristicaRequest>();

    }
}
