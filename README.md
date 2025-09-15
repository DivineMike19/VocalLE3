VocalLE3 – Blog Application

This repository contains my work for **LE2** and **LE3** in IT128.  
The project is a simple blogging system built using C# (.NET), SQL Server LocalDB, and Dapper ORM.

Features
- Register User – create new accounts with username, password, and full name.
- Login – verify credentials to access the system.
- Add Post – create a new blog post (title and body).
- List Posts – show all blog posts with author and date created.
- View Post Details – display full content of a single blog post.
  
Project Structure

VocalLE3/
│
├── BlogDataLibrary/ # Data access and models
│ ├── Data/
│ │ ├── ISqlDataAccess.cs
│ │ ├── SqlDataAccess.cs
│ │ └── SqlData.cs
│ ├── Models/
│ │ ├── UserModel.cs
│ │ ├── PostModel.cs
│ │ └── ListPostModel.cs
│
├── BlogTestUI/ # Console application (Program.cs, appsettings.json)
│
├── VocalBlogDB/ # Database scripts
│ ├── Tables/
│ │ ├── Users.sql
│ │ └── Posts.sql
│ ├── Stored Procedures/
│ ├── spUsers_Register.sql
│ ├── spPosts_Insert.sql
│ ├── spPosts_List.sql
│ └── spPosts_Detail.sql
│
└── VocalLE3.sln # Visual Studio solution
