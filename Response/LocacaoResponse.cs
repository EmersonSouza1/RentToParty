using RentToParty.Response;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Request
{
    public class LocacaoResponse
    {
        public ImovelResponse Imovel { get; set; }

        public PessoaResponse Cliente { get; set; }

        public DateTime DtainicioLocacao { get; set; }

        public DateTime DtaFimLocacao { get; set; }
    }

}