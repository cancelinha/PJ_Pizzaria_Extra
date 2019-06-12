using Pizzarias.Extra.WebApi.Domains;
using Pizzarias.Extra.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzarias.Extra.WebApi.Repositorios
{
    public class PizzariaRepositorio : IPizzariaRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog = Senai_Pizzarias; user id = sa; pwd = 132";

        public void Cadastrar(Pizzaria pizzaria)
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                ctx.Pizzarias.Add(pizzaria);
                ctx.SaveChanges();
            }
        }

        public List<Pizzaria> ListarPizzarias(int idrecebido, string tipousuario)
        {
            string QuerySelect = @"SELECT P.ID_PIZZARIA, P.NOME, P.ENDERECO, P.TELEFONE_COMERCIAL, P.OPCAO_VEGANA, CP.ID_CATEGORIA, CP.CATEGORIA AS CATEGORIA_DE_PREÇO FROM PIZZARIAS P 
JOIN CATEGORIA_PRECO CP  ON CP.ID_CATEGORIA = P.CATEGORIA_DO_PRECO";

            List<Pizzaria> listaPizzarias = new List<Pizzaria>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Pizzaria pizzaria = new Pizzaria();
                        pizzaria.IdPizzaria = Convert.ToInt32(sdr["ID_PIZZARIA"]);
                        pizzaria.Nome = sdr["NOME"].ToString();
                        pizzaria.Endereco = sdr["ENDERECO"].ToString();
                        pizzaria.TelefoneComercial = sdr["TELEFONE_COMERCIAL"].ToString();
                        pizzaria.OpcaoVegana = pizzaria.OpcaoVegana;
                        pizzaria.CategoriaDoPrecoNavigation = new CategoriaPreco();
                        pizzaria.CategoriaDoPrecoNavigation.IdCategoria = Convert.ToInt32(sdr["ID_CATEGORIA"]);
                        pizzaria.CategoriaDoPrecoNavigation = new CategoriaPreco();
                        pizzaria.CategoriaDoPrecoNavigation.Categoria = sdr["CATEGORIA_DE_PRECO"].ToString();
                        listaPizzarias.Add(pizzaria);
                    }
                }
            }

            return listaPizzarias   ;
        }

        public Pizzaria BuscarPizzaria(int IdPizzaria)
        {
            Pizzaria pizzariaBuscada = new Pizzaria();

            using (PizzariasContext ctx = new PizzariasContext())
            {
                pizzariaBuscada = ctx.Pizzarias.Find(IdPizzaria);
            }

            return pizzariaBuscada;
        }
    }
}
