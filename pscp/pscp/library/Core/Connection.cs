using System.Collections.Generic;
namespace pscp.wrapper
{   
    public partial class PSCP
    {
        // =======================================// 
        //          Constructor Functions         //        
        // =======================================//

        //Constructor which accepts the sftp login information
        public PSCP(string hostname, string username, string password, string thePort)
        {
            //Assigns the authentication and connection information
            host = hostname;
            user = username;
            pwd = password;
            port = thePort;

            //initiales the output list
            outputLog = new List<string>();
            //initiales the error list
            errorLog = new List<string>();
        }

        //Overload constructor for using certificates instead
        public PSCP(string hostname, string username, string passphrase, string thePort, string fileKeyLocation)
        {
            //Assigns the authentication and connection information
            host = hostname;
            user = username;
            pwd = passphrase;
            port = thePort;
            keyLocation = fileKeyLocation;

            //initiales the output list
            outputLog = new List<string>();
            //initiales the error list
            errorLog = new List<string>();
        }
            
    }    
}
