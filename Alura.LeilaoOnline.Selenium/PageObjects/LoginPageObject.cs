using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPageObject
    {

        private IWebDriver driver;

        //localizadores
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;

            //inicialização dos localizadores
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");

        }
        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");

        }

        public void PreencherFormulario(string login, string senha)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            driver.FindElement(byInputSenha).SendKeys(senha);
        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBotaoLogin).Submit(); //submit vai fazer a mesma função do click.
        }

        


    }
}
