namespace RentToParty.Response
{
    public class EnderecoResponse
    {
        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public BairroResponse Bairro { get; set; }

        public CidadeResponse Cidade { get; set; }
    }
}