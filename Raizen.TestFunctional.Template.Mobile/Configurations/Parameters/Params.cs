using Microsoft.Extensions.Configuration;
using System.IO;
using RaizenTestFuncional.Setup;
using RaizenTestFuncional.Mobile;
using RaizenTestFuncional.Credentials;
using System.Linq;
using System;

namespace Raizen.TestFunctional.Template.Mobile.Configurations.Parameters
{
    public static class Params
    {
        #region Variables
        public static IConfiguration parameters = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString())
            .AddJsonFile($"parameters.json", optional: true, reloadOnChange: true)
            .Build();
        #endregion

        #region Parameters

        public static void ConfigParams()
        {
            Configuration confdata = new Configuration();

            confdata.nodePath = NodePath();
            confdata.appiumPath = AppiumPath();
            confdata.devOps = DevOps();
            confdata.timeOut = TimeOut();
            confdata.activedReportTest = ReportTest();
            confdata.reportFolder = ReportFolder();
            confdata.screenshots = ReportScreenshots();
            confdata.mobileAndroid = MobileAndroid();
            confdata.mobileiOS = MobileiOS();
            confdata.safeCredentials = SafeCredentials();

            ConfigurationData.configurationData.Add(confdata);
        }

        private static string NodePath()
        {
            return parameters.GetSection("appSettings:NodePath").Value.ToLower();
        }

        private static string AppiumPath()
        {
            return parameters.GetSection("appSettings:AppiumPath").Value.ToLower();
        }
        
        private static bool MobileAndroid()
        {
            if (bool.Parse(parameters.GetSection("appSettings:MobileAndroid").Value)){
                EnviromentAndroid();
            }

            return bool.Parse(parameters.GetSection("appSettings:MobileAndroid").Value.ToLower());
        }

        private static void EnviromentAndroid()
        {
            var length = parameters.GetSection("appSettings:MobileAndroidConfiguration").GetChildren().ToList();
            for (var i = 0; i <= length.Count - 1; i++)
            {
                MobileAndroidParams configParams = new MobileAndroidParams();
                configParams.mobileAndroidPlatformName = parameters.GetSection("appSettings:MobileAndroidConfiguration:" + i + ":MobileAndroidPlatformName").Value;
                configParams.mobileAndroidPlatformVersion = parameters.GetSection("appSettings:MobileAndroidConfiguration:" + i + ":MobileAndroidPlatformVersion").Value;
                configParams.mobileAndroidDeviceName = parameters.GetSection("appSettings:MobileAndroidConfiguration:" + i + ":MobileAndroidDeviceName").Value;
                configParams.mobileAndroidAppPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString()) + "/Apps/" + parameters.GetSection("appSettings:MobileAndroidConfiguration:" + i + ":MobileAndroidAppPath").Value;
                configParams.mobileAndroidActivity = parameters.GetSection("appSettings:MobileAndroidConfiguration:" + i + ":MobileAndroidActivity").Value;
                configParams.mobileAndroidAppPackage = parameters.GetSection("appSettings:MobileAndroidConfiguration:" + i + ":MobileAndroidAppPackage").Value;
                configParams.mobileAndroidUDID = parameters.GetSection("appSettings:MobileAndroidConfiguration:" + i + ":MobileAndroidUDID").Value;
                MobileData.mobileAndroidData.Add(configParams);
            }

        }

        private static bool MobileiOS()
        {
            if (bool.Parse(parameters.GetSection("appSettings:MobileiOS").Value))
            {
                EnviromentiOS();
            }
            return bool.Parse(parameters.GetSection("appSettings:MobileiOS").Value.ToLower());
        }

        private static void EnviromentiOS()
        {
            var length = parameters.GetSection("appSettings:MobileiOSConfiguration").GetChildren().ToList();
            for (var i = 0; i <= length.Count - 1; i++)
            {
                MobileiOSParams configParams = new MobileiOSParams();
                configParams.mobileiOSPlatformVersion = parameters.GetSection("appSettings:MobileiOSConfiguration: " + i + " :MobileiOSPlatformName").Value;
                configParams.mobileiOSDeviceName = parameters.GetSection("appSettings:MobileiOSConfiguration: " + i + " :MobileiOSDeviceName").Value;
                configParams.mobileiOSAppPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()) + "\\App\\" + parameters.GetSection("appSettings:MobileiOSConfiguration: " + i + " :MobileiOSAppPath").Value;
                configParams.mobileiOSUDID = parameters.GetSection("appSettings:MobileiOSConfiguration: " + i + " :MobileiOSUDID").Value;

                MobileData.mobileiOSData.Add(configParams);
            }
        }

        private static TimeSpan TimeOut()
        {
            return TimeSpan.Parse(parameters.GetSection("appSettings:TimeOut").Value);
        }

        private static string DevOps()
        {
            return parameters.GetSection("appSettings:DevOps").Value.ToLower();
        }

        private static bool ReportTest()
        {
            return bool.Parse(parameters.GetSection("appSettings:ReportTest").Value.ToLower());
        }

        private static string ReportFolder()
        {
            return parameters.GetSection("appSettings:ReportFolder").Value.ToLower();
        }

        private static string ReportScreenshots()
        {
            return parameters.GetSection("appSettings:ReportScreenshots").Value.ToLower();
        }

        private static bool SafeCredentials()
        {
            if (bool.Parse(parameters.GetSection("appSettings:SafeCredentials").Value.ToLower()))
            {
                Credentials();
            }
            return bool.Parse(parameters.GetSection("appSettings:SafeCredentials").Value.ToLower());
        }

        private static void Credentials()
        {
            var length = parameters.GetSection("appSettings:SafeCredentials").GetChildren().ToList();

            for (var i = 0; i <= length.Count - 1; i++)
            {
                UserCredentials credentials = new UserCredentials();

                credentials.Name = parameters.GetSection("appSettings:SafeCredentials:" + i + ":Name").Value;
                credentials.Id = parameters.GetSection("appSettings:SafeCredentials:" + i + ":Id").Value;
                credentials.TokenKey = parameters.GetSection("appSettings:SafeCredentials:" + i + ":TokenKey").Value;
                credentials.TokenSecret = parameters.GetSection("appSettings:SafeCredentials:" + i + ":TokenSecret").Value;
                credentials.ConsumerKey = parameters.GetSection("appSettings:SafeCredentials:" + i + ":ConsumerKey").Value;
                credentials.ConsumerSecret = parameters.GetSection("appSettings:SafeCredentials:" + i + ":ConsumerSecret").Value;

                UserInfo.credentials.Add(credentials);
            }
        }
        #endregion
    }
}
