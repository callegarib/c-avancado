using Microsoft.Data.Sqlite;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.DAO
{
    public class ClienteDao
    {
        private const string ConnectionString = "Data Source=Pizza.db";

        public ClienteDao()
        {
            CriarBancoDeDadosCliente();
        }

        public void CriarBancoDeDadosCliente()
        {
            using (
                var sqlConnection
                = new SqliteConnection(ConnectionString)
                )
            {
                sqlConnection.Open();
                using (var cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS TB_CLIENTE
                (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,                   
                    NOME VARCHAR(100)
                )";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CriarCliente(Cliente clienteVo)
        {
            using (
                var sqlConnection
                = new SqliteConnection(ConnectionString)
                )
            {
                sqlConnection.Open();
                using (var cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = @$"INSERT INTO TB_CLIENTE
                     (NOME)
                     VALUES('{clienteVo.Nome}')";
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public List<Cliente> ObterClientes()
        {
                List<Cliente> clientes = new List<Cliente>();

                using (
                    var sqlConnection
                    = new SqliteConnection(ConnectionString)
                    )
                {
                    sqlConnection.Open();
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = @$"SELECT * FROM  TB_CLIENTE";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            Cliente cliente = new Cliente
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nome = reader["Nome"].ToString()
                                };
                                clientes.Add(cliente);

                            }
                        }

                    }
                }
            return clientes;
        }

        public string ObterInformacoesClientes()
        {
        List<Cliente> clientes = ObterClientes();        
        StringBuilder clienteInfo = new StringBuilder();
        foreach (var cliente in clientes)
        {
            clienteInfo.AppendLine($"ID: {cliente.Id} - Nome: {cliente.Nome}");
        }

        return clienteInfo.ToString(); 
        }



    }

    
}
