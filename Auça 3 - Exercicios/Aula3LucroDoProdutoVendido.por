programa
{
	
	funcao inicio()
	{
		real lucroProdutoUm = 0.0, lucroProdutoDois = 0.0, lucroProdutoTres = 0.0, lucroTotal
		cadeia produtos[3] = {"mouse", "teclado", "monitor"}
		real valores[3][3] = { {5.00, 10.00, 20.00},
						   {3.00, 15.00, 23.00},
						   {1.00, 700.00, 1200.00}}
		

						   para(inteiro l = 0; l <3;  l++){
						   	lucroProdutoUm = 0.0
						   	lucroProdutoDois = 0.0
						   	lucroProdutoTres = 0.0	
						   	para(inteiro c = 0; c <3;  c++){
						   		lucroProdutoUm =   (valores[0][2] - valores[0][1]) * valores[0][0]
						   		lucroProdutoDois = (valores[1][2] - valores[1][1]) * valores[1][0]
						   		lucroProdutoTres = (valores[2][2] - valores[2][1]) * valores[2][0]
						   	}

						   	
						   }
						lucroTotal = lucroProdutoUm + lucroProdutoDois + lucroProdutoTres
 
		escreva("O produto ",produtos[0] , " vendeu a quantidade de " ,valores[0][0] ," unidades com o preço de compra de R$: ",valores[0][1], " e o preço de venda de R$: ",valores[0][2], ".\n")
		escreva("O produto ",produtos[1] , " vendeu a quantidade de " ,valores[1][0] ," unidades com o preço de compra de R$: ",valores[1][1], " e o preço de venda de R$: ",valores[1][2], ".\n")
		escreva("O produto ",produtos[2] , " vendeu a quantidade de " ,valores[2][0] ," unidades com o preço de compra de R$: ",valores[2][1], " e o preço de venda de R$: ",valores[2][2], ".\n\n")
						
		escreva("O lucro do produto ", produtos[0]," foi de R$: ",lucroProdutoUm, " .\n")
		escreva("O lucro do produto ", produtos[1]," foi de R$: ",lucroProdutoDois, " .\n")
		escreva("O lucro do produto ", produtos[2]," foi de R$: ",lucroProdutoTres, " .\n")
		escreva("O lucro total, somando todos os produtos foi de R$: ", lucroTotal," ." )
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 732; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = {lucroProdutoUm, 6, 7, 14}-{lucroProdutoDois, 6, 29, 16}-{lucroProdutoTres, 6, 53, 16}-{valores, 8, 7, 7};
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */