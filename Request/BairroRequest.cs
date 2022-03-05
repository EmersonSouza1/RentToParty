using System.Collections.Generic;

namespace RentToParty.Request
{
    public class BairroRequest
    {
        public int Id { get; set; }
        public List<EnderecoRequest> Enderecos { get; set; } = new List<EnderecoRequest>();

        public CidadeRequest Cidade { get; set; }
    }
}