using CondominiosWAPI.Contracts;
using CondominiosWAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Controllers
{
    [Route("api/reserva")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IInquilinoRepository _inquilinoRepository;
        private readonly IAreaRepository _areaRepository;

        public ReservaController(IReservaRepository reservaRepository, IInquilinoRepository inquilinoRepository, IAreaRepository areaRepository)
        {
            _reservaRepository = reservaRepository;
            _inquilinoRepository = inquilinoRepository;
            _areaRepository = areaRepository;
        }

        [HttpGet]
        [Route("reserva/{id}")]
        public async Task<IActionResult> GetReserva(int id)
        {
            try
            {
                var reserva = await _reservaRepository.GetReserva(id);
                if (reserva == null)
                    return NotFound();
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReserva(ReservaForCreationDto reserva)
        {
            try
            {
                var createdReserva = await _reservaRepository.CreateReserva(reserva);
                return Ok(createdReserva);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("inquilinos")]
        public async Task<IActionResult> GetInquilinos()
        {
            try
            {
                var inquilinos = await _inquilinoRepository.GetInquilinos();
                if (inquilinos == null)
                    return NotFound();
                return Ok(inquilinos);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("inquilino/{name}")]
        public async Task<IActionResult> GetInquilinoByName(string name)
        {
            try
            {
                var inquilino = await _inquilinoRepository.GetInquilinoByName(name);
                if (inquilino == null)
                    return NotFound();
                return Ok(inquilino);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("tiposarea")]
        public async Task<IActionResult> GetTiposArea()
        {
            try
            {
                var tiposArea = await _areaRepository.GetTiposArea();
                if (tiposArea == null)
                    return NotFound();
                return Ok(tiposArea);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("tipoarea/{id}")]
        public async Task<IActionResult> GetTipoArea(int id)
        {
            try
            {
                var tipoArea = await _areaRepository.GetTipoArea(id);
                if (tipoArea == null)
                    return NotFound();
                return Ok(tipoArea);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("areascomunes")]
        public async Task<IActionResult> GetTorres()
        {
            try
            {
                var areasComunes = await _areaRepository.GetAreasComunes();
                if (areasComunes == null)
                    return NotFound();
                return Ok(areasComunes);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("areacomun/{id}")]
        public async Task<IActionResult> GetTorre(int id)
        {
            try
            {
                var areaComun = await _areaRepository.GetAreaComun(id);
                if (areaComun == null)
                    return NotFound();
                return Ok(areaComun);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
