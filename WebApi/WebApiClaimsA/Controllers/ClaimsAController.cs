using AutoMapper;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ResourceModel.Api;
using ResourceModel.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiClaimsA.Repository;

namespace WebApiClaimsA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ClaimsAController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClaimsAController> _logger;
        private readonly IClaimsRepository _claimsRepository;

        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public ClaimsAController(IMapper mapper, ILogger<ClaimsAController> logger, IClaimsRepository claimsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _claimsRepository = claimsRepository;
        }

        [Authorize]
        [HttpGet("GetClaimsCountAsync")]
        public async Task<Int64> GetClaimsCountAsync(Int64 userId)
        {
            Int64 claimsACount = 0;

            claimsACount = await this._claimsRepository.GetClaimsCountAsync(userId);

            return claimsACount;
        }
       
    }
}