
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;

namespace Raizen.TestFunctional.Template.Mobile.Pages
{
    public class CommonPage : Configurations.Pages
    {
        #region Mapeamento de Elementos
        /// Classes Page são classes que possuem o mapeamento do objetos da interface da aplicação, permitindo interação com estes elementos.
        #endregion

        [FindsByAndroidUIAutomator(ID = "android:id/text1")]
        public IMobileElement<AndroidElement> TxtAutoComplete;

        [FindsByAndroidUIAutomator(ID = "com.loginmodule.learning:id/textInputEditTextEmail")]
        public IMobileElement<AndroidElement> FldEmail;

        [FindsByAndroidUIAutomator(ID = "com.loginmodule.learning:id/textInputEditTextPassword")]
        public IMobileElement<AndroidElement> FldPassword;

        [FindsByAndroidUIAutomator(ID = "appCompatButtonLogin")]
        public IMobileElement<AndroidElement> BtnLogin;

        [FindsByAndroidUIAutomator(ID = "com.loginmodule.learning:id/textViewLinkRegister")]
        public IMobileElement<AndroidElement> LnkCreateOne;

        [FindsByAndroidUIAutomator(ID = "com.loginmodule.learning:id/textInputEditTextName")]
        public IMobileElement<AndroidElement> FldName;

        [FindsByAndroidUIAutomator(ID = "com.loginmodule.learning:id/textInputEditTextConfirmPassword")]
        public IMobileElement<AndroidElement> FldConfirmPass;

        [FindsByAndroidUIAutomator(ID = "com.loginmodule.learning:id/appCompatButtonRegister")]
        public IMobileElement<AndroidElement> BtnRegister;

        [FindsByAndroidUIAutomator(ID = "com.loginmodule.learning:id/snackbar_text")]
        public IMobileElement<AndroidElement> StatusMessage;

    }
}
