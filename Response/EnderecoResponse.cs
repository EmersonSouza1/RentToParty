using System.Text.Json.Serialization;

namespace RentToParty.Response
{
    /// <summary>
    /// Endereço.
    /// </summa
    public class EnderecoResponse
    {
        /// <summary>
        /// Identificador do Endereço.
        /// </summa
        public int IdEndereco { get; set; }

        /// <summary>
        /// Cep do endereço.
        /// </summa
        public string Cep { get; set; }

        /// <summary>
        /// Logradouro.
        /// </summa
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do local.
        /// </summa
        public string Numero { get; set; }

        /// <summary>
        /// Informação complementar ao endereço.
        /// </summa
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Complemento { get; set; }

        /// <summary>
        /// Bairro.
        /// </summa
        public string Bairro { get; set; }

        /// <summary>
        /// Cidade.
        /// </summa
        public string Cidade { get; set; }
    }
}