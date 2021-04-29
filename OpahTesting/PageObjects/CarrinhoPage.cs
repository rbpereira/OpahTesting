using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpahTesting.PageObjects
{
    public static class CarrinhoPage
    {
        public static By lblNomeProduto()
        {
            By obj = (By.XPath("//*[@id='cc-cart-item-0']/div[1]"));
            return obj;
        }

        public static By lblTotalPontos()
        {
            By obj = (By.XPath("//*[@id='cc-cart-item-0']/div[3]"));
            return obj;
        }


        public static By LnkRemover()
        {
            By obj = (By.XPath("//a[text()='Remover']"));
            return obj;
        }

        public static By LblNaoExisteItensNoCarrinho()
        {
            By obj = (By.XPath("//*[@id='CC-cart-empty']/div/h2"));
            return obj;
        }


    }
}
