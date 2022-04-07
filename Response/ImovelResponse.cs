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
        /// Identificador do imovel.
        /// </summary>
        public int IdIMovel { get; set; }
        
        /// <summary>
        /// Descrição do Imovel.
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Proprietario do Imovel.
        /// </summary>
        public PessoaResponse Proprietario { get; set; }

        /// <summary>
        /// Endereço do Imovel.
        /// </summary>
        public EnderecoResponse Endereco { get; set; }

    }
}
