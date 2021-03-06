# OnlineBookStore
 An Online Book Store as a desktop application.
 
 Note: This project was coded together with school friends using OOP logic. The product photos used in the program are used purely for educational purposes.


 
# 1.	INTRODUCTION

In this project, we made a desktop application where users can sign up and buy products in different categories. Two types of users can enter the application, the first is the customer login and the other is the admin login. If the customer has a registered account, they can log in to the application, if they do not have an account, they can create a new account by clicking the "create an account" text. When logging in to the application, you can see the username and name at the top left, access the day date and time information at the bottom left, and log out with the "logout" button if desired. At the same time, the customer can switch between 3 different categories (books, magazines, music/cd) and click on the image of the product they want, access the detailed information about the product on the pop-up screen, and add as many products as they want to the shopping cart. If he/she cannot find the desired product in any category, he/she can search for the product name and access that product using the "Search Button". It can be displayed in the shopping cart with the "My Cart" button on the left panel. He/she can see the products he added to his/her cart in a list box and can remove the product from his/her cart by double-clicking on the product he/she wants to remove from his/her cart. He/she can see the total amount of his/her basket at the bottom right, and he/she can delete all the products in his/her basket with the "delete all products" button, and his/her can buy the products in his/her basket with the "buy" button. The invoice containing the purchased products is sent to the user via e-mail. If an admin log in, in addition to everything the customer can do, they can add and remove products to any category they want through the "admin panel", update the product they want, and with the "clear" button, they can delete the text boxes containing the information about the product they have created.


# 2.	DESIGN

### a.	Login & Sign-Up Screens

 
![image](https://user-images.githubusercontent.com/93702923/140304774-4621940e-3c35-4e15-8f85-1e22bfaabf94.png)
![image](https://user-images.githubusercontent.com/93702923/140304786-c3ea7f7e-cb3e-465f-b25a-49f939f72e1a.png)


The application starts with login screen. If the person has a user account, he/she can access the application via this screen. If the person is an admin, he/she also can access the application via their admin username and password. If the person is not sure about the password what he/she wrote, by clicking the “show password” image the person can see his/her password. In sign-up screen the person can sign up with his/her information, except admin. A user can only be given admin authority over the database.
Main Menu


#### Books

![image](https://user-images.githubusercontent.com/93702923/140304868-b06588d6-c49f-4609-a92e-de253e40cf47.png)

#### Magazines

![image](https://user-images.githubusercontent.com/93702923/140304881-4a826613-2c7c-4d11-858e-f77d6e6fb657.png)

#### Music/CD

![image](https://user-images.githubusercontent.com/93702923/140304892-3bf858ca-6262-402a-b1ba-e5d018b021e5.png)
 
#### When using the search button

![image](https://user-images.githubusercontent.com/93702923/140304904-9e88e8a1-b70c-4e83-8c87-0d03cb6f7b4c.png)

#### The Pop-up Screen

![image](https://user-images.githubusercontent.com/93702923/140305066-84277675-b6a5-4776-a51b-b4eb1ff1bbbd.png)


When the user entered the application, he/she sees main menu. Main menu starts with books, he/she can change categories by clicking on their names and click on the image of the product they want, access the detailed information about the product on the pop-up screen, and add as many products as they want to the shopping cart. If they did not find the product they want, they can search the name of the product via the “Search Button”. By using “My Cart” button, they can see their shopping cart. 

### b.	My Cart

![image](https://user-images.githubusercontent.com/93702923/140305083-7c3f9fda-3b79-49c7-867b-fe886bdcf3cd.png)

The user can see products which he/she added to his/her shopping cart in this page. If he/she wants to remove a product, he/she can double click the product he/she wants to remove or to remove all product he/she can use “Remove All” button. Our bookstore has just 2 payment type; cash and credit card. If the user chooses credit cart as payment type, he/she must input his/her credit card information. After purchasing the products in the shopping cart, the invoice goes to the mail.

#### Invoice Mail

![image](https://user-images.githubusercontent.com/93702923/140305102-c1aec2dc-ccea-47bc-a2f0-7e704f586d6f.png)

#### Admin Panel

![image](https://user-images.githubusercontent.com/93702923/140305110-a908782c-94c6-45e0-8802-26d1f223848a.png)


This page is the Admin Panel, if you an admin, you can access to this page and you can control products from database with this panel. To update a product, you must enter the name of the product right, because the application access to product with the name and you can update all the information except the product name. If you want to delete the product you can do it just with the product name.

### c.	UML Diagram

![image](https://user-images.githubusercontent.com/93702923/140305136-0803603a-1b80-461d-bc90-5e696fe8e272.png)



### d.	Design Patterns That We Used

#### Singleton Design Pattern

![image](https://user-images.githubusercontent.com/93702923/140305152-eda6710a-68e3-4c1b-9af5-dfa2c16a76f7.png)
![image](https://user-images.githubusercontent.com/93702923/140305164-12fca4d4-544f-4664-a073-b3c5e13d13b1.png)


We used 2 design patterns in our project. First, Singleton Design Pattern, and the second one is Strategy Design Pattern. To make our code more readable, firstly we used Singleton Design Pattern for “ShoppingCart” class. As a result, each user can only have one shopping cart. We decided to use this design pattern in the “ShoppingCart” class in order not to overload the RAM. 


#### Strategy Design Pattern

![image](https://user-images.githubusercontent.com/93702923/140305184-b102ddec-a7fe-440d-83b7-114e12502d49.png)
![image](https://user-images.githubusercontent.com/93702923/140305194-507dbe74-e31b-4032-b46d-f173532af762.png)
![image](https://user-images.githubusercontent.com/93702923/140305202-194119f4-e780-4356-9806-7344843565d9.png)
![image](https://user-images.githubusercontent.com/93702923/140305222-7ef37b33-b75a-4d11-aa6e-b5d2b87b9c7f.png)


The purpose of using this pattern is to make database connections in different SQL types (MySQL, MSSQL). We created a class called “IDataBaseConnection”, this interface class has 3 function which called “Connect, Open and Close”. Classes that inherit this interface populate these functions according to their connection types. We also have “SQLCreator” class, and the purpose of this class ensures the continuity of the program by taking the MySQL or MSSQL type object we created into the parameter of the interface type in the constructor function it contains, finding its own specific SQL type with the help of polymorphism and running its functions.
