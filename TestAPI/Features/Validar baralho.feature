Funcionalidade: Validar baralho
	Como jogador de baralho
	Quero poder validar meu Deck de cartas
	De modo que possa usufruir durante meus jogos.


Cenario: Validar baralho
	Dado que eu envie requisição para embaralhar o baralho
	Quando eu pegar o retorno da requisição de embaralhar e fizer a requisição de tirar cartas 
	Então então terei as cartas para jogar

Cenario: Validar requisição passando id invalido
	Dado que eu envie requisição para embaralhar o baralho
	Quando eu fizer uma requisição para retirar as cartas passando id alr5rb15tg 
	Então então terei as cartas para jogar