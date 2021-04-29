Funcionalidade: Cadastrar produtos no carrinho
	Como futuro cliente da Livelo
	Quero poder adicionar produtos no carrinho
	De modo que possa usufruir após meus acessos.

Esquema do Cenario: Adicionar produtos no carrinho
	Dado Que eu pesquiso o item <item>
	Quando selecionar um produto
	Entao Será possivel adicionar esse produto ao carrinho
Exemplos: 
| item                  |
| Televisão             |
| Celulares e Telefonia |
| Eletrodomesticos      |



Esquema do Cenario: Remover produto do carrinho
	Dado Que eu tenho o item <item> no carrinho
	Quando remover esse item
	Entao o carrinho ficará vazio e exibe a mensagem <mensagem>
Exemplos: 
| item      | mensagem                                |
| Televisão | Ainda não existem itens no seu carrinho |
