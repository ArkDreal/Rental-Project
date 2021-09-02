using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository
    {
        private string stringConexao = "Data Source=NOTE0113G3/SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE VEICULO SET = @placaVeiculo WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.Modelo.idModelo);
                    cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.Empresa.idEmpresa);
                    cmd.Parameters.AddWithValue("@placaVeiculo", veiculoAtualizado.placaVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT E.nomeEmpresa,
	                                               M.nomeModelo,
	                                               MA.nomeMarca,
                                                   V.placa
                                              FROM VEICULO V
                                             INNER JOIN EMPRESA E
                                                ON V.idEmpresa = E.idEmpresa
                                             INNER JOIN MODELO M
                                                ON V.idModelo = M.idModelo
                                             INNER JOIN MARCA MA
	                                            ON M.idMarca = MA.idMarca
                                             WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                            Empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                            },

                            Modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(reader["idModelo"])
                            },

                            placaVeiculo = reader["placaVeiculo"].ToString()
                        };

                        return VeiculoBuscado;
                    }

                    return null;
                }
            }
        }
        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO(idEmpresa, idModelo, placaVeiculo) VALUES (@idEmpresa, @idModelo, @placaVeiculo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoVeiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.Empresa.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.Modelo.idModelo);
                    cmd.Parameters.AddWithValue("@placaVeiculo", novoVeiculo.placaVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
       public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idVeiculo, idEmpresa, idModelo FROM VEICULO";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain Veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            Empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[1]),
                            },
                            Modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr[2]),
                            },
                            
                            placaVeiculo = rdr[3].ToString()

                        };

                        listaVeiculos.Add(Veiculo);

                    }
                }

            }
            return listaVeiculos;
        }
    }
}
