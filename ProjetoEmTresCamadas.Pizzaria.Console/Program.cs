// See https://aka.ms/new-console-template for more information
using ProjetoEmTresCamadas.Pizzaria.DAO;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio;

PizzaDao pizzaDao = new PizzaDao();
ClienteDao clienteDao = new ClienteDao();
PedidoDao pedidoDao = new PedidoDao();



Console.WriteLine("Bem vindo a nossa pizaria");
Console.WriteLine("Gostaria de uma pizza, S para sim e N para não?");
var resposta = Console.ReadLine();

if(resposta == "S")
{
    var pizza = new Pizza();
    Console.WriteLine("Qual o sabor de pizza, calabresa 'C' , frango 'F' ?");
    var sabor = Console.ReadLine();
    Console.WriteLine($"O sabor escolhido foi {pizza.DefinirSabor(sabor)}");
    Console.WriteLine("Qual o tamanho da pizza, pequeno 'P', medio 'M', grande 'G'?");
    var tamanho = Console.ReadLine();
    Console.WriteLine($"O tamanho escolhido foi {pizza.DefinirTamanho(tamanho)}");
    pizzaDao.CriarPizza(pizza);
    var pizzas = pizzaDao.ObterPizzas();
    var infoPizzas = pizzaDao.ObterInformacoesPizzas(); // Chamar o método ObterInformacoesPizzas da instância de PizzaDao
    Console.WriteLine(infoPizzas);
    
    

    var cliente = new Cliente();
    Console.WriteLine("Digite seu nome:");
    var nome = Console.ReadLine();
    cliente.Nome = nome;
    clienteDao.CriarCliente(cliente);
    var clientes = clienteDao.ObterClientes();
    Console.WriteLine($"Cliente: {cliente}");

    var pedido = new Pedido();
    Console.WriteLine("Digite o código do cliente:");
    var ClienteId = Convert.ToInt32(Console.ReadLine());
    pedido.ClienteId = ClienteId;
    Console.WriteLine("Digite o código da pizza:");
    var PizzaId = Convert.ToInt32(Console.ReadLine());
    pedido.PizzaId = PizzaId;

    pedidoDao.CriarPedido(PizzaId, ClienteId); // Passando os IDs diretamente para o método

    var pedidos = pedidoDao.ObterPedidos();



    /* pedidoDao.CriarPedido(pizzas.Last(), clientes.Last());
    var pedidos = pedidoDao.ObterPedidos; */








    
    Console.WriteLine($"Sua pizza é: {pizza}");
    

}


Console.WriteLine("Fim");

