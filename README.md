# KKBOX OpenAPI SDK for .NET

## SDK usage
### Compatibility
1. The SDK itself is supported Universal Windows Platform(Build 15063+) and .NET Framework 4.6.1+.
1. It should be able to use with Visual Studio 2017.

### Use Nuget to install the SDK
- [![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/KKBOX.OpenAPI.Standard/)
- .NET Standard 1.4, .NET Framework 4.5/6.1 and Universal Windows Platform.

### Prepare client ID & client secret
Browse [KKBOX Developer Website](https://developer.kkbox.com/) and create an developer account, then create an app to get the client ID and client secret.

### Use the SDK
- For Universal Windows Platform, need internet capability: 

```xml
<Capabilities>
    <Capability Name="internetClient" />
</Capabilities>
```

- Get access token: 

```csharp
// Request to get access token
var authResult = await KKBOXOAuth.SignInAsync(clientId, clientSecret);
string accessToken = authResult.Content.AccessToken;
```

- Use KKBOX Open API:

```csharp
KKBOXAPI openAPI = new KKBOXAPI();
// Must setting access token
openAPI.AccessToken = accessToken;
// Must setting user territory
OpenAPI.TerritoryType = TerritoryType.TW;

// example get album metadata
var album = await openAPI.GetAlbumAsync(albumId);
```

- Reference [Sample](Sample/OpenAPI.App.Shared/MainPageViewModel.cs) to learn how to use the SDK.

### SDK document
Please browse [Dotnet SDK document](Doc/Home.md)

## SDK Development
### Development Environment
1. Below applies to those who wants to develop the SDK.
1. If you were just using the SDK, please refer to previous parts.
1. Install Visual Studio 2017 or latest version.
   - include Windows 10 (Build 15063+) SDK.
   - .NET Framework 4.6.1+.
   - Windows 10 (Build 15063+).

### Develop the library
Fork the repository to develop, don't develop and custom class name on the repository.
If you have any issue, please oepn [issue](https://github.com/KKBOX/OpenAPI-Dotnet/issues)。

## License
Copyright 2017 KKBOX Technologies Limited

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.