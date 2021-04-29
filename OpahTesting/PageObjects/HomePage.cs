using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpahTesting.PageObjects
{
    public static class HomePage
    {
        public static By TxtOqueVoceEstaProcurando()
        {
            By obj = (By.Id("input-search"));
            return obj;
        }

        public static By BtnSearch()
        {
            By obj = (By.Id("span-searchIcon"));
            return obj;
        }

        public static By BtnClose()
        {
            By obj = (By.XPath("/html/body/div[1]/a[1]"));
            return obj;
        }

        public static By BtnAutorizar()
        {
            By obj = (By.Id("btn-authorizeCoookies"));
            return obj;
        }

        public static By Loading()
        {
            By obj = (By.Id("livelo-spinner"));
            return obj;
        }

        public static By Produto()
        {
            By obj = (By.XPath("//*[@id='wi6200019-endeca-product-listing-points-id']/div[1]"));
            return obj;
        }

        public static By SelecionarVoltagem()
        {
            By obj = (By.Id("CC-prodDetails-sku-type_other_v_voltage"));
            return obj;
        }

        public static By SelecionarCor()
        {
            By obj = (By.Id("CC-prodDetails-sku-type_other_v_color"));
            return obj;
        }
    }
}
