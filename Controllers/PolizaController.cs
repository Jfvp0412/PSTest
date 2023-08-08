using System;
using Microsoft.AspNetCore.Mvc;
using PSTest.Services;
using PSTest.Models;

namespace PSTest.Controllers;

[Controller]
[Route("api/[controller]")]
public class PolizaController : Controller
{
    private readonly MongoDBService _mongoDBService;

    public PolizaController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Poliza>> Get()
    {
        return await _mongoDBService.GetAsync();
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Poliza poliza)
    {
        var fechaInicio = DateTime.Parse(poliza.fecha_poliza);
        var fechaFin = DateTime.Parse(poliza.fecha_fin);
        Console.WriteLine(fechaInicio.ToString() + ' '  + fechaFin);
        if (fechaInicio >= fechaFin)
        {
            return BadRequest("La poliza no puede ser creada si se encuentra vencida.");
        }
        await _mongoDBService.CreateAsync(poliza);
        return CreatedAtAction(nameof(Get), new { id = poliza.Id }, poliza);
    }

    [HttpGet("getByPlaca/{placa}")]
    public async Task<ActionResult<List<Poliza>>> GetByPlaca(string placa)
    {
        List<Poliza> polizas = await _mongoDBService.GetByPlacaAsync(placa);
        return polizas;
    }

    [HttpGet("getByNPoliza/{nPoliza}")]
    public async Task<ActionResult<List<Poliza>>> GetByNPoliza(long nPoliza)
    {
        List<Poliza> polizas = await _mongoDBService.GetByNPolizaAsync(nPoliza);
        return polizas;
    }

}