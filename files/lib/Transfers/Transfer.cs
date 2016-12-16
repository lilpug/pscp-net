using System;
namespace pscp.wrapper
{   
    public partial class PSCP
    {
        // ====================================// 
        //          Transfer Functions         //        
        // ====================================//

        //Method for transfering files from one location to another (local to remote)
        public bool Transfer(string localLocation, string remoteLocation)
        {   
            try
            {
                //General pscp syntax for the command
                //"pscp -l username -pw password -sftp local_location server:remote_location"

                //The echo y is in case its on a new machine with no cached rsa key.
                /*Note: if on new machine and the echo y is not used the WaitForExit will hang infinitely
                    * This is because its waiting for the input of yes and no*/

                string command_build = "";

                //This builds the command up

                //Checks whether we are using a certificate or supplying the password
                if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
                {
                    //If no pass phrase is supplied it will not be put into the syntax
                    if (!string.IsNullOrWhiteSpace(pwd))
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -pw {3} -sftp ""{4}"" {5}:""{6}""", port, user, keyLocation, pwd, localLocation, host, remoteLocation);
                    }
                    else
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -sftp ""{3}"" {4}:""{5}""", port, user, keyLocation, localLocation, host, remoteLocation);                            
                    }
                }
                else //Builds normal syntax with password supplied
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -pw {2} -sftp ""{3}"" {4}:""{5}""", port, user, pwd, localLocation, host, remoteLocation);                        
                }

                //Fixes any slash problems in windows escapes
                command_build.Replace(@"\\", @"\");

                //This sends the command off to be run
                cmd_run(command_build);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

		//Method for transfering files from one location to another (folder, local to remote)
        public bool FolderTransfer(string localLocation, string remoteLocation)
        {
            try
            {
                //General pscp syntax for the command
                //"pscp -l username -pw password -sftp local_location server:remote_location"

                //The echo y is in case its on a new machine with no cached rsa key.
                /*Note: if on new machine and the echo y is not used the WaitForExit will hang infinitely
                    * This is because its waiting for the input of yes and no*/

                string command_build = "";

                //This builds the command up

                //Checks whether we are using a certificate or supplying the password
                if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
                {
                    //If no pass phrase is supplied it will not be put into the syntax
                    if (!string.IsNullOrWhiteSpace(pwd))
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -pw {3} -sftp ""{4}"" {5}:""{6}""", port, user, keyLocation, pwd, localLocation, host, remoteLocation);
                    }
                    else
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -sftp ""{3}"" {4}:""{5}""", port, user, keyLocation, localLocation, host, remoteLocation);                            
                    }
                }
                else //Builds normal syntax with password supplied
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -pw {2} -sftp ""{3}"" {4}:""{5}""", port, user, pwd, localLocation, host, remoteLocation);                        
                }

                //Fixes any slash problems in windows escapes
                command_build.Replace(@"\\", @"\");

                //This sends the command off to be run
                cmd_run(command_build);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
		
        //Method for transfering files from one location to another (remote to local)
        public bool RemoteTransfer(string remoteLocation, string localLocation)
        {
            try
            {
                //General pscp syntax for the command
                //"pscp -l username -pw password -sftp local_location server:remote_location"

                //The echo y is in case its on a new machine with no cached rsa key.
                /*Note: if on new machine and the echo y is not used the WaitForExit will hang infinitely
                    * This is because its waiting for the input of yes and no*/

                string command_build = "";

                //This builds the command up

                //Checks whether we are using a certificate or supplying the password
                if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
                {
                    //If no pass phrase is supplied it will not be put into the syntax
                    if (!string.IsNullOrWhiteSpace(pwd))
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -pw {3} -sftp {4}:""{5}"" ""{6}""", port, user, keyLocation, pwd, host, remoteLocation, localLocation);
                    }
                    else
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -i ""{2}"" -sftp {3}:""{4}"" ""{5}""", port, user, keyLocation, host, remoteLocation, localLocation);
                    }
                }
                else //Builds normal syntax with password supplied
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -l {1} -pw {2} -sftp {3}:""{4}"" ""{5}""", port, user, pwd, host, remoteLocation, localLocation);
                }

                //Fixes any slash problems in windows escapes
                command_build.Replace(@"\\", @"\");

                //This sends the command off to be run
                cmd_run(command_build);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Method for transfering files from one location to another (folder, remote to local)
        public bool RemoteFolderTransfer(string remoteLocation, string localLocation)
        {
            try
            {
                //General pscp syntax for the command
                //"pscp -l username -pw password -sftp local_location server:remote_location"

                //The echo y is in case its on a new machine with no cached rsa key.
                /*Note: if on new machine and the echo y is not used the WaitForExit will hang infinitely
                    * This is because its waiting for the input of yes and no*/

                string command_build = "";

                //This builds the command up

                //Checks whether we are using a certificate or supplying the password
                if (!string.IsNullOrWhiteSpace(keyLocation))//Builds the certificate syntax
                {
                    //If no pass phrase is supplied it will not be put into the syntax
                    if (!string.IsNullOrWhiteSpace(pwd))
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -pw {3} -sftp {4}:""{5}"" ""{6}""", port, user, keyLocation, pwd, host, remoteLocation, localLocation);                            
                    }
                    else
                    {
                        command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -i ""{2}"" -sftp {3}:""{4}"" ""{5}""", port, user, keyLocation, host, remoteLocation, localLocation);                            
                    }
                }
                else //Builds normal syntax with password supplied
                {
                    command_build = string.Format(@"/C echo 'y' | pscp -P {0} -r -l {1} -pw {2} -sftp {3}:""{4}"" ""{5}""", port, user, pwd, host, remoteLocation, localLocation);                        
                }

                //Fixes any slash problems in windows escapes
                command_build.Replace(@"\\", @"\");

                //This sends the command off to be run
                cmd_run(command_build);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }            

    }    
}
