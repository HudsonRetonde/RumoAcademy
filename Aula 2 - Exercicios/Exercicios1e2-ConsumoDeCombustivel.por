programa
{
	
	funcao inicio()	
	{
		//*** Atividade 1 - Calcular o consumo de um carro ***
		
		//Variável que guarda a quantidade em litros de combustível do veículo:
		real quantidadeDeCombustivel

		//Variável que diz a quantidade de quilômetros percorridos:

		real quilometorsPercorridos

		escreva("\nDigite a quantidade em litros de combustível que continha no veículo: ")
		leia(quantidadeDeCombustivel)

		// Verifica se o usuário digitou corretamente um número que possibilite a execução do cálculo:
		se(quantidadeDeCombustivel <= 0 ) {
				escreva("Por gentileza, indormar um número maior que zero para a quantidade de litros de combustível que continha no veículo.")
				retorne				
		}

		escreva("\nDigite a quantidade de quilômetors percorridos pelo veículo: ")
		leia(quilometorsPercorridos)

		// Verifica se o usuário digitou corretamente um número que possibilite a execução do cálculo:
		se(quilometorsPercorridos <= 0 ) {
				escreva("Por gentileza, indormar um número maior que zero para representar a quantidade de quilômetros percorridos pelo veículo")
				retorne
		}		
		
		//Variável que efetua o cálcuo de consumo do veículo:
		real consumoDoVeiculo = quilometorsPercorridos / quantidadeDeCombustivel
		escreva("\nO consumo do seu veículo é " + consumoDoVeiculo + " KM/L.")
		escreva("\n")

		//*** Atividade 2 - Calcular a distancia máxima que um carro ou moto pode percorrer ao realizar o abastecimento de um veículo ***
		
		//Variável que efetua o cálculo de autonomia do veículo com base na quantidade de litros de combustível:
		real distanciaMaxima = quantidadeDeCombustivel * consumoDoVeiculo
		
		escreva("\nComo seu veículo possui " + quantidadeDeCombustivel + " litros de combustível, com consumo de " + consumoDoVeiculo + ".")
		escreva("\n")		
		escreva("\nLogo, você terá uma autonomia de " + distanciaMaxima + " quilômetos em circunstâncias normais de trânsito e de clima.")
		
	}

	
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 1100; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */