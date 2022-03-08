using System.Collections.Generic;

namespace RentToParty.Response
{
    public class CidadeResponse
    {
        public string Nome { get; set; }
        public List<EnderecoResponse> Enderecos { get; set; } = new List<EnderecoResponse>();

        public List<BairroResponse> Bairros { get; set; } = new List<BairroResponse>();
    }
}