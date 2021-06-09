using Raizen.TestFunctional.Template.Mobile.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Raizen.TestFunctional.Template.Mobile.StepsDefinition
{
    [Binding]
    public class LoginSteps
    {
        private CommonPage page;

        public LoginSteps()
        {
            page = new CommonPage();
        }

        [Given(@"que o usuário esteja na tela de login")]
        public void DadoQueOUsuarioEstejaNaTelaDeLogin()
        {
            
        }
        
        [Given(@"o usuário informe no campo Email o valor ""(.*)""")]
        public void DadoOUsuarioInformeNoCampoEmailOValor(string p0)
        {
            page.FldEmail.SendKeys(p0);
        }
        
        [Given(@"o usuário informe no campo Password o valor ""(.*)""")]
        public void DadoOUsuarioInformeNoCampoPasswordOValor(string p0)
        {
            page.FldPassword.SendKeys(p0);
        }
        
        [Then(@"clico no botão Login")]
        public void EntaoClicoNoBotaoLogin()
        {
            Thread.Sleep(3000);
            page.BtnLogin.Click();
        }
    }
}
