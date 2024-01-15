﻿using Tung.ApiEndpoints;
using Tung.Result.AspNetCore;
using Tung.Result.Sample.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Tung.Result.Sample.Core.Model;

namespace Tung.Result.SampleWeb.PersonFeature;

public class PersonEndpoint : EndpointBaseSync
    .WithRequest<int>
    .WithActionResult
{
    private readonly PersonService _personService;

    public PersonEndpoint(PersonService personService)
    {
        _personService = personService;
    }

    /// <summary>
    /// This uses an extension method to convert to an ActionResult
    /// </summary>
    /// <returns></returns>
    [HttpDelete("/Person/Delete/{id}")]
    public override ActionResult Handle(int id)
    {
        if (DateTime.Now.Second % 2 == 0) // just so we can show both versions
        {
            // Extension method on ControllerBase
            return this.ToActionResult(_personService.Remove(id));
        }

        Result result = _personService.Remove(id);

        // Extension method on a Result instance (passing in ControllerBase instance)
        return result.ToActionResult(this);
    }
}
