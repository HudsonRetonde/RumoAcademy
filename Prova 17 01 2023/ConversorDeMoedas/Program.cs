using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace ConversorDeMoedas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double real, convertDolar, convertEuro, convertPesoArgentino, convertBathTailandes;

            Console.WriteLine("#########################################");
            Console.WriteLine("########## CONVERSOR DE MOEDAS ##########");
            Console.WriteLine("#########################################\n");
            Console.WriteLine("Olá, insira o valor em real que deseja converter: ");
            while (!double.TryParse(Console.ReadLine(), out real))
            {
                Console.WriteLine("Por gentileza, insira apenas números");
            }

            convertDolar = real * 5.10;
            convertEuro = real * 5.50;
            convertPesoArgentino = real * 0.028;
            convertBathTailandes = real * 0.15;

            Console.WriteLine($"O valor digitado em R$ {real.ToString("F2")} vale \n" +
                $"US$ {convertDolar.ToString("F2")} Dólares, \n" +
                $"€ {convertEuro.ToString("F2")} Euros, \n" +
                $"$ {convertPesoArgentino.ToString("F2")} Pesos Argentino e \n" +
                $"฿ {convertBathTailandes.ToString("F2")} Baths Tailandês.\n");
            Console.ReadKey();
        }
    }
}