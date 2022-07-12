using CondominiosWAPI.Contracts;
using CondominiosWAPI.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/gasto")]
    [ApiController]
    public class GastoController : Controller
    {
        private readonly IGastoRepository _gastoRepo;
        private readonly IProveedorRepository _proveedorRepo;
        private readonly ICondominioRepository _condominioRepo;
        private readonly IDepartamentoRepository _departamentoRepo;
        private readonly ITorreRepository _torreRepo;

        public GastoController(IGastoRepository gastoRepo, IProveedorRepository proveedorRepo, ICondominioRepository condominioRepo,
            IDepartamentoRepository departamentoRepo, ITorreRepository torreRepo)
        {
            _gastoRepo = gastoRepo;
            _proveedorRepo = proveedorRepo;
            _condominioRepo = condominioRepo;
            _departamentoRepo = departamentoRepo;
            _torreRepo = torreRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetGasto(string idCondominio, string idTorre, string idDepartamento, string idProveedor,
            string fechaGasto, string fechaVencimiento)
        {
            GastoForQueryDto filtros = new GastoForQueryDto();
            filtros.IdCondominio = Convert.ToInt32(idCondominio);
            filtros.IdTorre = Convert.ToInt32(idTorre);
            filtros.IdDepartamento = Convert.ToInt32(idDepartamento);
            filtros.IdProveedor = Convert.ToInt32(idProveedor);
            filtros.FechaGasto = DateTime.ParseExact(fechaGasto, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            filtros.FechaVencimiento = DateTime.ParseExact(fechaVencimiento, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            try
            {
                var gasto = await _gastoRepo.GetGasto(filtros);
                if (gasto == null)
                    return NotFound();
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [AllowAnonymous]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateGasto(GastoForCreationDto gasto)
        {
            try
            {
                var createdGasto = await _gastoRepo.CreateGasto(gasto);
                return Ok(createdGasto);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("proveedores")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProveedores()
        {
            try
            {
                var proveedores = await _proveedorRepo.GetProveedores();
                if (proveedores == null)
                    return NotFound();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("proveedores/{name}")]
        public async Task<IActionResult> GetProveedorByName(string name)
        {
            try
            {
                var proveedores = await _proveedorRepo.GetProveedoresByName(name);
                if (proveedores == null)
                    return NotFound();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("tiposgasto")]
        public IActionResult GetTiposGasto()
        {
            try
            {
                var tiposGasto = _gastoRepo.GetTiposGasto();
                if (tiposGasto == null)
                    return NotFound();
                return Ok(tiposGasto);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("tipogasto/{id}")]
        public IActionResult GetTipoGasto(int id)
        {
            try
            {
                var tipoGasto = _gastoRepo.GetTipoGasto(id);
                if (tipoGasto == null)
                    return NotFound();
                return Ok(tipoGasto);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("condominios")]
        public async Task<IActionResult> GetCondominios()
        {
            try
            {
                var condominios = await _condominioRepo.GetCondominios();
                if (condominios == null)
                    return NotFound();
                return Ok(condominios);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("condominio/{id}")]
        public async Task<IActionResult> GetCondominio(int id)
        {
            try
            {
                var proveedor = await _condominioRepo.GetCondominio(id);
                if (proveedor == null)
                    return NotFound();
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("torres")]
        public async Task<IActionResult> GetTorres()
        {
            try
            {
                var torres = await _torreRepo.GetTorres();
                if (torres == null)
                    return NotFound();
                return Ok(torres);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("torre/{id}")]
        public async Task<IActionResult> GetTorre(int id)
        {
            try
            {
                var torre = await _torreRepo.GetTorre(id);
                if (torre == null)
                    return NotFound();
                return Ok(torre);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("torres/{idCondominio}")]
        public async Task<IActionResult> GetTorresByCondominio(int idCondominio)
        {
            try
            {
                var torres = await _torreRepo.GetTorresByCondominio(idCondominio);
                if (torres == null)
                    return NotFound();
                return Ok(torres);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("departamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            try
            {
                var departamentos = await _departamentoRepo.GetDepartamentos();
                if (departamentos == null)
                    return NotFound();
                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("departamento/{id}")]
        public async Task<IActionResult> GetDepartamento(int id)
        {
            try
            {
                var departamento = await _departamentoRepo.GetDepartamento(id);
                if (departamento == null)
                    return NotFound();
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("departamentos/{idTorre}")]
        public async Task<IActionResult> GetDepartamentosByTorre(int idTorre)
        {
            try
            {
                var torres = await _departamentoRepo.GetDepartamentosByTorre(idTorre);
                if (torres == null)
                    return NotFound();
                return Ok(torres);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("tiposcalculo")]
        public IActionResult GetTiposCalculo()
        {
            try
            {
                var tiposCalculo = _gastoRepo.GetTiposCalculo();
                if (tiposCalculo == null)
                    return NotFound();
                return Ok(tiposCalculo);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("tipocalculo/{id}")]
        public IActionResult GetTipoCalculo(int id)
        {
            try
            {
                var tipoCalculo = _gastoRepo.GetTipoCalculo(id);
                if (tipoCalculo == null)
                    return NotFound();
                return Ok(tipoCalculo);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
