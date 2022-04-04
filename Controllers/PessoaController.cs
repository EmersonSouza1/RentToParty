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
                [FromBody] PessoaRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.IdEndereco == 0 && model.Endereco == null)
                return BadRequest(new ErroResponse("Nenhum Endereço informado."));
            
            if (model.IdEndereco > 0)
            {
                try
                {
                    var retorno = _enderecoController.GetByIdAsync(context, model.IdEndereco);
                                       
                    var result = retorno.Result as OkObjectResult;

                    if (result == null)
                        return BadRequest("IdEndeco não encontrado.");

                    model.Endereco = null;
                }
                catch (Exception ex)
                {
                    return BadRequest("Falha na busca do Endereco: \n" + ex.Message);
                }                   
            }
            else if (model.Endereco != null)
            {
                try
                {
                    var retorno = _enderecoController.PostAsync(context, model.Endereco);

                    var result = retorno.Result as CreatedResult;

                    if (result == null)
                    {
                        var badresp = retorno.Result as BadRequestObjectResult;

                        string msg = "Endereço invalido: \n";

                        if (badresp != null)
                            msg += badresp.Value.ToString();

                        return BadRequest(msg);
                    }
                    
                    var endrespo = _mapper.Map<EnderecoResponse>(result.Value);

                    model.IdEndereco =  endrespo.IdEndereco;

            }
                catch (Exception ex)
            {
                return BadRequest("Falha no inserção do Endereco: \n" + ex.Message);
            }
        }
                

            var pessoa = _mapper.Map<PessoaModel>(model);

            try
            {
                await context.Pessoas.AddAsync(pessoa);
                await context.SaveChangesAsync();

                return Created($"v1/pessoa/{pessoa.IdPessoa}", pessoa);
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
            {
                return BadRequest(ModelState);
            }

            try
            {
                var pessoa = await context.Pessoas.AsNoTracking().FirstOrDefaultAsync(x => x.CPF_CNPJ == request.CPF_CNPJ);
                
                if ( pessoa == null)
                {
                    return NotFound();
                }

                pessoa.Nome = string.IsNullOrEmpty(request.Nome) ? pessoa.Nome : request.Nome;

                pessoa.Telefone = request.Telefone;

                pessoa.Email = request.Email;

                await context.SaveChangesAsync();

                return Created($"v1/pessoa/{pessoa.IdPessoa}", pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
