Sample Windows Service in Visual Basic.NET

I.  WHAT IT DOES

This application is intended as an illustration of how to create a Windows Service in VB.NET.  It does the following:

-- Read files in subdirectory Emails under Environment.CurrentDirectory, which because this is a service, evaluates to the System32 directory.  If the subdirectory Emails does not exist, it will be created by the service at start-up.

--  If the files are formatted correctly, as defined by the code, send e-mail to the person specified, using the SMTP methods provided by the System.Web.Mail namespace.  The format of messages is as follows:

FromEmail####ToEmail####Subject####Message.

#### is the delimiter used by the program.  A sample message is included in the .zip file.

-- If the e-mail is sent successfully, the system deletes the file; otherwise it is copied to the Errors subfolder (which the service creates if it doesn't exist).

-- The loop to check the Emails directory is run on a separate thread that is activated when the service starts.


For more detail, please refer to the code and comments.


II.  INSTALLATION/CONFIGURATION

For this to work, you will need to have the .NET framework installed on a Windows 2000 machine (and presumably XP, though I have not tested it with XP).

To install the service, you need to use the InstallUtil Utility that comes with Visual Studio.NET.  From the command prompt, navigate to the subdirectory where you have SimpleEmailService.exe installed.  Then type:

InstallUtil SimpleEmailService.exe.

Note that if you have upgraded Visual Studio.NET at all, you may have multiple versions of InstallUtil on your system.  If this is the case, you may have to naviagate to the the WinNT\Microsoft.NET\Framework\(Latest Version) subdirectory from the command prompt; on my system, this was C:\Winnt\Microsoft.NET\Framework\v1.0.3705. From here, you type:

InstallUtil [Full Path to SimpleEmailService.exe]\SimpleEmailService.exe