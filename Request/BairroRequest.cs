using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    public class BairroRequest
    {
        [Required]
        public string Nome { get; set; }
        public List<EnderecoRequest> Enderecos { get; set; } = new List<EnderecoRequest>();

        public CidadeRequest Cidade { get; set; }
    }
}