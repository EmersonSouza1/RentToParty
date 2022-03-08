using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Response
{
    /// <summary>
    /// Dados do Imovel.
    /// </summary>
    public class ImovelResponse
    {
        /// <summary>
        /// Proprietario do Imovel.
        /// </summary>
        public PessoaResponse Proprietario { get; set; }

        /// <summary>
        /// Endereço do Imovel.
        /// </summary>
        public EnderecoResponse Endereco { get; set; }

        /// <summary>
        /// Caracteristicas do Imovel.
        /// </summary>
        public List<CaracteristicaResponse> Caracteristicas { get; set; }
    }
}
