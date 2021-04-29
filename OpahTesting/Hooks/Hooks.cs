using OpahTesting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace OpahTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            string url = "https://www.livelo.com.br/home";
            Funcionalidades.Inicializar(url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Funcionalidades.FecharBrowser();
        }
    }
}
