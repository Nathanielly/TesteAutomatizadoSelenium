using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes
{ 
    [Collection ("Chrome Drive")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento()
        {

            //arrange - Chrome aberto, página inicial do sistema de leilões, dados de registro válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //capturar os dados por meio do ID.
            //nome 
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //password
            var inputPassword = driver.FindElement(By.Id("Password"));

            //confirmpassword
            var inputConfirmPassword = driver.FindElement(By.Id("ConfirmPassword"));

            //botao de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));


            //inserir os dados no formulário
            inputNome.SendKeys("Daniel Portugal");
            inputEmail.SendKeys("daniel.portugal@caelum.com.br");
            inputPassword.SendKeys("123");
            inputConfirmPassword.SendKeys("123");





            //act - quando realizo o registro 
            botaoRegistro.Click(); //clicar no botao de registrar




            //assert - devo ser direcionado para a página de agradecimento.
            Assert.Contains("Obrigado", driver.PageSource);



        }
    }
}
