using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentToParty.Model
{

    public class LocacaoModel
    {
        public int Id { get; set; }
        public ImovelModel Imovel { get; set; }

        public PessoaModel Cliente { get; set; }

        public DateTime DtainicioLocacao  { get; set; }

        public DateTime DtaFimLocacao { get; set; }

    }
}
