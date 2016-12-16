using System.Diagnostics;
using System.Linq;
namespace pscp.wrapper
{   
    public partial class PSCP
    {
        // =======================================// 
        //           Execution Functions          //        
        // =======================================//

        //This method is used within the transfer processes to start up the pscp process
        private void cmd_run(string command)
        {
            //Sets up the process information to run CMD with the passed command
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "cmd.exe";
            cmdStartInfo.Arguments = command;
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = true;

            //Starts the process for running CMD with the specified command
            Process cmdProcess = new Process();
                
            //Starts the process                
            cmdProcess = Process.Start(cmdStartInfo);

            //Tells the process to run cmd_error and cmd_datareceived on errors and feedback to the process
            cmdProcess.ErrorDataReceived += new DataReceivedEventHandler(cmd_Error);
            cmdProcess.OutputDataReceived += new DataReceivedEventHandler(cmd_DataReceived);
            cmdProcess.EnableRaisingEvents = true;
                
            //Starts the streams a
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
                
            //Waits for the process to exit
            cmdProcess.WaitForExit();                
        }

        //This method is used as a generic output buffer for the process
        private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            //Does not add blank strings to the output log only the finished output
            if (!string.IsNullOrWhiteSpace(e.Data) && e.Data.EndsWith("100%"))
            {
                outputLog.Add(e.Data);
            }
        }

        //This method is used as a generic error output buffer for the process
        private void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            string[] newConnectionStalling = new string[]
            {
                "The server's host key is not cached in the registry. You",
                "have no guarantee that the server is the computer you",
                "think it is.",
                "The server's dss key fingerprint is:",
                "If you trust this host, enter \"y\" to add the key to",
                "PuTTY's cache and carry on connecting.",
                "If you want to carry on connecting just once, without",
                "adding the key to the cache, enter \"n\".",
                "If you do not trust this host, press Return to abandon the",                    
                "connection.",
                "Store key in cache? (y/n) ",
                "The server's rsa2 key fingerprint is:"
            };

            //Should hopefully stop the Y key stalling
            if (
                !string.IsNullOrWhiteSpace(e.Data) && 
                !newConnectionStalling.Contains(e.Data) && 
                e.Data.IndexOf("ssh-dss") == -1 &&
                e.Data.IndexOf("ssh-rsa") == -1
                )
            {
                errorLog.Add(e.Data);
            }
        }

    }    
}
