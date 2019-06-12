using System;
using System.Collections.Generic;

namespace Pizzarias.Extra.WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoDeUsuario { get; set; }

        public TipoUsuario TipoDeUsuarioNavigation { get; set; }
    }
}
