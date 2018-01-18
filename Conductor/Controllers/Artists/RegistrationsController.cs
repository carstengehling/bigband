using Conductor.Repositories;
using Conductor.Repositories.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Conductor.Controllers
{
    [Produces("application/json")]
    [Route("api/Artists/Registrations")]
    public class RegistrationsController : Controller
    {
        private readonly IConfiguration _configuration;
        private IArtistRepository _repository;

        public RegistrationsController(IConfiguration configuration, IArtistRepository repository)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public IActionResult Post([FromBody]ArtistRegistrationDTO registration)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var artist = _repository.CreateArtist(registration);

            var token = GenerateJwtToken(artist);
            return Created($"/api/artists/{artist.Key}/compositions", token);
        }

        private object GenerateJwtToken(ArtistDTO artist)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, artist.Key),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, artist.Key)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
