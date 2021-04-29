using OpahTesting.PageObjects;
using OpahTesting.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace OpahTesting.Steps
{
    [Binding]
    public class CadastrarProdutosNoCarrinhoSteps
    {
        public string tipoproduto;
        public string quantidadepontos;
        public string codigoproduto;
        public string nomeproduto;

        [Given(@"Que eu pesquiso o item (.*)")]
        public void DadoQueEuPesquisoOItem(string Item)
        {
            tipoproduto = Item;

            //Funcionalidades.EsperarObjetoCarregar(HomePage.BtnClose());
            //Funcionalidades.Clicar(HomePage.BtnClose());
            Funcionalidades.EsperarObjetoCarregar(HomePage.BtnAutorizar());
            Funcionalidades.Clicar(HomePage.BtnAutorizar());
            Funcionalidades.EsperarObjetoCarregar(HomePage.TxtOqueVoceEstaProcurando());
            Funcionalidades.EnviarTexto(Item, HomePage.TxtOqueVoceEstaProcurando());
            Funcionalidades.Clicar(HomePage.BtnSearch());
            Funcionalidades.ObjetoEstaVisivel(HomePage.Loading());
        }

        [When(@"selecionar um produto")]
        public void QuandoSelecionarUmProduto()
        {
            Funcionalidades.ObjetoEstaVisivel(HomePage.Loading());
            Funcionalidades.EsperarObjetoCarregar(HomePage.Produto());
            Funcionalidades.Clicar(HomePage.Produto());
            Funcionalidades.ObjetoEstaVisivel(HomePage.Loading());
            Funcionalidades.EsperarObjetoCarregar(ProdutoPage.LblCodigoProduto());
            codigoproduto = Funcionalidades.CapturarTexto(ProdutoPage.LblCodigoProduto());
            nomeproduto = Funcionalidades.CapturarTexto(ProdutoPage.NomeProduto());


            if (tipoproduto.ToUpper().Contains("TELEFONIA"))
            {
                Functions.SelecionarCor();
            }
            else
            {
                Functions.SelecionarVoltagem();
            }

            Funcionalidades.EnviarTexto("04546000", ProdutoPage.TxtCep());
            Funcionalidades.Clicar(ProdutoPage.BtnBuscarCep());

            
            quantidadepontos = Funcionalidades.CapturarTexto(ProdutoPage.Quantidadepontos());

            Funcionalidades.Clicar(ProdutoPage.BtnAdicionarCarrinho());
        }

        [Then(@"Será possivel adicionar esse produto ao carrinho")]
        public void EntaoSeraPossivelAdicionarEsseProdutoAoCarrinho()
        {
            Funcionalidades.ObjetoEstaVisivel(HomePage.Loading());
            Funcionalidades.EsperarObjetoCarregar(CarrinhoPage.lblNomeProduto());

            string NomeProduto = Funcionalidades.CapturarTexto(CarrinhoPage.lblNomeProduto())[10..];
            string ValorTotal = Funcionalidades.CapturarTexto(CarrinhoPage.lblTotalPontos());

            //Assert.Contains(nomeproduto.ToLower(), NomeProduto.ToLower());
            Assert.Contains(quantidadepontos.ToLower(), ValorTotal.ToLower());


        }


        [Given(@"Que eu tenho o item (.*) no carrinho")]
        public void DadoQueEuTenhoOItemTelevisaoNoCarrinho(string Item)
        {
            DadoQueEuPesquisoOItem(Item);
            QuandoSelecionarUmProduto();
        }

        [When(@"remover esse item")]
        public void QuandoRemoverEsseItem()
        {
            Funcionalidades.EsperarObjetoCarregar(CarrinhoPage.LnkRemover());
            Funcionalidades.Clicar(CarrinhoPage.LnkRemover());
        }

        [Then(@"o carrinho ficará vazio e exibe a mensagem (.*)")]
        public void EntaoOCarrinhoFicaraVazioEExibeAMensagem(string mensagem)
        {
            string msg = Funcionalidades.CapturarTexto(CarrinhoPage.LblNaoExisteItensNoCarrinho());
            Assert.Equal(mensagem.ToLower(), msg.ToLower());
        }

    }



}


