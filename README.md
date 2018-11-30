# Assignment 2 – Server-Side Scripting Function of this application:


-	Using BooksControllerTest to test in Unit Testing project.

-	Create IBooksMock is virtual database to test.

-	Create Unit Tests for each method in ONE Controller to test code as possible such as Index, Details, Edit, Create, Delete based on the scenarios:

- Index:

  - Do we have Book data?

  - Testing result, does the correct view load? 


- Details:

  - Id is null returns error

  - Book is null returns Error

  - Valid Id loads View return Details

  - Valid Id loads Book return Book

- Edit:

  - Id is null returns Error

  - Book is null returns Error

  - Valid Id loads View returns Edit

  - Valid Id loads Book returns Edit

  - ViewBag Artist if is not null test display result

  - ViewBag Category if is not null test display result

  - ViewBag Publisher if is not null test display result

  - Redirect returns result

- Create:

  - Loads view returns Create

  - ViewBag Artist if is not null returns result

  - ViewBag Category if is not null returns result

  - ViewBag Publisher if is not null returns result

  - Load Redirect View when Book is null returns result

  - Load Redirect View when Book is not null returns result

- Delete:

  - Id is null returns Error

  - Book is null returns Error

  - Valid Id Loads View test Delete

  - Valid Id Delete test Delete

  - Redirect Valid Id DeleteComfirmed test result 


-	Using Moq to create mock data, that is virual data to test database in production .

My Link:

https://comp2084-assignment2-p1-bookstore.azurewebsites.net

