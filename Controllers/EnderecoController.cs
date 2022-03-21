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
using ViaCepConsumer;
using System.Threading;

namespace RentToParty.Controllers
{
    [ApiController]
    [Route(template:  _version )]
    public class EnderecoController : BaseApiController
    {
        private CancellationTokenSource _source;
        private CancellationToken _token;
        private ViaCepClient _cepConsumer;

        #region Ctor
        public EnderecoController(IMapper mapper) : base(mapper)    {

             _source = new CancellationTokenSource();
             _token = _source.Token;
             _cepConsumer = new ViaCepClient();
    }

        #endregion


        #region API - Routes

        [HttpGet]
        [Route(template: "enderecos")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var enderecos = await context.Enderecos.AsNoTracking().ToListAsync();

            var getenderecos = _mapper.Map<List<EnderecoResponse>>(enderecos);

            return getenderecos == null ? NotFound() : Ok(getenderecos);
        }

        [HttpGet]
        [Route(template: "endereco/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                       [FromRoute] int id)
        {
            var endereco = await context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.IdEndereco == id);

            var getpessoa = _mapper.Map<EnderecoResponse>(endereco);

            return endereco == null ? NotFound() : Ok(endereco);
        }

        [HttpPost(template: "endereco")]
        [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] EnderecoRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var enderecobusc = new EnderecoModel();
            if (model.Cep > 0)
            {

                var result = _cepConsumer.SearchAsync(model.Cep.ToString(), _token);

                if (_token.IsCancellationRequested)
                    throw new BusinessException($"Falha ao salvar atributo {model.Cep}");
                if (result != null)
                    enderecobusc = _mapper.Map<EnderecoModel>(result.Result);
                
            }

            var endereco = _mapper.Map<EnderecoModel>(model);

            endereco.Logradouro = enderecobusc.Logradouro;
            endereco.Bairro = enderecobusc.Bairro;
            endereco.Cidade = enderecobusc.Cidade;

            try
            {
                await context.Enderecos.AddAsync(endereco);
                await context.SaveChangesAsync();

                return Created($"v1/endereco/{endereco.IdEndereco}", endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(template: "endereco")]
        [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
                [FromServices] AppDbContext context, 
                [FromQuery] EnderecoPutRequest request)
        {
            if (!ModelState.IsValid)
               return BadRequest(ModelState);
            

            try
            {
                var endereco = await context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.IdEndereco == request.IdEndereco);
                
                if ( endereco == null)
                    return NotFound();



                if (request.Cep != endereco.Cep)
                {
                    
                    var result = _cepConsumer.SearchAsync(request.Cep.ToString(), _token);

                    //if (token.IsCancellationRequested)
                      //  throw Excep
                    if (result != null)
                       endereco = _mapper.Map<EnderecoModel>(result.Result);

                }
                endereco.Numero = request.Numero;
                endereco.Complemento = request.Complemento;

                await context.SaveChangesAsync();

                return Created($"v1/endereco/{endereco.IdEndereco}", endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private 
        #endregion
    }
}
