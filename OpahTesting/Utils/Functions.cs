using OpahTesting.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpahTesting.Utils
{
    class Functions
    {
        public static void SelecionarCor()
        {

            Funcionalidades.EsperarObjetoCarregar(HomePage.SelecionarCor());
            IWebElement EducationDropDownElement = Funcionalidades.Driver.FindElement(HomePage.SelecionarCor());
            SelectElement SelectAnEducation = new SelectElement(EducationDropDownElement);

            Funcionalidades.Driver.FindElement(HomePage.SelecionarCor()).Click();

            SelectAnEducation.SelectByIndex(1);
        }

        public static void SelecionarVoltagem()
        {
            Funcionalidades.EsperarObjetoCarregar(HomePage.SelecionarVoltagem());
            IWebElement EducationDropDownElement = Funcionalidades.Driver.FindElement(HomePage.SelecionarVoltagem());
            SelectElement SelectAnEducation = new SelectElement(EducationDropDownElement);

            if (SelectAnEducation.Options.Count > 1)
            {
                SelectAnEducation.SelectByIndex(1);
            }

            
        }


    }
}
