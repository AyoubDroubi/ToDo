# Learning Blazor Web App by making a Todo App

This Todo app project was created to learn CRUD operations using **Blazor Web App**.

## Technologies
- **Blazor Web App (C#)**: Blazor is a framework for building interactive web UIs using C# instead of JavaScript.
- **MySQL**: A popular open-source relational database management system.
- **Bootstrap**: A front-end framework for developing responsive and mobile-first websites.
- **MudBlazor UI library**: A UI component library for Blazor applications, providing reusable components and layouts.

## Functionalities
- **Authentication**: Users can register and log in to access their own todos. There's also the option to edit their profile details.
- **Add a Todo**: Each user can add a todo item, and only they can access their todos.
- **Display Todos**: Todos registered in the database are displayed to the current user.
- **Update a Todo**: Users can edit and update their existing todos.
- **Delete a Todo**: Users can delete their todos.

## Get Started
To set up the project, follow these steps:

1. **Configure Database Connection**:
   - Open the `appsettings.json` file and replace the placeholder values with your actual database connection details:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=server;Port=port;Database=mydb;User=root;Password=pass;"
     },
     ```
   - Example
     ```json
     "ConnectionStrings" : {
        "DefaultConnection" : "Server=localhost;Port=8081;Database=MyTodoDatabase;User=fadilix;Password=password123;"
     },

2. **Modify Database Configuration**:
   - If you're using a database other than MySQL, adjust the database configuration in the `Program.cs` file accordingly:
     ```csharp
     var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
     builder.Services.AddDbContext<AppDbContext>(options => {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
     };
     ```
3. **There you go**

## Outcome
This project provided an invaluable learning experience. Although I faced challenges initially, I've made significant progress and have gained confidence in my abilities. Continuing to iterate and refine this project will undoubtedly enhance my skills further.
