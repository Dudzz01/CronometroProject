using System;
using System.Threading;

namespace CronometroProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            char option = 'a'; // valor default

            while (option != 'e')
            {
                Console.WriteLine("Observe as opcoes abaixo!\n");
                Console.WriteLine("Para selecionar o cronometro em segundos, digite por exemplo: 10s ");
                Console.WriteLine("Para selecionar o cronometro em minutos, digite por exemplo: 10m ");
                Console.WriteLine("Para sair do programa, digite: E\n");

                string data = Console.ReadLine().ToLower(); // vai ler a string e colocar tudo em letra minuscula

                if (data.Contains('.'))
                {
                    data = data.Replace('.', ',');
                }

                string dataValue = data.Substring(0, data.Length - 1); //vai pegar todo o valor menos o ultimo caracter( que é a letra), ou seja, é o valor time em forma de string
                float timeStop = float.Parse(dataValue); // conversao do valor time para float
                option = char.Parse(data.Substring(data.Length - 1, 1)); // converte string em char, e utiliza o metodo substring que basicamente cria uma outra string a partir da reparticao da string original (pega o sufixo s de Segundos ou m de Minutos)

                switch (option)
                {
                    case 's':
                        RunCronometro(timeStop, option);
                        break;
                    case 'm':
                        RunCronometro(timeStop, option);
                        break;
                    case 'e':
                        Console.WriteLine("Encerrando o cronometro...");

                        break;
                    default:
                        Console.WriteLine("\nComando inválido, tente novamente.\n");
                        break;
                }

            }

        }

        public static void RunCronometro(float timeStop, char sufix)
        {
            float currentSeconds = 0;
            float currentMinutes = 0;
            float auxMinutes = 0;
            float auxSeconds = 0;

            System.Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            System.Console.WriteLine("Go...");
            Thread.Sleep(1000);

            #region CronometroInSeconds

            if (sufix == 's')
            {
                while (currentSeconds < timeStop)
                {
                    Console.Clear();
                    System.Console.WriteLine("time stop: " + timeStop);
                    currentSeconds++;
                    System.Console.WriteLine("Time current: " + currentSeconds + sufix);
                    Thread.Sleep(1000); //1000 milliseconds = 1 second, this function stop the execution by x seconds (depends of the value that you put in the parametrer, in this case is 1 second), and after this time, the program run normally
                }
                return;
            }
            #endregion
            #region CronometroInMinutes
            while (auxSeconds < timeStop * 60)
            {
                Console.Clear();
                currentSeconds++;
                auxMinutes++;
                auxSeconds++;
                System.Console.WriteLine("time stop: " + timeStop);
                System.Console.WriteLine("Aux seconds: " + auxSeconds);
                if (auxMinutes >= 60)
                {
                    currentMinutes++;
                    currentSeconds = 0;
                    auxMinutes = 0;
                }
                System.Console.WriteLine($"Time current: {currentMinutes}{sufix} {currentSeconds}s");
                Thread.Sleep(1000); //1000 milliseconds = 1 second, this function stop the execution by x seconds (depends of the value that you put in the parametrer, in this case is 1 second), and after this time, the program run normally
            }
            #endregion

        }
    }
}
