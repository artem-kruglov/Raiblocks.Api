# RaiBlocks - Blockchain Integration API

This is a RaiBlocks Integration API. It was developed during the competition [RaiBlocks - Blockchain Integration API](https://streams.lykke.com/Project/ProjectDetails/raiblocks-blockchain-integration-api) in accordance to [the requirements 1.0.0-rc-2](https://docs.google.com/document/d/1KVd-2tg-Ze5-b3kFYh1GUdGn9jvoo7HFO3wH_knpd3U/).

The project was made in compliance with [Lykke template](https://github.com/LykkeCity/lykke.dotnettemplates/tree/master/Lykke.Service.LykkeService).

# Prerequisites

- [ASP.NET Core 2](https://docs.microsoft.com/en-us/aspnet/core/getting-started)

# Running
 
Getting the repository:
```
git clone -b dev https://github.com/artem-kruglov/Raiblocks.Api.git
cd ./Raiblocks.ApiService
git submodule init
git submodule update
```

Running:
```
cd ./Lykke.Service.Raiblocks.Api/src/Lykke.Service.RaiblocksApi
dotnet restore
dotnet run
```
Go to [http://localhost:5000/swagger/ui/#/](http://localhost:5000/swagger/ui/#/)

# Environment setup

Path to [config file](https://github.com/artem-kruglov/Raiblocks.Api/blob/dev/Lykke.Service.Raiblocks.Api/src/Lykke.Service.RaiblocksApi/appsettings.json) is specified in enviroment variabled "SettingUrl".

DataConnString field contains connection string to Azure Table Storage. NodeURL field specifies the address of [RPC Raiblocks](https://github.com/clemahieu/raiblocks/wiki/RPC-protocol).

# Development

Azure Table Storage is used to store date.

![Data Scheme](https://github.com/artem-kruglov/Raiblocks.Api/blob/dev/Lykke.Service.Raiblocks.Api/ClassDiagram.gif)

# See also

 - [RaiBlocks Integration Sign Service](https://github.com/artem-kruglov/Raiblocks.Sign/tree/dev)

 - [Test private RaiBlocks node with a custom generis block](https://github.com/artem-kruglov/raiblocks/tree/testnet)
