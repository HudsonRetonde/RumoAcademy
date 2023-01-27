using System.Text.RegularExpressions;

namespace CategoriaNadador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int idade;
            string nome;
            Console.WriteLine("#########################################################");
            Console.WriteLine("################# CATEGORIA DO NADADOR ##################");
            Console.WriteLine("#########################################################\n");

            Console.WriteLine("Por gentileza, digite o nome do nadador em LETRAS MAIÚSCULAS: ");
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
           
            Console.WriteLine("Por gentileza, digite a idade do atleta: ");
            while (!int.TryParse(Console.ReadLine(), out idade))
            {
                Console.WriteLine("Por gentileza, insira números inteiros");
            }


            if (idade == 5 || idade <= 7)
            {
                Console.WriteLine($"O nadador {nome}, possui {idade} anos, logo, nadará na categoria Infantil A = 5 - 7 anos.");
            } 
            else if (idade == 8 || idade <= 10)
            {
                Console.WriteLine($"O nadador {nome}, possui {idade} anos, logo, nadará na categoria de Infantil B = 8 - 10 anos.");
            }
            else if (idade == 11 || idade <= 13)
            {
                Console.WriteLine($"O nadador {nome}, possui {idade} anos, logo, nadará na categoria de Juvenil A = 11 - 13 anos.");
            }
            else if (idade == 14 || idade <= 17)
            {
                Console.WriteLine($"O nadador {nome}, possui {idade} anos, logo, nadará na categoria de Juvenil B = 14 - 17 anos.");
            }
            else if (idade == 18 || idade <= 25)
            {
                Console.WriteLine($"O nadador {nome}, possui {idade} anos, logo, nadará na categoria de Sênior = 18 - 25 anos.");
            }
            else
            {
                Console.WriteLine("Infelizmente o atleta não poderá concorrer ao campeonato" +
                    " me nenhuma das catecorias, pois só é possível para os atletas de 5 até 25 anos " +
                    "" +
                    "em suas respectivas categorias.");
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