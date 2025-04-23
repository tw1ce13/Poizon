# service-update-extension

## 🚀 Быстрый старт

Чтобы начать использовать библиотеку, выполните следующие шаги:

1. Создать экземпляр главного класса **Updater** 
```csharp
   Updater service = new Updater();
```
2. Проинициализировать класс для информации об обновляемом объекте через конструктор
```csharp
var applicationInfo = new ApplicationInfo();
```
3. Выполнить команду на проверку обновления 
```csharp
var result = await service.CheckForUpdates(applicationInfo);
```

## 📄 Документация

```csharp
class ApplicationInfo
```
**ApplicationName** - полное название обновляемого плагина, как на CDN площадке (к примеру Get.Front.DxBxExciseStamps)
**PathToApplicationFolder** - путь до папки с плагином
**License** - лицензия приложения (если есть)
**BaseUrl** - url для запроса к cdn площадке (к примеру https://cdn.dxbx.ru/iiko/plugins/, то есть выставлять путь до папки, в которой лежит repository.json)

```csharp
class Updater
```
Методы:
   ```csharp
   public async Task<Response<List<Assembling>>> CheckForUpdates(ApplicationInfo applicationInfo)
   ```
      🛠️ Осуществляет проверку на новые версии плагинов, скачивает обновление и заменяет файлы
      ✅ Результатом выполнения метода является Reponse, который будет содержать в себе 
         1. Данные в виде релиза
         2. Сообщение
         3. Статус
         4. Необходимость перезагрузить приложения
   ```csharp
   public async Task<List<Release>> GetVersions(ApplicationInfo applicationInfo, string endPoint)
   ```
      🛠️ Осуществляет запрос к cdn площадкам
      ✅ Результатом выполнения метода являются все версии плагина
   ```csharp
   public async Task<Response<Assembling>> UpdateForCurrentVersion(ApplicationInfo applicationInfo, Version version)
   ```
      🛠️ Обновляет плагин на определенную версию
      ✅ Результатом выполнения метода является Reponse, который будет содержать в себе 
         1. Данные в виде установленного релиза
         2. Сообщение
         3. Статус
         4. Необходимость перезагрузить приложения
---

© 2025 DocsInBox Team. Все права защищены.
