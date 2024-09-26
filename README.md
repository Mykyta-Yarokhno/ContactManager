# Contact Manager Web Application

This is a .NET web application that allows users to upload CSV files containing contact information, store the data into an MS SQL database, and display the stored data on a web page.

## Features

- **CSV File Upload**: Users can upload CSV files with the following fields:
  - Name (string)
  - Date of Birth (date)
  - Married (bool)
  - Phone (string)
  - Salary (decimal)

- **Data Storage**: The uploaded data is stored in an MS SQL database.

- **Data Display**: Stored data is displayed in a table format on the web page.

- **Filtering and Sorting**: Users can filter data by any column and sort by any field on the client side using JavaScript.

- **Inline Editing**: The table provides inline editing for any row, allowing users to update or remove records directly.

- **Data Validation**: The application includes data validation features to ensure the integrity of the data.

## Technologies

- **.NET 8.0**: Core framework for building the web application.
- **ASP.NET Core MVC**: For handling the web requests and serving views.
- **Entity Framework Core**: For database operations and communication with MS SQL Server.
- **MS SQL Server**: For data storage.
- **JavaScript & jQuery**: For client-side functionality, including filtering, sorting, and inline editing.
- **Bootstrap**: For responsive design and UI styling.
- **DataTables**: For table display, sorting, and filtering functionalities.

## Setup

1. **Clone the Repository**

    ```bash
    git clone https://github.com/Mykyta-Yarokhno/ContactManagerWebApplication.git
    cd ContactManagerWebApplication
    ```

2. **Set Up the Database**:
   - Ensure you have MS SQL Server installed.
   - Create a new database.
   - **Restore the provided database backup file**:
     - Open SQL Server Management Studio (SSMS).
     - Connect to your SQL Server instance.
     - Right-click on the "Databases" node in Object Explorer and select "Restore Database...".
     - Choose "Device" and browse to select the provided `.bak` file.
     - Follow the steps to complete the database restoration.

3. **Configure the Application**:
   - Update the connection string in the `appsettings.json` file to point to your restored database.

4. **Run the Application**:
   - Open the solution in Visual Studio.
   - Restore the NuGet packages.
   - Run the application using IIS Express or your preferred web server.

5. **Usage**:
   - Navigate to the application URL.
   - Use the file upload feature to upload your CSV files.
   - View, filter, sort, and edit the data as needed.
