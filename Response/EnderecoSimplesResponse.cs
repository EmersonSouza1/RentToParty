using System.Text.Json.Serialization;

namespace RentToParty.Response
{
    /// <summary>
    /// Endereço.
    /// </summa
    public class EnderecoSimplesResponse
    {
        /// <summary>
        /// Logradouro e Numero.
        /// </summa
        public string Logradouro_Numero { get; set; }

        /// <summary>
        /// Informação complementar ao endereço.
        /// </summa
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Complemento { get; set; }

        /// <summary>
        /// Cidade.
        /// </summa
        public string Cidade { get; set; }
    }
}