using System.Collections.Generic;

namespace RentToParty.Model
{
    public class CidadeModel
    {
        
        public int Id { get; set; }
        public List<EnderecoModel> Enderecos { get; set; } = new List<EnderecoModel>();

        public List<BairroModel> Bairros { get; set; } = new List<BairroModel>();
        
    }
}