using Microsoft.Data.Sqlite;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.DAO
{
    public class PedidoDao
    {
        private const string ConnectionString = "Data Source=Pizza.db";

        public PedidoDao()
        {
            CriarBancoDeDadosPedido();
        }

        public void CriarBancoDeDadosPedido()
        {
            using (
                var sqlConnection
                = new SqliteConnection(ConnectionString)
                )
            {
                sqlConnection.Open();
                using (var cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS TB_PEDIDO
                (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,                   
                    CLIENTE_ID INTEGER,
                    PIZZA_ID INTEGER
                )";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /* public void CriarPedido(Pizza pizzaVo, Cliente clienteVo)
        {
            using (
                var sqlConnection
                = new SqliteConnection(ConnectionString)
                )
            {
                sqlConnection.Open();
                using (var cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = @$"INSERT INTO TB_PEDIDO
                     (CLIENTE_ID, PIZZA_ID)
                     VALUES({clienteVo.Id},
                            {pizzaVo.Id}    
                    )";
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public List<Pedido> ObterPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (
                var sqlConnection
                = new SqliteConnection(ConnectionString)
                )
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = @$"SELECT * FROM  TB_PEDIDO";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                ClienteId = Convert.ToInt32(reader["CLIENTE_ID"]),
                                PizzaId = Convert.ToInt32(reader["PIZZA_ID"])                                
                            };
                            pedidos.Add(pedido);

                        }
                    }

                }
            }
            return pedidos;
        } */

        public void CriarPedido(int clienteId, int pizzaId)
        {
            using (var sqlConnection = new SqliteConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = @$"INSERT INTO TB_PEDIDO (CLIENTE_ID, PIZZA_ID) VALUES({clienteId}, {pizzaId})";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Pedido> ObterPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (var sqlConnection = new SqliteConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM TB_PEDIDO";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                ClienteId = Convert.ToInt32(reader["CLIENTE_ID"]),
                                PizzaId = Convert.ToInt32(reader["PIZZA_ID"])
                            };
                            pedidos.Add(pedido);
                        }
                    }
                }
            }

            return pedidos;
        }

        public string ObterInformacoesPedidos()
        {
        List<Pedido> pedidos = ObterPedidos();        
        StringBuilder pedidoInfo = new StringBuilder();
        foreach (var pedido in pedidos)
        {
            pedidoInfo.AppendLine($"ID: {pedido.Id} - ID DO CLIENTE: {pedido.ClienteId} - ID DA PIZZA: {pedido.PizzaId}");
        }

        return pedidoInfo.ToString(); 
        }
    }
}
