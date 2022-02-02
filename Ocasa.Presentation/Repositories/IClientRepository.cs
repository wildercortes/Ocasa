using Ocasa.Entities;
using System.Collections.Generic;

namespace Ocasa.Presentation.Repositories
{
    public interface IClientRepository
    {
        bool ClienteExists(int? id);
        List<Cliente> GetAllClientes();
        Cliente GetClienteByID(int? id);
        void InsertClient(Cliente cliente);
        void UpdateClient(Cliente cliente);
    }
}