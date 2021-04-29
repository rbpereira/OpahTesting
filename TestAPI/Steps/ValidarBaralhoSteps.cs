using RestSharp;
using System;
using System.Text.Json;
using TechTalk.SpecFlow;
using TestAPI.utils;
using Xunit;

namespace TestAPI.Steps
{
    [Binding]
    public class ValidarBaralhoSteps
    {
        public class responseJson
        {
            public bool success { get; set; }
            public String deck_id { get; set; }
            public int remaining { get; set; }
            public bool shuffled { get; set; }
        }

        public string deck_id;
        IRestResponse responsePost;
        IRestResponse responseGet;

        [Given(@"que eu envie requisição para embaralhar o baralho")]
        public void DadoQueEuEnvieRequisicaoParaEmbaralharOBaralho()
        {

            string urlGet = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";

            responseGet = Functions.SendApi(urlGet, "Get");

            var jsonSerializer = JsonSerializer.Deserialize<responseJson>(responseGet.Content);
            deck_id = jsonSerializer.deck_id;
            Assert.Equal("OK", responseGet.StatusCode.ToString());

        }
       
        [When(@"eu pegar o retorno da requisição de embaralhar e fizer a requisição de tirar cartas")]
        public void QuandoEuPegarORetornoDaRequisicaoDeEmbaralharEFizerARequisicaoDeTirarCartas()
        {
            string urlPost = "https://deckofcardsapi.com/api/deck/" + deck_id + "/draw/?count=2";

            responsePost = Functions.SendApi(urlPost, "Post");
        }

        [When(@"eu fizer uma requisição para retirar as cartas passando id (.*)")]
        public void QuandoEuFizerUmaRequisicaoParaRetirarAsCartasPassandoIdAlrrbtg(String Id)
        {
            string urlPost = "https://deckofcardsapi.com/api/deck/" + Id + "/draw/?count=2";

            responsePost = Functions.SendApi(urlPost, "Post");
        }


        [Then(@"então terei as cartas para jogar")]
        public void EntaoEntaoTereiAsCartasParaJogar()
        {
            Assert.Equal("OK", responsePost.StatusCode.ToString());
        }
    }
}
