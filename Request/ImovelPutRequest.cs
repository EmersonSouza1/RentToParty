using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    /// <summary>
    /// Dados do Imovel.
    /// </summary>
    public class ImovelPutRequest
    {
        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel é obrigatorio!")]
        public int IdIMovel { get; set; }

        /// <summary>
        /// Descrição do Imovel.
        /// </summary>
        [StringLength(14, ErrorMessage = "A Descrição deve conter até 14 caracteres!")]
        public string Descricao { get; set; }

        /// <summary>
        /// Identificador do proprietario.
        /// </summary>
        public int IdProprietario { get; set; }

        /// <summary>
        /// Identificador do endereço.
        /// </summary>
        public int IdEndereco { get; set; }

    }
}
