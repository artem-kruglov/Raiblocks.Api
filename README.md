# RaiBlocks - Blockchain Integration API

This is a RaiBlocks Integration API. It is developed during the competition [RaiBlocks - Blockchain Integration API](https://streams.lykke.com/Project/ProjectDetails/raiblocks-blockchain-integration-api) with accordance for [the requirements](https://docs.google.com/document/d/1KVd-2tg-Ze5-b3kFYh1GUdGn9jvoo7HFO3wH_knpd3U/).

Слой интеграции с криптовалютой RaiBlocks. Реализован в рамках участия в конкурсе [RaiBlocks - Blockchain Integration API](https://streams.lykke.com/Project/ProjectDetails/raiblocks-blockchain-integration-api) в соответствии с [требованиями 1.0.0-rc-2](https://docs.google.com/document/d/1KVd-2tg-Ze5-b3kFYh1GUdGn9jvoo7HFO3wH_knpd3U/).

The project was made in compliance with [Lykke template](https://github.com/LykkeCity/lykke.dotnettemplates/tree/master/Lykke.Service.LykkeService).

Проект выполенен в соответствии с [шаблоном Lykke](https://github.com/LykkeCity/lykke.dotnettemplates/tree/master/Lykke.Service.LykkeService).

# Prerequisites

- [Visual Studio 2017](https://www.microsoft.com/net/core#windowsvs2017)
- [ASP.NET Core 2](https://docs.microsoft.com/en-us/aspnet/core/getting-started)

# Running
 
Getting the repository:
```
git clone https://github.com/artem-kruglov/Raiblocks.Api.git
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

The path to [config file](https://github.com/artem-kruglov/Raiblocks.Api/blob/dev/Lykke.Service.Raiblocks.Api/src/Lykke.Service.RaiblocksApi/appsettings.json) is specified in enviroment variabled "SettingUrl".

Путь к файлу настроек указывается в переменной среды "SettingUrl". В ней необходимо указать путь до [конфигурационного файла](https://github.com/artem-kruglov/Raiblocks.Api/blob/dev/Lykke.Service.Raiblocks.Api/src/Lykke.Service.RaiblocksApi/appsettings.json).

The field DataConnString contains connection string to Azure Table Storage. The field NodeURL specify the address of [RPC Raiblocks](https://github.com/clemahieu/raiblocks/wiki/RPC-protocol).

Где в поле DataConnString необходимо указать строку подключения к Azure Table Storage. В поле NodeURL адррес [RPC Raiblocks](https://github.com/clemahieu/raiblocks/wiki/RPC-protocol).

# Development

To storage a data is used Azure Table Storage.

![Data Scheme](https://github.com/artem-kruglov/Raiblocks.Api/blob/dev/Lykke.Service.Raiblocks.Api/ClassDiagram.gif)


