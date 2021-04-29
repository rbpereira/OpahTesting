using OpenQA.Selenium;

namespace OpahTesting.PageObjects
{
    public static class ProdutoPage
    {
        public static By NomeProduto()
        {
            By obj = (By.XPath("//h2[@class='h2']"));
            return obj;
        }

        public static By Quantidadepontos()
        {
            By obj = (By.XPath("//*[@id='div-listPrice-02']/div/div/div/span[1]"));
            return obj;
        }

        public static By LblCodigoProduto()
        {
            By obj = (By.Id("span-productId"));
            return obj;
        }
        

        public static By TxtCep()
        {
            By obj = (By.Id("inpt-cep__pdp"));
            return obj;
        }

        public static By BtnBuscarCep()
        {
            By obj = (By.XPath("//span[.='Buscar']"));
            return obj;
        }

        public static By BtnAdicionarCarrinho()
        {
            By obj = (By.XPath("//*[@id='CC-prodDetails-addToCart']/button"));
            return obj;
        }
    }
}
