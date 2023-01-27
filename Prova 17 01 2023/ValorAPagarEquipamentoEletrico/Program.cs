using System.Globalization;
namespace ValorAPagarEquipamentoEletrico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double kWh, kW, precoKW, valorASerPago;
            int potencia, horasDia, diasMes;
            Console.WriteLine("#######################################################################");
            Console.WriteLine("###### VALOR A SER PAGO AO FINAL DO MÊS DO EQUIPAMENTO ELÉTRICO #######");
            Console.WriteLine("#######################################################################\n");

            Console.WriteLine("Qual o preço do Kilo Watt da energia?");

            while (!double.TryParse(Console.ReadLine(), out precoKW))
            {
                Console.WriteLine("Por gentileza, insira apenas números");
            }

            Console.WriteLine("Qual a potência em Watts do dispositivo?");
            while (!int.TryParse(Console.ReadLine(), out potencia))
            {
                Console.WriteLine("Por gentileza, insira números inteiros");
            }

            Console.WriteLine("Quantas horas o dispositivo fica ligado por dia?");
            while (!int.TryParse(Console.ReadLine(), out horasDia))
            {
                Console.WriteLine("Por gentileza, insira números inteiros");
            }

            Console.WriteLine("Quantos dias o dispositivo fica em funcionamento por mês?");
            while (!int.TryParse(Console.ReadLine(), out diasMes))
            {
                Console.WriteLine("Por gentileza, insira números inteiros");
            }

            kWh = horasDia * diasMes;

            kW = (potencia * kWh) / 1000;

            valorASerPago = precoKW * kW;

            Console.WriteLine($"Como o preço do Kilo Watt é de R$ {precoKW.ToString("F2")}, \n" +
                $"seu dispositivo tem a potência de {potencia} Watts, \n" +
                $"fica em uso por {horasDia} horas por dia e {diasMes} dias por mês, \n" +
                $"ele gastou {kW.ToString("F2")} kWh e o valor total a ser pago é de R$ {valorASerPago.ToString("F2")}.");
        }


    }
}