using System;
using System.Collections.Generic;

namespace Pizzarias.Extra.WebApi.Domains
{
    public partial class CategoriaPreco
    {

        public int IdCategoria { get; set; }
        public string Preco { get; set; }
        public string Categoria { get; set; }

        public CategoriaPreco()
        {
            Pizzarias = new HashSet<Pizzaria>();
        }
        public ICollection<Pizzaria> Pizzarias { get; set; }
    }
}
