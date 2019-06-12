using Pizzarias.Extra.WebApi.Domains;
using Pizzarias.Extra.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzarias.Extra.WebApi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog = Senai_Pizzarias; user id = sa; pwd = 132";

        public List<Usuario> ListarUsuarios()
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
               return ctx.Usuario.ToList();
            }
        }
        public void Cadastrar(Usuario usuario)
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuario BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = @"SELECT U.ID_USUARIO, U.EMAIL, U.SENHA, U.TIPO_DE_USUARIO, TU.NOME AS NOMETIPOUSUARIO
                                        FROM USUARIO U INNER JOIN TIPO_USUARIO TU ON TU.ID_TIPO_USUARIO = U.TIPO_DE_USUARIO
                                        WHERE EMAIL=@EMAIL AND SENHA=@SENHA";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        Usuario usuario = new Usuario();

                        while (sdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(sdr["ID_USUARIO"]);
                            usuario.Email = sdr["EMAIL"].ToString();
                            usuario.TipoDeUsuarioNavigation = new TipoUsuario();
                            usuario.TipoDeUsuarioNavigation.Nome = sdr["NOMETIPOUSUARIO"].ToString();
                        }
                        return usuario;
                    }
                }
                return null;
            }
        }

        public void Deletar(int id)
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                ctx.Usuario.Remove(ctx.Usuario.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Alterar(Usuario usuario)
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                Usuario usuarioExiste = ctx.Usuario.Find(usuario.IdUsuario);

                usuarioExiste.IdUsuario = usuario.IdUsuario;
                ctx.Usuario.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuario BuscarUsuario(int usuarioId)
        {
            Usuario usuarioBuscado = new Usuario();

            using (PizzariasContext ctx = new PizzariasContext())
            {
                usuarioBuscado = ctx.Usuario.Find(usuarioId);
            }

            return usuarioBuscado;
        }

    }
}
