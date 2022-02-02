using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ocasa.Entities;
using Ocasa.Presentation.Data;
using System.Collections.Generic;
using System.Linq;

namespace Ocasa.Presentation.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext context;

        public ClientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Cliente GetClienteByID(int? id)
                => (context.Clientes.FromSqlRaw<Cliente>("sp_ConsultarCliente {0}", id).ToList().FirstOrDefault());

        public List<Cliente> GetAllClientes()
                => context.Clientes.FromSqlRaw<Cliente>("sp_GetAllClients").ToList();

        public bool ClienteExists(int? id)
               => (GetClienteByID(id)) != null;

        public void InsertClient(Cliente cliente)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarCliente";
            cmd.Parameters.Add("RazonSocial", System.Data.SqlDbType.VarChar, 50).Value = cliente.RazonSocial;
            cmd.Parameters.Add("Direccion", System.Data.SqlDbType.VarChar, 200).Value = cliente.Direccion;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateClient(Cliente cliente)
        {
            SqlConnection conn = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarCliente";
            cmd.Parameters.Add("RazonSocial", System.Data.SqlDbType.VarChar, 50).Value = cliente.RazonSocial;
            cmd.Parameters.Add("Direccion", System.Data.SqlDbType.VarChar, 200).Value = cliente.Direccion;
            cmd.Parameters.Add("IdCliente", System.Data.SqlDbType.Int).Value = cliente.IdCliente;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
