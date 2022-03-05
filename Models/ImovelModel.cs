using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Model
{

    public class ImovelModel
    {
        public int Id { get; set; }
        [Required]
        public PessoaModel Proprietario { get; set; }
        [Required]
        public EnderecoModel Endereco { get; set; }

        public List<CaracteristicaModel> Caracteristicas { get; set; } = new List<CaracteristicaModel>();

    }
}
