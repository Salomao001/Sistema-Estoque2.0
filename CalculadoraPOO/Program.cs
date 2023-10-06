using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace CalculadoraPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Digite o primeiro valor: ");
            var valor1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite o segundo valor: ");
            var valor2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Qual operação (+ - x /): ");
            var operador = Convert.ToChar(Console.ReadLine());

            var calculo = new Calculadora(valor1, valor2, operador);
            calculo.Show();

        }
    }
}