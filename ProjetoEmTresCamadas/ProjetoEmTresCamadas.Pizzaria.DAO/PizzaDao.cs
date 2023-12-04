using Microsoft.Data.Sqlite;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProjetoEmTresCamadas.Pizzaria.DAO;

public class PizzaDao
{
    private const string ConnectionString = "Data Source=Pizza.db";
    public PizzaDao()
    {
        CriarBancoDeDados();
    }

    public void CriarBancoDeDados()
    {
        using (
            var sqlConnection
            = new SqliteConnection(ConnectionString)
            )
        {
            sqlConnection.Open();
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS TB_PIZZA
                (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Sabor VARCHAR(50) not null,
                    Descricao VARCHAR(100),
                    TAMANHODAPIZZA INTEGER
                )";
                cmd.ExecuteNonQuery();
            }
        }
    }


    public void CriarPizza(Pizza pizzaVo)
    {
        using (
            var sqlConnection
            = new SqliteConnection(ConnectionString)
            )
        {
            sqlConnection.Open();
            using (var cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = @$"INSERT INTO TB_PIZZA
                     (SABOR, Descricao, TAMANHODAPIZZA)
                     VALUES('{pizzaVo.Sabor}',
                            '{pizzaVo.Descricao}',
                             {(int)pizzaVo.TamanhoDePizza})";
                cmd.ExecuteNonQuery();
            }
        }

    }

    public List<Pizza> ObterPizzas()
    {
        List<Pizza> pizzas = new List<Pizza>();

        using (
            var sqlConnection
            = new SqliteConnection(ConnectionString)
            )
        {
            sqlConnection.Open();
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = @$"SELECT * FROM  TB_PIZZA";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pizza pizza = new Pizza
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Sabor = reader["Sabor"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            TamanhoDePizza = (TamanhoDePizza)Convert.ToInt32(reader["TAMANHODAPIZZA"])
                        };
                        pizzas.Add(pizza);

                    }
                }

            }
            return pizzas;
        }
    }

    public string ObterInformacoesPizzas()
    {
    List<Pizza> pizzas = ObterPizzas(); // Obtém as pizzas do banco de dados usando o método existente

    // Cria uma string para armazenar as informações das pizzas
    StringBuilder pizzaInfo = new StringBuilder();

    foreach (var pizza in pizzas)
    {
        // Adiciona as informações de cada pizza à string
        pizzaInfo.AppendLine($"ID: {pizza.Id} - Sabor: {pizza.Sabor} - Descrição: {pizza.Descricao} - Tamanho: {pizza.TamanhoDePizza}");
    }

    return pizzaInfo.ToString(); // Retorna a string com as informações das pizzas
    }

    
}
    