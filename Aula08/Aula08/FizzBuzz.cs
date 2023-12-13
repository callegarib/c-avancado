using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Aula08
{
    public class ExerciciosFizzBuzz
    {
        static object lockObject = new object();
        static int currentNumber = 1;
        static int maxNumber = 100;
        public void ExecutarFizzBuzz()
        {
            Task fizzTask = Task.Run(Fizz);
            Task buzzTask = Task.Run(Buzz);
            Task fizzBuzzTask = Task.Run(FizzBuzz);

            Task.WaitAll(fizzTask, buzzTask, fizzBuzzTask);
        }

        // Substitui múltiplos de 3 por "Fizz"
        static void Fizz()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (currentNumber > maxNumber)
                        break;
                    if (currentNumber % 3 == 0 && currentNumber % 5 != 0)
                    {
                        Console.WriteLine("Fizz");
                        currentNumber++;
                    }
                }
                Thread.Sleep(10);
            }
        }

        // Substitui Múltiplos de 5 por "Buzz"
        static void Buzz()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (currentNumber > maxNumber)
                        break;
                    if (currentNumber % 5 == 0 && currentNumber % 3 != 0)
                    {
                        Console.WriteLine("Buzz");
                        currentNumber++;
                    }
                }
                Thread.Sleep(10);
            }
        }

        //Substitui Multíplos de 3 e 5 por "FizzBuzz"
        static void FizzBuzz()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (currentNumber > maxNumber)
                        break;
                    if (currentNumber % 3 == 0 && currentNumber % 5 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                        currentNumber++;
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
