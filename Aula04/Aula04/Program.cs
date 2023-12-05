
using Aula04;
using System;
using System.IO;
using System.Collections.Generic;

ExemploTimeSpan exemploTimeSpan = new ExemploTimeSpan();

exemploTimeSpan.ShowTimeSpan();


ExemploFile exemploFile = new ExemploFile();

string caminhoDoArquivo = $@"{AppDomain.CurrentDomain.BaseDirectory}\meuarquivo.txt";

exemploFile.CriarArquivo(caminhoDoArquivo);

exemploFile.EscreverEmArquivo("olá arquivo em c#", caminhoDoArquivo);

string conteudoArquivo = exemploFile.LerArquivo(caminhoDoArquivo);

ExemploDirectory exemploDirectory = new ExemploDirectory();
string[] arquivosDaminhaPasta = exemploDirectory.TrazerTodosOsArquivos("C:\\");

Console.ReadKey();

// EXERCÍCIOS
//1 Pergunte o nome de quem está digitando
//2 Pergunte como ela está
//3 Grave as respostas em arquivo dividindo em datas
//4 O nome do arquivo deve ser no formato “como_esta_vc_DD_MM_YYYY_hh_mm_ss.txt

    Console.WriteLine("Digite seu nome: ");
    string nome = Console.ReadLine();

    Console.WriteLine("Como você está?");
    string status = Console.ReadLine();

    // Obter a data e hora atual
    DateTime dataAtual = DateTime.Now;

    // Formatar a data e hora atual para o formato desejado
    string dataFormatada = dataAtual.ToString("dd_MM_yyyy_HH_mm_ss");

    // Criar o nome do arquivo com base na data e hora atual
    string nomeArquivo = $"como_esta_vc_{dataFormatada}.txt";

    // Caminho onde o arquivo será salvo
    string diretorio = Environment.CurrentDirectory;

    // Combinar o caminho e o nome do arquivo
    string caminhoCompleto = Path.Combine(diretorio, nomeArquivo);

    // Escrever as respostas no arquivo
    using (StreamWriter arquivo = File.AppendText(caminhoCompleto))
    {
        arquivo.WriteLine($"Nome: {nome}");
        arquivo.WriteLine($"Status: {status}");
        arquivo.WriteLine(); // Adiciona uma linha em branco para separar entradas de diferentes usuários
    }

    Console.WriteLine("Suas respostas foram salvas no arquivo.");

//Escreva outro programa que leia o arquivo feito no primeiro programa e tenha a seguintes regras:
//1 Mostrar os nomes
//2 Busque as respostas por data
//3 Busque as respostas por nome


    Console.WriteLine("Lendo arquivo...");

    // Solicita o nome do arquivo ao usuário
    Console.WriteLine("Digite o nome do arquivo a ser lido:");
    string nomeArquivoNovo = Console.ReadLine();

    // Verifica se o arquivo existe
    if (File.Exists(nomeArquivoNovo))
    {
        // Lê todas as linhas do arquivo
        string[] linhas = File.ReadAllLines(nomeArquivoNovo);

        // Lista para armazenar as respostas
        List<string[]> respostas = new List<string[]>();
        List<string> nomes = new List<string>();

        // Variável para armazenar a data do registro
        string dataRegistro = "";

        foreach (string linha in linhas)
        {
            if (linha.StartsWith("Nome:"))
            {
                string nomeUsuario = linha.Substring(6).Trim();
                nomes.Add(nomeUsuario);
            }
            else if (linha.StartsWith("Status:"))
            {
                string statusUsuario = linha.Substring(8).Trim();
                respostas.Add(new string[] { dataRegistro, statusUsuario });
            }
            else if (linha.Length > 0 && DateTime.TryParseExact(linha, "dd_MM_yyyy_HH_mm_ss", null, System.Globalization.DateTimeStyles.None, out _))
            {
                dataRegistro = linha;
            }
        }

        // Mostrar os nomes
        Console.WriteLine("Nomes registrados:");
        foreach (string nomeUsuario in nomes)
        {
            Console.WriteLine(nomeUsuario);
        }

        // Buscar respostas por data
        Console.WriteLine("\nDigite a data (no formato dd_MM_yyyy_HH_mm_ss) para buscar as respostas:");
        string dataParaBuscar = Console.ReadLine();

        Console.WriteLine($"\nRespostas registradas em {dataParaBuscar}:");
        foreach (var resposta in respostas)
        {
            if (resposta[0] == dataParaBuscar)
            {
                Console.WriteLine(resposta[1]);
            }
        }

        // Buscar respostas por nome
        Console.WriteLine("\nDigite o nome para buscar as respostas:");
        string nomeParaBuscar = Console.ReadLine();

        Console.WriteLine($"\nRespostas registradas para {nomeParaBuscar}:");
        for (int i = 0; i < nomes.Count; i++)
        {
            if (nomes[i] == nomeParaBuscar)
            {
                Console.WriteLine(respostas[i][1]);
            }
        }
    }
    else
    {
        Console.WriteLine("O arquivo especificado não foi encontrado.");
    }

