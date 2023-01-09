programa
{
	inclua biblioteca Tipos
	funcao inicio()
	{
		/*1.    Faça um programa que calcula a média das notas de provas de uma turma.
		  André, tomei a liberdade de adcionar condições a título de treinamento para verificar se o aluno seria aprovado ou não.
		  */

		escreva("*** Programa que realiza a média das notas do aluno e diz se o mesmo foi aprovado ou não caso tenha média, pelo menos, igual a 7. ***")
		
		inteiro vet[5], soma = 0
		real media
		
		
		para(inteiro notas = 0; notas < 5; notas++  )
		{
			
			escreva("\nEscreva a ", notas + 1 , "° nota: ")
			leia(vet[notas])
			soma += vet[notas]
		}

		media = soma/5
		escreva("\nA média das notas é: " + media)

		se(media >= 7)
		{
			escreva("Aluno aprovado!")
		} senao {
			escreva("Aluno aprovado!")
		}
			
		
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 449; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */