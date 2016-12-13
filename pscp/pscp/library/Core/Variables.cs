using System;
using System.Collections.Generic;
using System.Linq;
namespace pscp.wrapper
{   
    public partial class PSCP
    {
        // ========================================// 
        //                Variables                //        
        // ========================================//        

        //Class variables used for connection information
        internal string host;
        internal string user;
        internal string pwd; //Note: This will be used as a passphrase if keylocation is supplied
        internal string port;
        internal string keyLocation;

        //This is a class variable used to store the output log
        public List<string> outputLog {get;set;}

        //This is a class variable used to store the error log
        public List<string> errorLog {get;set;}

        //This method allows the user to pull out the latest error which has occured
        public string get_latest_error_output()
        {
            try
            {
                return errorLog.ElementAt(errorLog.Count - 1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //This method returns the latest output from the process
        public string get_latest_output()
        {
            try
            {
                return outputLog.ElementAt(outputLog.Count - 1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }    
}
