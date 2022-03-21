using System;
using System.IO;
using System.Management.Automation;
using System.Text;

namespace Megumin
{
    public static class Utils
    {
        // all code in here from onix launcher
        public static string OnixPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                        "\\Megumin";

        public static string GetXboxGamertag()
        {
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var xboxName = "Unknown";

            if (File.Exists(OnixPath + "\\XboxLiveGamer.xml.txt"))
                File.Delete(OnixPath + "\\XboxLiveGamer.xml.txt");
            if (!File.Exists(
                    localappdata + "\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe\\LocalState\\XboxLiveGamer.xml"))
                return xboxName;
            try
            {
                File.Copy(localappdata + "\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe\\LocalState\\XboxLiveGamer.xml",
                    OnixPath + "\\XboxLiveGamer.xml.txt");
                foreach (var readAllLine in File.ReadAllLines(OnixPath + "\\XboxLiveGamer.xml.txt"))
                    if (readAllLine.Contains("Gamertag"))
                        xboxName = readAllLine;
                xboxName = xboxName.Replace("\"Gamertag\"", "");
                xboxName = xboxName.Replace("\"", "");
                xboxName = xboxName.Replace(": ", "");
                xboxName = xboxName.Replace(",", "");
                xboxName = xboxName.Trim();
            }
            catch (ArgumentException)
            {
            }

            return xboxName;
        }

        public static string GetVersion()
        {
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript("Get-AppPackage -name Microsoft.MinecraftUWP | select -expandproperty Version");
                powerShell.AddCommand("Out-String");
                var psOutput = powerShell.Invoke();
                var stringBuilder = new StringBuilder();
                foreach (var pSObject in psOutput)
                    stringBuilder.AppendLine(pSObject.ToString());
                var version = stringBuilder.ToString().Replace(Environment.NewLine, "");
                powerShell.Dispose();
                return version;
            }
        }
    }
}