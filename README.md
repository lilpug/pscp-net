# Putty Secure Copy Client .NET Wrapper

The pscp .Net wrapper is a small library that sits on top of the original pscp.exe, it sends commands to the exe to help automate the commands process so it can be used within any .Net

## Getting Started
* Download and reference the dll file in compiled folder.
* Download pscp.exe http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html and make sure its in the bin directory of the .Net project you are using it for.

##Functions

###Initialising Functions
Functions that initialise the class and determine how we should be processing the connection.
```c#
	//Initialises the pscp object with the default connection details
	PSCP pscp = new PSCP(hostname, username, password, thePort);
	
	//Initialises the pscp object with a password key file and a passphrase if one is supplied
	PSCP pscp = new PSCP(hostname, username, passphrase, thePort, fileKeyLocation);	
```

###Local Transfer Functions
Functions that transfer from the local caller to the remote server.
```c#
	//This function transfers a file from the local caller to the remote server
	pscp.Transfer("local file location", "remote file location");
	
	//This function transfers a folder from the local caller to the remote server
	pscp.FolderTransfer("local folder location", "remote folder location");
```	
	
###Remote Transfer Functions
Functions that transfer from the remote server to the local caller.
```c#		
	//This function transfers a file from the local caller to the remote server
	pscp.RemoteTransfer("remote file location", "local file location");
	
	//This function transfers a folder from the local caller to the remote server
	pscp.RemoteFolderTransfer("remote folder location", "local folder location");
```

###Output
How to Get the output from the tranfers that have been executed.
```c#		
	//This is a List<string> variable that stores all the output that has occured
	outputLog
	
	//This is a List<string> variable which stores any errors which have occured
	errorLog
```

###Debug Functions
Functions that pass back the commands we are executing to achieve the transfers.
```c#
	pscp.DebugTransfer("local file location", "remote file location");
	pscp.DebugFolderTransfer("local folder location", "remote folder location");
	pscp.DebugRemoteTransfer("remote file location", "local file location");
	pscp.DebugRemoteFolderTransfer("remote folder location", "local folder location");
```

## Copyright and License
Copyright &copy; David Whitehead

This project is licensed under the MIT License.

You do not have to do anything special by using the MIT license and you don't have to notify anyone that your using this license. You are free to use, modify and distribute this software in any normal and commercial usage. If being used for any commercial purposes the latest copyright license file supplied above which is known as "LICENSE" must also be distributed with any compiled code that is being sold that utilises "Putty Secure Copy Client .NET Wrapper".