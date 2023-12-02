using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio
{
    public class Pedido
    {
        // `Pedidos`: - Colunas: `Id` (chave primária), `ClienteId`, `PizzasIds` (lista de IDs de pizzas associadas).

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PizzaId { get; set; }

        public void PedidoService()
        {
            
        }

    }

}
