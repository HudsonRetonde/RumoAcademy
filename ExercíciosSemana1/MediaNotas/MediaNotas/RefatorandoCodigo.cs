using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNotas
{    
    internal class RefatorandoCodigo
    {
        private string NomeAluno { get; set; }
        private int QuantidadeDeNotas { get; set; }
        private double Soma { get; set; }
        private double Media { get; set; }
        public void Executar()
        {
            try
            {
                Cabecalho();
                RecebeInformacoes();
                Relatorio();

            }
            catch (FormatException)
            {
                Console.WriteLine("Para realizar o cálculo é necessário a inserção de números e não letras! ");
                Console.WriteLine("");
                Console.WriteLine("******* Por gentileza, reinicie o programa. *******");
                Console.WriteLine("");
            }

            catch (OverflowException)
            {
                Console.WriteLine("Para realizar o cálculo é necessário a inserção de números e não letras!");
                Console.WriteLine("******* Por gentileza, reinicie o programa. *******");
                Console.WriteLine("");
            }
        }

        private void Cabecalho()
        {
            Console.WriteLine("#########################################################");
            Console.WriteLine("############### MÉDIA DE NOTAS DOS ALUNOS ###############");
            Console.WriteLine("#########################################################");
            Console.WriteLine("");
        }
        private void RecebeInformacoes()
        {
            Console.WriteLine("Qual o nome do(a) aluno(a): ");
            NomeAluno = Console.ReadLine();

            Soma = 0.00;


            Console.WriteLine("Você quer fazer a média de quantas notas? ");
            QuantidadeDeNotas = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double[] vetNotas;
            vetNotas = new double[QuantidadeDeNotas];

            for (int notas = 0; notas < QuantidadeDeNotas; notas++)
            {
                Console.WriteLine($"Escreva a {notas + 1} ° nota: ");
                vetNotas[notas] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (vetNotas[notas] < 0)
                {
                    Console.WriteLine("Insira um valor que não seja negativo para a devida execução do programa.");
                    Console.WriteLine("");
                    Console.WriteLine("Reinicie para executar da forma correta.");
                    Console.WriteLine("");
                }

                Soma += vetNotas[notas];
            }
            Media = Soma / QuantidadeDeNotas;
        }
       
        private void Relatorio()
        {
            
            Console.WriteLine($"A soma das {QuantidadeDeNotas} notas é igual a {Soma.ToString("F2", CultureInfo.InvariantCulture)}.");
            Console.WriteLine($"Portanto, a média total do(a) aluno(a) {NomeAluno} é de {Media.ToString("F2", CultureInfo.InvariantCulture)}. ");
            if(Media >= 7)
            {
                Console.WriteLine($"O(a) {NomeAluno} obteve a média de {Media.ToString("F2", CultureInfo.InvariantCulture)}. Logo, foi aprovado(a). Parabéns!  ");
            } else
            {
                Console.WriteLine($"Infelizmente o(a) {NomeAluno} obteve a média de {Media.ToString("F2", CultureInfo.InvariantCulture)}. Assim, infelizmente, foi reprovado(a).");
            }
            Console.ReadKey();
        }
    }
}
