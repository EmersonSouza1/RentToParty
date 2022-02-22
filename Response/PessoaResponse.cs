using System.ComponentModel.DataAnnotations;

namespace RentToParty.Response
{

    public class PessoaResponse
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }
        public long Telefone { get; set; }
    }
}
