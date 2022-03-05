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
        
        #region Ctor
        public PessoaController(IMapper mapper) : base(mapper)    {        }

        #endregion


        #region API - Routes

        [HttpGet( template: "search")]
        [ProducesResponseType(typeof(PessoaResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PersistAsync([FromQuery] PessoaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_mapper.Map<PessoaResponse>(request));
        }

        [HttpGet]
        [Route(template: "pessoa")]
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
            var pessoa = await context.Pessoas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

           PessoaResponse getpessoa = _mapper.Map<PessoaResponse>(pessoa);

            return pessoa == null ? NotFound() : Ok(pessoa);
        }

        [HttpPost(template: "pessoa")]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] PessoaRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var pessoa = _mapper.Map<PessoaModel>(model);

            try
            {
                await context.Pessoas.AddAsync(pessoa);
                await context.SaveChangesAsync();

                return Created($"v1/pessoa/{pessoa.Id}", pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}
