using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Aula08.CalculoINSS;

namespace Aula08
{
    public class CalculoINSS_Lambda
    {
        public delegate double CalcularInss(double salario);
        public void Executar()
        {
            Console.WriteLine("Entre com o seu salário:");
            var salario = Convert.ToDouble(Console.ReadLine());

            CalcularInss calcularINSS = salario switch
            {
                var s when s <= 1320 => (s) => s * 0.075, // 7.5%
                var s when s > 1320 && s <= 2571.29 => (s) => s * 0.09, // 9%
                var s when s > 2571.29 && s <= 3856.94 => (s) => s * 0.12, // 12%
                var s when s > 3856.94 && s <= 7507.29 => (s) => s * 0.14, // 14%
                _ => throw new ArgumentOutOfRangeException("Salário fora das faixas de cálculo do INSS"),
            };

            Console.WriteLine(calcularINSS(salario));
        }
    }
}
