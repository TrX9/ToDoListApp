# ToDoListApp


Solution содержит 2 проекта.
Первый проект — это веб-API (ToDoListApp), а второй проект — веб-приложение (ToDoListFrontEnd).

Чтобы запустить этот проект:

1- Создайте базу данных под названием «ToDoAppDb» (я использовал MSSQL).

2- Чтобы создать таблицы, запустите команды миграции в cmd или Nuget Package Manager Console в проекта Web Api:

"dotnet ef migrations add CreateM"
"dotnet ef database update"

3. В проекте веб-приложения откройте Program.cs и замените существующий URL-адрес URL-адресом Web Api (на вашем компьютере он может отличаться).
Эту строку следует изменить:

 client.BaseAddress = новый Uri("https://localhost:7257/api/"); // Обновить URL-адрес веб-API
 
URL-адрес должен соответствовать URL-адресу API. (https://localhost:xxxx/api/)

5. Запустите оба проекта одновременно (я использовал Visual Studio), и вы сможете использовать веб-приложение, которое теперь подключено к веб-API в 1-м проекте.

Вы также можете протестировать Web Api индивидуально через Swagger UI.

Я написал это на английском и перевел на русский через Google, если что-то не понятно, дайте знать.


----------------------------------------------------------------------------------------------------

English Version:

This solution contains 2 projects.
The first project is the Web Api (To Do List App), and the 2nd project is the Web App (To Do List Front End).

To run this project:

1- Create a database called "ToDoAppDb" (I used MSSQL).

2- To create the tables, Run Migration commands in cmd or Nuget Package Manager Console in the Web Api project directory:

"dotnet ef migrations add CreateM"
"dotnet ef database update"

3- In the Web app project, open Program.cs and replace the existing url with the Web Api url (it might be different on your pc).
This line should be changed:
    client.BaseAddress = new Uri("https://localhost:7257/api/"); // Update Web API URL
The url should match the api url.
	
4- Run both projects at the same time(I used Visual Studio), and you can use the Web App which is now connected to the Web Api in the 1st project.

You can also test the Web Api individually via Swagger UI.
