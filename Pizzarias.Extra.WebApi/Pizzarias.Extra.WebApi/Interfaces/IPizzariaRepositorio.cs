using Pizzarias.Extra.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzarias.Extra.WebApi.Interfaces
{
    interface IPizzariaRepositorio
    {
        void Cadastrar(Pizzaria pizzaria);
        List<Pizzaria> ListarPizzarias(int idrecebido, string tipousuario);
        Pizzaria BuscarPizzaria(int IdPizzaria);
    }
}
