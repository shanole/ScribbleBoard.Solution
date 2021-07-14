![banner](./ScribbleBoard/wwwroot/img/banner.gif "ScribbleBoard Banner")

# _Scribble Board_

* _Date Created: July 5th 2021_
* _Last Updated: July 13th 2021_

#### By _Garrett Brown, Shannon Lee, Salim Mayan_

***

## Description
Scribble Board is a program that allows users to draw simple pictures, using their cursor as a drawing point. They can use several different colors, making pixel art reminiscent of Microsoft Paint.

Users can then save and display their images, along with data such as title and description. The images are stored via a custom API, and users are only allowed to access edit or delete functions for pictures they create (however, users will be able to see all images from all users).


<details>
    <summary><span style="color:red"><strong>Expand to Read User Stories</strong></summary>

1. User can log into their own art profile.
2. User can create new canvases and draw/erase on that canvas.
3. User can post drawings to the viewing gallery.
4. User can browse the profiles of other users to see their drawings.
5. User can delete their own drawings.
6. Users can see gallery of all drawings from all users.

</details>


## Setup/Installation Requirements

<details>
    <summary>Required Programs</summary>
    
1. An internet browser.
2. Visual Code Studio (or another code editor).
3. .NET
4. MySQL
5. MySQLWorkbench
</details>

<details>
    <summary>Installation of Program</summary>

1. Open the terminal on your local machine and navigate to "Desktop."
2. Clone "ScribbleBoard.Solution" with the following git command `git clone https://github.com/shanole/ScribbleBoard.Solution`
3. Navigate to the top level of the repository with the command `cd ScribbleBoard.Solution`

</details>

<details>
    <summary>Startup</summary>

#### Scribble Board Installation
1. Navigate to the top level of the repository with the command `cd ScribbleBoard.Solution`
2. Navigate into "ScribbleBoard" with git command `cd ScribbleBoard`
3. Navigate to root directory in project.
4. Restore project with git command `dotnet restore`
5. Build project with git command `dotnet build`
6. To run program, run git command `dotnet run`
7. In browser, navigate to http://localhost:5000 

#### Scribble Board API Installation
1. Navigate to the top level of the repository with the command `cd ScribbleBoard.Solution`
2. Navigate into "ScribbleBoardApi" with git command `cd ScribbleBoardApi`
3. Navigate to root directory in project.
4. Restore project with git command `dotnet restore`
5. Build project with git command `dotnet build`
6. To run program, run git command `dotnet run`
7. In browser, navigate to http://localhost:2000 

</details>

<details>
    <summary>Recreate Database</summary>
    
#### ScribbleBoard `appsettings.json` Creation

1. Navigate to the top level of the repository with the command `cd ScribbleBoard.Solution`
2. Navigate into "ScribbleBoard" with git command `cd ScribbleBoard`
3. Create a file in the root directory called `appsettings.json`. 
4. Add `appsettings.json` to `.gitignore`.
5. Insert the following code into `appsettings.json`:
    
``` 
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=scribbleboard_client;uid=root;pwd=YOUR-PASSWORD;"
    }
}
```

5. Replace `YOUR-PASSWORD` with password you selected when installing MySQLWorkbench.
6. In the root directory, run `dotnet ef database update` 
7. In the root directory, run `dotnet ef database restore`

This will recreate the database on your computer, using MySQLWorkbench. 

#### ScribbleBoardAPI `appsettings.json` Creation

1. Navigate to the top level of the repository with the command `cd ScribbleBoard.Solution`
2. Navigate into "ScribbleBoardApi" with git command `cd ScribbleBoardApi`
3. Create a file in the root directory called `appsettings.json`. 
4. Add `appsettings.json` to `.gitignore`.
5. Insert the following code into `appsettings.json`:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=scribbleboard_api;uid=root;pwd=YOUR-PASSWORD;"
  }
}
```

6. Replace `YOUR-PASSWORD` with password you selected when installing MySQLWorkbench.
7. In the root directory, run `dotnet ef database update` 
8. In the root directory, run `dotnet ef database restore`

</details>

## API Exploration
### Swagger
To explore ScribbleBoardApi with Swagger - Swashbuckle, go to your program directory and launch the program with `dotnet run`. Once the program is running, open a browser window and go to `https://localhost:2001/swagger`, and you will be able to navigate and have full CRUD functionality.

### Endpoints

Basic URL: `https://localhost:2001`

HTTP Request Structure (add after Basic URL)


| Route                         | Usage                  |   
|-------------------------------|------------------------|
| GET /api/Images               | Return all Images      | 
| POST /api/Images              | Create new image       |
| GET /api/Images/{id}          | Return image by id     |
| PUT /api/Images/{id}          | Edit image by id       |
| DELETE /api/Images/{id}       | Delete image by id     |
| POST /api/Images/UploadDirect | Posts an image uploaded directly from local files |

### Path Parameters
Explanation of parameters for GET /api/Images:


| Parameter | Required? | Type   | Description                                |
|-----------|-----------|--------|--------------------------------------------|
| PageNumber      | no       | int |  Page of API requested. By default and at minimum, PageNumber = 1                |
| PageSize   | no       | int | Number of entries returned per page. By default and at maximum, PageSize = 24 |
| UserName       | no       | string | Returns images that have been created by User with given UserName.|



### Searching via Parameters
In order to search for Images matching a parameter, use this format:

```
GET /api/Images?{parameter}={search-term}
```

#### Example:
```
https://localhost:2001/api/Images?PageNumber=1
```

In order to search for a specific image matching multiple parameters, add a `&` between searches:

#### Example:
```
https://localhost:2001/api/Images?PageNumber=1&PageSize=9
```

*** 


## Known Bugs

_There are currently no known bugs._

## Further Exploration
This is an active program. The team wants to update this program, and experiment with new features, such as:
* JWT authorization
* Hosting
* Tags, comments, more user profile features

## Support and contact details

_For assistance, please contact:_ 
* Garrett Brown <garrettpaulbrown@gmail.com>
* Shannon Lee <shannonleehj@gmail.com>
* Salim Mayan <mailsalim@gmail.com>

## Technologies Used

<details>
    <summary><strong>Scribble Board API</strong></summary>

* _Github, Visusal Studio Code_
* _C#, Markdown_
* _Entity Framework_
* _Authentication and Authorization with Identity_
* _.NET Core 5.0.1_
* _Swashbuckle_

</details>

<details>
    <summary><strong>Scribble Board Client</strong></summary>

* _Github, Visual Studio Code_
* _C#, Markdown_
* _HTML, CSS, JS_
* _Bootstrap, JQuery_ 
* _Entity Framework_
* _Authentication and Authorization with Identity_
* _.NET Core 5.0.1_
* _ASP.NET Core MVC_
* _ASP.NET Core Razor Pages_
* _RestSharp_
* _Procreate_

</details>



## Licensing

```

MIT License

Copyright (c) 2021 GARRETT BROWN, SHANNON LEE, SALIM MAYAN

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

```
