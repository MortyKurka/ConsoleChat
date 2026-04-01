# Console Chat
Простой консольный чат на .NET и TCP-сокетах

## Требования для сборки
- .NET SDK 10.x - основная платформа
- Git - для клонирования репозитория

## Быстрый старт
### Клонирование репозитория 
```bash
git clone https://github.com/MortyKurka/ConsoleChat
cd ConsoleChat
```
### Сборка проекта 
#### Windows-x64
```powershell
dotnet restore src/Chat.sln
dotnet build src/Chat.sln -c Release
dotnet publish src/Chat.sln -c Release --runtime win-x64 --self-contained false -o ./publish/win-x64
```
#### Linux-x64
```bash
dotnet restore src/Chat.sln
dotnet build src/Chat.sln -c Release
dotnet publish src/Chat.sln -c Release --runtime linux-x64 --self-contained false -o ./publish/linux-x64
```

## Использование
### Server
Сервер автоматически прослушивает все порты, при запуске в консоль ввести конкретный порт для прослушивания
### Chat
При запуске клиента необходимо ввести ip-адрес запущенного сервера в локальной сети и порт для прослушивания

## Структура проекта
```text
ConsoleChat
│├── src/               #Исходный код
││├── Chat.Server/      #Исходный код сервера
││├── Chat.Shared/      #Исходный код библиотеки классов
││├── Chat.TcpClient/   #Исходный код клиента
│├── docs/              #Документация
│├── publish/           #Собранное приложение (появляется только после сборки)
```
