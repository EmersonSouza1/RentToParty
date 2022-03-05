using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    public class EnderecoRequest
    {
        public int Id { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public BairroRequest Bairro { get; set; }

        public CidadeRequest Cidade { get; set; }
    }
}