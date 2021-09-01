using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {
        public List<ClienteDomain> ListarTodos();

        public ClienteDomain BuscarPorId(int idCliente);


        void Cadastrar(ClienteDomain novoCliente);


        void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado);


        void Deletar(int idCliente);
    }
}
