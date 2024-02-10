# RNGCommands
RNGCommands is a [SalemModLoader](https://github.com/Curtbot9000/SalemModLoader) mod for [Town of Salem 2](https://store.steampowered.com/app/2140510/Town_of_Salem_2/) by BlankMediaGames.

RNGCommands is developed by Valtsu0 and is unaffiliated with with BlankMediaGames.

Most of the mod, including this README with the exception of this line and the above, is copied from [SlashSlander](https://github.com/voidbehemoth/CommandLib) by voidbehemoth, permitted by the GPLv3 license.

## Building
Want to build the latest (potentially unreleased) version of the mod yourself? Follow these steps:

1. Make sure you have the latest version of the repo on your client.
2. Create a file in the same directory as AutoGG.csproj called SteamLibrary.targets and copy the following into it:
```
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
        <SteamLibraryPath>REPLACE</SteamLibraryPath>
    </PropertyGroup>
</Project>
```
3. Replace the text 'REPLACE' with the location of your 'SteamLibrary' folder (or 'ApplicationSupport/Steam' on OSX).
4. Build the mod using either the [dotnet cli](https://dotnet.microsoft.com/en-us/download), [Visual Studio](https://visualstudio.microsoft.com/), or some other means.

NOTE: This repository is licensed under the GNU General Public License v3.0. Learn more about what this means [here](https://www.tldrlegal.com/license/gnu-general-public-license-v3-gpl-3).