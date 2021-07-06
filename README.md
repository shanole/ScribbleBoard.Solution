# _Scribble Board_

 * _Scribble Board_
 * _Date Created: July 5th 2021_

#### By _Garrett Brown, Shannon Lee, Salim Mayan_

## Description
_Scribble Board!_

### User Stories

<details>
    <summary>Expand</summary>

#### User Stories

</details>

## Setup/Installation Requirements
Table of Contents
* Required Programs
* Installation of Program
* Startup

<details>
    <summary>Expand for Instructions</summary>

### Required Programs
1. An internet browser.
2. Visual Code Studio (or another code editor).
3. .NET
4. MySQL
5. MySQLWorkbench


### Installation of Program
* _Open the terminal on your local machine and navigate to "Desktop."_
* _Clone "ScribbleBoard.Solution" with the following git command `git clone https://github.com/shanole/ScribbleBoard.Solution`
* _Navigate to the top level of the repository with the command `cd ScribbleBoard.Solution`_ 
* _Navigate into "ScribbleBoard" with git command `cd ScribbleBoard`_

### Recreate Database

#### Instructions: `appsettings.json` Creation

1. Create a file in the root directory called `appsettings.json`. 
2. Add `appsettings.json` to `.gitignore`.
3. Insert the following code into `appsettings.json`:
    
``` 
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=YOUR-DATABASE;uid=root;pwd=YOUR-PASSWORD;"
    }
}
```

4. Replace `YOUR-PASSWORD` with password you selected when installing MySQLWorkbench.
5. Replace `YOUR-DATABASE` with the name of your database.
6. In the root directory, run `dotnet ef databse update` 
7. In the root directory, run `dotnet ef databse restore`

This will recreate the database on your computer, using MySQLWorkbench. You can proceed to Startup.


### Startup
* Navigate to root directory in project.
* Restore project with git command `dotnet restore`
* Build project with git command `dotnet build`
* To run program, run git command `dotnet run`
* In browser, navigate to http://localhost:5000 

</details>

## Known Bugs

_There are currently no known bugs._

## Support and contact details

_For assistance, please contact:_ 
* Garrett Brown <garrettpaulbrown@gmail.com>_
* Shannon Lee <shannonleehj@gmail.com>
* Salim Mayan <mailsalim@gmail.com>

## Technologies Used

* _Github, VS Code_
* _Bootstrap, MarkDown_
* _Entity Framework_
* _C#_
* _Authentication and Authorization_
* _.NET Core 5.0.1_
* _ASP.NET Core MVC_
* _ASP.NET Core Razor Pages_
* _HTML, CSS_

