using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Classes;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    // POST api/<PatientController>/AddPatient
    [HttpPost]
    [Route("AddPatient")]
    public async Task<IActionResult> AddPatient([FromBody] PatientDTO patient)
    {
        try
        {
            bool success= await _patientService.AddPatient(patient);
            return !success ? BadRequest("Adding patient failed! try again later...") : Ok();

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
