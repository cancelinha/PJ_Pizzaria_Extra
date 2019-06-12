using Pizzarias.Extra.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzarias.Extra.WebApi.Interfaces
{
    interface IUsuarioRepositorio
    {
        List<Usuario> ListarUsuarios();
        void Cadastrar(Usuario usuario);
        Usuario BuscarEmailSenha(string email, string senha);
        void Deletar(int id);
        void Alterar(Usuario usuario);
        Usuario BuscarUsuario(int usuarioId);
    }
}
