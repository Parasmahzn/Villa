using Mapster;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa.API.Data;
using Villa.API.Logging;
using Villa.API.Models;
using Villa.API.Models.Dto;

namespace Villa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VillaAPIController : ControllerBase
{
    private readonly ILogging _logger;
    private readonly ApplicationDbContext _db;

    public VillaAPIController(ILogging logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet(Name = "GetVillas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<VillaDTO>> GetVillas()
    {

        _logger.Log("Getting all Villas", "");
        return Ok(_db.Villas.ToList());
    }

    [HttpGet("{id:int}", Name = "GetVilla")]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDTO> GetVilla(int id)
    {
        if (id == 0)
        {
            _logger.Log("Get villa error with id " + id, "error");
            return BadRequest();
        }
        var villa = _db.Villas.FirstOrDefault(x => x.Id == id);

        if (villa == null)

            return NotFound();

        return Ok(villa);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        if (_db.Villas.FirstOrDefault(x => x.Name.ToLower() == villaDTO.Name.ToLower()) != null)
        {
            ModelState.AddModelError("CustomerError", "Villa already Exists");
            return BadRequest(ModelState);
        }

        if (villaDTO == null)
            return BadRequest(villaDTO);
        if (villaDTO.Id > 0)
            return StatusCode(StatusCodes.Status500InternalServerError);

        var villaModel = villaDTO.Adapt<VillaModel>();
        _db.Villas.Add(villaModel);
        _db.SaveChanges();
        return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id:int}", Name = "DeleteVilla")]
    public IActionResult DeleteVilla(int id)
    {
        if (id == 0)
            return BadRequest();

        var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
        if (villa == null)
            return NotFound();

        _db.Villas.Remove(villa);
        _db.SaveChanges();
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id:int}", Name = "UpdateVilla")]
    public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
    {
        if (villaDTO == null || id != villaDTO.Id)
            return BadRequest();

        var villaModel = villaDTO.Adapt<VillaModel>();
        _db.Villas.Update(villaModel);
        _db.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
    {
        if (patchDTO == null || id == 0)
            return BadRequest();
        var villa = _db.Villas
                       .AsNoTracking()
                       .FirstOrDefault(u => u.Id == id);

        if (villa == null)
            return BadRequest();

        var villaDTo = villa.Adapt<VillaDTO>();

        patchDTO.ApplyTo(villaDTo, ModelState);

        var model = villaDTo.Adapt<VillaModel>();
        _db.Villas.Update(model);
        _db.SaveChanges();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return NoContent();
    }
}