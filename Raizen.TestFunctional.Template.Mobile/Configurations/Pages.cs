using OpenQA.Selenium.Appium.PageObjects;
using RaizenTestFuncional;
using RaizenTestFuncional.Setup;
using SeleniumExtras.PageObjects;

namespace Raizen.TestFunctional.Template.Mobile.Configurations
{
    public class Pages : DriverFactory
    {
        public Pages()
        {
            if (ConfigurationData.configurationData[0].mobileAndroid)
            {
                PageFactory.InitElements(GetAndroidDriver(), this, new AppiumPageObjectMemberDecorator());
            }

            if (ConfigurationData.configurationData[0].mobileiOS)
            {
                PageFactory.InitElements(GetiOSDriver(), this, new AppiumPageObjectMemberDecorator());
            }
        }
    }
}
