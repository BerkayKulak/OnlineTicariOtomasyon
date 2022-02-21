


<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

<img width="100%" src="https://user-images.githubusercontent.com/61355143/154913272-62d4a6ed-36eb-4f9d-b798-8663c6878c4f.gif">
<img width="100%" src="https://user-images.githubusercontent.com/61355143/154913400-87a33902-5f6e-40d8-8e9e-080f096918fa.gif">



Here's why:

This project consists of 3 basic panels of a store, namely a storefront, admin and user. In particular, I have developed a concrete project with both a powerful interface to design and SQL structures such as Entity Framework, Trigger, Procedure via Linq queries beyond crud operations, especially with the dashboard part of the admin panel.

## You will find answers to the following questions

- How to check layout
- How should the Controller Structure be provided
- How to write Complex SQL queries
- What is the Entity Framework approach
- What is the Model Structure
- How to write Linq Queries.
- What are the criteria to be considered in the Related Tables.
- How to Use Trigger
- How Do We Create a Procedure
- How to provide a view structure.


### Built With



* [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)
* [Bootstrap](https://getbootstrap.com/)
* [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019)

### Technologies and Methods

- Layout Control
- Controller Structure
- Partial View
- Code First
- Entity Framework
- Model Structure
- Linq Queries
- Related Tables
- Usage of Trigger
- Installation and Editing of a Ready-made Template
- Bootstrap
- Dashboard yapısı



<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

* dotnet ECommerce.NET-Angular.Infrastructure.csproj
  ```sh
  https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472
  ```
  
  
## Database Configuration (Web.config)

```bash
	<connectionStrings>
		<add name="Context" connectionString="data source=(localdb)\MSSQLLocalDB;initial catalog=KfauAutomationProject;integrated security=True" providerName="System.Data.SqlClient" />
	</connectionStrings>
```


### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

To clone and run this application, The .NET command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET applications.

1. Clone the repo
   ```sh
   https://github.com/BerkayKulak/OnlineTicariOtomasyon.git
   ```
2. Update Nuget packages
   ```sh
   dotnet tool update <PACKAGE_ID> -g|--global
   ```
3. Add Migration
   ```js
   dotnet ef migrations add InitialCreate
   ```
4. Update Database
   ```js
   dotnet ef database update
   ```

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

```bash
# Go into the repository API
$ cd \OnlineTicariOtomasyon\OnlineTicariOtomasyon

# Run the app
$ dotnet run
$ dotnet run --project ./projects/proj1/proj1.csproj
```


<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
## Bug / Feature Request

If you find a bug (the website couldn't handle the query and / or gave undesired results), kindly open an issue [here](https://github.com/BerkayKulak/OnlineTicariOtomasyon/issues/new) by including your search query and the expected result.

If you'd like to request a new function, feel free to do so by opening an issue [here](https://github.com/BerkayKulak/OnlineTicariOtomasyon/issues/new). Please include sample queries and their corresponding results.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Berkay Kulak - (https://www.linkedin.com/in/berkay-kulak-3442311b1/) - kulakberkay15@gmail.com

Project Link:   (https://github.com/BerkayKulak/OnlineTicariOtomasyon)

<p align="right">(<a href="#top">back to top</a>)</p>





