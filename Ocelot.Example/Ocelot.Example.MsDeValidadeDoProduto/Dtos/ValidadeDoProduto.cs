using System;

namespace Ocelot.Example.MsDeValidadeDoProduto.Dtos
{
    public class ValidadeDoProduto
    {
        public int IdDoProduto { get; set; }
        public string NomeDoProduto { get; set; }
        public DateTime DataDeValidade { get; set; }
    }
}