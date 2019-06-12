using System;
using System.Collections.Generic;

namespace Pizzarias.Extra.WebApi.Domains
{
    public partial class Pizzaria
    {
        public int IdPizzaria { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string TelefoneComercial { get; set; }
        public bool? OpcaoVegana { get; set; }
        public int? CategoriaDoPreco { get; set; }

        public CategoriaPreco CategoriaDoPrecoNavigation { get; set; }
    }
}
