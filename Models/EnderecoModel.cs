namespace RentToParty.Model
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public BairroModel Bairro { get; set; }

        public CidadeModel Cidade { get; set; }



    }
}