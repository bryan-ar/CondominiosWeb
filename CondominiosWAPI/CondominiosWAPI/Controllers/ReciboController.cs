using CondominiosWAPI.Contracts;
using CondominiosWAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Controllers
{

    [Route("api/recibo")]
    [ApiController]
    public class ReciboController : Controller
    {
        private readonly IReciboRepository _reciboRepository;

        public ReciboController(IReciboRepository reciboRepository)
        {
            _reciboRepository = reciboRepository;
        }

        [HttpGet]
        [Route("recibos")]
        public async Task<IActionResult> GetRecibos([FromBody] ReciboForQueryDto filtros)
        {
            try
            {
                var recibos = await _reciboRepository.GetRecibos(filtros);
                if (recibos == null)
                    return NotFound();
                return Ok(recibos);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("recibo/{id}")]
        public async Task<IActionResult> GetRecibo(int id)
        {
            try
            {
                var recibo = await _reciboRepository.GetRecibo(id);
                if (recibo == null)
                    return NotFound();
                return Ok(recibo);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("estados")]
        public async Task<IActionResult> GetEstados()
        {
            try
            {
                var estados = await _reciboRepository.GetEstadosRecibo();
                if (estados == null)
                    return NotFound();
                return Ok(estados);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("estado/{id}")]
        public async Task<IActionResult> GetEstado(int id)
        {
            try
            {
                var estado = await _reciboRepository.GetEstadoRecibo(id);
                if (estado == null)
                    return NotFound();
                return Ok(estado);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecibo(ReciboForCreationDto recibo)
        {
            try
            {
                var createdRecibo = await _reciboRepository.CreateRecibo(recibo);
                return Ok(createdRecibo);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PagarRecibo(ReciboForPaymentDto payment)
        {
            try
            {
                var recibo = await _reciboRepository.GetRecibo(payment.idrecibo);
                if (recibo == null)
                    return NotFound();
                await _reciboRepository.PagarRecibo(payment);
                return Ok("Recibo pagado con éxito");
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
