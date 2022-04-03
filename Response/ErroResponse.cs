namespace RentToParty.Response
{
    /// <summary>
    /// Erro.
    /// </summa
    public class ErroResponse
    {
        public ErroResponse(string MsgErro)
        {
            MensagemErro = MsgErro;
        }
        /// <summary>
        /// Mensagem de Erro.
        /// </summa
        public string MensagemErro { get; set; }

    }
}