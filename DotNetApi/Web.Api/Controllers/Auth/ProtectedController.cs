﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.Auth
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        // GET api/protected/home
        [HttpGet]
        public IActionResult Home()
        {
            return new OkObjectResult(new { result = true });
        }
    }
}
