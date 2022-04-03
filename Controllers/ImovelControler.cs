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
    public class ImovelController : BaseApiController
    {
        
        #region Ctor
        public ImovelController(IMapper mapper) : base(mapper)    {        }

        #endregion


        #region API - Routes

        [HttpGet]
        [Route(template: "imovel")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var imevel = await context.Imoveis.AsNoTracking().ToListAsync();

            List<ImovelResponse> getimoveis = _mapper.Map<List<ImovelResponse>>(imevel);

            return getimoveis == null ? NotFound() : Ok(getimoveis);
        }

        [HttpGet]
        [Route(template: "imovel/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                       [FromRoute] int id)
        {
            var imevel = await context.Imoveis.AsNoTracking().FirstOrDefaultAsync(x => x.IdIMovel == id);

            ImovelResponse getpessoa = _mapper.Map<ImovelResponse>(imevel);

            return imevel == null ? NotFound() : Ok(imevel);
        }

        [HttpPost(template: "imovel")]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] ImovelRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var imovel = _mapper.Map<ImovelModel>(model);

            try
            {
                await context.Imoveis.AddAsync(imovel);
                await context.SaveChangesAsync();

                return Created($"v1/imovel/{imovel.IdIMovel}", imovel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion
    }
}
