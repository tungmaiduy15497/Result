﻿using Tung.Result.AspNetCore;
using Tung.Result.Sample.Core.DTOs;
using Tung.Result.Sample.Core.Model;
using Tung.Result.Sample.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tung.Result.SampleWeb.PersonFeature;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;

    public PersonController(PersonService personService)
    {
        _personService = personService;
    }

    /// <summary>
    /// This uses a filter to convert an Tung.Result return type to an ActionResult.
    /// This filter could be used per controller or globally!
    /// </summary>
    /// <returns></returns>
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.NotFound, ResultStatus.Invalid)]
    [HttpDelete("Remove/{id}")]
    public Result RemovePerson(int id)
    {
        return _personService.Remove(id);
    }
    
    /// <summary>
    /// This uses a filter to convert an Tung.Result return type to an ActionResult.
    /// This filter could be used per controller or globally!
    /// </summary>
    /// <returns></returns>
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.NotFound, ResultStatus.Invalid)]
    [HttpPost("New/")]
    public Result<Person> CreatePerson(CreatePersonRequestDto request)
    {
        return _personService.Create(request.FirstName, request.LastName);
    }
}
