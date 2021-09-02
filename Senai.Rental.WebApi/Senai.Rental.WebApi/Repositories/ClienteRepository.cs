using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=NOTE0113G3/SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";


        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @nomeCliente WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobrenomeCliente FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            nomeCliente = reader["nomeCliente"].ToString(),

                            sobrenomeCliente = reader["sobrenomeCliente"].ToString()
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

            public void Cadastrar(ClienteDomain novoCliente)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryInsert = "INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente, CNH) VALUES (@nomeCliente, @sobrenomeCliente)";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                        cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                        cmd.Parameters.AddWithValue("@CNH", novoCliente.CNH);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void Deletar(int idCliente)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public List<ClienteDomain> ListarTodos()
            {
                List<ClienteDomain> listaClientes = new List<ClienteDomain>();

                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectAll = "SELECT idCliente, nomeCliente, sobrenomeCliente, CNH FROM CLIENTE";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            ClienteDomain cliente = new ClienteDomain
                            {
                                idCliente = Convert.ToInt32(rdr[0]),
                                nomeCliente = rdr[1].ToString(),
                                sobrenomeCliente = rdr[2].ToString(),
                                CNH = Convert.ToInt32(rdr[3])

                            };

                            listaClientes.Add(cliente);

                        }
                    }

                }
                return listaClientes;
            }
        }
    }

