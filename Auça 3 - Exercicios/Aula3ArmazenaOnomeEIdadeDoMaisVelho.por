programa
{
	/*** 3.    Faça um programa armazena o nome e idade (inteiro) de 10 pessoas, e mostra o mais velho para o usuário. ***
	FALTA VALIDAR
	**/
	funcao inicio()
	{			
		inteiro idade, maisVelho = 0
		cadeia nome, nomeDoMaisVelho =""

		para(inteiro cont = 1; cont < 11; cont++)
		{
			escreva("Digite o seu nome: ")
			leia(nome)
			escreva("Digite a ", cont , "° idade: ")
			leia(idade)
			
			se (cont ==1)
			{
				maisVelho = idade	
				nomeDoMaisVelho = nome			
			} senao {
				se(idade > maisVelho)
				{
					maisVelho = idade
					nomeDoMaisVelho = nome
				}
			}
		}

		escreva("\nO(a)" , nomeDoMaisVelho, " é o(a) mais velho(a) e possui ", maisVelho, " anos de idade.")
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 479; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */