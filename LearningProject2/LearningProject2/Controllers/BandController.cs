using LearningProject2.Data;
using LearningProject2.DTO;
using Microsoft.AspNetCore.Mvc;
using LearningProject2.Models;
using LearningProject2.Interfaces;
using LearningProject2.Properties.CustomException;
using Microsoft.EntityFrameworkCore;

namespace LearningProject2.Controllers;

  [Route("api/[controller]")]
  [ApiController]
public class BandController(IBandService _bandService) : ControllerBase
{
    /*
    private readonly IBandService _bandService;
    public BandController(IBandService BandService)
    {
       _bandService = BandService;
    }*/
    
    // GET Methods
    [HttpGet]
    public async Task<IActionResult>ConusltAllBands()
    {
        var bandlist = await _bandService.ConsultAllBands();
        if (bandlist.Any()==false) {
            return NotFound("There are no Bands in Data Base");
        }
        return Ok(bandlist);
        
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult>ConusltBandById(int id)
    {
        var bands_list =await  _bandService.ConsultBandById(id);
        if (bands_list == null) {
            return NotFound("Query not found");
        }
        return Ok(bands_list);
        
        
    }
    
    [HttpGet("country/{country}")]
    public async Task<IActionResult>ConusltBandById(string country)
    {
        var bands_list =await  _bandService.ConsultBandByCountry(country);
        if (bands_list.Any()==false) {
            return NotFound("Bands of that country are not registered");
        }
        return Ok(bands_list);
    }
    
    //Post Methods
    [HttpPost]
    public async Task<ActionResult> AddBand([FromBody] Band band)
    {
        var band_list = await _bandService.AddBand(band);
        return Ok(band_list);
    }
    
    //Update
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBand([FromBody]Band band,int id)
    {
        try
        {
            var band_list = await _bandService.UpdateBand(band, id);
            return Ok(band_list);

        }
        catch(InvalidIdException e)
        {
            return NotFound(e.Message);
        }
        catch(ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    //Delete
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBand(int id)
    {
        await _bandService.DeleteBandById(id);
        return Ok();
    }
}