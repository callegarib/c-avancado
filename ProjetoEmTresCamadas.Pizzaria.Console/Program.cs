using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio;

Console.WriteLine("Bem vindo a nossa pizzaria");
Console.WriteLine("Gostaria de uma pizza: S p/ sim e N para não");
var resposta = Console.ReadLine();
Console.WriteLine(resposta);

if(resposta == "S")
{
    var pizza = new Pizza();
    Console.WriteLine("Qual o sabor de pizza? Calabresa 'C', frango 'F'.");
    var sabor = Console.ReadLine();
    Console.WriteLine($"O sabor escolhido foi:{pizza.DefinirSabor(sabor)}");
    Console.WriteLine("Quak o tamanho da pizza, pequeno 'P', médio 'M', grande 'G'?");
    var tamanho = Console.ReadLine();
    Console.WriteLine($"O tamanho escolhido foi:{pizza.DefinirTamanho(tamanho)}");


}

Console.WriteLine("Fim");