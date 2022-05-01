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
    public class PessoaController : BaseApiController
    {
        private EnderecoController _enderecoController;
        #region Ctor
        public PessoaController(IMapper mapper) : base(mapper)    {

            _enderecoController = new EnderecoController(mapper);
        }

        
        #endregion


        #region API - Routes

        [HttpGet]
        [Route(template: "pessoas")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var pessoas = await context.Pessoas.AsNoTracking().ToListAsync();

            List<PessoaResponse> getpessoas = _mapper.Map<List<PessoaResponse>>(pessoas);

            return getpessoas == null ? NotFound() : Ok(getpessoas);
        }

        [HttpGet]
        [Route(template: "pessoa/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                       [FromRoute] int id)
        {
            var pessoa = await context.Pessoas.AsNoTracking().FirstOrDefaultAsync(x => x.IdPessoa == id);

           PessoaResponse getpessoa = _mapper.Map<PessoaResponse>(pessoa);

            return pessoa == null ? NotFound() : Ok(getpessoa);
        }

        [HttpPost(template: "pessoa")]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] PessoaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (request.IdEndereco == 0 && request.Endereco == null)
                return BadRequest(new ErroResponse("Nenhum Endereço informado."));

            var model = _mapper.Map<PessoaModel>(request);
            var msg = AplicaMudancaEndereco(model, context);
            
            if (!string.IsNullOrEmpty(msg))
                BadRequest(msg);

            try
            {
                await context.Pessoas.AddAsync(model);
                await context.SaveChangesAsync();

                return Created($"v1/pessoa/{model.IdPessoa}", model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut(template: "pessoa")]
        [ProducesResponseType(typeof(PessoaResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
                [FromServices] AppDbContext context, 
                [FromQuery] PessoaPutRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var pessoa = await context.Pessoas.AsNoTracking().FirstOrDefaultAsync(x => x.CPF_CNPJ == request.CPF_CNPJ);
                
                if ( pessoa == null)
                 return NotFound();

                if ( string.IsNullOrEmpty(request.Nome) && string.Compare(request.Telefone, pessoa.Telefone) == 0 && string.Compare(request.Email, pessoa.Email) == 0 &&
                     request.IdEndereco <= 0 && request.Endereco == null )
                    return BadRequest(new ErroResponse("Nenhuma informação para ser alterada!"));

                pessoa.Nome = string.IsNullOrEmpty(request.Nome) ? pessoa.Nome : request.Nome;

                pessoa.Telefone = string.Compare(request.Telefone, pessoa.Telefone) == 0 ? pessoa.Telefone : request.Telefone;

                pessoa.Email = string.Compare(request.Email, pessoa.Email) == 0 ? pessoa.Email : request.Email;

                if (request.IdEndereco > 0 || request.Endereco != null)
                {
                    pessoa.IdEndereco = request.IdEndereco;
                    pessoa.Endereco = _mapper.Map <EnderecoModel>(request.Endereco);

                    var msg = AplicaMudancaEndereco(pessoa, context);

                    if (!string.IsNullOrEmpty(msg))
                        BadRequest(msg);
                }

                await context.SaveChangesAsync();

                return Created($"v1/pessoa/{pessoa.IdPessoa}", pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(template: "pessoa/id")]
        public async Task<IActionResult> DeleteAsync(
                [FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                var pessoa = await context.Pessoas.AsNoTracking().FirstOrDefaultAsync(x => x.IdPessoa == id);

                if (pessoa == null)
                    return NotFound();

                context.Remove(pessoa);
                await context.SaveChangesAsync();

                return Ok("Pessoa removida com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string AplicaMudancaEndereco(PessoaModel pessoa, AppDbContext context)
        {
            if (pessoa.IdEndereco > 0)
            {
                var result = BuscaEndereco(pessoa.IdEndereco, context);
                if (result == null || result.Id <= 0)
                    return "Identificador do Endereço não encontrado!";
            }
            else if (pessoa.Endereco != null)
            {
                try
                {
                    var retorno = _enderecoController.PostAsync(context, _mapper.Map<EnderecoRequest>(pessoa.Endereco));

                    var result = retorno.Result as CreatedResult;

                    if (result == null)
                    {
                        var badresp = retorno.Result as BadRequestObjectResult;

                        string msg = "Endereço invalido: \n";

                        if (badresp != null)
                            msg += badresp.Value.ToString();

                        return msg;
                    }

                    var endrespo = _mapper.Map<EnderecoResponse>(result.Value);

                    pessoa.IdEndereco = endrespo.IdEndereco;

                }
                catch (Exception ex)
                {
                    return "Falha no inserção do Endereco: \n" + ex.Message;
                }
            }

            return null;

        }

        private async Task<PessoaResponse> BuscaPessoa(int id, AppDbContext context)
        {
            var pessoa = await context.Pessoas.AsNoTracking().FirstOrDefaultAsync(x => x.IdPessoa == id);

            var getpessoa = _mapper.Map<PessoaResponse>(pessoa);

            return getpessoa;
        }

        private async Task<EnderecoResponse> BuscaEndereco(int id, AppDbContext context)
        {
            var endereco = await context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.IdEndereco == id);

            var getendereco = _mapper.Map<EnderecoResponse>(endereco);

            return getendereco;
        }
        #endregion
    }
}
