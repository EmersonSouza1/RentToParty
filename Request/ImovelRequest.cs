using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    /// <summary>
    /// Dados do Imovel.
    /// </summary>
    public class ImovelRequest
    {
        /// <summary>
        /// Identificador do Imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel � obrigatorio!")]
        public int IdIMovel { get; set; }

        /// <summary>
        /// Descri��o do Imovel.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do imovel � obrigatorio!")]
        [StringLength(14, ErrorMessage = "A Descri��o deve conter at� 14 caracteres!")]
        public string Descricao { get; set; }

        /// <summary>
        /// Identificador do proprietario.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do proprietario � obrigatorio!")]
        public int IdProprietario { get; set; }

        /// <summary>
        /// Identificador do endere�o.
        /// </summary>
        [Required(ErrorMessage = "O Identificador do endereco � obrigatorio!")]
        public int IdEndereco { get; set; }

    }
}
