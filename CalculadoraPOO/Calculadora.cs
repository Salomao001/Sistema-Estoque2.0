namespace CalculadoraPOO
{
    public class Calculadora
    {
        public Calculadora(double valor1, double valor2, char operador)
        {
            Valor1 = valor1;
            Valor2 = valor2;
            Operador = operador;
        }

        private double Valor1 { get; set; }
        private double Valor2 { get; set; }
        private char Operador { get; set; }

        public double Calculate()
        {
            switch (Operador.ToString().ToLower())
            {
                case "+": return Valor1 + Valor2;
                case "-": return Valor1 - Valor2;
                case "x": return Valor1 * Valor2;
                case "/": return Valor1 / Valor2;
                default: Environment.Exit(0); break;
            }
            return 0;
        }

        public void Show()
        {
            var calculo = Calculate();

            Console.WriteLine($"{Valor1} {Operador.ToString().ToLower()} {Valor2} = {calculo}");
        }

    }
}