using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Suponha que você esteja desenvolvendo um sistema de gerenciamento de funcionários, e você deseja calcular o valor do INSS com base no salário de cada funcionário.
//Crie um programa que utilize um delegate para calcular o INSS para diferentes tipos de faixa.
//As alíquotas inss são de 7,5% para aqueles que ganham até R$ 1.320,00;
//De 9% para quem ganha entre R$ 1.320,01 até R$2.571,29;
//De 12% para os que ganham entre R$ 2.571,30 até R$ 3.856,94;
//E de 14% para quem ganha de R$ 3.856,95 até R$ 7.507,29.

//01 - Crie uma implementação usando um método para o delegate
//02 - Resolve com o uso do lambda
// Considere a seguinte assinatura para o delegate: public delegate double CalcularInss(double salario);

namespace Aula08;
public class CalculoINSS {

    public delegate double CalcularInss(double salario);
    public void Executar()
    {
        Console.WriteLine("Entre com o seu salãrio:");
        var salario = Convert.ToDouble(Console.ReadLine());
        CalcularInss calcularINSS;
        if (salario <= 1320)
        {
            calcularINSS = CalcularFaixa1;
        }
        else if (salario > 1320 && salario <= 2571.29)
        {
            calcularINSS = CalcularFaixa2;
        }
        else if (salario > 2571.30 && salario <= 3856.94)
        {
            calcularINSS = CalcularFaixa3;
        }
        else
        {
            calcularINSS = CalcularFaixa4;
        }

        Console.WriteLine(calcularINSS(salario));

    }
    public static double CalcularFaixa1(double salario)
    {
        return salario * 0.075; // 7.5%
    }

    public static double CalcularFaixa2(double salario)
    {
        return salario * 0.09; // 9%
    }

    public static double CalcularFaixa3(double salario)
    {
        return salario * 0.12; // 12%
    }

    public static double CalcularFaixa4(double salario)
    {
        return salario * 0.14; // 14%
    }

}
