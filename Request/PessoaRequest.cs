using RentToParty.Models.ModelRequest;
using System.ComponentModel.DataAnnotations;
namespace RentToParty.Request
{

    public class PessoaRequest 
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }
        public long Telefone { get; set; }
    }
}
