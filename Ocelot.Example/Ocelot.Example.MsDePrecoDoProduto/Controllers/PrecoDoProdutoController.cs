using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocelot.Example.MsDePrecoDoProduto.Dtos;

namespace Ocelot.Example.MsDePrecoDoProduto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrecoDoProdutoController : ControllerBase
    {
        private static readonly string[] _nomesDeProdutos = new[]
        {
           "Coca-cola",
           "Pepsi",
           "Fandangos",
           "Teclado",
           "Saco de carvão"
        };

        private readonly ILogger<PrecoDoProdutoController> _logger;

        public PrecoDoProdutoController(ILogger<PrecoDoProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public PrecoDoProduto Get()
        {
            var rng = new Random();

            return new PrecoDoProduto
            {
                IdDoProduto = rng.Next(1, 1000),
                NomeDoProduto = _nomesDeProdutos[rng.Next(_nomesDeProdutos.Length)],
                Preco = rng.Next(10, 20)
            };
        }
    }
}