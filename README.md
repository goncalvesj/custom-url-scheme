# Publish .NET Core App

Because it's a .NET Core 3 console application it needs to be published first as a "self-contained" application to generate an .exe file.

Run the below command and retrieve the .exe location

```
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true
```

# Add Key to Registry

Open the sample.reg file.

Replace
C:\\Program Files\\YourApp\\YourApp.exe\
with the .exe location you retrieved earlier.

Run the registry file in the registry folder.
It will create the following entry in the Windows Registry.

```
HKEY_CLASSES_ROOT
   sample
      (Default) = "URL:Sample Protocol"
      URL Protocol = ""
      DefaultIcon
         (Default) = "sample.exe,1"
      shell
         open
            command
               (Default) = "C:\Program Files\Sample\sample.exe" "%1"
```

# Website

Open index.html

Click the open app button

A prompt should appear to open you desktop app

Value is displayed in the console app