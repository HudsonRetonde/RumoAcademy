programa
{
	
	funcao inicio()
	{

	 /*** 2. Faça um algoritmo que receba 15 números e exiba somente os positivos para o usuário 
	 FALTA ARRUMAR OS COMENTÁRIOS E VALIDAÇÕES***/
	 
		inteiro vetor[15]
		inteiro cont = 0

		enquanto(cont < 5){
			limpa()
			escreva("Por gentileza, digite o ", cont + 1,"° número: " )
			inteiro numero
			leia(numero)
			vetor[cont] = numero
			cont++

		}
		para (inteiro i=0; i < 15; i++)
		{
			se(vetor[i] > 0)
			{
				escreva("\nO número ", vetor[i] , " é positivo, logo foi impresso.\n" )
			}	
		}
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 354; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = funcao;
 */