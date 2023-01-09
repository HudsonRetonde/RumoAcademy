programa
{
	inclua biblioteca Tipos
	inclua biblioteca Matematica
	inclua biblioteca Texto
	funcao inicio()
	{		

		//*** 1. Faça um programa que leia o nome de um vendedor, o seu salário fixo e o total de vendas efetuadas por ele no mês (em dinheiro). 
		//Sabendo que este vendedor ganha 15% de comissão sobre suas vendas efetuadas, 
		//informar o seu nome, o salário fixo e salário final do mês. ***

		escreva("Seja bem-vindo ao programa Destrinchando Dados do(a) Vendedor(a). ")
		escreva("\n\nNele solicitaremos o nome completo, o salário fixo, o total de vendas efetuadas pelo(a) vendedor(a) no mês.")
		escreva("\n\nDepois calcularemos a sua comissão e o valor bruto recebido por ele(a).")
		escreva("\n\nPara iniciarmos, por gentileza, digite o nome do vendedor: ")

		//Variável que recebe o nome do vendedor
		cadeia nomeDoVendedor
		leia(nomeDoVendedor)	
			//André, fiquei feliz e logo fiquei triste rs Tentei procurar uma função que convertesse cadeia para número mas não consegui
			//Tinha feito desta forma e tinha dado certo, porém, se eu digitar mais de um "número" o programa aceita.
			//se(nomeDoVendedor == "0" ou nomeDoVendedor == "1" ou nomeDoVendedor == "2" ou nomeDoVendedor == "3" ou nomeDoVendedor == "4" ou nomeDoVendedor == "5" ou nomeDoVendedor == "6" ou nomeDoVendedor == "7" ou nomeDoVendedor == "8" ou nomeDoVendedor == "9") 
			//{
			//	escreva("Por favor, digite um nome e não um número. Execute o programa novamente para continuar...")
			//} 
			
		//Variável que recebe o nome do vendedor
		//Também não encontrei a função que "varresse" o array para tirar uma possível vírgula e colocasse um ponto no lugar de um número float.
		//Todavia, consegui fazer a validação conforme a aula de hoje.
		escreva("\nAgora digite o valor do seu salário fixo em R$ : ")
		cadeia salarioFixoString				
		leia(salarioFixoString)
		cadeia salarioFixoStringComOuSemVirgula = Texto.substituir(salarioFixoString, ",", ".")
			se(ValidarFormatarValores(salarioFixoStringComOuSemVirgula) < 0)
			{
				retorne
			}
		real salarioFixo = ValidarFormatarValores(salarioFixoStringComOuSemVirgula)
			

		escreva("\nPor fim, informe o total de vendas em R$ acumuladas no mês : ")
		cadeia quantidadeDeVendasNoMesString
		leia(quantidadeDeVendasNoMesString)
			se(ValidarFormatarValores(quantidadeDeVendasNoMesString) < 0)
			{
				retorne
			}
			
		real quantidadeDeVendasNoMes = ValidarFormatarValores(quantidadeDeVendasNoMesString)
	
		real comissao = quantidadeDeVendasNoMes * 0.15
		real comissaoFormatada = Matematica.arredondar(comissao, 2)
		escreva("\nA comissão do(a) vendedor(a) " + nomeDoVendedor + " é de R$:" + comissaoFormatada)
		
		real salarioBruto = salarioFixo + comissao
		real salarioBrutoFormatado = Matematica.arredondar(salarioBruto, 2)

		escreva("\n\nO valor total recebido pelo(a) vendedor(a) "+ nomeDoVendedor + " - salário fixo + comissão - é de R$:" + salarioBrutoFormatado)
				
	}	
	
	funcao real ValidarFormatarValores(cadeia valorString)
	{
		logico tipoReal = Tipos.cadeia_e_real(valorString)
		logico tipoNumero = Tipos.cadeia_e_inteiro(valorString, 10)
		se(tipoReal == falso e tipoNumero == falso){
			escreva("\nPor gentileza, insira um número válido e execute o programa novamente.")
			retorne -1.00
		}

		real resultadoFormatado = Tipos.cadeia_para_real(valorString)

		se(resultadoFormatado <= 0){
			escreva("\nPor gentileza, insira um número válido e execute o programa novamente.")
			retorne -1.00
		}
		
		retorne resultadoFormatado
	}	

} 
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 2343; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */