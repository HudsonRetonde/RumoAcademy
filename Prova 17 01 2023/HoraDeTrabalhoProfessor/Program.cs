using System.Globalization;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace HoraDeTrabalhoProfessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome;
            int nivel, horasTrabalhadas;
            double valorDiaDeTrabalho;

            Console.WriteLine("#########################################################");
            Console.WriteLine("###### PAGAMENTO POR DIA DE TRABALHO DO PROFESSOR #######");
            Console.WriteLine("#########################################################\n");

            Console.WriteLine("Por gentileza, digite o nome do(a) professora(a) em LETRAS MAIÚSCULAS: ");
            while (true)
            {
                nome = Console.ReadLine();
                if (ValidaNome(nome))
                {
                    Console.WriteLine("Nome válido\n");
                    break;

                }
                else
                {
                    Console.WriteLine("Nome inválido, digite novamente: \n");

                }
            }
            Console.WriteLine("Foram efetuadas quantas horas aula no dia? ");
            horasTrabalhadas = int.Parse(Console.ReadLine());
            Console.WriteLine("Por fim, digite o nível do(a) profissional, se é 1, 2 ou 3: ");
            nivel = int.Parse(Console.ReadLine());
            
            if (nivel == 1)
            {
                Console.WriteLine("O(a) professor(a) é de nível 1, sua hora aula é de R$ 12,00.\n");
                valorDiaDeTrabalho = horasTrabalhadas * 12;
                Console.WriteLine($"Como o(a) professor(a) {nome} é de nível 1 " +
                    $"e trabalhou {horasTrabalhadas}, " +
                    $"o valor total que receberá no dia é de R$ {valorDiaDeTrabalho.ToString("F2", CultureInfo.InvariantCulture)} .");
            }
            else if (nivel == 2)
            {
                Console.WriteLine("O(a) professor(a) é de nível 2, sua hora aula é de R$ 18,00.");
                valorDiaDeTrabalho = horasTrabalhadas * 18;
                Console.WriteLine($"Como o(a) professor(a) {nome} é de nível 2 " +
                    $"e trabalhou {horasTrabalhadas}, " +
                    $"o valor total que receberá no dia é de R$ {valorDiaDeTrabalho.ToString("F2", CultureInfo.InvariantCulture)} .");
            }
            else if (nivel == 3)
            {
                Console.WriteLine("O(a) professor(a) é de nível 3, sua hora aula é de R$ 25,00.");
                valorDiaDeTrabalho = horasTrabalhadas * 25;
                Console.WriteLine($"Como o(a) professor(a) {nome} é de nível 3 " +
                    $"e trabalhou {horasTrabalhadas}, " +
                    $"o valor total que receberá no dia é de R$ {valorDiaDeTrabalho.ToString("F2", CultureInfo.InvariantCulture)} .");
            }
            else
            {
                Console.WriteLine("Por gentileza, diga se o profisisonal é de nível 1, 2 ou 3.");
                Console.WriteLine("Reinicie o programa e, por gentileza, faça novamente.");
            }

        }
        public static bool ValidaNome(string nome)
        {
            if (nome is null or "")
            {
                return false;
            }
            if (!(nome.Length >= 3 && nome.Length <= 80))
            {
                return false;
            }
            string pattern = @"^[A-Z]*$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(nome);
        }
    }
}