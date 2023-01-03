programa
{
	
	funcao inicio()
	{
		//Variável que guarda a quantidade em litros de combustível do veículo:
		real quantidadeDeCombustivel

		//Variável que diz a quantidade de quilômetros percorridos:

		real quilometorsPercorridos

		escreva("/nDigite a quantidade em litros de combustível que continha no veículo: ")
		leia(quantidadeDeCombustivel)

		se(quantidadeDeCombustivel <= 0 ) {
				escreva("Por gentileza, indormar um número maior que zero para a quantidade de litros de combustível que continha no veículo.")
		}

		escreva("/nDigite a quantidade de qyulômetors percorridos pelo veículo: ")
		leia(quilometorsPercorridos)

		se(quilometorsPercorridos <= 0 ) {
				escreva("Por gentileza, indormar um número maior que zero para representar a quantidade de quilômetros percorridos pelo veículo")
		}		
		
		 
		real consumoDoVeiculo = quilometorsPercorridos / quantidadeDeCombustivel
		escreva("O consumo do seu veículo é " + consumoDoVeiculo + " MK/L.")
		  
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 982; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */