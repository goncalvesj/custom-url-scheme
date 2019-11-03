# Requirements

- Windows
- .NET Core CLI
- .NET Core 3.0

# Contents

### client-app/client-app folder
Custom console application that will respond to the custom url

### client-app/register-protocol folder
Console application that will add the custom url scheme to windows registry

### registry/sample.reg
Example registry file that can be used to register the custom url

### website/index.html
Test website to execute the custom url with params

Params types:
- string
- json string
- base64 encoded json string

# Steps

## Add to registry and publish console app
The .NET Core 3 console application it needs to be published first as a "self-contained" application to generate an .exe file.
Execute the following powershell script
```
installapps.ps1
```
OR
1. Open Visual Studio 2019
2. Run Register-Protocol project
3. Publish Client-App project using the existing FolderProfile

# Confirm registry was created
Win+R and type 
```
regedit
```
The following entry in the Windows Registry should be in place.

```
HKEY_CLASSES_ROOT
   clientapp
```

# Test the Custom URL

Open index.html in any browser

Click any of the buttons

A prompt should appear to open you desktop app

Value is displayed in the console app