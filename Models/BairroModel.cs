using System.Collections.Generic;

namespace RentToParty.Model
{
    public class BairroModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<EnderecoModel> Enderecos { get; set; } = new List<EnderecoModel>();

        public CidadeModel Cidade { get; set; }


    }
}