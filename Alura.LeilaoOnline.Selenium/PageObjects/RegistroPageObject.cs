using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPageObject
    {
        private IWebDriver driver;

        //localizadores
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputPassword;
        private By byInputConfirmPassword;
        private By bybotaoRegistro;
        private By bySpanErroEmail;
        

        public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;

        public RegistroPageObject(IWebDriver driver)
        {
            this.driver = driver;

            //inicialização
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputPassword = By.Id("Password");
            byInputConfirmPassword = By.Id("ConfirmPassword");
            bybotaoRegistro = By.Id("btnRegistro");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");

        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");


        }

        public void SubmeterFormulario()
        {
            driver.FindElement(bybotaoRegistro).Click();

        }

        public void PreencherFormulario(string nome, string email, string password, string confirmPassword)
        {

            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputPassword).SendKeys(password);
            driver.FindElement(byInputConfirmPassword).SendKeys(confirmPassword);
            

        }
    }
}
