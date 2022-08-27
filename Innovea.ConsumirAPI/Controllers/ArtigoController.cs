using Innovea.ConsumirAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Innovea.ConsumirAPI.Controllers
{
    [ApiController]
    [Route("api/artigos")]
    public class ArtigoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string _baseUrl;

        public ArtigoController(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("BaseUrl").Value;
        }

        public async Task<IActionResult> ObterListaDeArtigos()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);

                var response = await httpClient.GetAsync(_baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var artigos = JsonConvert.DeserializeObject<Recurso>(json);
                    return Ok(artigos);
                }
                else
                    return BadRequest();

            }
        }
    }
}
