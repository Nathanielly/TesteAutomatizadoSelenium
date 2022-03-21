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
    [Collection ("Chrome Driver")]
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

        [Theory] //funciona quando a expectativa é a mesma, podemos usar nessa caso pq vamos testar varios campos com a mesma expectativa.
        [InlineData("", "daniel.portugal@caelum.com.br", "123", "123")]
        [InlineData("Nathanielly", "Nath", "123", "123")]
        [InlineData("Nathanielly", "daniel.portugal@caelum.com.br", "123", "456")]
        [InlineData("Nathanielly", "daniel.portugal@caelum.com.br", "123", "")]
        public void DadoInformacoesInvalidasDeveManterNaHome(string nome, string email, string senha, string confirmSenha)
        {

            //arrange - Chrome aberto, página inicial do sistema de leilões, dados de registro inválidos informados
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
            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputPassword.SendKeys(senha);
            inputConfirmPassword.SendKeys(confirmSenha);


            //act 
            botaoRegistro.Click(); //clicar no botao de registrar


            //assert
            Assert.Contains("section-registro", driver.PageSource);


        }

        [Fact]
        public void DadoNomeEmBrancoDeveAparecerMensagemDeErro()
        {


            //arrange 
            driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));


            //act 
            botaoRegistro.Click(); //clicar no botao de registrar


            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
           
            Assert.Equal("The Nome field is required.", elemento.Text);
            //displayed retorna booleano.



        }


        [Fact]
        public void DadoEmailInvalidoDeveAparecerMensagemDeErro()
        {


            //arrange 
            driver.Navigate().GoToUrl("http://localhost:5000");

            var inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys("Nath");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));


            //act 
            botaoRegistro.Click(); //clicar no botao de registrar


            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));
           
            Assert.Equal("Please enter a valid email address.",elemento.Text);
            //displayed retorna booleano.



        }


    
    }
}
