using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocelot.Example.MsDeValidadeDoProduto.Dtos;
using System;

namespace Ocelot.Example.MsDeValidadeDoProduto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidadeDoProdutoController : ControllerBase
    {
        private static readonly string[] _nomesDeProdutos = new[]
        {
            "Coca-cola",
            "Pepsi",
            "Fandangos",
            "Teclado",
            "Saco de carvão"
        };

        private readonly ILogger<ValidadeDoProdutoController> _logger;

        public ValidadeDoProdutoController(ILogger<ValidadeDoProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ValidadeDoProduto Get()
        {
            var rng = new Random();

            return new ValidadeDoProduto
            {
                IdDoProduto = rng.Next(1, 1000),
                NomeDoProduto = _nomesDeProdutos[rng.Next(_nomesDeProdutos.Length)],
                DataDeValidade = DateTime.Now.AddDays(rng.Next(10, 20))
            };
        }
    }
}