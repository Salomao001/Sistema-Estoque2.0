﻿using System.Threading;

namespace Cronometro
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 10m = 10 minutos");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar? ");

            string data = Console.ReadLine().ToLower();
            char tipo = char.Parse(data.Substring(data.Length - 1, 1));
            int tempo = int.Parse(data.Substring(0, data.Length - 1));
            int multiplicador = 1;

            if (tipo == 'm')
            {
                multiplicador = 60;
            }
            if (tempo == 0)
            {
                Environment.Exit(0);
            }

            PreInicio(tempo * multiplicador);
        }

        static void PreInicio(int tempo)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Go...");
            Thread.Sleep(1000);

            Inicio(tempo);
        }
        static void Inicio(int tempo)
        {
            int tempoAtual = 0;

            while (tempoAtual != tempo)
            {
                Console.Clear();
                tempoAtual++;
                Console.WriteLine(tempoAtual);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Cronometro finalizado");
            Thread.Sleep(2000);

            Menu();
        }
    }
}