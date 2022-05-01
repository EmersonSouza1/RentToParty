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
using Swashbuckle.AspNetCore.Annotations;

namespace RentToParty.Controllers
{
    [ApiController]
    [Route(template:  _version )]
    public class CaracteristicasController : BaseApiController
    {
        #region Properties

        const string _controllerName = "Caracteristica";

        #endregion

        #region Ctor
        public CaracteristicasController(IMapper mapper) : base(mapper)    {
        }

        #endregion


        #region API - Routes

        /// <summary>Caracteristica</summary>
        /// <remarks>Retorna todas as caracteristicas</remarks>
        /// <returns>Lista de Caracteristicas</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        
        [HttpGet]
        [Route(template: "caracteristicas")]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var caracteristicas = await context.Caracteristicas.AsNoTracking().ToListAsync();

            var retcaracteristicas = _mapper.Map<List<CaracteristicaResponse>>(caracteristicas);

            return retcaracteristicas == null ? NotFound() : Ok(retcaracteristicas);
        }

        /// 
        /// <summary>
        /// Retornar uma caractecteristica com base no id.
        /// </summary>
        /// <param name="id">Identificador da caracteristica.</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route(template: "caracteristica/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,
                                                       [FromRoute] int id)
        {
            var caracteristica = await context.Caracteristicas.AsNoTracking().FirstOrDefaultAsync(x => x.IdCaracteristica == id);

            var getcaracteristica = _mapper.Map<CaracteristicaResponse>(caracteristica);

            return getcaracteristica == null ? NotFound() : Ok(getcaracteristica);
        }

        [HttpPost(template: "caracteristica")]
        public async Task<IActionResult> PostAsync(
                [FromServices] AppDbContext context,
                [FromBody] CaracteristicaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<CaracteristicaModel>(request);

            try
            {
                await context.Caracteristicas.AddAsync(model);
                await context.SaveChangesAsync();

                return Created($"v1/caracteristica/{model.IdCaracteristica}", model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(template: "caracteristica")]
        [ProducesResponseType(typeof(PessoaResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(
                [FromServices] AppDbContext context, 
                [FromQuery] CaracteristicaPutRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var caracteristica = await context.Caracteristicas.AsNoTracking().FirstOrDefaultAsync(x => x.IdCaracteristica == request.IdCaracteristica);

                if (caracteristica == null)
                   return NotFound();


                if (string.IsNullOrEmpty(request.Descricao) &&  request.Tipo != caracteristica.Tipo )
                    return BadRequest("Nenhuma informação para ser alterada!");

                caracteristica.Descricao = string.IsNullOrEmpty(request.Descricao) ? caracteristica.Descricao : request.Descricao;

                caracteristica.Tipo = request.Tipo != caracteristica.Tipo ? caracteristica.Tipo : request.Tipo;

                await context.SaveChangesAsync();

                return Created($"v1/caracteristica/{caracteristica.IdCaracteristica}", caracteristica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(template: "caracteristica/id")]
        public async Task<IActionResult> DeleteAsync(
                [FromServices] AppDbContext context, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var imovel = await context.Caracteristicas.AsNoTracking().FirstOrDefaultAsync(x => x.IdCaracteristica == id);

                if (imovel == null)
                    return NotFound();

                context.Remove(imovel);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
