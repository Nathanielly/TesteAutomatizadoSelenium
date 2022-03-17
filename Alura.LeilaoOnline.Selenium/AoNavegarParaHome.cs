using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome
    {
        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange - Abrir navegador
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            

            //act - Navegar para a url em questão
            driver.Navigate().GoToUrl("http://localhost:5000");


            //assert - espera-se que contenha no titulo a palavra leilões
            Assert.Contains("Leilões", driver.Title);

        }


        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {

            //arrange - Abrir navegador
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);


            //act - Navegar para a url em questão
            driver.Navigate().GoToUrl("http://localhost:5000");


            //assert - espera-se que contenha no titulo a palavra leilões
            Assert.Contains("Próximos Leilões", driver.PageSource);



        }

    }

    
}
