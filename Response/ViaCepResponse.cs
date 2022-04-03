using Newtonsoft.Json;

namespace RentToParty.Response
{
    /// <summary>
    /// Endereço.
    /// </summa
    public class ViaCepResponse
    {
        /// <summary>
        /// Cep do endereço.
        /// </summa
        public string Cep { get; set; }

        /// <summary>
        /// Logradouro.
        /// </summa
        public string Logradouro { get; set; }


        /// <summary>
        /// Informação complementar ao endereço.
        /// </summa
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro.
        /// </summa
        public string Bairro { get; set; }

        /// <summary>
        /// Cidade.
        /// </summa
        [JsonProperty("localidade")]
        public string Cidade { get; set; }

        /// <summary>
        /// Estado.
        /// </summa
        [JsonProperty("uf")]
        public string Estado { get; set; }

        /// <summary>
        /// Código do IBGE.
        /// </summa
        [JsonProperty("ibge")]
        public string CodigoIBGE { get; set; }

        /// <summary>
        /// DDD da Região.
        /// </summa
        [JsonProperty("ddd")]
        public string Cod_DDD { get; set; }
    }

}