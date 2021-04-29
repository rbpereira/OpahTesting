using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using Xunit;

namespace OpahTesting.Utils
{
        public class Funcionalidades
        {
            /*****TIPOS DE LOCATORS ******
            *   id                       *
            *   Name                     *
            *   Linktext                 *
            *   Partial Linktext         *
            *   Tag Name                 *
            *   Class Name               *
            *   Css                      *
            *   Xpath                    *
            ****************************/

            //public static AppiumDriver<AppiumWebElement> Driver { get; set; }
            public static IWebDriver Driver { get; set; }
            public static string BrowserConfig = "CHROME";
           

            
            //Inicialização do driver
            public static void Inicializar(string url)
            {
                if (Driver == null)
                {
                            //switch (browser.ToUpper())
                            switch (BrowserConfig.ToUpper())
                            {
                                case "CHROME":
                                    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                                    break;
                                case "FIREFOX":
                                    //Driver = new FirefoxDriver();
                                    break;
                                case "IE":
                                    //Driver = new InternetExplorerDriver();
                                    break;
                                case "EDGE":
                                    //Driver = new EdgeDriver();
                                    break;
                                default:
                                    //Driver = new ChromeDriver();
                                    break;
                            }

                Driver.Manage().Window.Maximize();
                Driver.Url = url;
            }
                else
                {
                Driver.Manage().Window.Maximize();
                Driver.Url = url;
                }
            }

            //Fechar o Browser
            public static void FecharBrowser()
            {
                if (Driver != null)
                {
                    Driver.Quit();
                    Driver.Dispose();
                    Driver = null;
                }
            }

            //Clicar em um objeto
            public static void Clicar(By Locator)
            {
                Driver.FindElement(Locator).Click();
            }


            //Enviar texto para um objeto
            public static void EnviarTexto(string Text, By Locator)
            {
                if (!Locator.ToString().Contains("body"))
                {
                    Driver.FindElement(Locator).Clear();
                }
                Driver.FindElement(Locator).SendKeys(Text);
            }

            //Capturar o texto de um objeto
            public static string CapturarTexto(By Locator)
            {
                string ObjectText = Driver.FindElement(Locator).Text.ToString();
                return ObjectText;
            }

            //Capturar o texto de um objeto
            public static string SelecionarOpcaoPorTexto(By Locator)
            {
                string ObjectText = Driver.FindElement(Locator).Text.ToString();
                return ObjectText;
            }

            //Comparar textos
            public static void CompararTexto(string TextoEsperado, string TextoAtual)
            {
                Assert.Equal(TextoEsperado, TextoAtual);
            }

            //Comparar textos
            public static void ObjetoContemTexto(string TextoEsperado, string TextoAtual)
            {
                Assert.True(TextoAtual.Contains(TextoEsperado));
            }

            //Selecionar uma opção dentro de um option
            public static void SelecionarOpcao(string OptionText, By Locator)
            {
                // select the drop down list
                var Object = Driver.FindElement(Locator);
                //create select element object 
                var selectElement = new SelectElement(Object);
                // select by text
                selectElement.SelectByText(OptionText);
            }

            //Tirar print da tela
            public static void PrintScreen()
            {
                //Take the screenshot
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                //Save the screenshot
                CriarNovaPasta(ConfigurationManager.AppSettings["EnderecoPrint"].ToString());

                var tempFileName = Path.Combine(ConfigurationManager.AppSettings["EnderecoPrint"].ToString(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }

            //Apagar informações em campos
            public static void LimparCampo(By Locator)
            {
                Driver.FindElement(Locator).Clear();
            }

            //Verifica se o objeto está visivel
            public static bool ObjetoEstaVisivel(By Locator)
            {
                bool status = Driver.FindElement(Locator).Displayed;

                return status;
            }

            //verifica se o objeto está habilitado
            public static bool ObjetoEstaHabilitado(By Locator)
            {
                bool status = Driver.FindElement(Locator).Enabled;
                return status;
            }

            //Espera o objeto carregar
            public static void EsperarObjetoCarregar(By Locator)
            {
                int secondsToWait = 60;

                WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, secondsToWait));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Locator));
            }

            public static void EsperarTextoAparecer(string texto, By locator)
            {
                int secondsToWait = 30;
                WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, secondsToWait));

                wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, texto));
            }


            public static void EsperarTextoDesaparecer(string texto, By locator)
            {
                int secondsToWait = 300;
                WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, secondsToWait));

                wait.Until((ExpectedConditions.InvisibilityOfElementWithText(locator, texto)));
            }


            //Verifica se o objeto desapareceu da tela
            public static void VerificarQdoObjetoDesaparecer(By Locator)
            {
                int secondsToWait = 300;
                WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, secondsToWait));


                wait.Until(d => d.FindElement(Locator).Enabled && d.FindElement(Locator).Displayed);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Locator));

            }

            //Esperar
            public static void Esperar()
            {
                Thread.Sleep(6000);
                //Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(900);
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            }

            //Encerrar processo.
            public static void EncerrarProcesso()
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName == "chromedriver" || process.ProcessName == "firefoxdriver" || process.ProcessName == "internetexplorerdriver" || process.ProcessName == "edgedriver" || process.ProcessName == "geckodriver" || process.ProcessName == "MicrosoftWebDriver")
                    {
                        process.Kill();
                    }
                }
            }


            public static void CriarNovaPasta(string path)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            

            public static void SelecionarData(string DataNascimento, By DtaNascimento, By ElementDia, By ElementMes, By ElementAno)
            {
                string[] arrayDate = DataNascimento.Split('/');
                string Dia = arrayDate[0];
                string Mes = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(Convert.ToInt32(arrayDate[1]));
                string Ano = arrayDate[2];

                Funcionalidades.EsperarObjetoCarregar(DtaNascimento);
                Funcionalidades.Clicar(DtaNascimento);

                Funcionalidades.EsperarObjetoCarregar(ElementDia);
                Funcionalidades.Clicar(ElementDia);
                Funcionalidades.Driver.FindElement(ElementDia).Clear();
                Funcionalidades.EnviarTexto(Dia, ElementDia);

                Funcionalidades.Clicar(ElementMes);
                Funcionalidades.Driver.FindElement(ElementMes).Clear();
                Funcionalidades.EnviarTexto(Mes, ElementMes);

                Funcionalidades.Clicar(ElementAno);
                Funcionalidades.Driver.FindElement(ElementAno).Clear();
                Funcionalidades.EnviarTexto(Ano, ElementAno);
            }

            public static bool ObjetoExiste(By Locator)
            {
                try
                {
                    Driver.FindElement(Locator);
                    return true;
                }
                catch (NoSuchElementException e)
                {
                    return false;
                }
            }

           
    }
    }