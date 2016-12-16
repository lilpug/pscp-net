namespace pscp.wrapper
{   
    public partial class PSCP
    {
        // ========================================// 
        //          Debug Output Functions         //        
        // ========================================//

        //This method outputs the syntax for what will be run on file transfer
        public string DebugTransfer(string local_location, string remote_location)
        {
            string command_build = "";

            //This builds the command up

            //Checks whether we are using a certificate or supplying the password
            if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
            {
                if (!string.IsNullOrWhiteSpace(pwd))
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -pw {3} -sftp ""{4}"" {5}:""{6}""", port, user, keyLocation, pwd, local_location, host, remote_location);                                                
                }
                else
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -sftp ""{3}"" {4}:""{5}""", port, user, keyLocation, local_location, host, remote_location);                        
                }
            }
            else //Builds normal syntax with password supplied
            {
                command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -pw {2} -sftp ""{3}"" {4}:""{5}""", port, user, pwd, local_location, host, remote_location);                    
            }

            //Fixes any slash problems in windows escapes
            command_build.Replace(@"\\", @"\");

            return command_build;
        }

		//This method outputs the syntax for what will be run on file transfer
        public string DebugFolderTransfer(string local_location, string remote_location)
        {
            string command_build = "";

            //This builds the command up

            //Checks whether we are using a certificate or supplying the password
            if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
            {
                if (!string.IsNullOrWhiteSpace(pwd))
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -pw {3} -sftp ""{4}"" {5}:""{6}""", port, user, keyLocation, pwd, local_location, host, remote_location);                                                
                }
                else
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -sftp ""{3}"" {4}:""{5}""", port, user, keyLocation, local_location, host, remote_location);                        
                }
            }
            else //Builds normal syntax with password supplied
            {
                command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -pw {2} -sftp ""{3}"" {4}:""{5}""", port, user, pwd, local_location, host, remote_location);                    
            }

            //Fixes any slash problems in windows escapes
            command_build.Replace(@"\\", @"\");

            return command_build;
        }
		
        //This method outputs the syntax for what will be run on the file remote transfer
        public string DebugRemoteTransfer(string remote_location, string local_location)
        {
            string command_build = "";

            //This builds the command up

            //Checks whether we are using a certificate or supplying the password
            if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
            {
                //If no pass phrase is supplied it will not be put into the syntax
                if (!string.IsNullOrWhiteSpace(pwd))
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -pw {3} -sftp {4}:""{5}"" ""{6}""", port, user, keyLocation, pwd, host, remote_location, local_location);                        
                }
                else
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -sftp {3}:""{4}"" ""{5}""", port, user, keyLocation, host, remote_location, local_location);                        
                }
            }
            else //Builds normal syntax with password supplied
            {
                command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -pw {2} -sftp {3}:""{4}"" ""{5}""", port, user, pwd, host, remote_location, local_location);                    
            }

            return command_build;
        }
        
        //This method outputs the syntax for what will be run on the file remote transfer
        public string DebugRemoteFolderTransfer(string remote_location, string local_location)
        {
            string command_build = "";

            //This builds the command up

            //Checks whether we are using a certificate or supplying the password
            if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
            {
                //If no pass phrase is supplied it will not be put into the syntax
                if (!string.IsNullOrWhiteSpace(pwd))
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -pw {3} -sftp {4}:""{5}"" ""{6}""", port, user, keyLocation, pwd, host, remote_location, local_location);                        
                }
                else
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -sftp {3}:""{4}"" ""{5}""", port, user, keyLocation, host, remote_location, local_location);                        
                }
            }
            else //Builds normal syntax with password supplied
            {
                command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -pw {2} -sftp {3}:""{4}"" ""{5}""", port, user, pwd, host, remote_location, local_location);                    
            }

            return command_build;
        }
        
		
    }    
}
