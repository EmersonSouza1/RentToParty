using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Response
{
    /// <summary>
    /// Dados do Imovel.
    /// </summary>
    public class ImovelSimplesResponse
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
        public string Proprietario { get; set; }

        /// <summary>
        /// Endereço do Imovel.
        /// </summary>
        public EnderecoSimplesResponse Endereco { get; set; }

    }
}
