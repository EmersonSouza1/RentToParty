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
        private ImovelController _imovelcontroller;

        private PessoaController _pessoaController;

        #region Ctor
        public LocacaoController(IMapper mapper) : base(mapper)    {
            _imovelcontroller = new ImovelController(mapper);
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

            try
            {
                var msg = VerificaSeExiste(locacao, context);

                if (!string.IsNullOrEmpty(msg))
                    return BadRequest(msg);

                await context.Locacoes.AddAsync(locacao);
                await context.SaveChangesAsync();

                return Created($"v1/locacao/{locacao.IdLocacao}", locacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        
        [HttpPut(template: "locacao")]
        [ProducesResponseType(typeof(PessoaResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
                [FromServices] AppDbContext context,
                [FromQuery] LocacaoPutRequest request)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);

            try
            {
                var locacao = await context.Locacoes.AsNoTracking().FirstOrDefaultAsync(x => x.IdLocacao == request.IdLocacao);

                if (locacao == null)
                   return NotFound();

                if (request.DtainicioLocacao == null && request.DtaFimLocacao == null &&
                    request.Valor != locacao.Valor )
                    return BadRequest(new ErroResponse("Nenhuma informação para ser alterada!"));

                locacao.DtainicioLocacao = request.DtainicioLocacao != null  ?  (DateTime)request.DtainicioLocacao : locacao.DtainicioLocacao;

                locacao.DtaFimLocacao = request.DtaFimLocacao != null ? (DateTime)request.DtaFimLocacao : locacao.DtaFimLocacao;

                locacao.Valor = request.Valor != locacao.Valor ? request.Valor : locacao.Valor;

                var msg = VerificaSeExiste(locacao, context);

                if (!string.IsNullOrEmpty(msg))
                    return BadRequest(msg);

                await context.SaveChangesAsync();

                return Created($"v1/locacao/{locacao.IdLocacao}", locacao);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        private string VerificaSeExiste(LocacaoModel locacao, AppDbContext context)
        {

            var resultedereco = _pessoaController.BuscaPessoa(locacao.IdLocatario, context);

            if (resultedereco == null || resultedereco.Id <= 0)
                return "Identificador do Imovel não encontrado!";

            var resultadoimovel = _imovelcontroller.BuscaImovel(locacao.IdImovel, context);
            if (resultadoimovel == null || resultadoimovel.Id <= 0)
                return "Identificador do Endereço não encontrado!";

            return null;

        }
        #endregion
    }
}
