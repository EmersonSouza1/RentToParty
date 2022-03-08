using System;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    public class LocacaoRequest 
    {
        [Required]
        public ImovelRequest Imovel { get; set; }
        [Required]
        public PessoaRequest Cliente { get; set; }
        [Required]
        public DateTime DtainicioLocacao { get; set; }
        [Required]
        public DateTime DtaFimLocacao { get; set; }
    }

}