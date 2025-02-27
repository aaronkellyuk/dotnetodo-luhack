using System;
using System.Diagnostics;

namespace LoginLogic
{
    public static class LoginValidator
    {
        public static bool ValidateLogin(string username, string password)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.Arguments = $"-File \"ValidateUser.ps1" -username { username } -password { password } ";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    return bool.Parse(result.Trim());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}