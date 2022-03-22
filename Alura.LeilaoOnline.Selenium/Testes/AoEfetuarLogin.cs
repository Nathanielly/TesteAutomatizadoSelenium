using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaPaginaDeDashboard()
        {

            //Arrange - 
            var loginPo = new LoginPageObject(driver);
            loginPo.Visitar();
            loginPo.PreencherFormulario("fulano@example.org", "123");

            //Act - 
            loginPo.SubmeterFormulario();

            //Assert - 
            Assert.Contains("Dashboard", driver.Title);


        }

        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarLogin()
        {

            //Arrange - 
            var loginPo = new LoginPageObject(driver);
            loginPo.Visitar();
            loginPo.PreencherFormulario("fulano@example.org", "");

            //Act - 
            loginPo.SubmeterFormulario();

            //Assert - 
            Assert.Contains("Login", driver.PageSource);


        }


    }
}
