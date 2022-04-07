using Flurl;
using Flurl.Http;
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

using System.Threading;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace RentToParty.Controllers
{
    [ApiController]
    [Route(template:  _version )]
    public class EnderecoController : BaseApiController
    {


        private readonly string _baseUrl;

        #region Ctor
        public EnderecoController(IMapper mapper) : base(mapper)    {



            _baseUrl = "https://viacep.com.br/ws/";
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
        [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route(template: "endereco/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                       [FromRoute] int id)
        {
            var getpessoa = BuscaEndereco(id, context);

            return getpessoa == null ? NotFound() : Ok(getpessoa);
        }

        [HttpPost(template: "endereco")]
        [ProducesResponseType(typeof(EnderecoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] EnderecoRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var enderecobusc = new EnderecoModel();

            enderecobusc = await BuscaCepAsync(model.Cep);

            if (string.IsNullOrEmpty( enderecobusc.Logradouro) )
                return BadRequest("Cep invalido ou não encontrado");

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
                [FromBody] EnderecoPutRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var endereco = await context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.IdEndereco == request.Id);

                if ( endereco == null)
                    return NotFound(request);

                if (string.IsNullOrEmpty(request.Cep) && string.IsNullOrEmpty(request.Numero) &&
                    string.Compare(request.Complemento, endereco.Complemento) == 0)
                    return BadRequest(new ErroResponse("Nenhuma informação para ser alterada!"));

                var enderecobusc = new EnderecoModel();

                if (request.Cep != endereco.Cep.ToString())
                {
                    enderecobusc = await BuscaCepAsync(request.Cep);

                    if (string.IsNullOrEmpty(enderecobusc.Logradouro))
                        return BadRequest("Cep invalido ou não encontrado");

                    endereco.Logradouro = enderecobusc.Logradouro;
                    endereco.Cidade = enderecobusc.Cidade;
                    endereco.Bairro = enderecobusc.Bairro;
                }

                endereco.Numero = request.Numero != endereco.Numero ? request.Numero : endereco.Numero;
                endereco.Complemento = request.Complemento != endereco.Complemento ? request.Complemento : endereco.Complemento;

                await context.SaveChangesAsync();

                return Created($"v1/endereco/{endereco.IdEndereco}", endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

        private async Task<EnderecoModel> BuscaCepAsync(string cep)
        {
            EnderecoModel enderecobusc = new EnderecoModel();
            try
            {
                var response = await _baseUrl
                .AppendPathSegment($"{cep}/json/")
                .GetAsync();

                if (response.StatusCode != 200)
                    return enderecobusc;

                var ret = JsonConvert.DeserializeObject<ViaCepResponse>(await response.ResponseMessage.Content.ReadAsStringAsync());

                enderecobusc = _mapper.Map<EnderecoModel>(ret);

            }
            catch 
            {
                throw new BusinessException("Falha na consulta ao CEP externo.");
            }
            
            return enderecobusc;
        }

        public async Task<EnderecoResponse> BuscaEndereco(int id, AppDbContext context)
        {
            var endereco = await context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.IdEndereco == id);

            var getendereco = _mapper.Map<EnderecoResponse>(endereco);

            return getendereco;
        }  

    }
}
