using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentToParty.Request;
using System;
using System.Threading.Tasks;
using AutoMapper;
using RentToParty.Response;
using RentToParty.Data;
using RentToParty.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RentToParty.Controllers
{
    [ApiController]
    [Route(template:  _version )]
    public class LocacaoController : BaseApiController
    {
        private EnderecoController _enderecoController;

        private PessoaController _pessoaController;

        #region Ctor
        public LocacaoController(IMapper mapper) : base(mapper)    {
            _enderecoController = new EnderecoController(mapper);
            _pessoaController = new PessoaController(mapper);
        }

        #endregion


        #region API - Routes

        [HttpGet]
        [Route(template: "locacoes")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var locacoes = await context.Locacoes.AsNoTracking().ToListAsync();

            var getlocacoes = _mapper.Map<List<LocacaoResponse>>(locacoes);

            return locacoes == null ? NotFound() : Ok(getlocacoes);
        }

        [HttpGet]
        [Route(template: "locacao/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                       [FromRoute] int id)
        {
            var locacao = await context.Locacoes.AsNoTracking().FirstOrDefaultAsync(x => x.IdLocacao == id);

            ImovelResponse getlocacao = _mapper.Map<ImovelResponse>(locacao);

            return locacao == null ? NotFound() : Ok(getlocacao);
        }

        [HttpPost(template: "locacao")]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] LocacaoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var locacao = _mapper.Map<LocacaoModel>(request);

            return BadRequest("Não finalizado");
            

        }

        [HttpPut(template: "imovel")]
        [ProducesResponseType(typeof(PessoaResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
                [FromServices] AppDbContext context,
                [FromQuery] ImovelPutRequest request)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);

            try
            {
                var imovel = await context.Imoveis.AsNoTracking().FirstOrDefaultAsync(x => x.IdIMovel == request.IdIMovel);

                if (imovel == null)
                   return NotFound();

                if (request .IdEndereco <= 0 && request.IdProprietario <= 0 &&
                    string.Compare(request.Descricao, imovel.Descricao) == 0 )
                    return BadRequest(new ErroResponse("Nenhuma informação para ser alterada!"));

                imovel.Descricao = string.Compare(request.Descricao, imovel.Descricao) == 0 ? imovel.Descricao : request.Descricao;

                var msg = VerificaSeExiste(imovel, context);

                if (!string.IsNullOrEmpty(msg))
                    return BadRequest(msg);

                await context.SaveChangesAsync();

                return Created($"v1/pessoa/{imovel.IdIMovel}", imovel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string VerificaSeExiste(ImovelModel imovel, AppDbContext context)
        {

            var resulte = _pessoaController.BuscaPessoa(imovel.IdProprietario, context);

            if (resulte == null || resulte.Id <= 0)
                return "Identificador do Proprietario não encontrado!";

            var resultp = _enderecoController.BuscaEndereco(imovel.IdEndereco, context);
            if (resultp == null || resultp.Id <= 0)
                return "Identificador do Endereço não encontrado!";

            return null;

        }
        #endregion
    }
}
