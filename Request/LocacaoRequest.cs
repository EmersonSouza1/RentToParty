using System;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    public class LocacaoRequest 
    {
        public int Id { get; set; }
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