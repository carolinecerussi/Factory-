# Mr.SillyStringz Factory!

#### By Caroline Cerussi

#### {Brief description of application}

## Technologies Used

* HTML
* CSS
* C#
* .NET
* ASP.NET CORE MVC
* Razor
* MySql
* MySql Workbench
* EF Core

## Description

Upon opening the webpage, there is an index of Dr. Sillystringz' engineers and machines in his factory. He can view a list of engineers with individual detail pages linked into each listed name. If you click into an engineer's details, you can then view info such as their name, machines they use, and how many years of experience they have. You have the option to add a machine to their specific page. 
Another option off the homepage index, is to similarly click into a detailed page for specific machinery listed by clicking the hyperlinked name. You can then view the machine's name, and see a list of engineers that use it, and can add an engineer. He is also able to add and remove both the machine and engineer from any entry. 


## Setup/Installation Requirements

* Clone repository to desktop
* to run this program, you will need to import the caroline_cerussi.sql file into MySql Workbench and create a new schema named caroline_cerussi
* Create an appsettings.json file in the Factory directory and copy in the following:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=claire_thorington;uid=root;pwd=epicodus;"
  }
}

* navigate to the Factory.Solution directory in your terminal, cd to Factory directory, and type dotnet restore, dotnet build, and then dotnet run to run localhost website.

## Known Bugs

* Code has been broken, need to update my mysql workbench database

## License
[MIT]

Copyright (c) 2022 CAROLINE CERUSSI
