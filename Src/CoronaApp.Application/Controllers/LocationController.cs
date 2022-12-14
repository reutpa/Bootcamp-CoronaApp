using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Classes;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    public LocationController(ILocationService locationDal)
    {
        _locationService = locationDal;
    }

    // GET: api/<LocationController>/GetAllLocations
    [HttpGet]
    [Route("GetAllLocations")]
    public async Task<IActionResult> GetAllLocations()
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetAllLocations();
            return locations == null ? BadRequest("failed! try again later...") :
                locations.ToArray().Length == 0 ? NoContent() : Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/<LocationController>/GetAllLocationsByCity/Jerusalem
    [HttpGet]
    [Route("GetAllLocationsByCity/{city}")]
    public async Task<IActionResult> GetAllLocationsByCity(string city)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetAllLocations(city);
            return locations==null ? BadRequest("failed! try again later...") : 
                locations.ToArray().Length == 0 ? NoContent(): Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/<LocationController>/GetLocationsByLocationSearch
    [HttpGet]
    [Route("GetLocationsByLocationSearch")]
    public async Task<IActionResult> GetLocationsByLocationSearch([FromBody] LocationSearch locationSearch)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetLocationsByLocationSearch(locationSearch);
            return locations == null ? BadRequest("failed! try again later...") :
                locations.ToArray().Length == 0 ? NoContent() : Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/<LocationController>/GetLocationsPerPatient/123456789
    [HttpGet]
    [Route("GetLocationsPerPatient/{id}")]
    public async Task<IActionResult> GetLocationsPerPatient(string id)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetLocationsPerPatient(id);
            return locations == null ? BadRequest("failed! try again later...") :
                locations.ToArray().Length == 0 ? NoContent() : Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // POST: api/<LocationController>/AddLocation
    [HttpPost]
    [Route("AddLocation")]
    public async Task<IActionResult> AddLocation([FromBody] LocationDTO location)
    {
        try
        {
            bool success = await _locationService.AddLocation(location);
            return !success ? BadRequest("Adding location failed! try again later...") : Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // DELETE: api/<LocationController>/123456789
    [HttpDelete]
    [Route("DeleteLocation")]
    public async Task<IActionResult> DeleteLocation([FromBody] LocationDTO location)
    {
        try
        {
            bool success = await _locationService.DeleteLocation(location);
            return !success ? BadRequest("Deleting location failed! try again later...") : Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}