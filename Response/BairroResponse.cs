using System.Collections.Generic;

namespace RentToParty.Response
{
    public class BairroResponse
    {
        public string Nome { get; set; }
        public List<EnderecoResponse> Enderecos { get; set; } = new List<EnderecoResponse>();

        public CidadeResponse Cidade { get; set; }
    }
}