using System.Collections.Generic;

namespace RentToParty.Request
{
    public class CidadeRequest
    {
        public int Id { get; set; }
        public List<EnderecoRequest> Enderecos { get; set; } = new List<EnderecoRequest>();

        public List<BairroRequest> Bairros { get; set; } = new List<BairroRequest>();
    }
}