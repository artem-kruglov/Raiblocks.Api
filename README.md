# RaiBlocks - Blockchain Integration API

Слой интеграции с криптоволютой RaiBlocks. Реализован в рамках участия в рамках конкурса [RaiBlocks - Blockchain Integration API](https://streams.lykke.com/Project/ProjectDetails/raiblocks-blockchain-integration-api) в соответствии с требованиями версии [1.0.0-rc-1](https://docs.google.com/document/d/1KVd-2tg-Ze5-b3kFYh1GUdGn9jvoo7HFO3wH_knpd3U/).

Проект выполенен в соответствии с [шабоном Lykke](https://github.com/LykkeCity/lykke.dotnettemplates/tree/master/Lykke.Service.LykkeService).

# Prerequisites

- [Visual Studio 2017](https://www.microsoft.com/net/core#windowsvs2017)
- [ASP.NET Core 2](https://docs.microsoft.com/en-us/aspnet/core/getting-started)

# Running
 
 Получение репозитория:
```
git clone https://github.com/mao29/Raiblocks.ApiService.git
cd ./Raiblocks.ApiService
git submodule init
git submodule update
```

Запуск:
```
cd ./Lykke.Service.Raiblocks.Api/src/Lykke.Service.RaiblocksApi
dotnet restore
dotnet run
```
Перейти [http://localhost:5000/swagger/ui/#/](http://localhost:5000/swagger/ui/#/)

# Environment setup

Путь к файлу настроек указывается в переменной среды "SettingUrl". В ней необходимо указать путь до [конфигурационного файла](https://github.com/mao29/Raiblocks.ApiService/blob/dev/Lykke.Service.Raiblocks.Api/src/Lykke.Service.RaiblocksApi/appsettings.json).

Где в поле DataConnString необходимо указать строку подключения к Azure Table Storage. В поле NodeURL адррес [RPC Raiblocks](https://github.com/clemahieu/raiblocks/wiki/RPC-protocol).

# Development

Для хранения данных используется Azure Table Storage.

![Схема данных](https://github.com/mao29/Raiblocks.ApiService/blob/dev/Lykke.Service.Raiblocks.Api/ClassDiagram.gif)


